namespace SubtitleNudger;

public partial class Main : Form
{
    #region ----- FIELDS
    private SubtitleContainer _container;
    private readonly RecentFiles _recentFiles;
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
    #endregion

    #region ----- EVENTS
    private void Main_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_recentFiles.Recent0)) return;

        TB_LoadedFile.Text = _recentFiles.Recent0;

        InitContainer(_recentFiles.Recent0);
    }

    private void MTB_Time_TextChanged(object sender, EventArgs e)
    {
        BTN_Execute.Enabled = int.TryParse(MTB_Time.Text, out int _);
    }

    private void BTN_Execute_Click(object sender, EventArgs e)
    {
        if (Convert.ToInt32(MTB_Time.Text) == 0) return;

        switch (RB_Add.Checked)
        {
            case true:
                _container.AddTime(Convert.ToInt32(MTB_Time.Text));
                break;
            case false:
                try
                {
                    _container.SubtractTime(Convert.ToInt32(MTB_Time.Text));
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                    MTB_Time.Text = string.Empty;
                }
                break;
        }

        BTN_Save.Text = "SAVE *";
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
}
