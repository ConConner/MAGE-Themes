using System.IO;

namespace mage;

public static class MusicList
{
    public static string SelectedListName { get; set; } = "";
    public static string ListsPath { get; set; } = "";

    public static string GetSelectedMusicListPath()
    {
        if (ListsPath == "" || SelectedListName == "")
            return "";

        return Path.Combine(ListsPath, SelectedListName);
    }

    public static string ReadSelectedMusiclist()
    {
        string path = GetSelectedMusicListPath();

        if (path == "" || !File.Exists(path))
            return "";

        return File.ReadAllText(path);
    }
}