﻿using mage.Data;
using mage.Options;
using mage.Properties;
using System;
using System.IO;
using System.Windows.Forms;

namespace mage
{
    public static class Test
    {
        public static void Room(FormMain main, bool debug, int xPos, int yPos, sRam ram = null)
        {
            ByteStream bs = ROM.Stream;
            Room room = main.Room;
            DoorList doorList = room.doorList;
            bool isMF = Version.IsMF;

            // backup previous rom data
            byte[] backup = ROM.BackupData();

            // apply changes to rom
            Patch p = Version.TestRoom;
            p.Apply();

            // debug menu
            if (debug)
            {
                if (isMF)
                {
                    p = new Patch(Properties.Resources.MF_U_debugMenu);
                }
                else
                {
                    p = new Patch(Properties.Resources.ZM_U_itemToggle);
                }
                p.Apply();
            }

            // if there are no doors, skip room overwrite
            byte doorNum;
            if (doorList.Count == 0)
            {
                int offset;
                if (isMF) { offset = 0x64C8C; }
                else { offset = 0x567E0; }
                bs.Write16(offset, 0xE001);
                doorNum = 0;
            }
            else
            {
                doorNum = doorList[0].doorNum;
                if (doorNum == 0 && doorList.Count >= 2)
                {
                    doorNum = doorList[1].doorNum;
                }
            }

            int sramAddr;
            if (isMF) { sramAddr = 0x65C500; }
            else { sramAddr = 0x7D8000; }

            // write area and room/door
            bs.Write8(sramAddr + 0x1D, room.AreaID);
            bs.Write8(sramAddr + 0x1E, room.RoomID);
            bs.Write8(sramAddr + 0x1F, doorNum);

            // write position and music
            xPos = xPos * 64 + 31;
            yPos = yPos * 64 + 63;
            int xEdge = room.Width * 64 - 0x440;
            int yEdge = room.Height * 64 - 0x300;
            ushort xScreen = (ushort)Math.Max(0x80, Math.Min(xEdge, xPos - 0x1E0));
            ushort yScreen = (ushort)Math.Max(0x80, Math.Min(yEdge, yPos - 0x150));
            ushort music = room.header.music;
            if (isMF)
            {
                bs.Write16(sramAddr + 0x76, (ushort)xPos);
                bs.Write16(sramAddr + 0x78, (ushort)yPos);
                bs.Write16(sramAddr + 0xE8, music);
                bs.Write16(sramAddr + 0x2C, xScreen);
                bs.Write16(sramAddr + 0x30, yScreen);
                bs.Write16(sramAddr + 0x40, xScreen);
                bs.Write16(sramAddr + 0x42, yScreen);
                bs.Write16(sramAddr + 0x44, xScreen);
                bs.Write16(sramAddr + 0x46, yScreen);
                bs.Write16(sramAddr + 0x48, xScreen);
                bs.Write16(sramAddr + 0x4A, yScreen);
            }
            else
            {
                bs.Write16(sramAddr + 0x72, (ushort)xPos);
                bs.Write16(sramAddr + 0x74, (ushort)yPos);
                bs.Write16(sramAddr + 0x244, music);
                bs.Write16(sramAddr + 0x24, xScreen);
                bs.Write16(sramAddr + 0x26, yScreen);
                bs.Write16(sramAddr + 0x2C, xScreen);
                bs.Write16(sramAddr + 0x2E, yScreen);
                bs.Write16(sramAddr + 0x30, xScreen);
                bs.Write16(sramAddr + 0x32, yScreen);
                bs.Write16(sramAddr + 0x34, xScreen);
                bs.Write16(sramAddr + 0x36, yScreen);

                //Setting samus equipment
                ram?.WriteToRom();

                if (ROM.useMotherShipHatches)
                {
                    bs.Write8(sramAddr + 0x3D, 1);
                }
            }

            // save new changes and launch
            try
            {
                string path = Program.Config.TestRomPath != string.Empty ? Program.Config.TestRomPath : Path.GetTempPath();
                string testSymbolPath = Path.Combine(path, "test.sym");
                string romName = Path.GetFileNameWithoutExtension(main.filename);
                romName = Path.Combine(Path.GetDirectoryName(main.filename), romName);

                path = Path.Combine(path, "test.gba");
                room.SaveObjects();
                ROM.SaveROM(path, false);

                //Copy a symbol file if it exists
                string romSymbolPath = romName + ".sym";
                if (File.Exists(romSymbolPath)) File.Copy(romSymbolPath, testSymbolPath, true);

                Sound.PlaySound("test.wav");
                RunEmulator($"\"{path}\"");
            }
            catch (Exception e)
            {
                MessageBox.Show("Test ROM could not be launched.\n\n" + e.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // restore data
            ROM.RestoreData(backup);
        }

        public static void Demo(byte demoNum)
        {
            // backup previous rom data
            byte[] backup = ROM.BackupData();

            // apply changes to rom
            Patch p = Version.TestDemo;
            p.Apply();

            // write demo number
            switch (Version.GameCode)
            {
                case "AMTE":
                    ROM.Stream.Write8(0x718E8, demoNum);
                    break;
                case "BMXE":
                    ROM.Stream.Write8(0x60B42, demoNum);
                    break;
            }

            // save new changes and launch
            try
            {
                string path = Path.GetTempPath();
                path = Path.Combine(path, "test.gba");
                ROM.SaveROM(path, false);
                RunEmulator(path);
            }
            catch (Exception e)
            {
                MessageBox.Show("Test ROM could not be launched.\n\n" + e.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // restore data
            ROM.RestoreData(backup);
        }

        private static void RunEmulator(string romPath)
        {
            // check for emulator path
            string emuPath = Program.Config.SelectedEmulatorPath;
            string error = null;
            if (string.IsNullOrEmpty(emuPath) && Program.Config.EmulatorPaths.Count == 0)
            {
                error = "No GBA emulator paths have been added. Would you like to add one now?";
            }
            else if (string.IsNullOrEmpty(emuPath))
            {
                error = "No GBA emulator has been selected. Would you like to select one now?";
            }
            else if (!File.Exists(emuPath))
            {
                error = $"Could not find GBA emulator {Path.GetFileName(emuPath)} at path:\n\n{emuPath}" +
                    "\n\nWould you like to update it now or choose a different path?";
            }
            if (error != null)
            {
                AskForNewPath(error);
                return;
            }
            System.Diagnostics.Process.Start(emuPath, romPath);
        }

        private static void AskForNewPath(string msg)
        {
            var result = MessageBox.Show(msg, "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result != DialogResult.Yes) return;

            new FormOption("Preferences", PageLists.ApplicationOptionPages, "Tools").ShowDialog();
        }

    }
}
