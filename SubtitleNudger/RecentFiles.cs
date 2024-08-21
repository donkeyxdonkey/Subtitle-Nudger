
namespace SubtitleNudger;

public class RecentFiles
{
    const int LEN = 5;

    #region ----- PROPERTIES
    public string Recent0 => _recent[0];

    public string Recent1 => _recent[1];

    public string Recent2 => _recent[2];

    public string Recent3 => _recent[3];

    public string Recent4 => _recent[4];
    #endregion

    #region ----- FIELDS
    private string[] _recent;
    #endregion

    #region ----- CONSTRUCTOR
    public RecentFiles()
    {
        _recent = new string[LEN];

        for (int i = 0; i < LEN; i++)
        {
            switch (i)
            {
                case 0:
                    _recent[i] = Properties.Settings.Default.Recent0;
                    break;
                case 1:
                    _recent[i] = Properties.Settings.Default.Recent1;
                    break;
                case 2:
                    _recent[i] = Properties.Settings.Default.Recent2;
                    break;
                case 3:
                    _recent[i] = Properties.Settings.Default.Recent3;
                    break;
                case 4:
                    _recent[i] = Properties.Settings.Default.Recent4;
                    break;
            }
        }
    }
    #endregion

    #region ----- METHODS
    public void Add(string fileName)
    {
        for (int i = 0; i < LEN; i++)
        {
            if (_recent[i] != fileName)
                continue;

            if (i == 0) return;

            DeleteShiftLeft(i);
        }

        ShiftRight();
        Properties.Settings.Default.Recent0 = _recent[0] = fileName;
        Properties.Settings.Default.Save();
    }

    private void ShiftRight()
    {
        for (int i = LEN - 2; i >= 0; i--)
        {
            _recent[i + 1] = _recent[i];
            switch (i)
            {
                case 0:
                    Properties.Settings.Default.Recent1 = _recent[i + 1];
                    break;
                case 1:
                    Properties.Settings.Default.Recent2 = _recent[i + 1];
                    break;
                case 2:
                    Properties.Settings.Default.Recent3 = _recent[i + 1];
                    break;
                case 3:
                    Properties.Settings.Default.Recent4 = _recent[i + 1];
                    break;
            }
        }
        Properties.Settings.Default.Save();
    }

    private void DeleteShiftLeft(int i)
    {
        for (int j = i; j < LEN - 1; j++)
        {
            _recent[j] = _recent[j + 1];
        }

        _recent[^1] = string.Empty;
    }

    public void Load(int index)
    {
        if (index == 0) return;

        string temp = _recent[0];

        switch (index)
        {
            case 1:
                _recent[0] = _recent[1];
                _recent[1] = temp;
                Properties.Settings.Default.Recent1 = _recent[1];
                break;
            case 2:
                _recent[0] = _recent[2];
                _recent[2] = temp;
                Properties.Settings.Default.Recent2 = _recent[2];
                break;
            case 3:
                _recent[0] = _recent[3];
                _recent[3] = temp;
                Properties.Settings.Default.Recent3 = _recent[3];
                break;
            case 4:
                _recent[0] = _recent[4];
                _recent[4] = temp;
                Properties.Settings.Default.Recent4 = _recent[4];
                break;
        }

        Properties.Settings.Default.Recent0 = _recent[0];
        Properties.Settings.Default.Save();
    }

    internal void DeleteBadPath(string path)
    {
        for (int i = 0; i < LEN; i++)
        {
            if (_recent[i] != path)
                continue;

            DeleteShiftLeft(i);
            break;
        }

        Properties.Settings.Default.Recent0 = _recent[0];
        Properties.Settings.Default.Recent1 = _recent[1];
        Properties.Settings.Default.Recent2 = _recent[2];
        Properties.Settings.Default.Recent3 = _recent[3];
        Properties.Settings.Default.Recent4 = _recent[4];
        Properties.Settings.Default.Save();
    }
    #endregion
}
