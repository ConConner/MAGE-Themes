using mage.Properties;
using mage.Updates;
using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.Versioning;
using System.Windows.Forms;

namespace mage
{
    [SupportedOSPlatform("windows")]
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetDefaultFont(new Font(new FontFamily("Microsoft Sans Serif"), 8f));

            Program.Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            MigrateSettings();

            // check for opening rom directly
            string[] args = Environment.GetCommandLineArgs();
            FormMain form = new FormMain();
            if (args.Length > 1)
            {
                string path = args[1];
                if (File.Exists(path))
                    form.OpenROM(path);
            }

            Sound.PlaySound("mage.wav");

            Application.Run(form);
        }

        public static string Version { get; private set; }
        public static string ShortVersion
        {
            get
            {
                string[] parts = Version.Split('.');
                return $"{parts[0]}.{parts[1]}";
            }
        }

        private static bool experimentalFeaturesEnabled = false;
        public static bool ExperimentalFeaturesEnabled 
        { 
            get => experimentalFeaturesEnabled; 
            set
            {
                experimentalFeaturesEnabled = value;
                if (Settings.Default.experimentalFeatures == value) return;
                MessageBox.Show("You may need to restart the program for all changes to take effect.", "Restart required", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private static bool legacyEditor = false;
        public static bool LegacyEditors
        {
            get => legacyEditor;
            set
            {
                legacyEditor = value;
                if (Settings.Default.legacyEditors == value) return;
            }
        }
        public static Config Config { get; set; }

        private static void MigrateSettings()
        {
            if (!Properties.Settings.Default.UpgradeRequired) return;

            Properties.Settings.Default.Upgrade();
            Properties.Settings.Default.UpgradeRequired = false;
            Properties.Settings.Default.Save();
        }
    }
}
