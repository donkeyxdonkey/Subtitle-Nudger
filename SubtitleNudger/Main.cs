namespace SubtitleNudger;

public partial class Main : Form
{
    const string SAVE_ACTIVE = "SAVE *";

    #region ----- FIELDS
    private SubtitleContainer _container;
    private readonly RecentFiles _recentFiles;

    private bool _formLoaded;
    #endregion

    #region ----- CONSTRUCTOR
    public Main()
    {
        InitializeComponent();
        _container = new SubtitleContainer();
        _recentFiles = new RecentFiles();
    }
    #endregion

    #region ----- METHODS
    private void InitContainer(string path)
    {
    CoWabBuNgA:
        try
        {
            _container = new(path, DisplayAllLines);
        }
        catch (FileNotFoundException)
        {
            _recentFiles.DeleteBadPath(path);
            UpdateRecentFiles();
            path = _recentFiles.Recent0;
            if (string.IsNullOrEmpty(path))
                return;

            goto CoWabBuNgA;
        }
        DisplayAllLines();
        UpdateRecentFiles();
    }

    private void DisplayAllLines()
    {
        if (LB_Content.Items.Count > 0) LB_Content.Items.Clear();

        foreach (SubtitleLine line in _container.Items)
        {
            LB_Content.Items.Add(line.DisplayString);
        }

        if (LB_Content.Items.Count > 0 && LB_Content.SelectedIndex < 0)
            LB_Content.SetSelected(0, true);
    }

    private void UpdateRecentFiles()
    {
        if (string.IsNullOrEmpty(_recentFiles.Recent0))
            return;

        TB_LoadedFile.Text = _recentFiles.Recent0;
        TSM_Recent0.Text = _recentFiles.Recent0;
        TSM_Recent0.Enabled = true;

        if (string.IsNullOrEmpty(_recentFiles.Recent1))
            return;

        TSM_Recent1.Text = _recentFiles.Recent1;
        TSM_Recent1.Enabled = true;

        if (string.IsNullOrEmpty(_recentFiles.Recent2))
            return;

        TSM_Recent2.Text = _recentFiles.Recent2;
        TSM_Recent2.Enabled = true;

        if (string.IsNullOrEmpty(_recentFiles.Recent3))
            return;

        TSM_Recent3.Text = _recentFiles.Recent3;
        TSM_Recent3.Enabled = true;

        if (string.IsNullOrEmpty(_recentFiles.Recent4))
            return;

        TSM_Recent4.Text = _recentFiles.Recent4;
        TSM_Recent4.Enabled = true;
    }

    private static int ConvertToMetric(int value, TimeMetric metric)
    {
        switch (metric)
        {
            case TimeMetric.Milliseconds:
                return value;
            case TimeMetric.Seconds:
                return value * 1000;
            case TimeMetric.Minutes:
                return value * 1000 * 60;
            case TimeMetric.Hours:
                return value * 1000 * 60 * 60;
        }

        throw new ArgumentException("unreachable");
    }
    #endregion

    #region ----- EVENTS
    private void Main_Load(object sender, EventArgs e)
    {
        LoadStoredRegex();
        _formLoaded = true;

        if (string.IsNullOrEmpty(_recentFiles.Recent0)) return;

        TB_LoadedFile.Text = _recentFiles.Recent0;

        foreach (TimeMetric metric in Enum.GetValues(typeof(TimeMetric)))
        {
            CB_TimeMetric.Items.Add(metric.ToString());
        }

        CB_TimeMetric.SelectedIndex = 0;

        InitContainer(_recentFiles.Recent0);
    }

    private void LoadStoredRegex()
    {
        if (!string.IsNullOrEmpty(Properties.Settings.Default.Regex0))
        {
            TSM_Regex0.Text = Properties.Settings.Default.Regex0;
        }

        if (!string.IsNullOrEmpty(Properties.Settings.Default.Regex1))
        {
            TSM_Regex1.Text = Properties.Settings.Default.Regex1;
        }

        if (!string.IsNullOrEmpty(Properties.Settings.Default.Regex2))
        {
            TSM_Regex2.Text = Properties.Settings.Default.Regex2;
        }

        if (!string.IsNullOrEmpty(Properties.Settings.Default.Regex3))
        {
            TSM_Regex3.Text = Properties.Settings.Default.Regex3;
        }

        if (!string.IsNullOrEmpty(Properties.Settings.Default.Regex4))
        {
            TSM_Regex4.Text = Properties.Settings.Default.Regex4;
        }
    }

    private void MTB_Time_TextChanged(object sender, EventArgs e)
    {
        BTN_Execute.Enabled = int.TryParse(MTB_Time.Text, out int _);
    }

