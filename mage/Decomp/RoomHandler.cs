using mage.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace mage.Decomp;

public static class RoomHandler
{
    private static int GetBackgroundPointer(Room room, int index)
    {
        switch (index)
        {
            case 0: return room.header.BG0ptr;
            case 1: return room.header.BG1ptr;
            case 2: return room.header.BG2ptr;
            case 3: return room.header.clipPtr;
        }
        return -1;
    }


    private static ResourceResponse SaveBackground(BG bg, string bgName)
    {
        // Parent filepath
        string areaNameCap = Version.AreaNames[bg.AreaID];
        string areaName = areaNameCap.ToLower();
        string relativePath = Path.Combine("data", "rooms", areaName);
        string path = Path.Combine(Version.ProjectConfig.DecompPath, relativePath);

        // Path
        string fileName = $"{areaName}_{bg.RoomID}_{bgName}.gfx";
        path = Path.Combine(path, fileName);

        ResourceResponse response = new();
        ByteStream bs = new();
        bg.Export(bs);
        FileWriter.WriteToFile(path, bs);

        response.ResourcePathReal = path;
        response.ResourcePathDecomp = $"data/rooms/{areaName}/{fileName}";
        response.ResourceLabel = $"s{areaNameCap}_{bg.RoomID}_{bgName}";
        response.Size = bs.Length;

        return response;
    }

    public static Dictionary<int, ResourceResponse> SaveRLEBackgrounds(Room room, Dictionary<int, ResourceResponse>? existingBackgrounds = null)
    {
        if (existingBackgrounds == null) existingBackgrounds = new();
        for (int i = 0; i < 4; i++)
        {
            BG bg = room.backgrounds[i];
            if (bg.IsLZ77 || !bg.Exists) continue;

            // Save Background
            string backgroundName = i == 3 ? "clipdata" : $"bg{i}";
            ResourceResponse res = SaveBackground(bg, backgroundName);

            // Find BG Pointer
            res.ResourcePointer = GetBackgroundPointer(room, i);
            existingBackgrounds[res.ResourcePointer] = res;
        }

        return existingBackgrounds;
    }

    public static Dictionary<int, ResourceResponse> SaveLZ77Backgrounds(Room room, Dictionary<int, ResourceResponse>? existingBackgrounds = null)
    {
        if (existingBackgrounds == null) existingBackgrounds = new();
        if (room.BG0.IsLZ77 && room.BG0.Exists)
        {
            int pointer = room.header.BG0ptr;
            if (!existingBackgrounds.ContainsKey(pointer))
            {
                var res = SaveBackground(room.BG0, "bg0");
                res.ResourcePointer = pointer;
                existingBackgrounds.Add(res.ResourcePointer, res);
            }
        }
        if (room.BG3.IsLZ77 && room.BG3.Exists)
        {
            int pointer = room.header.BG3ptr;
            if (!existingBackgrounds.ContainsKey(pointer))
            {
                var res = SaveBackground(room.BG3, "bg3");
                res.ResourcePointer = pointer;
                existingBackgrounds.Add(res.ResourcePointer, res);
            }
        }

        return existingBackgrounds;
    }


    public static List<string> GetScrollsAsArray(Room room)
    {
        List<string> result = new();
        result.Add(room.RoomID.ToString());
        result.Add(room.scrollList.Count.ToString());

        foreach (Scroll s in room.scrollList)
        {
            result.Add(s.xStart.ToString());
            result.Add(s.xEnd.ToString());
            result.Add(s.yStart.ToString());
            result.Add(s.yEnd.ToString());
            result.Add(s.xBreak.ToString());
            result.Add(s.yBreak.ToString());
            result.Add(s.replace.ToString());
            result.Add(s.newBound.ToString());
        }

        return result;
    }

