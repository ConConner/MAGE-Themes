namespace mage
{
    partial class FormClearRom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            // the icon is shared with the add dialog
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdd));
            label_info = new System.Windows.Forms.Label();
            groupBox_rooms = new System.Windows.Forms.GroupBox();
            checkBox_scrolls = new System.Windows.Forms.CheckBox();
            checkBox_doors = new System.Windows.Forms.CheckBox();
            checkBox_roomSprites = new System.Windows.Forms.CheckBox();
            checkBox_rooms = new System.Windows.Forms.CheckBox();
            groupBox_connections = new System.Windows.Forms.GroupBox();
            checkBox_hatchLocks = new System.Windows.Forms.CheckBox();
            checkBox_locationNames = new System.Windows.Forms.CheckBox();
            checkBox_doorEvents = new System.Windows.Forms.CheckBox();
            checkBox_areaConnections = new System.Windows.Forms.CheckBox();
            groupBox_graphics = new System.Windows.Forms.GroupBox();
            checkBox_spritesets = new System.Windows.Forms.CheckBox();
            checkBox_animPalettes = new System.Windows.Forms.CheckBox();
            checkBox_animGfx = new System.Windows.Forms.CheckBox();
            checkBox_animTilesets = new System.Windows.Forms.CheckBox();
            checkBox_tilesets = new System.Windows.Forms.CheckBox();
            groupBox_other = new System.Windows.Forms.GroupBox();
            checkBox_demos = new System.Windows.Forms.CheckBox();
            checkBox_minimaps = new System.Windows.Forms.CheckBox();
            label_notes = new System.Windows.Forms.Label();
            checkBox_backup = new System.Windows.Forms.CheckBox();
            button_all = new System.Windows.Forms.Button();
            button_none = new System.Windows.Forms.Button();
            button_clear = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            groupBox_rooms.SuspendLayout();
            groupBox_connections.SuspendLayout();
            groupBox_graphics.SuspendLayout();
            groupBox_other.SuspendLayout();
            SuspendLayout();
            //
            // label_info
            //
            label_info.Location = new System.Drawing.Point(12, 9);
            label_info.Name = "label_info";
            label_info.Size = new System.Drawing.Size(496, 48);
            label_info.TabIndex = 0;
            label_info.Text = "Select the assets to remove. One blank asset of every removed type is kept so the editors have something to open. The space of the removed data is marked as free space and gets reused for new data.";
            //
            // groupBox_rooms
            //
            groupBox_rooms.Controls.Add(checkBox_scrolls);
            groupBox_rooms.Controls.Add(checkBox_doors);
            groupBox_rooms.Controls.Add(checkBox_roomSprites);
            groupBox_rooms.Controls.Add(checkBox_rooms);
            groupBox_rooms.Location = new System.Drawing.Point(12, 60);
            groupBox_rooms.Name = "groupBox_rooms";
            groupBox_rooms.Size = new System.Drawing.Size(242, 125);
            groupBox_rooms.TabIndex = 1;
            groupBox_rooms.TabStop = false;
            groupBox_rooms.Text = "Rooms";
            //
            // checkBox_rooms
            //
            checkBox_rooms.AutoSize = true;
            checkBox_rooms.Location = new System.Drawing.Point(10, 22);
            checkBox_rooms.Name = "checkBox_rooms";
            checkBox_rooms.Size = new System.Drawing.Size(62, 19);
            checkBox_rooms.TabIndex = 0;
            checkBox_rooms.Text = "Rooms";
            toolTip.SetToolTip(checkBox_rooms, "Removes all rooms except one blank room per area, including their backgrounds and clipdata.\nDoors, scrolls, room sprites, hatch lock events and location names refer to rooms and are removed as well.");
            checkBox_rooms.UseVisualStyleBackColor = true;
            //
            // checkBox_roomSprites
            //
            checkBox_roomSprites.AutoSize = true;
            checkBox_roomSprites.Location = new System.Drawing.Point(10, 47);
            checkBox_roomSprites.Name = "checkBox_roomSprites";
            checkBox_roomSprites.Size = new System.Drawing.Size(93, 19);
            checkBox_roomSprites.TabIndex = 1;
            checkBox_roomSprites.Text = "Room sprites";
            toolTip.SetToolTip(checkBox_roomSprites, "Removes the sprites placed in every room. The spriteset events of the rooms are reset.");
            checkBox_roomSprites.UseVisualStyleBackColor = true;
            //
            // checkBox_doors
            //
            checkBox_doors.AutoSize = true;
            checkBox_doors.Location = new System.Drawing.Point(10, 72);
            checkBox_doors.Name = "checkBox_doors";
            checkBox_doors.Size = new System.Drawing.Size(57, 19);
            checkBox_doors.TabIndex = 2;
            checkBox_doors.Text = "Doors";
            toolTip.SetToolTip(checkBox_doors, "Removes all doors. Every area keeps a blank door 0 in room 0, because the game loads rooms through doors.\nArea connections and door events refer to doors and are removed as well.");
            checkBox_doors.UseVisualStyleBackColor = true;
            //
            // checkBox_scrolls
            //
            checkBox_scrolls.AutoSize = true;
            checkBox_scrolls.Location = new System.Drawing.Point(10, 97);
            checkBox_scrolls.Name = "checkBox_scrolls";
            checkBox_scrolls.Size = new System.Drawing.Size(60, 19);
            checkBox_scrolls.TabIndex = 3;
            checkBox_scrolls.Text = "Scrolls";
            toolTip.SetToolTip(checkBox_scrolls, "Removes the scrolls of all rooms.");
            checkBox_scrolls.UseVisualStyleBackColor = true;
            //
            // groupBox_connections
            //
            groupBox_connections.Controls.Add(checkBox_hatchLocks);
            groupBox_connections.Controls.Add(checkBox_locationNames);
            groupBox_connections.Controls.Add(checkBox_doorEvents);
            groupBox_connections.Controls.Add(checkBox_areaConnections);
            groupBox_connections.Location = new System.Drawing.Point(266, 60);
            groupBox_connections.Name = "groupBox_connections";
            groupBox_connections.Size = new System.Drawing.Size(242, 125);
            groupBox_connections.TabIndex = 2;
            groupBox_connections.TabStop = false;
            groupBox_connections.Text = "Connections";
            //
            // checkBox_areaConnections
            //
            checkBox_areaConnections.AutoSize = true;
            checkBox_areaConnections.Location = new System.Drawing.Point(10, 22);
            checkBox_areaConnections.Name = "checkBox_areaConnections";
            checkBox_areaConnections.Size = new System.Drawing.Size(117, 19);
            checkBox_areaConnections.TabIndex = 0;
            checkBox_areaConnections.Text = "Area connections";
            toolTip.SetToolTip(checkBox_areaConnections, "Removes all area connections.");
            checkBox_areaConnections.UseVisualStyleBackColor = true;
            //
            // checkBox_doorEvents
            //
            checkBox_doorEvents.AutoSize = true;
            checkBox_doorEvents.Location = new System.Drawing.Point(10, 47);
            checkBox_doorEvents.Name = "checkBox_doorEvents";
            checkBox_doorEvents.Size = new System.Drawing.Size(88, 19);
            checkBox_doorEvents.TabIndex = 1;
            checkBox_doorEvents.Text = "Door events";
            toolTip.SetToolTip(checkBox_doorEvents, "Removes all door events (event based connections).");
            checkBox_doorEvents.UseVisualStyleBackColor = true;
            //
            // checkBox_locationNames
            //
            checkBox_locationNames.AutoSize = true;
            checkBox_locationNames.Location = new System.Drawing.Point(10, 72);
            checkBox_locationNames.Name = "checkBox_locationNames";
            checkBox_locationNames.Size = new System.Drawing.Size(107, 19);
            checkBox_locationNames.TabIndex = 2;
            checkBox_locationNames.Text = "Location names";
            toolTip.SetToolTip(checkBox_locationNames, "Removes all location names. The texts themselves are kept.");
            checkBox_locationNames.UseVisualStyleBackColor = true;
            //
            // checkBox_hatchLocks
            //
            checkBox_hatchLocks.AutoSize = true;
            checkBox_hatchLocks.Location = new System.Drawing.Point(10, 97);
            checkBox_hatchLocks.Name = "checkBox_hatchLocks";
            checkBox_hatchLocks.Size = new System.Drawing.Size(119, 19);
            checkBox_hatchLocks.TabIndex = 3;
            checkBox_hatchLocks.Text = "Hatch lock events";
            toolTip.SetToolTip(checkBox_hatchLocks, "Removes all hatch lock events. A blank event that locks no hatches is kept.");
            checkBox_hatchLocks.UseVisualStyleBackColor = true;
            //
            // groupBox_graphics
            //
            groupBox_graphics.Controls.Add(checkBox_spritesets);
            groupBox_graphics.Controls.Add(checkBox_animPalettes);
            groupBox_graphics.Controls.Add(checkBox_animGfx);
            groupBox_graphics.Controls.Add(checkBox_animTilesets);
            groupBox_graphics.Controls.Add(checkBox_tilesets);
            groupBox_graphics.Location = new System.Drawing.Point(12, 191);
            groupBox_graphics.Name = "groupBox_graphics";
            groupBox_graphics.Size = new System.Drawing.Size(242, 150);
            groupBox_graphics.TabIndex = 3;
            groupBox_graphics.TabStop = false;
            groupBox_graphics.Text = "Tilesets and spritesets";
            //
            // checkBox_tilesets
            //
            checkBox_tilesets.AutoSize = true;
            checkBox_tilesets.Location = new System.Drawing.Point(10, 22);
            checkBox_tilesets.Name = "checkBox_tilesets";
            checkBox_tilesets.Size = new System.Drawing.Size(65, 19);
            checkBox_tilesets.TabIndex = 0;
            checkBox_tilesets.Text = "Tilesets";
            toolTip.SetToolTip(checkBox_tilesets, "Removes all tilesets including their graphics, palettes and tile tables. Remaining rooms use the blank tileset.");
            checkBox_tilesets.UseVisualStyleBackColor = true;
            //
            // checkBox_animTilesets
            //
            checkBox_animTilesets.AutoSize = true;
            checkBox_animTilesets.Location = new System.Drawing.Point(10, 47);
            checkBox_animTilesets.Name = "checkBox_animTilesets";
            checkBox_animTilesets.Size = new System.Drawing.Size(120, 19);
            checkBox_animTilesets.TabIndex = 1;
            checkBox_animTilesets.Text = "Animated tilesets";
            toolTip.SetToolTip(checkBox_animTilesets, "Removes all animated tilesets. Remaining tilesets use the blank animated tileset.");
            checkBox_animTilesets.UseVisualStyleBackColor = true;
            //
            // checkBox_animGfx
            //
            checkBox_animGfx.AutoSize = true;
            checkBox_animGfx.Location = new System.Drawing.Point(10, 72);
            checkBox_animGfx.Name = "checkBox_animGfx";
            checkBox_animGfx.Size = new System.Drawing.Size(126, 19);
            checkBox_animGfx.TabIndex = 2;
            checkBox_animGfx.Text = "Animated graphics";
            toolTip.SetToolTip(checkBox_animGfx, "Removes all animated graphics. Animated tilesets only consist of animated graphics and are removed as well.");
            checkBox_animGfx.UseVisualStyleBackColor = true;
            //
            // checkBox_animPalettes
            //
            checkBox_animPalettes.AutoSize = true;
            checkBox_animPalettes.Location = new System.Drawing.Point(10, 97);
            checkBox_animPalettes.Name = "checkBox_animPalettes";
            checkBox_animPalettes.Size = new System.Drawing.Size(122, 19);
            checkBox_animPalettes.TabIndex = 3;
            checkBox_animPalettes.Text = "Animated palettes";
            toolTip.SetToolTip(checkBox_animPalettes, "Removes all animated palettes. Remaining tilesets use the blank animated palette.");
            checkBox_animPalettes.UseVisualStyleBackColor = true;
            //
            // checkBox_spritesets
            //
            checkBox_spritesets.AutoSize = true;
            checkBox_spritesets.Location = new System.Drawing.Point(10, 122);
            checkBox_spritesets.Name = "checkBox_spritesets";
            checkBox_spritesets.Size = new System.Drawing.Size(77, 19);
            checkBox_spritesets.TabIndex = 4;
            checkBox_spritesets.Text = "Spritesets";
            toolTip.SetToolTip(checkBox_spritesets, "Removes all spritesets. Remaining rooms use the blank spriteset. Sprite graphics and stats are kept.");
            checkBox_spritesets.UseVisualStyleBackColor = true;
            //
            // groupBox_other
            //
            groupBox_other.Controls.Add(checkBox_demos);
            groupBox_other.Controls.Add(checkBox_minimaps);
            groupBox_other.Location = new System.Drawing.Point(266, 191);
            groupBox_other.Name = "groupBox_other";
            groupBox_other.Size = new System.Drawing.Size(242, 150);
            groupBox_other.TabIndex = 4;
            groupBox_other.TabStop = false;
            groupBox_other.Text = "Other";
            //
            // checkBox_minimaps
            //
            checkBox_minimaps.AutoSize = true;
            checkBox_minimaps.Location = new System.Drawing.Point(10, 22);
            checkBox_minimaps.Name = "checkBox_minimaps";
            checkBox_minimaps.Size = new System.Drawing.Size(77, 19);
            checkBox_minimaps.TabIndex = 0;
            checkBox_minimaps.Text = "Minimaps";
            toolTip.SetToolTip(checkBox_minimaps, "Replaces every minimap with a blank one.");
            checkBox_minimaps.UseVisualStyleBackColor = true;
            //
            // checkBox_demos
            //
            checkBox_demos.AutoSize = true;
            checkBox_demos.Location = new System.Drawing.Point(10, 47);
            checkBox_demos.Name = "checkBox_demos";
            checkBox_demos.Size = new System.Drawing.Size(62, 19);
            checkBox_demos.TabIndex = 1;
            checkBox_demos.Text = "Demos";
            toolTip.SetToolTip(checkBox_demos, "Clears the inputs of every demo and lets them start at door 0.");
            checkBox_demos.UseVisualStyleBackColor = true;
            //
            // label_notes
            //
            label_notes.Location = new System.Drawing.Point(12, 348);
            label_notes.Name = "label_notes";
            label_notes.Size = new System.Drawing.Size(496, 105);
            label_notes.TabIndex = 5;
            label_notes.Text = "notes";
            //
            // checkBox_backup
            //
            checkBox_backup.AutoSize = true;
            checkBox_backup.Checked = true;
            checkBox_backup.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_backup.Location = new System.Drawing.Point(12, 458);
            checkBox_backup.Name = "checkBox_backup";
            checkBox_backup.Size = new System.Drawing.Size(185, 19);
            checkBox_backup.TabIndex = 6;
            checkBox_backup.Text = "Create a backup before clearing";
            checkBox_backup.UseVisualStyleBackColor = true;
            //
            // button_all
            //
            button_all.Location = new System.Drawing.Point(12, 485);
            button_all.Name = "button_all";
            button_all.Size = new System.Drawing.Size(85, 25);
            button_all.TabIndex = 7;
            button_all.Text = "Select All";
            button_all.UseVisualStyleBackColor = true;
            button_all.Click += button_all_Click;
            //
            // button_none
            //
            button_none.Location = new System.Drawing.Point(103, 485);
            button_none.Name = "button_none";
            button_none.Size = new System.Drawing.Size(85, 25);
            button_none.TabIndex = 8;
            button_none.Text = "Select None";
            button_none.UseVisualStyleBackColor = true;
            button_none.Click += button_none_Click;
            //
            // button_clear
            //
            button_clear.Location = new System.Drawing.Point(332, 485);
            button_clear.Name = "button_clear";
            button_clear.Size = new System.Drawing.Size(85, 25);
            button_clear.TabIndex = 9;
            button_clear.Text = "Clear";
            button_clear.UseVisualStyleBackColor = true;
            button_clear.Click += button_clear_Click;
            //
            // button_cancel
            //
            button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            button_cancel.Location = new System.Drawing.Point(423, 485);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(85, 25);
            button_cancel.TabIndex = 10;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            //
            // toolTip
            //
            toolTip.AutoPopDelay = 15000;
            toolTip.InitialDelay = 400;
            toolTip.ReshowDelay = 100;
            //
            // FormClearRom
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            CancelButton = button_cancel;
            ClientSize = new System.Drawing.Size(520, 522);
            Controls.Add(button_cancel);
            Controls.Add(button_clear);
            Controls.Add(button_none);
            Controls.Add(button_all);
            Controls.Add(checkBox_backup);
            Controls.Add(label_notes);
            Controls.Add(groupBox_other);
            Controls.Add(groupBox_graphics);
            Controls.Add(groupBox_connections);
            Controls.Add(groupBox_rooms);
            Controls.Add(label_info);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormClearRom";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Clear ROM";
            groupBox_rooms.ResumeLayout(false);
            groupBox_rooms.PerformLayout();
            groupBox_connections.ResumeLayout(false);
            groupBox_connections.PerformLayout();
            groupBox_graphics.ResumeLayout(false);
            groupBox_graphics.PerformLayout();
            groupBox_other.ResumeLayout(false);
            groupBox_other.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.GroupBox groupBox_rooms;
        private System.Windows.Forms.CheckBox checkBox_rooms;
        private System.Windows.Forms.CheckBox checkBox_roomSprites;
        private System.Windows.Forms.CheckBox checkBox_doors;
        private System.Windows.Forms.CheckBox checkBox_scrolls;
        private System.Windows.Forms.GroupBox groupBox_connections;
        private System.Windows.Forms.CheckBox checkBox_areaConnections;
        private System.Windows.Forms.CheckBox checkBox_doorEvents;
        private System.Windows.Forms.CheckBox checkBox_locationNames;
        private System.Windows.Forms.CheckBox checkBox_hatchLocks;
        private System.Windows.Forms.GroupBox groupBox_graphics;
        private System.Windows.Forms.CheckBox checkBox_tilesets;
        private System.Windows.Forms.CheckBox checkBox_animTilesets;
        private System.Windows.Forms.CheckBox checkBox_animGfx;
        private System.Windows.Forms.CheckBox checkBox_animPalettes;
        private System.Windows.Forms.CheckBox checkBox_spritesets;
        private System.Windows.Forms.GroupBox groupBox_other;
        private System.Windows.Forms.CheckBox checkBox_minimaps;
        private System.Windows.Forms.CheckBox checkBox_demos;
        private System.Windows.Forms.Label label_notes;
        private System.Windows.Forms.CheckBox checkBox_backup;
        private System.Windows.Forms.Button button_all;
        private System.Windows.Forms.Button button_none;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
