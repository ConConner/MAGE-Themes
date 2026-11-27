namespace mage
{
    partial class FormConnection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConnection));
            listView_areaConnections = new System.Windows.Forms.ListView();
            columnHeader_src = new System.Windows.Forms.ColumnHeader();
            columnHeader_dst = new System.Windows.Forms.ColumnHeader();
            button_areaAdd = new System.Windows.Forms.Button();
            button_areaRemove = new System.Windows.Forms.Button();
            label_areaSource = new System.Windows.Forms.Label();
            label_areaDestination = new System.Windows.Forms.Label();
            comboBox_areaDstArea = new mage.Theming.CustomControls.FlatComboBox();
            comboBox_areaSrcArea = new mage.Theming.CustomControls.FlatComboBox();
            textBox_areaSrcDoor = new mage.Theming.CustomControls.FlatTextBox();
            label_areaDstRoom = new System.Windows.Forms.Label();
            label_areaSrcRoom = new System.Windows.Forms.Label();
            label_areaDstDoor = new System.Windows.Forms.Label();
            button_areaClose = new System.Windows.Forms.Button();
            button_areaApply = new System.Windows.Forms.Button();
            label_areaArea = new System.Windows.Forms.Label();
            label_areaRoom = new System.Windows.Forms.Label();
            label_areaDoor = new System.Windows.Forms.Label();
            tabControl = new mage.Theming.CustomControls.FlatTabControl();
            tabPage_area = new System.Windows.Forms.TabPage();
            tabPage_event = new System.Windows.Forms.TabPage();
            textBox_event = new mage.Theming.CustomControls.FlatTextBox();
            label_event = new System.Windows.Forms.Label();
            textBox_eventDstDoor = new mage.Theming.CustomControls.FlatTextBox();
            label_eventDstArea = new System.Windows.Forms.Label();
            listView_doorEvents = new System.Windows.Forms.ListView();
            columnHeader1 = new System.Windows.Forms.ColumnHeader();
            columnHeader2 = new System.Windows.Forms.ColumnHeader();
            columnHeader3 = new System.Windows.Forms.ColumnHeader();
            label_eventDoor = new System.Windows.Forms.Label();
            button_eventAdd = new System.Windows.Forms.Button();
            label_eventRoom = new System.Windows.Forms.Label();
            button_eventRemove = new System.Windows.Forms.Button();
            label_eventArea = new System.Windows.Forms.Label();
            label_eventSource = new System.Windows.Forms.Label();
            button_eventClose = new System.Windows.Forms.Button();
            label_eventDestination = new System.Windows.Forms.Label();
            button_eventApply = new System.Windows.Forms.Button();
            comboBox_eventSrcArea = new mage.Theming.CustomControls.FlatComboBox();
            label_eventSrcRoom = new System.Windows.Forms.Label();
            textBox_eventSrcDoor = new mage.Theming.CustomControls.FlatTextBox();
            label_eventDstRoom = new System.Windows.Forms.Label();
            tabPage_locNames = new System.Windows.Forms.TabPage();
            comboBox_locLanguage = new mage.Theming.CustomControls.FlatComboBox();
            label1 = new System.Windows.Forms.Label();
            textBox_locDstRoom = new mage.Theming.CustomControls.FlatTextBox();
            listView_locNames = new System.Windows.Forms.ListView();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            columnHeader5 = new System.Windows.Forms.ColumnHeader();
            columnHeader6 = new System.Windows.Forms.ColumnHeader();
            button_locAdd = new System.Windows.Forms.Button();
            label_locRoom = new System.Windows.Forms.Label();
            button_locRemove = new System.Windows.Forms.Button();
            label_locArea = new System.Windows.Forms.Label();
            label_locDestination = new System.Windows.Forms.Label();
            button_locClose = new System.Windows.Forms.Button();
            label_locText = new System.Windows.Forms.Label();
            button_locApply = new System.Windows.Forms.Button();
            comboBox_locDstArea = new mage.Theming.CustomControls.FlatComboBox();
            textBox_locText = new mage.Theming.CustomControls.FlatTextBox();
            label_locName = new System.Windows.Forms.Label();
            tabPage_hatchLock = new System.Windows.Forms.TabPage();
            radioButton_lockAfter = new System.Windows.Forms.RadioButton();
            radioButton_lockBefore = new System.Windows.Forms.RadioButton();
            listBox_lockHatches = new System.Windows.Forms.ListBox();
            textBox_lockEvent = new mage.Theming.CustomControls.FlatTextBox();
            label_lockEvent = new System.Windows.Forms.Label();
            textBox_lockRoom = new mage.Theming.CustomControls.FlatTextBox();
            label_lockRoom = new System.Windows.Forms.Label();
            listView_lockHatches = new System.Windows.Forms.ListView();
            columnHeader_lockDst = new System.Windows.Forms.ColumnHeader();
            columnHeader_lockEvent = new System.Windows.Forms.ColumnHeader();
            columnHeader_lockWhen = new System.Windows.Forms.ColumnHeader();
            columnHeader_lockHatches = new System.Windows.Forms.ColumnHeader();
            button_lockAdd = new System.Windows.Forms.Button();
            button_lockRemove = new System.Windows.Forms.Button();
            label_lockArea = new System.Windows.Forms.Label();
            button_lockClose = new System.Windows.Forms.Button();
            button_lockApply = new System.Windows.Forms.Button();
            comboBox_lockArea = new mage.Theming.CustomControls.FlatComboBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            tabControl.SuspendLayout();
            tabPage_area.SuspendLayout();
            tabPage_event.SuspendLayout();
            tabPage_locNames.SuspendLayout();
            tabPage_hatchLock.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // listView_areaConnections
            // 
            listView_areaConnections.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_src, columnHeader_dst });
            listView_areaConnections.FullRowSelect = true;
            listView_areaConnections.GridLines = true;
            listView_areaConnections.Location = new System.Drawing.Point(7, 7);
            listView_areaConnections.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView_areaConnections.MultiSelect = false;
            listView_areaConnections.Name = "listView_areaConnections";
            listView_areaConnections.Size = new System.Drawing.Size(628, 187);
            listView_areaConnections.TabIndex = 0;
            listView_areaConnections.UseCompatibleStateImageBehavior = false;
            listView_areaConnections.View = System.Windows.Forms.View.Details;
            listView_areaConnections.SelectedIndexChanged += listView_areaConnections_SelectedIndexChanged;
            // 
            // columnHeader_src
            // 
            columnHeader_src.Text = "Source";
            columnHeader_src.Width = 200;
            // 
            // columnHeader_dst
            // 
            columnHeader_dst.Text = "Destination";
            columnHeader_dst.Width = 200;
            // 
            // button_areaAdd
            // 
            button_areaAdd.Enabled = false;
            button_areaAdd.Location = new System.Drawing.Point(7, 218);
            button_areaAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_areaAdd.Name = "button_areaAdd";
            button_areaAdd.Size = new System.Drawing.Size(88, 27);
            button_areaAdd.TabIndex = 1;
            button_areaAdd.Text = "Add";
            button_areaAdd.UseVisualStyleBackColor = true;
            button_areaAdd.Click += button_areaAdd_Click;
            // 
            // button_areaRemove
            // 
            button_areaRemove.Enabled = false;
            button_areaRemove.Location = new System.Drawing.Point(7, 252);
            button_areaRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_areaRemove.Name = "button_areaRemove";
            button_areaRemove.Size = new System.Drawing.Size(88, 27);
            button_areaRemove.TabIndex = 2;
            button_areaRemove.Text = "Remove";
            button_areaRemove.UseVisualStyleBackColor = true;
            button_areaRemove.Click += button_areaRemove_Click;
            // 
            // label_areaSource
            // 
            label_areaSource.AutoSize = true;
            label_areaSource.Location = new System.Drawing.Point(106, 224);
            label_areaSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaSource.Name = "label_areaSource";
            label_areaSource.Size = new System.Drawing.Size(46, 15);
            label_areaSource.TabIndex = 0;
            label_areaSource.Text = "Source:";
            // 
            // label_areaDestination
            // 
            label_areaDestination.AutoSize = true;
            label_areaDestination.Location = new System.Drawing.Point(106, 255);
            label_areaDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaDestination.Name = "label_areaDestination";
            label_areaDestination.Size = new System.Drawing.Size(70, 15);
            label_areaDestination.TabIndex = 0;
            label_areaDestination.Text = "Destination:";
            // 
            // comboBox_areaDstArea
            // 
            comboBox_areaDstArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_areaDstArea.FormattingEnabled = true;
            comboBox_areaDstArea.Location = new System.Drawing.Point(187, 252);
            comboBox_areaDstArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_areaDstArea.Name = "comboBox_areaDstArea";
            comboBox_areaDstArea.Size = new System.Drawing.Size(93, 23);
            comboBox_areaDstArea.TabIndex = 5;
            comboBox_areaDstArea.SelectedIndexChanged += control_areaInfo_Changed;
            // 
            // comboBox_areaSrcArea
            // 
            comboBox_areaSrcArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_areaSrcArea.FormattingEnabled = true;
            comboBox_areaSrcArea.Location = new System.Drawing.Point(187, 220);
            comboBox_areaSrcArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_areaSrcArea.Name = "comboBox_areaSrcArea";
            comboBox_areaSrcArea.Size = new System.Drawing.Size(93, 23);
            comboBox_areaSrcArea.TabIndex = 3;
            comboBox_areaSrcArea.SelectedIndexChanged += control_areaInfo_Changed;
            // 
            // textBox_areaSrcDoor
            // 
            textBox_areaSrcDoor.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_areaSrcDoor.DisplayBorder = true;
            textBox_areaSrcDoor.HexSanitized = false;
            textBox_areaSrcDoor.HexSanitizedMaxValue = -1;
            textBox_areaSrcDoor.Location = new System.Drawing.Point(342, 220);
            textBox_areaSrcDoor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_areaSrcDoor.MaxLength = 32767;
            textBox_areaSrcDoor.Multiline = false;
            textBox_areaSrcDoor.Name = "textBox_areaSrcDoor";
            textBox_areaSrcDoor.OnTextChanged = null;
            textBox_areaSrcDoor.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_areaSrcDoor.PlaceholderText = "";
            textBox_areaSrcDoor.ReadOnly = false;
            textBox_areaSrcDoor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_areaSrcDoor.SelectionStart = 0;
            textBox_areaSrcDoor.Size = new System.Drawing.Size(35, 23);
            textBox_areaSrcDoor.TabIndex = 4;
            textBox_areaSrcDoor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_areaSrcDoor.ValueBox = false;
            textBox_areaSrcDoor.WordWrap = true;
            textBox_areaSrcDoor.TextChanged += control_areaInfo_Changed;
            // 
            // label_areaDstRoom
            // 
            label_areaDstRoom.AutoSize = true;
            label_areaDstRoom.Location = new System.Drawing.Point(294, 255);
            label_areaDstRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaDstRoom.Name = "label_areaDstRoom";
            label_areaDstRoom.Size = new System.Drawing.Size(13, 15);
            label_areaDstRoom.TabIndex = 0;
            label_areaDstRoom.Text = "–";
            // 
            // label_areaSrcRoom
            // 
            label_areaSrcRoom.AutoSize = true;
            label_areaSrcRoom.Location = new System.Drawing.Point(294, 224);
            label_areaSrcRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaSrcRoom.Name = "label_areaSrcRoom";
            label_areaSrcRoom.Size = new System.Drawing.Size(13, 15);
            label_areaSrcRoom.TabIndex = 0;
            label_areaSrcRoom.Text = "–";
            // 
            // label_areaDstDoor
            // 
            label_areaDstDoor.AutoSize = true;
            label_areaDstDoor.Location = new System.Drawing.Point(342, 255);
            label_areaDstDoor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaDstDoor.Name = "label_areaDstDoor";
            label_areaDstDoor.Size = new System.Drawing.Size(13, 15);
            label_areaDstDoor.TabIndex = 0;
            label_areaDstDoor.Text = "–";
            // 
            // button_areaClose
            // 
            button_areaClose.Location = new System.Drawing.Point(411, 252);
            button_areaClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_areaClose.Name = "button_areaClose";
            button_areaClose.Size = new System.Drawing.Size(88, 27);
            button_areaClose.TabIndex = 7;
            button_areaClose.Text = "Close";
            button_areaClose.UseVisualStyleBackColor = true;
            button_areaClose.Click += button_close_Click;
            // 
            // button_areaApply
            // 
            button_areaApply.Enabled = false;
            button_areaApply.Location = new System.Drawing.Point(411, 218);
            button_areaApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_areaApply.Name = "button_areaApply";
            button_areaApply.Size = new System.Drawing.Size(88, 27);
            button_areaApply.TabIndex = 6;
            button_areaApply.Text = "Apply";
            button_areaApply.UseVisualStyleBackColor = true;
            button_areaApply.Click += button_areaApply_Click;
            // 
            // label_areaArea
            // 
            label_areaArea.AutoSize = true;
            label_areaArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_areaArea.Location = new System.Drawing.Point(183, 202);
            label_areaArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaArea.Name = "label_areaArea";
            label_areaArea.Size = new System.Drawing.Size(29, 13);
            label_areaArea.TabIndex = 0;
            label_areaArea.Text = "Area";
            // 
            // label_areaRoom
            // 
            label_areaRoom.AutoSize = true;
            label_areaRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_areaRoom.Location = new System.Drawing.Point(294, 202);
            label_areaRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaRoom.Name = "label_areaRoom";
            label_areaRoom.Size = new System.Drawing.Size(35, 13);
            label_areaRoom.TabIndex = 0;
            label_areaRoom.Text = "Room";
            // 
            // label_areaDoor
            // 
            label_areaDoor.AutoSize = true;
            label_areaDoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_areaDoor.Location = new System.Drawing.Point(342, 202);
            label_areaDoor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_areaDoor.Name = "label_areaDoor";
            label_areaDoor.Size = new System.Drawing.Size(30, 13);
            label_areaDoor.TabIndex = 0;
            label_areaDoor.Text = "Door";
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Silver;
            tabControl.Controls.Add(tabPage_area);
            tabControl.Controls.Add(tabPage_event);
            tabControl.Controls.Add(tabPage_locNames);
            tabControl.Controls.Add(tabPage_hatchLock);
            tabControl.Location = new System.Drawing.Point(14, 14);
            tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(652, 343);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPage_area
            // 
            tabPage_area.Controls.Add(listView_areaConnections);
            tabPage_area.Controls.Add(label_areaDoor);
            tabPage_area.Controls.Add(button_areaAdd);
            tabPage_area.Controls.Add(label_areaRoom);
            tabPage_area.Controls.Add(button_areaRemove);
            tabPage_area.Controls.Add(label_areaArea);
            tabPage_area.Controls.Add(label_areaSource);
            tabPage_area.Controls.Add(button_areaClose);
            tabPage_area.Controls.Add(label_areaDestination);
            tabPage_area.Controls.Add(button_areaApply);
            tabPage_area.Controls.Add(comboBox_areaDstArea);
            tabPage_area.Controls.Add(label_areaDstDoor);
            tabPage_area.Controls.Add(comboBox_areaSrcArea);
            tabPage_area.Controls.Add(label_areaSrcRoom);
            tabPage_area.Controls.Add(textBox_areaSrcDoor);
            tabPage_area.Controls.Add(label_areaDstRoom);
            tabPage_area.Location = new System.Drawing.Point(4, 25);
            tabPage_area.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_area.Name = "tabPage_area";
            tabPage_area.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_area.Size = new System.Drawing.Size(644, 314);
            tabPage_area.TabIndex = 0;
            tabPage_area.Text = "Area Connections";
            // 
            // tabPage_event
            // 
            tabPage_event.Controls.Add(textBox_event);
            tabPage_event.Controls.Add(label_event);
            tabPage_event.Controls.Add(textBox_eventDstDoor);
            tabPage_event.Controls.Add(label_eventDstArea);
            tabPage_event.Controls.Add(listView_doorEvents);
            tabPage_event.Controls.Add(label_eventDoor);
            tabPage_event.Controls.Add(button_eventAdd);
            tabPage_event.Controls.Add(label_eventRoom);
            tabPage_event.Controls.Add(button_eventRemove);
            tabPage_event.Controls.Add(label_eventArea);
            tabPage_event.Controls.Add(label_eventSource);
            tabPage_event.Controls.Add(button_eventClose);
            tabPage_event.Controls.Add(label_eventDestination);
            tabPage_event.Controls.Add(button_eventApply);
            tabPage_event.Controls.Add(comboBox_eventSrcArea);
            tabPage_event.Controls.Add(label_eventSrcRoom);
            tabPage_event.Controls.Add(textBox_eventSrcDoor);
            tabPage_event.Controls.Add(label_eventDstRoom);
            tabPage_event.Location = new System.Drawing.Point(4, 25);
            tabPage_event.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_event.Name = "tabPage_event";
            tabPage_event.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_event.Size = new System.Drawing.Size(644, 314);
            tabPage_event.TabIndex = 1;
            tabPage_event.Text = "Event Based Connections";
            // 
            // textBox_event
            // 
            textBox_event.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_event.DisplayBorder = true;
            textBox_event.HexSanitized = false;
            textBox_event.HexSanitizedMaxValue = -1;
            textBox_event.Location = new System.Drawing.Point(187, 283);
            textBox_event.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_event.MaxLength = 32767;
            textBox_event.Multiline = false;
            textBox_event.Name = "textBox_event";
            textBox_event.OnTextChanged = null;
            textBox_event.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_event.PlaceholderText = "";
            textBox_event.ReadOnly = false;
            textBox_event.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_event.SelectionStart = 0;
            textBox_event.Size = new System.Drawing.Size(35, 23);
            textBox_event.TabIndex = 6;
            textBox_event.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_event.ValueBox = false;
            textBox_event.WordWrap = true;
            textBox_event.TextChanged += control_eventInfo_Changed;
            // 
            // label_event
            // 
            label_event.AutoSize = true;
            label_event.Location = new System.Drawing.Point(106, 286);
            label_event.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_event.Name = "label_event";
            label_event.Size = new System.Drawing.Size(39, 15);
            label_event.TabIndex = 0;
            label_event.Text = "Event:";
            // 
            // textBox_eventDstDoor
            // 
            textBox_eventDstDoor.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_eventDstDoor.DisplayBorder = true;
            textBox_eventDstDoor.HexSanitized = false;
            textBox_eventDstDoor.HexSanitizedMaxValue = -1;
            textBox_eventDstDoor.Location = new System.Drawing.Point(342, 252);
            textBox_eventDstDoor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_eventDstDoor.MaxLength = 32767;
            textBox_eventDstDoor.Multiline = false;
            textBox_eventDstDoor.Name = "textBox_eventDstDoor";
            textBox_eventDstDoor.OnTextChanged = null;
            textBox_eventDstDoor.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_eventDstDoor.PlaceholderText = "";
            textBox_eventDstDoor.ReadOnly = false;
            textBox_eventDstDoor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_eventDstDoor.SelectionStart = 0;
            textBox_eventDstDoor.Size = new System.Drawing.Size(35, 23);
            textBox_eventDstDoor.TabIndex = 5;
            textBox_eventDstDoor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_eventDstDoor.ValueBox = false;
            textBox_eventDstDoor.WordWrap = true;
            textBox_eventDstDoor.TextChanged += control_eventInfo_Changed;
            // 
            // label_eventDstArea
            // 
            label_eventDstArea.AutoSize = true;
            label_eventDstArea.Location = new System.Drawing.Point(187, 255);
            label_eventDstArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventDstArea.Name = "label_eventDstArea";
            label_eventDstArea.Size = new System.Drawing.Size(13, 15);
            label_eventDstArea.TabIndex = 0;
            label_eventDstArea.Text = "–";
            // 
            // listView_doorEvents
            // 
            listView_doorEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView_doorEvents.FullRowSelect = true;
            listView_doorEvents.GridLines = true;
            listView_doorEvents.Location = new System.Drawing.Point(7, 7);
            listView_doorEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView_doorEvents.MultiSelect = false;
            listView_doorEvents.Name = "listView_doorEvents";
            listView_doorEvents.Size = new System.Drawing.Size(628, 187);
            listView_doorEvents.TabIndex = 0;
            listView_doorEvents.UseCompatibleStateImageBehavior = false;
            listView_doorEvents.View = System.Windows.Forms.View.Details;
            listView_doorEvents.SelectedIndexChanged += listView_doorEvents_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Source";
            columnHeader1.Width = 225;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Event";
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Destination";
            columnHeader3.Width = 225;
            // 
            // label_eventDoor
            // 
            label_eventDoor.AutoSize = true;
            label_eventDoor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_eventDoor.Location = new System.Drawing.Point(342, 202);
            label_eventDoor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventDoor.Name = "label_eventDoor";
            label_eventDoor.Size = new System.Drawing.Size(30, 13);
            label_eventDoor.TabIndex = 0;
            label_eventDoor.Text = "Door";
            // 
            // button_eventAdd
            // 
            button_eventAdd.Enabled = false;
            button_eventAdd.Location = new System.Drawing.Point(7, 218);
            button_eventAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_eventAdd.Name = "button_eventAdd";
            button_eventAdd.Size = new System.Drawing.Size(88, 27);
            button_eventAdd.TabIndex = 1;
            button_eventAdd.Text = "Add";
            button_eventAdd.Click += button_eventAdd_Click;
            // 
            // label_eventRoom
            // 
            label_eventRoom.AutoSize = true;
            label_eventRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_eventRoom.Location = new System.Drawing.Point(294, 202);
            label_eventRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventRoom.Name = "label_eventRoom";
            label_eventRoom.Size = new System.Drawing.Size(35, 13);
            label_eventRoom.TabIndex = 0;
            label_eventRoom.Text = "Room";
            // 
            // button_eventRemove
            // 
            button_eventRemove.Enabled = false;
            button_eventRemove.Location = new System.Drawing.Point(7, 252);
            button_eventRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_eventRemove.Name = "button_eventRemove";
            button_eventRemove.Size = new System.Drawing.Size(88, 27);
            button_eventRemove.TabIndex = 2;
            button_eventRemove.Text = "Remove";
            button_eventRemove.Click += button_eventRemove_Click;
            // 
            // label_eventArea
            // 
            label_eventArea.AutoSize = true;
            label_eventArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_eventArea.Location = new System.Drawing.Point(183, 202);
            label_eventArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventArea.Name = "label_eventArea";
            label_eventArea.Size = new System.Drawing.Size(29, 13);
            label_eventArea.TabIndex = 0;
            label_eventArea.Text = "Area";
            // 
            // label_eventSource
            // 
            label_eventSource.AutoSize = true;
            label_eventSource.Location = new System.Drawing.Point(106, 224);
            label_eventSource.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventSource.Name = "label_eventSource";
            label_eventSource.Size = new System.Drawing.Size(46, 15);
            label_eventSource.TabIndex = 0;
            label_eventSource.Text = "Source:";
            // 
            // button_eventClose
            // 
            button_eventClose.Location = new System.Drawing.Point(411, 252);
            button_eventClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_eventClose.Name = "button_eventClose";
            button_eventClose.Size = new System.Drawing.Size(88, 27);
            button_eventClose.TabIndex = 8;
            button_eventClose.Text = "Close";
            button_eventClose.UseVisualStyleBackColor = true;
            button_eventClose.Click += button_close_Click;
            // 
            // label_eventDestination
            // 
            label_eventDestination.AutoSize = true;
            label_eventDestination.Location = new System.Drawing.Point(106, 255);
            label_eventDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventDestination.Name = "label_eventDestination";
            label_eventDestination.Size = new System.Drawing.Size(70, 15);
            label_eventDestination.TabIndex = 0;
            label_eventDestination.Text = "Destination:";
            // 
            // button_eventApply
            // 
            button_eventApply.Enabled = false;
            button_eventApply.Location = new System.Drawing.Point(411, 218);
            button_eventApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_eventApply.Name = "button_eventApply";
            button_eventApply.Size = new System.Drawing.Size(88, 27);
            button_eventApply.TabIndex = 7;
            button_eventApply.Text = "Apply";
            button_eventApply.UseVisualStyleBackColor = true;
            button_eventApply.Click += button_eventApply_Click;
            // 
            // comboBox_eventSrcArea
            // 
            comboBox_eventSrcArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_eventSrcArea.FormattingEnabled = true;
            comboBox_eventSrcArea.Location = new System.Drawing.Point(187, 220);
            comboBox_eventSrcArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_eventSrcArea.Name = "comboBox_eventSrcArea";
            comboBox_eventSrcArea.Size = new System.Drawing.Size(93, 23);
            comboBox_eventSrcArea.TabIndex = 3;
            comboBox_eventSrcArea.SelectedIndexChanged += control_eventInfo_Changed;
            // 
            // label_eventSrcRoom
            // 
            label_eventSrcRoom.AutoSize = true;
            label_eventSrcRoom.Location = new System.Drawing.Point(294, 224);
            label_eventSrcRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventSrcRoom.Name = "label_eventSrcRoom";
            label_eventSrcRoom.Size = new System.Drawing.Size(13, 15);
            label_eventSrcRoom.TabIndex = 0;
            label_eventSrcRoom.Text = "–";
            // 
            // textBox_eventSrcDoor
            // 
            textBox_eventSrcDoor.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_eventSrcDoor.DisplayBorder = true;
            textBox_eventSrcDoor.HexSanitized = false;
            textBox_eventSrcDoor.HexSanitizedMaxValue = -1;
            textBox_eventSrcDoor.Location = new System.Drawing.Point(342, 220);
            textBox_eventSrcDoor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_eventSrcDoor.MaxLength = 32767;
            textBox_eventSrcDoor.Multiline = false;
            textBox_eventSrcDoor.Name = "textBox_eventSrcDoor";
            textBox_eventSrcDoor.OnTextChanged = null;
            textBox_eventSrcDoor.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_eventSrcDoor.PlaceholderText = "";
            textBox_eventSrcDoor.ReadOnly = false;
            textBox_eventSrcDoor.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_eventSrcDoor.SelectionStart = 0;
            textBox_eventSrcDoor.Size = new System.Drawing.Size(35, 23);
            textBox_eventSrcDoor.TabIndex = 4;
            textBox_eventSrcDoor.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_eventSrcDoor.ValueBox = false;
            textBox_eventSrcDoor.WordWrap = true;
            textBox_eventSrcDoor.TextChanged += control_eventInfo_Changed;
            // 
            // label_eventDstRoom
            // 
            label_eventDstRoom.AutoSize = true;
            label_eventDstRoom.Location = new System.Drawing.Point(294, 255);
            label_eventDstRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_eventDstRoom.Name = "label_eventDstRoom";
            label_eventDstRoom.Size = new System.Drawing.Size(13, 15);
            label_eventDstRoom.TabIndex = 0;
            label_eventDstRoom.Text = "–";
            // 
            // tabPage_locNames
            // 
            tabPage_locNames.Controls.Add(comboBox_locLanguage);
            tabPage_locNames.Controls.Add(label1);
            tabPage_locNames.Controls.Add(textBox_locDstRoom);
            tabPage_locNames.Controls.Add(listView_locNames);
            tabPage_locNames.Controls.Add(button_locAdd);
            tabPage_locNames.Controls.Add(label_locRoom);
            tabPage_locNames.Controls.Add(button_locRemove);
            tabPage_locNames.Controls.Add(label_locArea);
            tabPage_locNames.Controls.Add(label_locDestination);
            tabPage_locNames.Controls.Add(button_locClose);
            tabPage_locNames.Controls.Add(label_locText);
            tabPage_locNames.Controls.Add(button_locApply);
            tabPage_locNames.Controls.Add(comboBox_locDstArea);
            tabPage_locNames.Controls.Add(textBox_locText);
            tabPage_locNames.Controls.Add(label_locName);
            tabPage_locNames.Location = new System.Drawing.Point(4, 25);
            tabPage_locNames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_locNames.Name = "tabPage_locNames";
            tabPage_locNames.Size = new System.Drawing.Size(644, 314);
            tabPage_locNames.TabIndex = 2;
            tabPage_locNames.Text = "Location Names";
            // 
            // comboBox_locLanguage
            // 
            comboBox_locLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_locLanguage.FormattingEnabled = true;
            comboBox_locLanguage.Location = new System.Drawing.Point(187, 283);
            comboBox_locLanguage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_locLanguage.Name = "comboBox_locLanguage";
            comboBox_locLanguage.Size = new System.Drawing.Size(93, 23);
            comboBox_locLanguage.TabIndex = 26;
            comboBox_locLanguage.SelectedIndexChanged += comboBox_locLanguage_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(106, 286);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(62, 15);
            label1.TabIndex = 25;
            label1.Text = "Language:";
            // 
            // textBox_locDstRoom
            // 
            textBox_locDstRoom.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_locDstRoom.DisplayBorder = true;
            textBox_locDstRoom.HexSanitized = false;
            textBox_locDstRoom.HexSanitizedMaxValue = -1;
            textBox_locDstRoom.Location = new System.Drawing.Point(294, 220);
            textBox_locDstRoom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_locDstRoom.MaxLength = 32767;
            textBox_locDstRoom.Multiline = false;
            textBox_locDstRoom.Name = "textBox_locDstRoom";
            textBox_locDstRoom.OnTextChanged = null;
            textBox_locDstRoom.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_locDstRoom.PlaceholderText = "";
            textBox_locDstRoom.ReadOnly = false;
            textBox_locDstRoom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_locDstRoom.SelectionStart = 0;
            textBox_locDstRoom.Size = new System.Drawing.Size(35, 23);
            textBox_locDstRoom.TabIndex = 24;
            textBox_locDstRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_locDstRoom.ValueBox = false;
            textBox_locDstRoom.WordWrap = true;
            textBox_locDstRoom.TextChanged += control_locInfo_Changed;
            // 
            // listView_locNames
            // 
            listView_locNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            listView_locNames.FullRowSelect = true;
            listView_locNames.GridLines = true;
            listView_locNames.Location = new System.Drawing.Point(7, 7);
            listView_locNames.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView_locNames.MultiSelect = false;
            listView_locNames.Name = "listView_locNames";
            listView_locNames.Size = new System.Drawing.Size(628, 187);
            listView_locNames.TabIndex = 8;
            listView_locNames.UseCompatibleStateImageBehavior = false;
            listView_locNames.View = System.Windows.Forms.View.Details;
            listView_locNames.SelectedIndexChanged += listView_locNames_SelectedIndexChanged;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Destination";
            columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Text #";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Name";
            columnHeader6.Width = 190;
            // 
            // button_locAdd
            // 
            button_locAdd.Enabled = false;
            button_locAdd.Location = new System.Drawing.Point(7, 218);
            button_locAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_locAdd.Name = "button_locAdd";
            button_locAdd.Size = new System.Drawing.Size(88, 27);
            button_locAdd.TabIndex = 17;
            button_locAdd.Text = "Add";
            button_locAdd.UseVisualStyleBackColor = true;
            button_locAdd.Click += button_locAdd_Click;
            // 
            // label_locRoom
            // 
            label_locRoom.AutoSize = true;
            label_locRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_locRoom.Location = new System.Drawing.Point(294, 202);
            label_locRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_locRoom.Name = "label_locRoom";
            label_locRoom.Size = new System.Drawing.Size(35, 13);
            label_locRoom.TabIndex = 10;
            label_locRoom.Text = "Room";
            // 
            // button_locRemove
            // 
            button_locRemove.Enabled = false;
            button_locRemove.Location = new System.Drawing.Point(7, 252);
            button_locRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_locRemove.Name = "button_locRemove";
            button_locRemove.Size = new System.Drawing.Size(88, 27);
            button_locRemove.TabIndex = 18;
            button_locRemove.Text = "Remove";
            button_locRemove.UseVisualStyleBackColor = true;
            button_locRemove.Click += button_locRemove_Click;
            // 
            // label_locArea
            // 
            label_locArea.AutoSize = true;
            label_locArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, 0);
            label_locArea.Location = new System.Drawing.Point(183, 202);
            label_locArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_locArea.Name = "label_locArea";
            label_locArea.Size = new System.Drawing.Size(29, 13);
            label_locArea.TabIndex = 11;
            label_locArea.Text = "Area";
            // 
            // label_locDestination
            // 
            label_locDestination.AutoSize = true;
            label_locDestination.Location = new System.Drawing.Point(106, 224);
            label_locDestination.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_locDestination.Name = "label_locDestination";
            label_locDestination.Size = new System.Drawing.Size(70, 15);
            label_locDestination.TabIndex = 12;
            label_locDestination.Text = "Destination:";
            // 
            // button_locClose
            // 
            button_locClose.Location = new System.Drawing.Point(411, 252);
            button_locClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_locClose.Name = "button_locClose";
            button_locClose.Size = new System.Drawing.Size(88, 27);
            button_locClose.TabIndex = 23;
            button_locClose.Text = "Close";
            button_locClose.UseVisualStyleBackColor = true;
            button_locClose.Click += button_close_Click;
            // 
            // label_locText
            // 
            label_locText.AutoSize = true;
            label_locText.Location = new System.Drawing.Point(106, 255);
            label_locText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_locText.Name = "label_locText";
            label_locText.Size = new System.Drawing.Size(31, 15);
            label_locText.TabIndex = 13;
            label_locText.Text = "Text:";
            // 
            // button_locApply
            // 
            button_locApply.Enabled = false;
            button_locApply.Location = new System.Drawing.Point(411, 218);
            button_locApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_locApply.Name = "button_locApply";
            button_locApply.Size = new System.Drawing.Size(88, 27);
            button_locApply.TabIndex = 22;
            button_locApply.Text = "Apply";
            button_locApply.UseVisualStyleBackColor = true;
            button_locApply.Click += button_locApply_Click;
            // 
            // comboBox_locDstArea
            // 
            comboBox_locDstArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_locDstArea.FormattingEnabled = true;
            comboBox_locDstArea.Location = new System.Drawing.Point(187, 220);
            comboBox_locDstArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_locDstArea.Name = "comboBox_locDstArea";
            comboBox_locDstArea.Size = new System.Drawing.Size(93, 23);
            comboBox_locDstArea.TabIndex = 19;
            comboBox_locDstArea.SelectedIndexChanged += control_locInfo_Changed;
            // 
            // textBox_locText
            // 
            textBox_locText.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_locText.DisplayBorder = true;
            textBox_locText.HexSanitized = false;
            textBox_locText.HexSanitizedMaxValue = -1;
            textBox_locText.Location = new System.Drawing.Point(187, 252);
            textBox_locText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_locText.MaxLength = 32767;
            textBox_locText.Multiline = false;
            textBox_locText.Name = "textBox_locText";
            textBox_locText.OnTextChanged = null;
            textBox_locText.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_locText.PlaceholderText = "";
            textBox_locText.ReadOnly = false;
            textBox_locText.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_locText.SelectionStart = 0;
            textBox_locText.Size = new System.Drawing.Size(35, 23);
            textBox_locText.TabIndex = 20;
            textBox_locText.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_locText.ValueBox = false;
            textBox_locText.WordWrap = true;
            textBox_locText.TextChanged += control_locInfo_Changed;
            // 
            // label_locName
            // 
            label_locName.AutoSize = true;
            label_locName.Location = new System.Drawing.Point(229, 255);
            label_locName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_locName.Name = "label_locName";
            label_locName.Size = new System.Drawing.Size(13, 15);
            label_locName.TabIndex = 16;
            label_locName.Text = "–";
            // 
            // tabPage_hatchLock
            // 
            tabPage_hatchLock.BackColor = System.Drawing.SystemColors.Control;
            tabPage_hatchLock.Controls.Add(radioButton_lockAfter);
            tabPage_hatchLock.Controls.Add(radioButton_lockBefore);
            tabPage_hatchLock.Controls.Add(listBox_lockHatches);
            tabPage_hatchLock.Controls.Add(textBox_lockEvent);
            tabPage_hatchLock.Controls.Add(label_lockEvent);
            tabPage_hatchLock.Controls.Add(textBox_lockRoom);
            tabPage_hatchLock.Controls.Add(label_lockRoom);
            tabPage_hatchLock.Controls.Add(listView_lockHatches);
            tabPage_hatchLock.Controls.Add(button_lockAdd);
            tabPage_hatchLock.Controls.Add(button_lockRemove);
            tabPage_hatchLock.Controls.Add(label_lockArea);
            tabPage_hatchLock.Controls.Add(button_lockClose);
            tabPage_hatchLock.Controls.Add(button_lockApply);
            tabPage_hatchLock.Controls.Add(comboBox_lockArea);
            tabPage_hatchLock.Location = new System.Drawing.Point(4, 25);
            tabPage_hatchLock.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_hatchLock.Name = "tabPage_hatchLock";
            tabPage_hatchLock.Size = new System.Drawing.Size(644, 314);
            tabPage_hatchLock.TabIndex = 3;
            tabPage_hatchLock.Text = "Hatch Lock Events";
            // 
            // radioButton_lockAfter
            // 
            radioButton_lockAfter.AutoSize = true;
            radioButton_lockAfter.Location = new System.Drawing.Point(200, 285);
            radioButton_lockAfter.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton_lockAfter.Name = "radioButton_lockAfter";
            radioButton_lockAfter.Size = new System.Drawing.Size(51, 19);
            radioButton_lockAfter.TabIndex = 7;
            radioButton_lockAfter.TabStop = true;
            radioButton_lockAfter.Text = "After";
            radioButton_lockAfter.UseVisualStyleBackColor = true;
            radioButton_lockAfter.CheckedChanged += control_lockInfo_Changed;
            // 
            // radioButton_lockBefore
            // 
            radioButton_lockBefore.AutoSize = true;
            radioButton_lockBefore.Location = new System.Drawing.Point(200, 263);
            radioButton_lockBefore.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            radioButton_lockBefore.Name = "radioButton_lockBefore";
            radioButton_lockBefore.Size = new System.Drawing.Size(59, 19);
            radioButton_lockBefore.TabIndex = 6;
            radioButton_lockBefore.TabStop = true;
            radioButton_lockBefore.Text = "Before";
            radioButton_lockBefore.UseVisualStyleBackColor = true;
            radioButton_lockBefore.CheckedChanged += control_lockInfo_Changed;
            // 
            // listBox_lockHatches
            // 
            listBox_lockHatches.FormattingEnabled = true;
            listBox_lockHatches.Items.AddRange(new object[] { "Hatch 0", "Hatch 1", "Hatch 2", "Hatch 3", "Hatch 4", "Hatch 5" });
            listBox_lockHatches.Location = new System.Drawing.Point(272, 209);
            listBox_lockHatches.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listBox_lockHatches.Name = "listBox_lockHatches";
            listBox_lockHatches.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            listBox_lockHatches.Size = new System.Drawing.Size(123, 94);
            listBox_lockHatches.TabIndex = 8;
            listBox_lockHatches.SelectedIndexChanged += control_lockInfo_Changed;
            // 
            // textBox_lockEvent
            // 
            textBox_lockEvent.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_lockEvent.DisplayBorder = true;
            textBox_lockEvent.HexSanitized = false;
            textBox_lockEvent.HexSanitizedMaxValue = -1;
            textBox_lockEvent.Location = new System.Drawing.Point(158, 271);
            textBox_lockEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_lockEvent.MaxLength = 32767;
            textBox_lockEvent.Multiline = false;
            textBox_lockEvent.Name = "textBox_lockEvent";
            textBox_lockEvent.OnTextChanged = null;
            textBox_lockEvent.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_lockEvent.PlaceholderText = "";
            textBox_lockEvent.ReadOnly = false;
            textBox_lockEvent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_lockEvent.SelectionStart = 0;
            textBox_lockEvent.Size = new System.Drawing.Size(35, 23);
            textBox_lockEvent.TabIndex = 5;
            textBox_lockEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_lockEvent.ValueBox = false;
            textBox_lockEvent.WordWrap = true;
            textBox_lockEvent.TextChanged += control_lockInfo_Changed;
            // 
            // label_lockEvent
            // 
            label_lockEvent.AutoSize = true;
            label_lockEvent.Location = new System.Drawing.Point(106, 275);
            label_lockEvent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_lockEvent.Name = "label_lockEvent";
            label_lockEvent.Size = new System.Drawing.Size(39, 15);
            label_lockEvent.TabIndex = 0;
            label_lockEvent.Text = "Event:";
            // 
            // textBox_lockRoom
            // 
            textBox_lockRoom.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_lockRoom.DisplayBorder = true;
            textBox_lockRoom.HexSanitized = false;
            textBox_lockRoom.HexSanitizedMaxValue = -1;
            textBox_lockRoom.Location = new System.Drawing.Point(158, 240);
            textBox_lockRoom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_lockRoom.MaxLength = 32767;
            textBox_lockRoom.Multiline = false;
            textBox_lockRoom.Name = "textBox_lockRoom";
            textBox_lockRoom.OnTextChanged = null;
            textBox_lockRoom.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_lockRoom.PlaceholderText = "";
            textBox_lockRoom.ReadOnly = false;
            textBox_lockRoom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_lockRoom.SelectionStart = 0;
            textBox_lockRoom.Size = new System.Drawing.Size(35, 23);
            textBox_lockRoom.TabIndex = 4;
            textBox_lockRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_lockRoom.ValueBox = false;
            textBox_lockRoom.WordWrap = true;
            textBox_lockRoom.TextChanged += control_lockInfo_Changed;
            // 
            // label_lockRoom
            // 
            label_lockRoom.AutoSize = true;
            label_lockRoom.Location = new System.Drawing.Point(106, 243);
            label_lockRoom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_lockRoom.Name = "label_lockRoom";
            label_lockRoom.Size = new System.Drawing.Size(42, 15);
            label_lockRoom.TabIndex = 0;
            label_lockRoom.Text = "Room:";
            // 
            // listView_lockHatches
            // 
            listView_lockHatches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_lockDst, columnHeader_lockEvent, columnHeader_lockWhen, columnHeader_lockHatches });
            listView_lockHatches.FullRowSelect = true;
            listView_lockHatches.GridLines = true;
            listView_lockHatches.Location = new System.Drawing.Point(7, 7);
            listView_lockHatches.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            listView_lockHatches.MultiSelect = false;
            listView_lockHatches.Name = "listView_lockHatches";
            listView_lockHatches.Size = new System.Drawing.Size(628, 187);
            listView_lockHatches.TabIndex = 0;
            listView_lockHatches.UseCompatibleStateImageBehavior = false;
            listView_lockHatches.View = System.Windows.Forms.View.Details;
            listView_lockHatches.SelectedIndexChanged += listView_lockHatches_SelectedIndexChanged;
            // 
            // columnHeader_lockDst
            // 
            columnHeader_lockDst.Text = "Destination";
            columnHeader_lockDst.Width = 180;
            // 
            // columnHeader_lockEvent
            // 
            columnHeader_lockEvent.Text = "Event";
            columnHeader_lockEvent.Width = 50;
            // 
            // columnHeader_lockWhen
            // 
            columnHeader_lockWhen.Text = "When";
            // 
            // columnHeader_lockHatches
            // 
            columnHeader_lockHatches.Text = "Hatches";
            columnHeader_lockHatches.Width = 130;
            // 
            // button_lockAdd
            // 
            button_lockAdd.Enabled = false;
            button_lockAdd.Location = new System.Drawing.Point(7, 218);
            button_lockAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_lockAdd.Name = "button_lockAdd";
            button_lockAdd.Size = new System.Drawing.Size(88, 27);
            button_lockAdd.TabIndex = 1;
            button_lockAdd.Text = "Add";
            button_lockAdd.Click += button_lockAdd_Click;
            // 
            // button_lockRemove
            // 
            button_lockRemove.Enabled = false;
            button_lockRemove.Location = new System.Drawing.Point(7, 252);
            button_lockRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_lockRemove.Name = "button_lockRemove";
            button_lockRemove.Size = new System.Drawing.Size(88, 27);
            button_lockRemove.TabIndex = 2;
            button_lockRemove.Text = "Remove";
            button_lockRemove.Click += button_lockRemove_Click;
            // 
            // label_lockArea
            // 
            label_lockArea.AutoSize = true;
            label_lockArea.Location = new System.Drawing.Point(106, 212);
            label_lockArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_lockArea.Name = "label_lockArea";
            label_lockArea.Size = new System.Drawing.Size(34, 15);
            label_lockArea.TabIndex = 0;
            label_lockArea.Text = "Area:";
            // 
            // button_lockClose
            // 
            button_lockClose.Location = new System.Drawing.Point(411, 252);
            button_lockClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_lockClose.Name = "button_lockClose";
            button_lockClose.Size = new System.Drawing.Size(88, 27);
            button_lockClose.TabIndex = 10;
            button_lockClose.Text = "Close";
            button_lockClose.UseVisualStyleBackColor = true;
            button_lockClose.Click += button_close_Click;
            // 
            // button_lockApply
            // 
            button_lockApply.Enabled = false;
            button_lockApply.Location = new System.Drawing.Point(411, 218);
            button_lockApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_lockApply.Name = "button_lockApply";
            button_lockApply.Size = new System.Drawing.Size(88, 27);
            button_lockApply.TabIndex = 9;
            button_lockApply.Text = "Apply";
            button_lockApply.UseVisualStyleBackColor = true;
            button_lockApply.Click += button_lockApply_Click;
            // 
            // comboBox_lockArea
            // 
            comboBox_lockArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_lockArea.FormattingEnabled = true;
            comboBox_lockArea.Location = new System.Drawing.Point(158, 209);
            comboBox_lockArea.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_lockArea.Name = "comboBox_lockArea";
            comboBox_lockArea.Size = new System.Drawing.Size(93, 23);
            comboBox_lockArea.TabIndex = 3;
            comboBox_lockArea.SelectedIndexChanged += control_lockInfo_Changed;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes });
            statusStrip.Location = new System.Drawing.Point(0, 363);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(673, 22);
            statusStrip.TabIndex = 1;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // FormConnection
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.SystemColors.Control;
            ClientSize = new System.Drawing.Size(673, 385);
            Controls.Add(statusStrip);
            Controls.Add(tabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormConnection";
            Text = "Connection Editor";
            tabControl.ResumeLayout(false);
            tabPage_area.ResumeLayout(false);
            tabPage_area.PerformLayout();
            tabPage_event.ResumeLayout(false);
            tabPage_event.PerformLayout();
            tabPage_locNames.ResumeLayout(false);
            tabPage_locNames.PerformLayout();
            tabPage_hatchLock.ResumeLayout(false);
            tabPage_hatchLock.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView_areaConnections;
        private System.Windows.Forms.ColumnHeader columnHeader_src;
        private System.Windows.Forms.ColumnHeader columnHeader_dst;
        private System.Windows.Forms.Button button_areaAdd;
        private System.Windows.Forms.Button button_areaRemove;
        private System.Windows.Forms.Label label_areaSource;
        private System.Windows.Forms.Label label_areaDestination;
        private mage.Theming.CustomControls.FlatComboBox comboBox_areaDstArea;
        private mage.Theming.CustomControls.FlatComboBox comboBox_areaSrcArea;
        private mage.Theming.CustomControls.FlatTextBox textBox_areaSrcDoor;
        private System.Windows.Forms.Label label_areaDstRoom;
        private System.Windows.Forms.Label label_areaSrcRoom;
        private System.Windows.Forms.Label label_areaDstDoor;
        private System.Windows.Forms.Button button_areaClose;
        private System.Windows.Forms.Button button_areaApply;
        private System.Windows.Forms.Label label_areaArea;
        private System.Windows.Forms.Label label_areaRoom;
        private System.Windows.Forms.Label label_areaDoor;
        private mage.Theming.CustomControls.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_area;
        private System.Windows.Forms.TabPage tabPage_event;
        private System.Windows.Forms.ListView listView_doorEvents;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label_eventDoor;
        private System.Windows.Forms.Button button_eventAdd;
        private System.Windows.Forms.Label label_eventRoom;
        private System.Windows.Forms.Button button_eventRemove;
        private System.Windows.Forms.Label label_eventArea;
        private System.Windows.Forms.Label label_eventSource;
        private System.Windows.Forms.Button button_eventClose;
        private System.Windows.Forms.Label label_eventDestination;
        private System.Windows.Forms.Button button_eventApply;
        private mage.Theming.CustomControls.FlatComboBox comboBox_eventSrcArea;
        private System.Windows.Forms.Label label_eventSrcRoom;
        private mage.Theming.CustomControls.FlatTextBox textBox_eventSrcDoor;
        private System.Windows.Forms.Label label_eventDstRoom;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private mage.Theming.CustomControls.FlatTextBox textBox_event;
        private System.Windows.Forms.Label label_event;
        private mage.Theming.CustomControls.FlatTextBox textBox_eventDstDoor;
        private System.Windows.Forms.Label label_eventDstArea;
        private System.Windows.Forms.TabPage tabPage_locNames;
        private System.Windows.Forms.ListView listView_locNames;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Button button_locAdd;
        private System.Windows.Forms.Label label_locRoom;
        private System.Windows.Forms.Button button_locRemove;
        private System.Windows.Forms.Label label_locArea;
        private System.Windows.Forms.Label label_locDestination;
        private System.Windows.Forms.Button button_locClose;
        private System.Windows.Forms.Label label_locText;
        private System.Windows.Forms.Button button_locApply;
        private mage.Theming.CustomControls.FlatComboBox comboBox_locDstArea;
        private mage.Theming.CustomControls.FlatTextBox textBox_locText;
        private System.Windows.Forms.Label label_locName;
        private mage.Theming.CustomControls.FlatTextBox textBox_locDstRoom;
        private mage.Theming.CustomControls.FlatComboBox comboBox_locLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.TabPage tabPage_hatchLock;
        private mage.Theming.CustomControls.FlatTextBox textBox_lockRoom;
        private System.Windows.Forms.Label label_lockRoom;
        private System.Windows.Forms.ListView listView_lockHatches;
        private System.Windows.Forms.ColumnHeader columnHeader_lockDst;
        private System.Windows.Forms.ColumnHeader columnHeader_lockEvent;
        private System.Windows.Forms.ColumnHeader columnHeader_lockWhen;
        private System.Windows.Forms.Button button_lockAdd;
        private System.Windows.Forms.Button button_lockRemove;
        private System.Windows.Forms.Label label_lockArea;
        private System.Windows.Forms.Button button_lockClose;
        private System.Windows.Forms.Button button_lockApply;
        private mage.Theming.CustomControls.FlatComboBox comboBox_lockArea;
        private System.Windows.Forms.ListBox listBox_lockHatches;
        private mage.Theming.CustomControls.FlatTextBox textBox_lockEvent;
        private System.Windows.Forms.Label label_lockEvent;
        private System.Windows.Forms.RadioButton radioButton_lockAfter;
        private System.Windows.Forms.RadioButton radioButton_lockBefore;
        private System.Windows.Forms.ColumnHeader columnHeader_lockHatches;
    }
}