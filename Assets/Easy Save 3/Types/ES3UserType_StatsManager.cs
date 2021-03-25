using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("baseProgrammingTap", "permanentProgrammingTapMultiplier", "baseArtisticTap", "permanentArtisticTapMultiplier", "baseSoundTap", "permanentSoundTapMultiplier", "baseGameDesignTap", "permanentGameDesignTapMultiplier", "baseProgrammingDPS", "permanentProgrammingDPSMultiplier", "baseArtisticDPS", "permanentArtisticDPSMultiplier", "baseSoundDPS", "permanentSoundDPSMultiplier", "baseGameDesignDPS", "permanentGameDesignDPSMultiplier", "studioProductivity", "allTapsMultiplier")]
	public class ES3UserType_StatsManager : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_StatsManager() : base(typeof(StatsManager)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (StatsManager)obj;
			
			writer.WritePrivateField("baseProgrammingTap", instance);
			writer.WritePrivateField("permanentProgrammingTapMultiplier", instance);
			writer.WritePrivateField("baseArtisticTap", instance);
			writer.WritePrivateField("permanentArtisticTapMultiplier", instance);
			writer.WritePrivateField("baseSoundTap", instance);
			writer.WritePrivateField("permanentSoundTapMultiplier", instance);
			writer.WritePrivateField("baseGameDesignTap", instance);
			writer.WritePrivateField("permanentGameDesignTapMultiplier", instance);
			writer.WritePrivateField("baseProgrammingDPS", instance);
			writer.WritePrivateField("permanentProgrammingDPSMultiplier", instance);
			writer.WritePrivateField("baseArtisticDPS", instance);
			writer.WritePrivateField("permanentArtisticDPSMultiplier", instance);
			writer.WritePrivateField("baseSoundDPS", instance);
			writer.WritePrivateField("permanentSoundDPSMultiplier", instance);
			writer.WritePrivateField("baseGameDesignDPS", instance);
			writer.WritePrivateField("permanentGameDesignDPSMultiplier", instance);
			writer.WritePrivateField("studioProductivity", instance);
			writer.WritePrivateField("allTapsMultiplier", instance);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (StatsManager)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "baseProgrammingTap":
					reader.SetPrivateField("baseProgrammingTap", reader.Read<System.Single>(), instance);
					break;
					case "permanentProgrammingTapMultiplier":
					reader.SetPrivateField("permanentProgrammingTapMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseArtisticTap":
					reader.SetPrivateField("baseArtisticTap", reader.Read<System.Single>(), instance);
					break;
					case "permanentArtisticTapMultiplier":
					reader.SetPrivateField("permanentArtisticTapMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseSoundTap":
					reader.SetPrivateField("baseSoundTap", reader.Read<System.Single>(), instance);
					break;
					case "permanentSoundTapMultiplier":
					reader.SetPrivateField("permanentSoundTapMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseGameDesignTap":
					reader.SetPrivateField("baseGameDesignTap", reader.Read<System.Single>(), instance);
					break;
					case "permanentGameDesignTapMultiplier":
					reader.SetPrivateField("permanentGameDesignTapMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseProgrammingDPS":
					reader.SetPrivateField("baseProgrammingDPS", reader.Read<System.Single>(), instance);
					break;
					case "permanentProgrammingDPSMultiplier":
					reader.SetPrivateField("permanentProgrammingDPSMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseArtisticDPS":
					reader.SetPrivateField("baseArtisticDPS", reader.Read<System.Single>(), instance);
					break;
					case "permanentArtisticDPSMultiplier":
					reader.SetPrivateField("permanentArtisticDPSMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseSoundDPS":
					reader.SetPrivateField("baseSoundDPS", reader.Read<System.Single>(), instance);
					break;
					case "permanentSoundDPSMultiplier":
					reader.SetPrivateField("permanentSoundDPSMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "baseGameDesignDPS":
					reader.SetPrivateField("baseGameDesignDPS", reader.Read<System.Single>(), instance);
					break;
					case "permanentGameDesignDPSMultiplier":
					reader.SetPrivateField("permanentGameDesignDPSMultiplier", reader.Read<System.Single>(), instance);
					break;
					case "studioProductivity":
					reader.SetPrivateField("studioProductivity", reader.Read<System.Single>(), instance);
					break;
					case "allTapsMultiplier":
					reader.SetPrivateField("allTapsMultiplier", reader.Read<System.Single>(), instance);
					break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_StatsManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_StatsManagerArray() : base(typeof(StatsManager[]), ES3UserType_StatsManager.Instance)
		{
			Instance = this;
		}
	}
}