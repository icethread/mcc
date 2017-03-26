namespace MinecraftCommandController
{
	public static class AppConst
	{
		// WebBrowserコントロールのIEバージョン設定
		public const string FEATURE_BROWSER_EMULATION = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
		// IEのバージョン
		public const int FEATURE_BROWSER_VERSION = 11001;

		//データ保存先関連
		public const string DIR_DATA = @".\Data\";

		//public const string PATH_DATA_DMWEB = @".\Data\dmweb.xml";
		//public const string PATH_DATA_PLAYER = @".\Data\players.xml";
		//public const string PATH_DATA_CONFIG = @".\Data\settings.config";

		//リソース保存先関連
		public const string DIR_RESOURCE = @".\Resource\";

		//public const string PATH_RESOURCE_EFFECTS = @".\Resource\effects.xml";
		//public const string PATH_RESOURCE_ENCHANTS = @".\Resource\enchants.xml";
		//public const string PATH_RESOURCE_GAMERULES = @".\Resource\gamerules.xml";
	}
}
