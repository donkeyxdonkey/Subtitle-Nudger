namespace SubtitleNudger;

partial class Main
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        TSM_Recent0 = new ToolStripMenuItem();
        TSM_Recent1 = new ToolStripMenuItem();
        TSM_Recent2 = new ToolStripMenuItem();
        TSM_Recent3 = new ToolStripMenuItem();
        TSM_Recent4 = new ToolStripMenuItem();
        TSM_Exit = new ToolStripMenuItem();
        LB_Content = new ListBox();
        panel1 = new Panel();
        LBL_Index = new Label();
        TB_SubtitleLine = new TextBox();
        label2 = new Label();
        LBL_TimeEnd = new Label();
        LBL_TimeStart = new Label();
        panel2 = new Panel();
        label4 = new Label();
        TB_ReplaceWith = new TextBox();
        CB_ReplaceAll = new CheckBox();
        label3 = new Label();
        TB_ReplaceAll = new TextBox();
        BTN_ReplaceAll = new Button();
        BTN_Execute = new Button();
        BTN_Load = new Button();
        TB_LoadedFile = new TextBox();
        label1 = new Label();
        MTB_Time = new MaskedTextBox();
        RB_Substract = new RadioButton();
        RB_Add = new RadioButton();
        BTN_Delete = new Button();
        backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
        BTN_Save = new Button();
        menuStrip1.SuspendLayout();
        panel1.SuspendLayout();
        panel2.SuspendLayout();
        SuspendLayout();
        // 
        // menuStrip1
        // 
        menuStrip1.BackColor = Color.FromArgb(44, 33, 44);
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(655, 24);
        menuStrip1.TabIndex = 0;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { TSM_Recent0, TSM_Recent1, TSM_Recent2, TSM_Recent3, TSM_Recent4, TSM_Exit });
        fileToolStripMenuItem.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        fileToolStripMenuItem.ForeColor = Color.FromArgb(199, 199, 199);
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(47, 20);
        fileToolStripMenuItem.Text = "File";
        // 
        // TSM_Recent0
        // 
        TSM_Recent0.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Recent0.Enabled = false;
        TSM_Recent0.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Recent0.Name = "TSM_Recent0";
        TSM_Recent0.ShortcutKeys = Keys.Control | Keys.D1;
        TSM_Recent0.Size = new Size(158, 22);
        TSM_Recent0.Text = ".....";
        TSM_Recent0.Click += TSM_Recent_Click;
        // 
        // TSM_Recent1
        // 
        TSM_Recent1.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Recent1.Enabled = false;
        TSM_Recent1.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Recent1.Name = "TSM_Recent1";
        TSM_Recent1.ShortcutKeys = Keys.Control | Keys.D2;
        TSM_Recent1.Size = new Size(158, 22);
        TSM_Recent1.Text = ".....";
        TSM_Recent1.Click += TSM_Recent_Click;
        // 
        // TSM_Recent2
        // 
        TSM_Recent2.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Recent2.Enabled = false;
        TSM_Recent2.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Recent2.Name = "TSM_Recent2";
        TSM_Recent2.ShortcutKeys = Keys.Control | Keys.D3;
        TSM_Recent2.Size = new Size(158, 22);
        TSM_Recent2.Text = ".....";
        TSM_Recent2.Click += TSM_Recent_Click;
        // 
        // TSM_Recent3
        // 
        TSM_Recent3.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Recent3.Enabled = false;
        TSM_Recent3.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Recent3.Name = "TSM_Recent3";
        TSM_Recent3.ShortcutKeys = Keys.Control | Keys.D4;
        TSM_Recent3.Size = new Size(158, 22);
        TSM_Recent3.Text = ".....";
        TSM_Recent3.Click += TSM_Recent_Click;
        // 
        // TSM_Recent4
        // 
        TSM_Recent4.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Recent4.Enabled = false;
        TSM_Recent4.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Recent4.Name = "TSM_Recent4";
        TSM_Recent4.ShortcutKeys = Keys.Control | Keys.D5;
        TSM_Recent4.Size = new Size(158, 22);
        TSM_Recent4.Text = ".....";
        TSM_Recent4.Click += TSM_Recent_Click;
        // 
        // TSM_Exit
        // 
        TSM_Exit.BackColor = Color.FromArgb(44, 33, 44);
        TSM_Exit.ForeColor = Color.FromArgb(199, 199, 199);
        TSM_Exit.Name = "TSM_Exit";
        TSM_Exit.ShortcutKeys = Keys.Control | Keys.E;
        TSM_Exit.Size = new Size(158, 22);
        TSM_Exit.Text = "Exit";
        TSM_Exit.Click += TSM_Exit_Click;
        // 
        // LB_Content
        // 
        LB_Content.FormattingEnabled = true;
        LB_Content.ItemHeight = 14;
        LB_Content.Location = new Point(352, 39);
        LB_Content.Name = "LB_Content";
        LB_Content.Size = new Size(288, 200);
        LB_Content.TabIndex = 1;
        LB_Content.SelectedIndexChanged += LB_Content_SelectedIndexChanged;
        // 
        // panel1
        // 
        panel1.BackColor = Color.FromArgb(44, 33, 44);
        panel1.Controls.Add(LBL_Index);
        panel1.Controls.Add(TB_SubtitleLine);
        panel1.Controls.Add(label2);
        panel1.Controls.Add(LBL_TimeEnd);
        panel1.Controls.Add(LBL_TimeStart);
        panel1.Location = new Point(12, 39);
        panel1.Name = "panel1";
        panel1.Size = new Size(317, 220);
        panel1.TabIndex = 2;
        // 
        // LBL_Index
        // 
        LBL_Index.BackColor = Color.Bisque;
        LBL_Index.ForeColor = Color.Black;
        LBL_Index.Location = new Point(21, 8);
        LBL_Index.Name = "LBL_Index";
        LBL_Index.Size = new Size(34, 17);
        LBL_Index.TabIndex = 6;
        LBL_Index.Text = "000";
        LBL_Index.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // TB_SubtitleLine
        // 
        TB_SubtitleLine.BackColor = Color.Bisque;
        TB_SubtitleLine.Location = new Point(21, 51);
        TB_SubtitleLine.Multiline = true;
        TB_SubtitleLine.Name = "TB_SubtitleLine";
        TB_SubtitleLine.ReadOnly = true;
        TB_SubtitleLine.Size = new Size(277, 155);
        TB_SubtitleLine.TabIndex = 5;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.ForeColor = Color.FromArgb(255, 255, 128);
        label2.Location = new Point(139, 32);
        label2.Name = "label2";
        label2.Size = new Size(28, 14);
        label2.TabIndex = 4;
        label2.Text = "-->";
        // 
        // LBL_TimeEnd
        // 
        LBL_TimeEnd.BackColor = Color.FromArgb(22, 11, 22);
        LBL_TimeEnd.ForeColor = Color.FromArgb(199, 199, 199);
        LBL_TimeEnd.Location = new Point(169, 31);
        LBL_TimeEnd.Name = "LBL_TimeEnd";
        LBL_TimeEnd.Size = new Size(102, 17);
        LBL_TimeEnd.TabIndex = 3;
        LBL_TimeEnd.Text = "00:00:00,000";
        LBL_TimeEnd.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // LBL_TimeStart
        // 
        LBL_TimeStart.BackColor = Color.FromArgb(22, 11, 22);
        LBL_TimeStart.ForeColor = Color.FromArgb(199, 199, 199);
        LBL_TimeStart.Location = new Point(36, 31);
        LBL_TimeStart.Name = "LBL_TimeStart";
        LBL_TimeStart.Size = new Size(102, 17);
        LBL_TimeStart.TabIndex = 2;
        LBL_TimeStart.Text = "00:00:00,000";
        LBL_TimeStart.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // panel2
        // 
        panel2.BackColor = Color.FromArgb(44, 33, 44);
        panel2.Controls.Add(label4);
        panel2.Controls.Add(TB_ReplaceWith);
        panel2.Controls.Add(CB_ReplaceAll);
        panel2.Controls.Add(label3);
        panel2.Controls.Add(TB_ReplaceAll);
        panel2.Controls.Add(BTN_ReplaceAll);
        panel2.Controls.Add(BTN_Execute);
        panel2.Controls.Add(BTN_Load);
        panel2.Controls.Add(TB_LoadedFile);
        panel2.Controls.Add(label1);
        panel2.Controls.Add(MTB_Time);
        panel2.Controls.Add(RB_Substract);
        panel2.Controls.Add(RB_Add);
        panel2.Location = new Point(12, 265);
        panel2.Name = "panel2";
        panel2.Size = new Size(628, 110);
        panel2.TabIndex = 3;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.ForeColor = Color.FromArgb(199, 199, 199);
        label4.Location = new Point(125, 85);
        label4.Name = "label4";
        label4.Size = new Size(42, 14);
        label4.TabIndex = 14;
        label4.Text = "With:";
        // 
        // TB_ReplaceWith
        // 
        TB_ReplaceWith.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_ReplaceWith.Location = new Point(171, 83);
        TB_ReplaceWith.Name = "TB_ReplaceWith";
        TB_ReplaceWith.Size = new Size(393, 20);
        TB_ReplaceWith.TabIndex = 13;
        // 
        // CB_ReplaceAll
        // 
        CB_ReplaceAll.AutoSize = true;
        CB_ReplaceAll.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        CB_ReplaceAll.ForeColor = Color.DarkGray;
        CB_ReplaceAll.Location = new Point(569, 85);
        CB_ReplaceAll.Name = "CB_ReplaceAll";
        CB_ReplaceAll.Size = new Size(56, 17);
        CB_ReplaceAll.TabIndex = 12;
        CB_ReplaceAll.Text = "Regex";
        CB_ReplaceAll.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.ForeColor = Color.FromArgb(199, 199, 199);
        label3.Location = new Point(81, 65);
        label3.Name = "label3";
        label3.Size = new Size(91, 14);
        label3.TabIndex = 11;
        label3.Text = "Replace All:";
        // 
        // TB_ReplaceAll
        // 
        TB_ReplaceAll.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_ReplaceAll.Location = new Point(171, 62);
        TB_ReplaceAll.Name = "TB_ReplaceAll";
        TB_ReplaceAll.Size = new Size(393, 20);
        TB_ReplaceAll.TabIndex = 10;
        TB_ReplaceAll.TextChanged += TB_ReplaceAll_TextChanged;
        // 
        // BTN_ReplaceAll
        // 
        BTN_ReplaceAll.Enabled = false;
        BTN_ReplaceAll.FlatStyle = FlatStyle.Flat;
        BTN_ReplaceAll.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        BTN_ReplaceAll.ForeColor = Color.FromArgb(199, 199, 199);
        BTN_ReplaceAll.Location = new Point(565, 62);
        BTN_ReplaceAll.Name = "BTN_ReplaceAll";
        BTN_ReplaceAll.Size = new Size(44, 20);
        BTN_ReplaceAll.TabIndex = 9;
        BTN_ReplaceAll.Text = "EXEC";
        BTN_ReplaceAll.UseVisualStyleBackColor = true;
        BTN_ReplaceAll.Click += BTN_ReplaceAll_Click;
        // 
        // BTN_Execute
        // 
        BTN_Execute.Enabled = false;
        BTN_Execute.FlatStyle = FlatStyle.Flat;
        BTN_Execute.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        BTN_Execute.ForeColor = Color.FromArgb(199, 199, 199);
        BTN_Execute.Location = new Point(105, 33);
        BTN_Execute.Name = "BTN_Execute";
        BTN_Execute.Size = new Size(44, 20);
        BTN_Execute.TabIndex = 8;
        BTN_Execute.Text = "EXEC";
        BTN_Execute.UseVisualStyleBackColor = true;
        BTN_Execute.Click += BTN_Execute_Click;
        // 
        // BTN_Load
        // 
        BTN_Load.FlatStyle = FlatStyle.Flat;
        BTN_Load.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        BTN_Load.ForeColor = Color.FromArgb(199, 199, 199);
        BTN_Load.Location = new Point(565, 32);
        BTN_Load.Name = "BTN_Load";
        BTN_Load.Size = new Size(44, 20);
        BTN_Load.TabIndex = 7;
        BTN_Load.Text = "LOAD";
        BTN_Load.UseVisualStyleBackColor = true;
        BTN_Load.Click += BTN_Load_Click;
        // 
        // TB_LoadedFile
        // 
        TB_LoadedFile.BackColor = Color.Bisque;
        TB_LoadedFile.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_LoadedFile.Location = new Point(171, 32);
        TB_LoadedFile.Name = "TB_LoadedFile";
        TB_LoadedFile.ReadOnly = true;
        TB_LoadedFile.Size = new Size(393, 20);
        TB_LoadedFile.TabIndex = 6;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.ForeColor = Color.FromArgb(199, 199, 199);
        label1.Location = new Point(169, 15);
        label1.Name = "label1";
        label1.Size = new Size(42, 14);
        label1.TabIndex = 5;
        label1.Text = "File:";
        // 
        // MTB_Time
        // 
        MTB_Time.Location = new Point(21, 32);
        MTB_Time.Mask = "000000";
        MTB_Time.Name = "MTB_Time";
        MTB_Time.Size = new Size(83, 22);
        MTB_Time.TabIndex = 2;
        MTB_Time.TextChanged += MTB_Time_TextChanged;
        // 
        // RB_Substract
        // 
        RB_Substract.AutoSize = true;
        RB_Substract.ForeColor = Color.FromArgb(199, 199, 199);
        RB_Substract.Location = new Point(73, 11);
        RB_Substract.Name = "RB_Substract";
        RB_Substract.Size = new Size(81, 18);
        RB_Substract.TabIndex = 1;
        RB_Substract.Text = "SUBTRACT";
        RB_Substract.UseVisualStyleBackColor = true;
        // 
        // RB_Add
        // 
        RB_Add.AutoSize = true;
        RB_Add.Checked = true;
        RB_Add.ForeColor = Color.FromArgb(199, 199, 199);
        RB_Add.Location = new Point(21, 11);
        RB_Add.Name = "RB_Add";
        RB_Add.Size = new Size(46, 18);
        RB_Add.TabIndex = 0;
        RB_Add.TabStop = true;
        RB_Add.Text = "ADD";
        RB_Add.UseVisualStyleBackColor = true;
        // 
        // BTN_Delete
        // 
        BTN_Delete.FlatStyle = FlatStyle.Flat;
        BTN_Delete.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        BTN_Delete.ForeColor = Color.FromArgb(199, 199, 199);
        BTN_Delete.Location = new Point(352, 239);
        BTN_Delete.Margin = new Padding(0);
        BTN_Delete.Name = "BTN_Delete";
        BTN_Delete.Size = new Size(213, 20);
        BTN_Delete.TabIndex = 9;
        BTN_Delete.Text = "DELETE LINE";
        BTN_Delete.UseVisualStyleBackColor = true;
        BTN_Delete.Click += BTN_Delete_Click;
        // 
        // BTN_Save
        // 
        BTN_Save.FlatStyle = FlatStyle.Flat;
        BTN_Save.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        BTN_Save.ForeColor = Color.FromArgb(199, 199, 199);
        BTN_Save.Location = new Point(565, 239);
        BTN_Save.Margin = new Padding(0);
        BTN_Save.Name = "BTN_Save";
        BTN_Save.Size = new Size(75, 20);
        BTN_Save.TabIndex = 10;
        BTN_Save.Text = "SAVE";
        BTN_Save.UseVisualStyleBackColor = true;
        BTN_Save.Click += BTN_Save_Click;
        // 
        // Main
        // 
        AutoScaleDimensions = new SizeF(7F, 14F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Black;
        ClientSize = new Size(655, 387);
        Controls.Add(BTN_Save);
        Controls.Add(BTN_Delete);
        Controls.Add(panel2);
        Controls.Add(panel1);
        Controls.Add(LB_Content);
        Controls.Add(menuStrip1);
        Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MainMenuStrip = menuStrip1;
        MaximizeBox = false;
        Name = "Main";
        Text = "Subtitle Nudger";
        Load += Main_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        panel2.ResumeLayout(false);
        panel2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem TSM_Recent0;
    private ToolStripMenuItem TSM_Recent1;
    private ToolStripMenuItem TSM_Recent2;
    private ToolStripMenuItem TSM_Recent3;
    private ToolStripMenuItem TSM_Recent4;
    private ToolStripMenuItem TSM_Exit;
    private ListBox LB_Content;
    private Panel panel1;
    private Label LBL_TimeStart;
    private Label label2;
    private Label LBL_TimeEnd;
    private TextBox TB_SubtitleLine;
    private Label LBL_Index;
    private Panel panel2;
    private Button BTN_Load;
    private TextBox TB_LoadedFile;
    private Label label1;
    private MaskedTextBox MTB_Time;
    private RadioButton RB_Substract;
    private RadioButton RB_Add;
    private Button BTN_Execute;
    private Button BTN_Delete;
    private System.ComponentModel.BackgroundWorker backgroundWorker1;
    private Button BTN_Save;
    private CheckBox CB_ReplaceAll;
    private Label label3;
    private TextBox TB_ReplaceAll;
    private Button BTN_ReplaceAll;
    private Label label4;
    private TextBox TB_ReplaceWith;
}
