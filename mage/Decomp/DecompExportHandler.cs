using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Decomp;

public class DecompExportHandler
{
    public void ExportGame()
    {
        Dictionary<int, ResourceResponse>[] gameBackgrounds = new Dictionary<int, ResourceResponse>[7];

        for (int areaID = 0; areaID < Version.AreaNames.Length; areaID++)
        {
            // Data structures to store label and background information
            gameBackgrounds[areaID] = new();
            List<string> roomDataLabels = new();

            // For each Room in Area
            for (int i = 0; i < Version.RoomsPerArea[areaID]; i++)
            {
                Room r = new(areaID, i);
                RoomHandler.SaveRLEBackgrounds(r, gameBackgrounds[areaID]);
                RoomHandler.SaveLZ77Backgrounds(r, gameBackgrounds[areaID]);
                RoomHandler.SaveRoomData(r, gameBackgrounds[areaID], roomDataLabels);
            }

            // Generate files for area
            AreaHandler.SaveAreaLZ77BackgroundsData(areaID, gameBackgrounds[areaID], roomDataLabels);
            AreaHandler.SaveAreaRoomsHeader(areaID, roomDataLabels);
        }

        // Update References in several Files
        GameHandler.SaveGameScrollData();
        GameHandler.SaveGameDoorData();
        GameHandler.SaveGameRoomEntryData(gameBackgrounds);
        GameHandler.UpdateGameRoomEntryHeader();
        GameHandler.UpdateLinkerRooms();
    }
}
