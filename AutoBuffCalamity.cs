using System.Collections.Generic;
using Terraria.ModLoader;
using AutoBuff;

namespace AutoBuffCalamity
{
	public class AutoBuffCalamity : Mod
	{

		string saveTag = "AutoBuffCalamity";

		string[,] buffs = new string[,]
		{
		{"AbyssalWeapon", "CalamitasBrew"},
		{"AnechoicCoating", "AnechoicCoating"},
		{"ArmorCrumbling", "CrumblingPotion"},
		{"ArmorShattering", "ShatteringPotion"},
		{"AstralInjectionBuff", "AstralInjection"},
		{"BoundingBuff", "BoundingPotion"},
		{"Cadence", "CadencePotion"},
		{"CalciumBuff", "CalciumPotion"},
		{"CeaselessHunger", "CeaselessHungerPotion"},
		{"DraconicSurgeBuff", "DraconicElixir"},
		{"GravityNormalizerBuff", "GravityNormalizerPotion"},
		{"HolyWrathBuff", "HolyWrathPotion"},
		{"Omniscience", "PotionofOmniscience"},
		{"PenumbraBuff", "PenumbraPotion"},
		{"PhotosynthesisBuff", "PhotosynthesisPotion"},
		{"ProfanedRageBuff", "ProfanedRagePotion"},
		{"Soaring", "SoaringPotion"},
		{"TitanScale", "TitanScalePotion"},
		{"TriumphBuff", "TriumphPotion"},
		{"YharimPower", "YharimsStimulants"},
		{"Zen", "ZenPotion"},
		{"Zerg", "ZergPotion"},
		};


		public AutoBuffCalamity()
		{
		}

		public override void PostSetupContent()
		{
			base.PostSetupContent();

			var buffMod = ModLoader.GetMod("AutoBuff");
			if (buffMod != null)
			{
				var mod = ModLoader.GetMod("CalamityMod");
				if (mod != null)
				{
					List<BuffValue> buffValues = new List<BuffValue>();


					for (int i = 0; i < buffs.GetLength(0); i++)
					{
						var buff = mod.GetBuff(buffs[i, 0]);
						var item = mod.GetItem(buffs[i, 1]);

						if (buff != null && item != null)
						{

							buffValues.Add(new BuffValue(false, buff.Type, buff.Name, "", null,
								new CostValue[] { new ItemCostValue(item.item.type, 30, item.Name) }, null, true));
						}
						else
						{
							this.Logger.Warn("START CROSS MOD");
							this.Logger.Warn(buffs[i, 0] + " = " + buff);
							this.Logger.Warn(buffs[i, 1] + " = " + item);
						}
					}
					
					buffMod.Call("AddModBuffs", saveTag, buffValues.ToArray());

				}
			}
		}
	}
}