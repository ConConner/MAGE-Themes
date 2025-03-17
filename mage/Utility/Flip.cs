using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Utility;

public static class Flip
{
    /// <summary>
    /// Flips all the background data of a <see cref="Room"/> on the set axis
    /// </summary>
    public static void FlipRoom(Room room, bool horizontal, bool vertical)
    {
        Block[,] origin = new Block[room.Width, room.Height];

        // Get old Data
        for (int x = 0; x < room.Width; x++)
            for (int y = 0; y < room.Height; y++)
                origin[x, y] = room.backgrounds.GetBlock(x, y);

        // Set new Data
        for (int x = 0; x < room.Width; x++)
            for (int y = 0; y < room.Height; y++)
                room.backgrounds.SetBlock(
                    origin[x, y],
                    horizontal ? room.Width - 1 - x : x,
                    vertical ? room.Height - 1 - y : y
                );

        // Mark Backgrounds as edited
        room.BG0.Edited = room.BG1.Edited = room.BG2.Edited = room.BG3.Edited = room.Clip.Edited = true;

        // Save Changes
        room.SaveObjects();
    }

    /// <summary>
    /// Loops through every tile in a room and substitutes them if they appear in the map
    /// </summary>
    public static void SubstituteTiles(Room room, Dictionary<ushort, ushort> subMap)
    {
        for (int x = 0; x < room.Width; x++)
            for (int y = 0; y < room.Height; y++)
            {
                Block b = room.backgrounds.GetBlock(x, y);
                b.BG0 = subMap.GetValueOrDefault(b.BG0, b.BG0);
                b.BG1 = subMap.GetValueOrDefault(b.BG1, b.BG1);
                b.BG2 = subMap.GetValueOrDefault(b.BG2, b.BG2);

                room.backgrounds.SetBlock(b, x, y);
            }

        room.BG0.Edited = room.BG1.Edited = room.BG2.Edited = room.BG3.Edited = room.Clip.Edited = true;
        room.SaveObjects();
    }

    /// <summary>
    /// Loops through every tile in a room and substitutes them if they appear in the map
    /// </summary>
    public static void SubstituteClipdata(Room room, Dictionary<ushort, ushort> subMap)
    {
        for (int x = 0; x < room.Width; x++)
            for (int y = 0; y < room.Height; y++)
            {
                Block b = room.backgrounds.GetBlock(x, y);
                b.CLP = subMap.GetValueOrDefault(b.CLP, b.CLP);

                room.backgrounds.SetBlock(b, x, y);
            }

        room.BG0.Edited = room.BG1.Edited = room.BG2.Edited = room.BG3.Edited = room.Clip.Edited = true;
        room.SaveObjects();
    }


    /// <summary>
    /// Flips the orientation of every tile inside a Tiletable.
    /// </summary>
    public static void FlipTiletable(ushort[] tileTable, int numOfTiles, bool horizontal, bool vertical, int startAtTile = 0)
    {
        // Move tile parts
        for (int i = startAtTile; i < numOfTiles; i += 4)
        {
            ushort[] unflippedTiles =
            {
                tileTable[i],
                tileTable[i + 1],
                tileTable[i + 2],
                tileTable[i + 3]
            };

            // Values that the indices should be shifted by depending on the axis
            int leftIndex = (horizontal ? 1 : 0) + (vertical ? 2 : 0);
            int rightIndex = (horizontal ? -1 : 0) + (vertical ? 2 : 0);

            tileTable[i + 0] = unflippedTiles[(i + 0 + leftIndex) % 4];
            tileTable[i + 1] = unflippedTiles[(i + 1 + rightIndex) % 4];
            tileTable[i + 2] = unflippedTiles[(i + 2 + leftIndex) % 4];
            tileTable[i + 3] = unflippedTiles[(i + 3 + rightIndex) % 4];
        }

        // Set Flip bit for axis
        for (int i = startAtTile; i < numOfTiles; i++) tileTable[i] = (ushort)(tileTable[i] ^ (horizontal ? 0x400 : 0) ^ (vertical ? 0x800 : 0));
    }
}

public static class Maps
{
    public static Dictionary<ushort, ushort> horizontalTileSubstitutionMap = new()
    {
        // Doorcaps
        // Gray        Blue           Red            Green          Yellow
        {0x6  ,0x7  }, {0x8  ,0x9  }, {0xA  ,0xB  }, {0xC  ,0xD  }, {0xE  ,0xF  },
        {0x16 ,0x17 }, {0x18 ,0x19 }, {0x1A ,0x1B }, {0x1C ,0x1D }, {0x1E ,0x1F },
        {0x26 ,0x27 }, {0x28 ,0x29 }, {0x2A ,0x2B }, {0x2C ,0x2D }, {0x2E ,0x2F },
        {0x36 ,0x37 }, {0x38 ,0x39 }, {0x3A ,0x3B }, {0x3C ,0x3D }, {0x3E ,0x3F },

        // Doorcaps Mirrored
        {0x7  ,0x6  }, {0x9  ,0x8  }, {0xB  ,0xA  }, {0xD  ,0xC  }, {0xF  ,0xE  },
        {0x17 ,0x16 }, {0x19 ,0x18 }, {0x1B ,0x1A }, {0x1D ,0x1C }, {0x1F ,0x1E },
        {0x27 ,0x26 }, {0x29 ,0x28 }, {0x2B ,0x2A }, {0x2D ,0x2C }, {0x2F ,0x2E },
        {0x37 ,0x36 }, {0x39 ,0x38 }, {0x3B ,0x3A }, {0x3D ,0x3C }, {0x3F ,0x3E },

        // Door Tube    Mirrored
        {0x1  ,0x2  }, {0x2  ,0x1  },
        {0x11 ,0x12 }, {0x12 ,0x11 },
        {0x21 ,0x22 }, {0x22 ,0x21 },
        {0x31 ,0x32 }, {0x32 ,0x31 },

    };

    public static Dictionary<ushort, ushort> horizontalClipdataSubstitutionMap = new()
    {
        // Steep slope
        {0x11 ,0x12 }, {0x12 ,0x11 },

        // Slight slope
        {0x13 ,0x16 }, {0x16 ,0x13 },
        {0x14 ,0x15 }, {0x15 ,0x14 },

        // Big shot blocks
        {0x50 ,0x51}, {0x51 ,0x50},
        {0x60 ,0x61}, {0x61 ,0x60},
    };
}