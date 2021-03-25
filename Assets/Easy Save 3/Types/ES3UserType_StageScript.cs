using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("maxNbrProject", "currentNbrStage", "spriteIndex")]
	public class ES3UserType_StageScript : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_StageScript() : base(typeof(StageScript)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (StageScript)obj;
			
			writer.WriteProperty("maxNbrProject", instance.maxNbrProject, ES3Type_int.Instance);
			writer.WriteProperty("currentNbrStage", instance.currentNbrStage, ES3Type_int.Instance);
			writer.WritePrivateField("spriteIndex", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (StageScript)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "maxNbrProject":
						instance.maxNbrProject = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "currentNbrStage":
						instance.currentNbrStage = reader.Read<System.Int32>(ES3Type_int.Instance);
						break;
					case "spriteIndex":
					reader.SetPrivateField("spriteIndex", reader.Read<System.Int32>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_StageScriptArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StageScriptArray() : base(typeof(StageScript[]), ES3UserType_StageScript.Instance)
		{
			Instance = this;
		}
	}
}