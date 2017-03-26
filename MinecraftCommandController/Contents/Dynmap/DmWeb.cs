using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

using Newtonsoft.Json;

using MinecraftCommandController.Base;
using MinecraftCommandController.Daos;
using MinecraftCommandController.Entities;

namespace MinecraftCommandController.Contents.Dynmap
{
	public partial class DmWeb : MccContentPageBase
	{
		public class DynmapWorldJson
		{
			public class Player
			{
				public string account { get; set; }
				public int armor { get; set; }
				public int health { get; set; }
				public string name { get; set; }
				public int sort { get; set; }
				public string type { get; set; }
				public string world { get; set; }
				public double x { get; set; }
				public double y { get; set; }
				public double z { get; set; }
			}

			public List<Player> players { get; set; }
		}

		public class DynmapConfigJson
		{
			public class World
			{
				public string title { get; set; }
				public string name { get; set; }
			}

			public List<World> worlds { get; set; }
		}

		private AppMainForm appMainForm; //メインフォームの参照
		private DmWebmapForm dmWebmapForm;

		//コンストラクタ
		public DmWeb(AppMainForm form)
		{
			this.appMainForm = form;
			InitializeComponent();
			init();
		}

		//初期処理
		private void init()
		{
			dmWebmapForm = new DmWebmapForm();

			DmWebEt et = new DmWebEt();
			DmWebDao dao = new DmWebDao();
			et = dao.LoadXml(AppConst.DIR_DATA + @"dmweb.xml");

			if (et != null)
			{
				textBox1.Text = et.URL;
			}

		}

		/* ***** 以下、デザイナからの半自動生成 ***** */
		//未使用コンストラクタ
		public DmWeb()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string sBaseUrl = textBox1.Text;
			string sReqConfigUrl = sBaseUrl + "/standalone/dynmap_config.json";

			HttpWebRequest req1 = (HttpWebRequest)WebRequest.Create(sReqConfigUrl);
			req1.Method = "GET";

			DynmapConfigJson objConfig = new DynmapConfigJson();
			try
			{
				using (HttpWebResponse res = (HttpWebResponse)req1.GetResponse())
				{
					using (Stream resStream = res.GetResponseStream())
					{
						using (StreamReader resRead = new StreamReader(resStream))
						{
							string json = resRead.ReadToEnd();
							objConfig = JsonConvert.DeserializeObject<DynmapConfigJson>(json);
						}
					}
				}
			}
			catch
			{
				MessageBox.Show("データ取得に失敗しました。");
				return;
			}

			listBox2.Items.Clear();
			foreach (DynmapConfigJson.World world in objConfig.worlds)
			{
				listBox2.Items.Add(world.name);
			}

			string sDefaultWorld = objConfig.worlds[0].name;


			string sReqWorldUrl = sBaseUrl + "/standalone/world/" + sDefaultWorld + ".json";

			HttpWebRequest req2 = (HttpWebRequest)WebRequest.Create(sReqWorldUrl);
			req2.Method = "GET";

			DynmapWorldJson objWorld = new DynmapWorldJson();
			try
			{
				using (HttpWebResponse res = (HttpWebResponse)req2.GetResponse())
				{
					using (Stream resStream = res.GetResponseStream())
					{
						using (StreamReader resRead = new StreamReader(resStream))
						{
							string json = resRead.ReadToEnd();
							objWorld = JsonConvert.DeserializeObject<DynmapWorldJson>(json);
						}
					}
				}
			}
			catch
			{
				MessageBox.Show("データ取得に失敗しました。");
				return;
			}

			listBox1.Items.Clear();
			foreach (DynmapWorldJson.Player player in objWorld.players)
			{
				listBox1.Items.Add(player.name);
			}

			// 保存
			DmWebEt et = new DmWebEt();
			et.URL = sBaseUrl;
			DmWebDao dao = new DmWebDao();
			dao.SaveXml(et, AppConst.DIR_DATA + @"dmweb.xml");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string url = textBox1.Text;
			dmWebmapForm.fncNavigate(url);
			dmWebmapForm.Show();

			DmWebEt et = new DmWebEt();
			et.URL = url;
			DmWebDao dao = new DmWebDao();
			dao.SaveXml(et, AppConst.DIR_DATA + @"dmweb.xml");
		}
	}
}
