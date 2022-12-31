using System;
using System.Windows.Forms;
using Zeyo.DotnetFrameworkViewer.Main;

namespace Zeyo.DotnetFrameworkViewer
{
  internal sealed class App
  {
    [STAThread]
    private static void Main(string[] args)
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}