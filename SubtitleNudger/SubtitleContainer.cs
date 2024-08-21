using System.Text.RegularExpressions;

namespace SubtitleNudger;

public partial class SubtitleContainer
{
    [GeneratedRegex("\\d{2,}:\\d{2,}:\\d{2,},\\d{3,} --> \\d{2,}:\\d{2,}:\\d{2,},\\d{3,}")]
    private static partial Regex DurationPattern();

    #region ----- PROPERTIES
    public List<SubtitleLine> Items => _data is not null ? _data : [];

    public int Count => _data is not null ? _data.Count : 0;
    #endregion

    #region ----- FIELDS
    private List<SubtitleLine>? _data;

    private readonly Action _update;
    #endregion

    #region ----- CONSTRUCTOR
    public SubtitleContainer()
    {
        _update = null!;
    }

    public SubtitleContainer(string path, Action update)
    {
        if (!File.Exists(path)) throw new FileNotFoundException();

        _update = update; // cannot be invoked from here as the object has to exist in the outside context

        ParseContent(File.ReadAllLines(path));
    }
    #endregion

    #region ----- METHODS
    private void ParseContent(string[] data)
    {
        _data ??= [];

        int lineIndex = 1;

        Regex kimono = DurationPattern();
        SubtitleLine temp = new(lineIndex);

        for (int i = 1; i < data.Length; i++)
        {
            if (int.TryParse(data[i], out _))
            { } // indexing is done elsewhere, simply to go to next iteration independent on line errors in file
            else if (kimono.IsMatch(data[i]))
                temp.SetDuration(data[i]);
            else if (string.IsNullOrEmpty(data[i]))
            {
                _data.Add(temp);
                temp = new(++lineIndex);
            }
            else
            {
                //temp.Text = string.IsNullOrEmpty(temp.Text) ? data[i] : $"{temp.Text}{Environment.NewLine}{data[i]}";
                temp.Text += $"{data[i]}{Environment.NewLine}";
            }
        }
    }

    public void AddTime(int milliseconds)
    {
        if (_data is null) throw new Exception("cowabunga");

        foreach (SubtitleLine item in _data)
        {
            item.Add(milliseconds);
        }

        _update();
    }

    public void SubtractTime(int milliseconds)
    {
        if (_data is null) throw new Exception("cowabunga");

        foreach (SubtitleLine item in _data)
        {
            item.Subtract(milliseconds);
        }

        _update();
    }

    public IEnumerable<string> SerializeContent()
    {
        string[] kakke = new string[_data!.Count];
        int i = 0;

        foreach (SubtitleLine item in _data)
        {
            kakke[i++] = item.ToString();
        }

        return kakke;
    }

    internal void Delete(int index)
    {
        _data!.RemoveAt(index);

        for (int i = index; i < _data.Count; i++)
        {
            _data[i].Index--;
        }

        _update();
    }
    #endregion
}
