using System.IO;
using System.Text;
using System.Xml.Serialization;

using MinecraftCommandController.Entities;

namespace MinecraftCommandController.Daos
{
	class DmWebDao
	{
		public DmWebDao()
		{

		}

		public void SaveXml(DmWebEt et, string filepath)
		{
			string dir = Path.GetDirectoryName(filepath);
			//ディレクトリが存在しない場合は作成
			if (!Directory.Exists(dir))
			{
				Directory.CreateDirectory(dir);
			}
			//＜XMLファイルに書き込む＞
			//XmlSerializerオブジェクトを作成
			//書き込むオブジェクトの型を指定する
			XmlSerializer serializer1 = new XmlSerializer(typeof(DmWebEt));
			//ファイルを開く（UTF-8 BOM無し）
			StreamWriter sw = new StreamWriter(filepath, false, new UTF8Encoding(false));
			//シリアル化し、XMLファイルに保存する
			serializer1.Serialize(sw, et);
			//閉じる
			sw.Close();
		}

		public DmWebEt LoadXml(string filepath)
		{
			DmWebEt et;
			if (!File.Exists(filepath))
			{
				return null;
			}
			//＜XMLファイルから読み込む＞
			//XmlSerializerオブジェクトの作成
			XmlSerializer serializer2 = new XmlSerializer(typeof(DmWebEt));
			//ファイルを開く
			StreamReader sr = new StreamReader(filepath, new UTF8Encoding(false));
			//XMLファイルから読み込み、逆シリアル化する
			et = (DmWebEt)serializer2.Deserialize(sr);
			//閉じる
			sr.Close();

			return et;
		}
	}
}
