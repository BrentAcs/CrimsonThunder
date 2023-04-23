using Balance.App.Forms;

namespace Balance.App;

internal static class Program
{
   /// <summary>
   ///  The main entry point for the application.
   /// </summary>
   [STAThread]
   static void Main()
   {
      // To customize application configuration such as set high DPI settings or default font,
      // see https://aka.ms/applicationconfiguration.
      ApplicationConfiguration.Initialize();
      Application.ThreadException += Application_ThreadException;
      Application.Run(new MainForm());
      //Application.Run(new TestForm());
      UserSettings.Default.Save();
   }

   private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
   {
      MessageBox.Show($"Shit's broke yo. {e.Exception.Message}");
   }
}
