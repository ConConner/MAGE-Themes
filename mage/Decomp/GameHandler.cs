using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace mage.Decomp;

public static class GameHandler
{
    public static void SaveGameScrollData()
    {
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "src", "scroll.c");
        string fileData = File.ReadAllText(path);

        // For each Area
        for (int area = 0; area < Version.AreaNames.Length; area++)
        {
            string areaName = Version.AreaNames[area];
            string areaScrollList = AreaHandler.GenerateAreaScrollList(area, areaName);

            string pattern = $@"static\s+const\s+u8\*\s+s{areaName}Scrolls\[\]\s*=\s*\{{[\s\S]*?\}};";
            fileData = Regex.Replace(fileData, pattern, areaScrollList);
        }

        FileWriter.WriteToFile(path, fileData);
    }

    public static void SaveGameDoorData()
    {
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "src", "data", "rooms_data.c");
        string fileData = File.ReadAllText(path);

        // For each Area
        for (int area = 0; area < Version.AreaNames.Length; area++)
        {
            string areaName = Version.AreaNames[area];
            string doorList = AreaHandler.GenerateAreaDoorList(area, areaName);

            string pattern = $@"const\s+struct\s+Door\s+s{areaName}Doors\[\d+\]\s*=\s*\{{[\s\S]*?\}};";
            fileData = Regex.Replace(fileData, pattern, doorList);
        }

        FileWriter.WriteToFile(path, fileData);
    }

    public static void SaveGameRoomEntryData(Dictionary<int, ResourceResponse>[] gameBackgrounds)
    {
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "src", "data", "rooms_data.c");
        string fileData = File.ReadAllText(path);

        // For each Area
        for (int area = 0; area < Version.AreaNames.Length; area++)
        {
            string areaName = Version.AreaNames[area];
            Dictionary<int, ResourceResponse> areaBackgrounds = gameBackgrounds[area];
            string areaRoomEntries = AreaHandler.GenerateRoomDataEntries(area, areaBackgrounds, areaName);

            string pattern = $@"const\s+struct\s+RoomEntryRom\s+s{areaName}RoomEntries\[\d+\]\s*=\s*\{{[\s\S]*?\}};";
            fileData = Regex.Replace(fileData, pattern, areaRoomEntries);
        }

        FileWriter.WriteToFile(path, fileData);
    }

    public static void UpdateGameRoomEntryHeader()
    {
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "include", "data", "rooms_data.h");
        string fileData = File.ReadAllText(path);

        for (int area = 0; area < Version.AreaNames.Length; area++)
        {
            string areaName = Version.AreaNames[area];

            // Update Doors
            int doorCount = DoorData.Count((byte)area) + 1;
            string doorPattern = $@"extern const struct Door s{areaName}Doors\[\d+\];";
            string doorReplacement = $"extern const struct Door s{areaName}Doors[{doorCount}];";
            fileData = Regex.Replace(fileData, doorPattern, doorReplacement);

            // Update Room Entries
            int roomCount = Version.RoomsPerArea[area];
            string roomPattern = $@"extern const struct RoomEntryRom s{areaName}RoomEntries\[\d+\];";
            string roomReplacement = $"extern const struct RoomEntryRom s{areaName}RoomEntries[{roomCount}];";
            fileData = Regex.Replace(fileData, roomPattern, roomReplacement);
        }

        FileWriter.WriteToFile(path, fileData);
    }

    private static List<string> GenerateLinkerRoomIncludes()
    {
        List<string> data = new();
        for (int area = 0; area < Version.AreaNames.Length; area++)
        {
            string areaName = Version.AreaNames[area];
            string areaNameLower = areaName.ToLower();

            for (int room = 0; room < Version.RoomsPerArea[area]; room++)
            { data.Add($"\t\tsrc/data/rooms/{areaNameLower}/{areaName}_{room}.o(.rodata);"); }

            data.Add($"\t\tsrc/data/rooms/{areaNameLower}/Bg3.o(.rodata);");
        }

        return data;
    }
    public static void UpdateLinkerRooms()
    {
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "linker.ld");
        List<string> lines = File.ReadAllLines(path).ToList();

        Predicate<string> lineMatch = l =>
            l.Trim().StartsWith("src/data/rooms/") && !l.Contains("test_rooms");

        // First occurrence of room includes
        int insertIndex = lines.FindIndex(lineMatch);
        if (insertIndex == -1) throw new Exception("No room entries found in linker script");

        // Remove all room lines
        lines.RemoveAll(lineMatch);

        // Add rooms again
        List<string> rooms = GenerateLinkerRoomIncludes();
        lines.InsertRange(insertIndex, rooms);

        File.WriteAllLines(path, lines);
    }
}
