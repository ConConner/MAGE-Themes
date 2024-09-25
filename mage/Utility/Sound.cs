using System;
using System.IO;
using System.Media;
using System.Windows.Forms;

namespace mage;

public class Sound
{
    public static string SoundPackName { get; set; } = "default";
    public static string SoundPacksPath { get; set; } = @"";

    public static void PlaySound(string name, bool silentFail = true)
    {

        try
        {
            if (SoundPacksPath == "" || SoundPackName == "") return;

            string path = Path.Combine(new string[] { SoundPacksPath, SoundPackName, name });
            if (!File.Exists(path)) return;

            SoundPlayer sound = new(path);
            sound.Play();
        }
        catch (Exception e)
        {
            if (!silentFail) return;
            MessageBox.Show($"An error occured while trying to play the sound {name}\n\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}