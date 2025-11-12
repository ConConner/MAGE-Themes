using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mage.Decomp;

public static class AreaHandler
{
    public static void SaveAreaRoomsHeader(int areaID, List<string> labels)
    {
        string areaNameCap = Version.AreaNames[areaID];
        string areaName = areaNameCap.ToLower();
        StringBuilder fileData = new StringBuilder();

        // Boilerplate
        fileData.AppendLine($"#ifndef {areaName.ToUpper()}_ROOMS_DATA_H");
        fileData.AppendLine($"#define {areaName.ToUpper()}_ROOMS_DATA_H");
        fileData.Include("types.h");
        fileData.Include("structs/scroll.h");
        fileData.Include("structs/sprite.h");
        fileData.Include("structs/room.h");

        // Include each room
        foreach (string label in labels) fileData.ExternConstU8Array(label);

        fileData.AppendLine("#endif");

        // Write File
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "include", "data", "rooms", $"{areaName}_rooms_data.h");
        FileWriter.WriteToFile(path, fileData.ToString());
    }

    public static void SaveAreaLZ77BackgroundsData(int areaID, Dictionary<int, ResourceResponse> backgrounds, List<string> labels)
    {
        string areaNameCap = Version.AreaNames[areaID];
        string areaName = areaNameCap.ToLower();
        StringBuilder fileData = new StringBuilder();

        // Boilerplate
        fileData.Include($"data/rooms/{areaName}_rooms_data.h");
        fileData.Include($"macros.h");

        // Include BGs
        HashSet<int> usedPointers = new();
        for (int i = 0; i < Version.RoomsPerArea[areaID]; i++)
        {
            Room r = new(areaID, i);
            RoomHandler.GenerateLZ77Include(fileData, r, backgrounds, labels, usedPointers);
        }

        // Write File
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "src", "data", "rooms", $"{areaName}", "Bg3.c");
        FileWriter.WriteToFile(path, fileData.ToString());
    }

    public static string GenerateAreaScrollList(int areaID, string areaName)
    {
        List<string> scrollList = new();
        // For each Room
        for (int id = 0; id < Version.RoomsPerArea[areaID]; id++)
        {
            Room r = new(areaID, id);
            if (r.scrollList.Count == 0) continue;

            scrollList.Add($"s{areaName}_{id}_Scrolls");
        }
        scrollList.Add("sScroll_Empty");

        StringBuilder sb = new();
        sb.AppendLine($"static const u8* s{areaName}Scrolls[] = {{");
        sb.Append('\t');
        sb.AppendJoin(",\n\t", scrollList);
        sb.AppendLine("\n};");

        return sb.ToString();
    }

    public static string GenerateDoorStruct(Door door)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("\t{");
        sb.AppendLine($"\t\t.type = {door.type},");
        sb.AppendLine($"\t\t.sourceRoom = {door.srcRoom},");
        sb.AppendLine($"\t\t.xStart = {door.xStart},");
        sb.AppendLine($"\t\t.xEnd = {door.xEnd},");
        sb.AppendLine($"\t\t.yStart = {door.yStart},");
        sb.AppendLine($"\t\t.yEnd = {door.yEnd},");
        sb.AppendLine($"\t\t.destinationDoor = {door.dstDoor},");
        sb.AppendLine($"\t\t.xExit = {door.xExitDistance},");
        sb.AppendLine($"\t\t.yExit = {door.yExitDistance}");
        sb.Append("\t}");
        return sb.ToString();
    }
    public static string GenerateAreaDoorList(int areaID, string areaName)
    {
        int count = DoorData.Count((byte)areaID);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"const struct Door s{areaName}Doors[{count + 1}] = {{");

        // For each door in the area
        List<string> doorData = new();
        for (byte i = 0; i < count; i++)
        {
            Door d = DoorData.GetDoor((byte)areaID, i);
            doorData.Add(GenerateDoorStruct(d));
        }

        // Add empty door
        Door empty = new Door() { type = 0, srcRoom = 0, xStart = 0, xEnd = 0, yStart = 0, yEnd = 0, dstDoor = 0, xExitDistance = 0, yExitDistance = 0 };
        doorData.Add(GenerateDoorStruct(empty));

        // Build List
        sb.AppendJoin(",\n", doorData);
        sb.AppendLine("};");

        return sb.ToString();
    }

    private static string getBackground(Dictionary<int, ResourceResponse> backgrounds, int key)
    {
        bool found = backgrounds.TryGetValue(key, out ResourceResponse resource);
        if (!found) return "sBackground_Empty";
        return resource.ResourceLabel;
    }
    private static string getSpriteset(Room room, string areaName, int set)
    {
        if (room.enemyLists[set] == null) return $"sEnemyRoomData_Empty";
        else return $"s{areaName}_{room.RoomID}_Spriteset{set}";
    }
    public static string GenerateRoomEntryStruct(Room room, Dictionary<int, ResourceResponse> backgrounds, int index, string areaName)
    {
        Header header = room.header;
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"\t[{index}] = {{");
        sb.AppendLine($"\t\t.tileset = {header.tileset},");
        sb.AppendLine($"\t\t.bg0Prop = {header.BG0prop},");
        sb.AppendLine($"\t\t.bg1Prop = {header.BG1prop},");
        sb.AppendLine($"\t\t.bg2Prop = {header.BG2prop},");
        sb.AppendLine($"\t\t.bg3Prop = {header.BG3prop},");
        sb.AppendLine($"\t\t.pBg0Data = {getBackground(backgrounds, header.BG0ptr)},");
        sb.AppendLine($"\t\t.pBg1Data = {getBackground(backgrounds, header.BG1ptr)},");
        sb.AppendLine($"\t\t.pBg2Data = {getBackground(backgrounds, header.BG2ptr)},");
        sb.AppendLine($"\t\t.pClipData = {getBackground(backgrounds, header.clipPtr)},");
        sb.AppendLine($"\t\t.pBg3Data = {getBackground(backgrounds, header.BG3ptr)},");
        sb.AppendLine($"\t\t.bg3Scrolling = {header.BG3scroll},");
        sb.AppendLine($"\t\t.transparency = {header.transparency},");
        sb.AppendLine($"\t\t.pDefaultSpriteData = s{areaName}_{header.roomID}_Spriteset0,");
        sb.AppendLine($"\t\t.defaultSpriteset = {header.spriteset0},");
        sb.AppendLine($"\t\t.firstSpritesetEvent = {header.spriteset1event},");
        sb.AppendLine($"\t\t.pFirstSpriteData = {getSpriteset(room, areaName, 1)},");
        sb.AppendLine($"\t\t.firstSpriteset = {header.spriteset1},");
        sb.AppendLine($"\t\t.secondSpritesetEvent = {header.spriteset2event},");
        sb.AppendLine($"\t\t.pSecondSpriteData = {getSpriteset(room, areaName, 2)},");
        sb.AppendLine($"\t\t.secondSpriteset = {header.spriteset2},");
        sb.AppendLine($"\t\t.mapX = {header.mapX},");
        sb.AppendLine($"\t\t.mapY = {header.mapY},");
        sb.AppendLine($"\t\t.effect = {header.effect},");
        sb.AppendLine($"\t\t.effectY = {header.effectY},");
        sb.AppendLine($"\t\t.musicTrack = {header.music},");
        sb.Append("\t}");
        return sb.ToString();
    }
    public static string GenerateRoomDataEntries(int areaID, Dictionary<int, ResourceResponse> areaBackgrounds, string areaName)
    {
        int count = Version.RoomsPerArea[areaID];
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"const struct RoomEntryRom s{areaName}RoomEntries[{count}] = {{");

        List<string> roomEntries = new();
        for (int id = 0; id < count; id++)
        {
            Room r = new(areaID, id);
            roomEntries.Add(GenerateRoomEntryStruct(r, areaBackgrounds, id, areaName));
        }

        sb.AppendJoin(",\n", roomEntries);
        sb.AppendLine("};");

        return sb.ToString();
    }
}
