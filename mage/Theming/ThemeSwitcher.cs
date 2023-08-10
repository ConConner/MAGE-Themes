﻿using mage.Theming.CustomControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Theming
{
    public static class ThemeSwitcher
    {
        /// <summary>
        /// Project Wide dictionary with all Color Themes
        /// </summary>
        public static Dictionary<string, ColorTheme> Themes = new Dictionary<string, ColorTheme>()
        {
            {"MageOld", new ColorTheme()
            {
                BackgroundColor = ColorTranslator.FromHtml("#F0F0F0"),
                TextColor = ColorTranslator.FromHtml("#000000"),
                PrimaryOutline = ColorTranslator.FromHtml("#BCBCBC"),
                SecondaryOutline = ColorTranslator.FromHtml("#DCDCDC"),
                AccentColor = ColorTranslator.FromHtml("#0078d7"),
            } },

            {"VSDark", new ColorTheme()
            {
                BackgroundColor = ColorTranslator.FromHtml("#1E1E1E"),
                TextColor = ColorTranslator.FromHtml("#DCDCDC"),
                PrimaryOutline = ColorTranslator.FromHtml("#5F5F5F"),
                SecondaryOutline = ColorTranslator.FromHtml("#3D3D3D"),
                AccentColor = ColorTranslator.FromHtml("#7160e8"),
            } },

            {"MageDark", new ColorTheme()
            {
                BackgroundColor = Color.FromArgb(0x00, 0x00, 0x00),
                TextColor = Color.FromArgb(0xF0, 0xF0, 0xF0),
                PrimaryOutline = Color.FromArgb(0xBC, 0xBC, 0xBC),
                SecondaryOutline = Color.FromArgb(0x34, 0x34, 0x34)
            } },
        };

        /// <summary>
        /// The currently used Color Theme
        /// </summary>
        public static ColorTheme ProjectTheme { get; set; }

        public static void ChangeTheme(ColorTheme theme, Control.ControlCollection container, Control Base = null)
        {
            ProjectTheme = theme;

            if (Base != null)
            {
                Base.BackColor = theme.BackgroundColor;
                Base.ForeColor = theme.TextColor;
            }

            foreach (Control component in container)
            {
                component.BackColor = theme.BackgroundColor;
                component.ForeColor = theme.TextColor;
                if (component.Tag?.ToString() == "accent") component.BackColor = theme.AccentColor;

                if (component.Controls.Count > 0)
                {
                    ChangeTheme(theme, component.Controls);
                }

                //Special handeling for special controls
                if (component is FlatComboBox)
                {
                    FlatComboBox box = component as FlatComboBox;
                    box.BorderColor = theme.PrimaryOutline;
                    box.ButtonColor = theme.BackgroundColor;
                }

                if (component is ToolStrip)
                {
                    ToolStrip strip = component as ToolStrip;
                    strip.Renderer = new MenuStripCustomRenderer(theme);
                }
            }
        }

        /// <summary>
        /// This injects new paint events into existing controls to allow for custom colors
        /// </summary>
        public static void InjectPaintOverrides(Control.ControlCollection container)
        {
            foreach (Control component in container)
            {
                //recursively inject the overrides in every child control
                if (component.Controls.Count > 0) InjectPaintOverrides(component.Controls);

                //Special handeling for special controls
                if (component is GroupBox) component.Paint += DrawGroupBox;
            }
        }

        /// <summary>
        /// Custom Paint event for GroupBoxes
        /// </summary>
        public static void DrawGroupBox(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            Graphics g = e.Graphics;
            Color textColor = box.ForeColor;
            Color borderColor = ProjectTheme.SecondaryOutline;

            Brush textBrush = new SolidBrush(textColor);
            Brush borderBrush = new SolidBrush(borderColor);
            Pen borderPen = new Pen(borderBrush);
            SizeF strSize = g.MeasureString(box.Text, box.Font);
            Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                           box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                           box.ClientRectangle.Width - 1,
                                           box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

            // Clear text and border
            g.Clear(box.BackColor);

            // Draw text
            g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

            // Drawing Border
            //Left
            g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
            //Right
            g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            //Bottom
            g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
            //Top1
            g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
            //Top2
            g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
        }
    }
}