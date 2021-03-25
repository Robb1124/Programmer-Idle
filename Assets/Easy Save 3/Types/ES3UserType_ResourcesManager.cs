using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("playerGold", "playerGems")]
	public class ES3UserType_ResourcesManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_ResourcesManager() : base(typeof(ResourcesManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (ResourcesManager)obj;
			
			writer.WritePrivateField("playerGold", instance);
			writer.WritePrivateField("playerGems", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (ResourcesManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "playerGold":
					reader.SetPrivateField("playerGold", reader.Read<System.Int32>(), instance);
					break;
					case "playerGems":
					reader.SetPrivateField("playerGems", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_ResourcesManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_ResourcesManagerArray() : base(typeof(ResourcesManager[]), ES3UserType_ResourcesManager.Instance)
		{
			Instance = this;
		}
	}
}