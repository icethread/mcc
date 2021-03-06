﻿using System.IO;
using System.Text;
using System.Xml.Serialization;

using MinecraftCommandController.Entities;

namespace MinecraftCommandController.Daos
{
	static class SettingDao
	{
		//保存先のファイル名
		static private string filepath = @".\Data\settings.config";
		static private SettingEt settings = new SettingEt();

		static public void SaveSettings()
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
			XmlSerializer serializer1 = new XmlSerializer(typeof(SettingEt));
			//ファイルを開く（UTF-8 BOM無し）
			StreamWriter sw = new StreamWriter(filepath, false, new UTF8Encoding(false));
			//シリアル化し、XMLファイルに保存する
			serializer1.Serialize(sw, settings);
			//閉じる
			sw.Close();
		}

		static public void SaveSettings(SettingEt data)
		{
			settings = data;
			SaveSettings();
		}

		static public SettingEt LoadSettings()
		{
			if (!File.Exists(filepath))
			{
				return settings;
			}
			//＜XMLファイルから読み込む＞
			//XmlSerializerオブジェクトの作成
			XmlSerializer serializer2 = new XmlSerializer(typeof(SettingEt));
			//ファイルを開く
			StreamReader sr = new StreamReader(filepath, new UTF8Encoding(false));
			//XMLファイルから読み込み、逆シリアル化する
			settings = (SettingEt)serializer2.Deserialize(sr);
			//閉じる
			sr.Close();

			return settings;
		}

		static public SettingEt ReferSettings()
		{
			return settings;
		}

	}
}
