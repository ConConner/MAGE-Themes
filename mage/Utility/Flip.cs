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
