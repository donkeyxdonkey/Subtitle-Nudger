
using System.Text.RegularExpressions;

namespace SubtitleNudger;

public class SubtitleLine
{
    #region ----- PROPERTIES
    public int Index { get => _index; set => _index = value; }

    public string DisplayString => $"{_index,-5}| {_duration}";

    public string TimeStart { get => _duration[0..12]; }

    public string TimeEnd { get => _duration[17..29]; }

    public string Duration { get => _duration; set => _duration = value; }

    public string Text { get => _text; set => _text = value; }
    #endregion

    #region ----- FIELDS
    int _index;
    string _duration;
    string _text;

    long _startMS;
    long _endMS;
    #endregion

    #region ----- CONSTRUCTOR
    public SubtitleLine(int index)
    {
        _index = index;
        _duration = _text = string.Empty;
    }
    #endregion

    #region ----- METHODS
    public void SetDuration(string duration)
    {
        _duration = duration;
        _startMS = ToMilliseconds(0, 12);
        _endMS = ToMilliseconds(17, 29);
    }

    public void Add(int milliseconds)
    {
        _startMS += milliseconds;
        _endMS += milliseconds;
        UpdateDisplay();
    }

    public void Subtract(int milliseconds)
    {
        if (_startMS - milliseconds < 0) throw new ArgumentException($"Time cannot be negative. Index: {_index}");

        _startMS -= milliseconds;
        _endMS -= milliseconds;
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _duration = $"{GetTimeString(_startMS)} --> {GetTimeString(_endMS)}";
    }

    private static string GetTimeString(long total)
    {
        int h = (int)(total / (60 * 60 * 1000));
        total %= (60 * 60 * 1000);

        int m = (int)(total / (60 * 1000));
        total %= (60 * 1000);

        int s = (int)(total / 1000);
        int ms = (int)(total % 1000);

        return $"{h:D2}:{m:D2}:{s:D2},{ms:D3}";
    }

    private void ConvertTime(int start, int end, out int Hours, out int Minutes, out int Seconds, out int Milliseconds)
    {
        int[] time = Array.ConvertAll(_duration[start..end].Split([':', ',']), Convert.ToInt32);

        Hours = time[0];
        Minutes = time[1];
        Seconds = time[2];
        Milliseconds = time[3];
    }

    private long ToMilliseconds(int start, int end)
    {
        ConvertTime(start, end, out int Hours, out int Minutes, out int Seconds, out int Milliseconds);

        return (Hours * 60 * 60 * 1000) +
               (Minutes * 60 * 1000) +
               (Seconds * 1000) +
                Milliseconds;
    }

    public override string ToString()
    {
        return $"{_index}{Environment.NewLine}{_duration}{Environment.NewLine}{_text}";
    }

    internal void Replace(string text, string with, ref List<int>? popIndices, bool enableRegex)
    {
        if (!_text.Contains(text))
            return;

        switch (enableRegex)
        {
            case true:
                throw new NotImplementedException();
            //break;
            case false:
                _text = _text.Replace(text, with);
                break;
        }

        while (_text.StartsWith(Environment.NewLine))
        {
            _text = _text[2..]; // cleanup when everything previous to a linebreak is replaced.
        }

        const string TWO_LINES = "\r\n\r\n";

        while (_text.Contains(TWO_LINES))
        {
            _text = _text.Replace(TWO_LINES, Environment.NewLine); // cleanup any double newlines
        }

        if (!_text.IsNullEmptyOrNewLine())
            return;

        popIndices!.Add(_index - 1);
    }
    #endregion
}
