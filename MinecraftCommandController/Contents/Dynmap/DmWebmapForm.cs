using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MinecraftCommandController.Contents.Dynmap
{
	public partial class DmWebmapForm : Form
	{
		public DmWebmapForm()
		{
			InitializeComponent();
		}

		public void fncNavigate(string url)
		{
			webBrowser1.Navigate(url);
		}

		private void DmWebmapForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			webBrowser1.Navigate("about:blank");
			if (e.CloseReason == CloseReason.UserClosing)
			{
				// × ボタンの場合は、Hide に変える。
				e.Cancel = true;
				this.Hide();
			}
		}
	}
}
