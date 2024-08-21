namespace SubtitleNudger;

internal static class Program
{
    /// <summary>
    ///  Hello Gynther.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Main());
    }
}