    private void BTN_Execute_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(MTB_Time.Text) == 0) return;

        TimeMetric metric = (TimeMetric)CB_TimeMetric.SelectedIndex;

        int value = ConvertToMetric(Convert.ToInt32(MTB_Time.Text), metric);

        switch (RB_Add.Checked)
        {
            case true:
                _container.AddTime(value);
                break;
            case false:
                try
                {
                    _container.SubtractTime(value);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    MTB_Time.Text = string.Empty;
                }
                break;
        }

        BTN_Save.Text = SAVE_ACTIVE;
    }

    private void BTN_Load_Click(object sender, EventArgs e)
    {
        string REVERT_DEFAULT = @"C:\";

        if (!Directory.Exists(Properties.Settings.Default.LastDirectory))
        {
            Properties.Settings.Default.LastDirectory = REVERT_DEFAULT;
            Properties.Settings.Default.Save();
        }

        OpenFileDialog openFileDialog = new()
        {
            Filter = "Subtitle Files (*.srt)|*.srt",
            InitialDirectory = Properties.Settings.Default.LastDirectory,
            Title = "Select Subtitle File"
        };

        DialogResult result = openFileDialog.ShowDialog();

        if (result != DialogResult.OK)
            return;

        _recentFiles.Add(openFileDialog.FileName);
        Properties.Settings.Default.LastDirectory = new FileInfo(_recentFiles.Recent0).DirectoryName;
        Properties.Settings.Default.Save();
        InitContainer(_recentFiles.Recent0);
        BTN_Save.Text = "SAVE";
    }

    private void LB_Content_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LB_Content.SelectedIndex < 0) return;

        SubtitleLine item = _container.Items[LB_Content.SelectedIndex];

        LBL_Index.Text = item.Index.ToString();

        LBL_TimeStart.Text = item.TimeStart;
        LBL_TimeEnd.Text = item.TimeEnd;

        TB_SubtitleLine.Text = item.Text;
    }

    private void BTN_Save_Click(object sender, EventArgs e)
    {
        if (BTN_Save.Text == "SAVE") return;

        File.WriteAllLines(_recentFiles.Recent0, _container.SerializeContent());

        BTN_Save.Text = "SAVE";
    }

    private void BTN_Delete_Click(object sender, EventArgs e)
    {
        int index = LB_Content.SelectedIndex;

        if (LB_Content.SelectedIndex < 0) return;

        _container.Delete(index);

        if (index >= _container.Count)
            index--;

        LB_Content.SelectedIndex = index;

        BTN_Save.Text = SAVE_ACTIVE;
    }

    private void TB_ReplaceAll_TextChanged(object sender, EventArgs e)
    {
        BTN_ReplaceAll.Enabled = TB_ReplaceAll.TextLength > 0;
    }

    private void BTN_ReplaceAll_Click(object sender, EventArgs e)
    {
        _container.ReplaceAll(TB_ReplaceAll.Text, TB_ReplaceWith.Text, CB_ReplaceAll.Checked);
        BTN_Save.Text = SAVE_ACTIVE;
    }

    private void Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (BTN_Save.Text != SAVE_ACTIVE)
            return;

        // TODO: CustomDialogue Save & Exit - Discard - Cancel
        DialogResult result = MessageBox.Show("Changes to file has been made, confirm application close.",
                                              "Confirm Exit",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question);

        if (result == DialogResult.No)
            e.Cancel = true;
    }
    #endregion

    #region ----- MENU EVENTS
    private void TSM_Exit_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void TSM_Recent_Click(object sender, EventArgs e)
    {
        int index = (sender as ToolStripMenuItem)!.Name![^1] - '0';
        _recentFiles.Load(index);
        InitContainer(_recentFiles.Recent0);
    }
    #endregion


    private void TSM_UseRegex_Click(object sender, EventArgs e)
    {
        int index = (sender as ToolStripMenuItem)!.Name![^1] - '0';
        TB_ReplaceAll.Text = index switch
        {
            0 => Properties.Settings.Default.Regex0,
            1 => Properties.Settings.Default.Regex1,
            2 => Properties.Settings.Default.Regex2,
            3 => Properties.Settings.Default.Regex3,
            _ => Properties.Settings.Default.Regex4,
        };
    }

    private void CB_ReplaceAll_MouseEnter(object sender, EventArgs e)
    {
        CB_ReplaceAll.ForeColor = Color.PaleVioletRed;
    }

    private void CB_ReplaceAll_MouseLeave(object sender, EventArgs e)
    {
        CB_ReplaceAll.ForeColor = Color.DarkGray;
    }

    private void CB_ReplaceAll_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right) return;

        EnableCMSButton();
        CMS_Regex.Show(Cursor.Position);
    }

    private void EnableCMSButton()
    {
        TSM_UseRegex0.Visible = !string.IsNullOrEmpty(Properties.Settings.Default.Regex0);
        TSM_UseRegex1.Visible = !string.IsNullOrEmpty(Properties.Settings.Default.Regex1);
        TSM_UseRegex2.Visible = !string.IsNullOrEmpty(Properties.Settings.Default.Regex2);
        TSM_UseRegex3.Visible = !string.IsNullOrEmpty(Properties.Settings.Default.Regex3);
        TSM_UseRegex4.Visible = !string.IsNullOrEmpty(Properties.Settings.Default.Regex4);
    }

    private void TSM_Regex_TextChanged(object sender, EventArgs e)
    {
        if (!_formLoaded) return;

        int index = (sender as ToolStripMenuItem)!.Name![^1] - '0';

        switch (index)
        {
            case 0:
                if (TSM_Regex0.Text == Properties.Settings.Default.Regex0) return;
                Properties.Settings.Default.Regex0 = TSM_Regex0.Text;
                break;
            case 1:
                if (TSM_Regex1.Text == Properties.Settings.Default.Regex1) return;
                Properties.Settings.Default.Regex1 = TSM_Regex1.Text;
                break;
            case 2:
                if (TSM_Regex2.Text == Properties.Settings.Default.Regex2) return;
                Properties.Settings.Default.Regex2 = TSM_Regex2.Text;
                break;
            case 3:
                if (TSM_Regex3.Text == Properties.Settings.Default.Regex3) return;
                Properties.Settings.Default.Regex3 = TSM_Regex3.Text;
                break;
            case 4:
                if (TSM_Regex4.Text == Properties.Settings.Default.Regex4) return;
                Properties.Settings.Default.Regex4 = TSM_Regex4.Text;
                break;
        }

        Properties.Settings.Default.Save();
    }
}
