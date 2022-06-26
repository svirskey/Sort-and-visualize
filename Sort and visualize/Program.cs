namespace Sort_and_visualize
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            var window = new MainWindow();
            Application.Run(window);
        }
    }
}