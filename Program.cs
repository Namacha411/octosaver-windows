namespace octosaver_windows;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        ApplicationConfiguration.Initialize();
        ShowScreenSaver();
        Application.Run();
    }    

    static void ShowScreenSaver()
    {
        foreach (Screen screen in Screen.AllScreens)
        {
            MainForm screensaver = new(screen.Bounds);
            screensaver.Show();
        }
    }
}