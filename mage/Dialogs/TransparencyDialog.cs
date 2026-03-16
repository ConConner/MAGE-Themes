using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinButton = System.Windows.Forms.Button;

namespace mage.Dialogs
{
    public partial class TransparencyDialog : Form
    {
        //Button Arrays for easier management
        private WinButton[] positionButtons;
        private WinButton[] transparencyButtons;
        //textBox_Value_Dialog.Text += textChanged;

        public byte Value = 0; //Hex.ToByte(FormHeader.textBox_transparency.Text);
        private byte PositionValue;
        private byte TransparencyValue;
        public TransparencyDialog(byte initialValue)
        {
            InitializeComponent();
            // Store incoming value
            this.Value = initialValue;

            // Split into components
            separateValues();


            // After InitializeComponent, but before showing the form
            this.Load += TransparencyDialog_Load;

            DialogResult = DialogResult.Cancel;
        }

        private void TransparencyDialog_Load(object sender, EventArgs e)
        {
            positionButtons = new[] { btn_overBG1_overSprite, btn_overBG2_overSprite, btn_overBG2_underSprite, btn_overBG3_underSprite };
            transparencyButtons = new[]
            {
                     button0, button1, button2, button3, button4,
                     button5, button6, button7, button8, button9, button10
                };

            UpdateUI();

            //Theming
            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);
        }

        private void textChanged(object sender, EventArgs e)
        {
            string ErrorText = string.Empty;
            //Validate values or throw error textBox_Value_Dialog
            try
            {
                byte newValue = Hex.ToByte(textBox_Value_Dialog.Text);
                if (newValue < 0 || newValue > 0xFF) throw new ArgumentOutOfRangeException(nameof(newValue), "Tile number must be between 0 and 0xFF.");
                Value = newValue;//update Value
                separateValues();
                UpdateUI();
            }
            catch (Exception exc)
            {
                ErrorText = exc.Message;
            }
        }
        private void UpdateUI()
        {
            combineValues();
            textBox_Value_Dialog.Text = Hex.ToString(Value);
            foreach (var b in positionButtons)
                b.BackColor = ThemeSwitcher.ProjectTheme.BackgroundColor;

            foreach (var b in transparencyButtons)
                b.BackColor = ThemeSwitcher.ProjectTheme.BackgroundColor;

            positionButtons[PositionValue].BackColor = ThemeSwitcher.ProjectTheme.AccentColor;
            positionButtons[PositionValue].ForeColor = ThemeSwitcher.ProjectTheme.TextColorHighlight;

            int buttonIndex = GetButtonIndexForGroup(TransparencyValue);
            transparencyButtons[buttonIndex].BackColor = ThemeSwitcher.ProjectTheme.AccentColor;
            transparencyButtons[buttonIndex].ForeColor = ThemeSwitcher.ProjectTheme.TextColorHighlight;
        }

        private byte combineValues()
        {
            Value = (byte)(PositionValue + 4 * TransparencyValue);
            return Value;
        }


        private void separateValues()
        {
            PositionValue = (byte)(Value % 4);
            TransparencyValue = (byte)(Value / 4);
        }

        private void returnValue(byte value)
        {
            DialogResult = DialogResult.OK;
            Value = value;
            Close();
        }

        private void buttonPositionClicked(object sender, EventArgs e)
        {
            WinButton b = sender as WinButton;
            int val = Convert.ToInt32(b.Tag.ToString(), 10);
            PositionValue = ((byte)val);
            UpdateUI();
        }
        private void buttonTransparencyClicked(object sender, EventArgs e)
        {
            WinButton b = sender as WinButton;
            int buttonIndex = Convert.ToInt32(b.Tag.ToString(), 10);
            TransparencyValue = AlphaGroupForButton[buttonIndex]; // group index (0..13)
            UpdateUI();
        }

        private void returnCombined(object sender, EventArgs e)
        {
            Value = combineValues();
            returnValue(Value);
        }
        private int GetButtonIndexForGroup(byte group)
        {
            for (int i = 0; i < AlphaGroupForButton.Length; i++)
                if (AlphaGroupForButton[i] == group)
                    return i;

            // Fallback: if group is a duplicate (1,12,13), map to 0 (16,0)
            return 0;
        }


        // Which BLDALPHA group each transparency button represents
        // index = button.Tag (0..10), value = group index (0..13)
        private static readonly byte[] AlphaGroupForButton =
        {
            12,  // button0 → group 13  (0x00–0x03, EVA=16, EVB=0)
            2,  // button1 → group 2  (0x08–0x0B, 16,7)
            3,  // button2 → group 3  (0x0C–0x0F, 16,10)
            4,  // button3 → group 4  (0x10–0x13, 16,13)
            5,  // button4 → group 5  (0x14–0x17, 16,16)
            6,  // button5 → group 6  (0x18–0x1B, 0,16)
            7,  // button6 → group 7  (0x1C–0x1F, 3,13)
            8,  // button7 → group 8  (0x20–0x23, 6,10)
            9,  // button8 → group 9  (0x24–0x27, 9,7)
            10, // button9 → group 10 (0x28–0x2B, 11,5)
            11  // button10 → group 11 (0x2C–0x2F, 13,3)
        };
    }
}
