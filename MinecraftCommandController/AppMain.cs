using System;
using System.Windows.Forms;

namespace MinecraftCommandController
{
	static class AppMain
	{
		/// <summary>
		/// アプリケーションのメイン エントリ ポイントです。
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new AppMainForm());
		}
	}
}