    public static List<string>? GetSpritesAsArray(Room room, int set)
    {
        if (set > 2) throw new ArgumentOutOfRangeException("The chosen spriteset must be between 0 and 2");
        EnemyList? el = room.enemyLists[set];
        if (el == null) return null;

        List<string> result = new();

        foreach (Enemy e in el)
        {
            result.Add(e.yPos.ToString());
            result.Add(e.xPos.ToString());
            
            int slot = e.SlotNum;
            result.Add($"SPRITESET_IDX({slot})");
        }

        result.Add("ROOM_SPRITE_DATA_TERMINATOR");
        return result;
    }


    private static string GenerateBGInclude(ResourceResponse resource, List<string>? labels)
    {
        string label = $"{resource.ResourceLabel}[{resource.Size}]";
        if (labels != null) labels.Add(label);
        return $"const u8 {label} = INCBIN_U8(\"{resource.ResourcePathDecomp}\");";
    }
    public static void GenerateLZ77Include(StringBuilder fileData, Room room, Dictionary<int, ResourceResponse> backgrounds, List<string>? labels, HashSet<int> usedPointers)
    {
        bool bg0Exists = room.backgrounds.bg0.IsLZ77 & backgrounds.TryGetValue(room.header.BG0ptr, out ResourceResponse bg0);
        bool bg3Exists = backgrounds.TryGetValue(room.header.BG3ptr, out ResourceResponse bg3);

        if (bg0Exists && !usedPointers.Contains(room.header.BG0ptr))
        {
            fileData.AppendLine(GenerateBGInclude(bg0, labels));
            usedPointers.Add(room.header.BG0ptr);
        }
        if (bg3Exists && !usedPointers.Contains(room.header.BG3ptr)) 
        {
            fileData.AppendLine(GenerateBGInclude(bg3, labels));
            usedPointers.Add(room.header.BG3ptr);
        }
    }


    public static void SaveRoomData(Room room, Dictionary<int, ResourceResponse> backgrounds, List<string> labels)
    {
        // Build .c file
        string areaNameCap = Version.AreaNames[room.AreaID];
        string areaName = areaNameCap.ToLower();

        StringBuilder fileData = new();

        // File Includes
        fileData.AppendLine($"#include \"data/rooms/{areaName}_rooms_data.h\"");
        fileData.AppendLine("#include \"macros.h\"");

        // Scroll Data
        if (room.scrollList.Count != 0) {
            List<string> scrolls = GetScrollsAsArray(room);
            int numScrolls = room.scrollList.Count;
            string scrollLabel = $"s{areaNameCap}_{room.RoomID}_Scrolls[SCROLL_DATA_SIZE({numScrolls})]";
            fileData.AppendLine($"const u8 {scrollLabel} = {{");
            fileData.Append('\t');
            fileData.AppendJoin(',', scrolls); fileData.AppendLine();
            fileData.AppendLine("};");
            labels.Add(scrollLabel);
        }

        // Sprites
        for (int i = 0; i < 3; i++)
        {
            List<string>? sprites = GetSpritesAsArray(room, i);
            if (sprites == null) continue;
            int numSprites = room.enemyLists[i].Count;

            string spriteLabel = $"s{areaNameCap}_{room.RoomID}_Spriteset{i}[ENEMY_ROOM_DATA_ARRAY_SIZE({numSprites + 1})]";
            fileData.AppendLine($"const u8 {spriteLabel} = {{");
            fileData.Append('\t');
            fileData.AppendJoin(',', sprites); fileData.AppendLine();
            fileData.AppendLine("};");
            labels.Add(spriteLabel);
        }

        // Backgrounds 
        for (int i = 0; i < 4; i++)
        {
            // Get resource
            if (room.backgrounds[i].IsLZ77 || !room.backgrounds[i].Exists) continue;
            int pointer = GetBackgroundPointer(room, i);
            ResourceResponse resource;
            bool found = backgrounds.TryGetValue(pointer, out resource);
            if (!found) continue;

            fileData.AppendLine(GenerateBGInclude(resource, labels));
        }

        // Write File
        string path = Path.Combine(Version.ProjectConfig.DecompPath, "src", "data", "rooms", areaName, $"{areaNameCap}_{room.RoomID}.c");
        FileWriter.WriteToFile(path, fileData.ToString());
    }
}
