using System.IO;

namespace mage;

public static class Muslist
{
    public static string MusiclistName { get; set; } = "";
    public static string MusiclistsPath { get; set; } = "";

    public static string GetSelectedMusiclistPath()
    {
        if (MusiclistsPath == "" || MusiclistName == "")
            return "";

        return Path.Combine(MusiclistsPath, MusiclistName);
    }

    public static string ReadSelectedMusiclist()
    {
        string path = GetSelectedMusiclistPath();

        if (path == "" || !File.Exists(path))
            return "";

        return File.ReadAllText(path);
    }
}