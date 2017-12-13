﻿using ElectronicObserver.Data.Battle.Phase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Battle
{
	/// <summary>
	/// 通常/連合艦隊 vs 連合艦隊　夜昼戦
	/// </summary>
	public class BattleEnemyCombinedDayFromNight : BattleDayFromNight
	{

		public override void LoadFromResponse(string apiname, dynamic data)
		{
			base.LoadFromResponse(apiname, (object)data);

			NightSupport = new PhaseSupport(this, "夜間支援攻撃", true);
			NightBattle = new PhaseNightBattle(this, "第一次夜戦", 1, false);
			NightBattle2 = new PhaseNightBattle(this, "第二次夜戦", 2, false);


			if (NextToDay)
			{
				JetBaseAirAttack = new PhaseJetBaseAirAttack(this, "噴式基地航空隊攻撃");
				JetAirBattle = new PhaseJetAirBattle(this, "噴式航空戦");
				BaseAirAttack = new PhaseBaseAirAttack(this, "基地航空隊攻撃");
				Support = new PhaseSupport(this, "支援攻撃");
				AirBattle = new PhaseAirBattle(this, "航空戦");
				OpeningASW = new PhaseOpeningASW(this, "先制対潜");
				OpeningTorpedo = new PhaseTorpedo(this, "先制雷撃", 0);
				Shelling1 = new PhaseShelling(this, "第一次砲撃戦", 1, "1");
				Shelling2 = new PhaseShelling(this, "第二次砲撃戦", 2, "2");
				Torpedo = new PhaseTorpedo(this, "雷撃戦", 3);
			}

			foreach (var phase in GetPhases())
				phase.EmulateBattle(_resultHPs, _attackDamages);
		}

		public override string APIName => "api_req_combined_battle/ec_night_to_day";

		public override string BattleName => "対連合艦隊　夜昼戦";



		public override IEnumerable<PhaseBase> GetPhases()
		{
			yield return Initial;
			yield return Searching;
			yield return NightSupport;
			yield return NightBattle;
			yield return NightBattle2;

			if (NextToDay)
			{
				yield return JetBaseAirAttack;
				yield return JetAirBattle;
				yield return BaseAirAttack;
				yield return Support;
				yield return AirBattle;
				yield return OpeningASW;
				yield return OpeningTorpedo;
				yield return Shelling1;
				yield return Shelling2;
				yield return Torpedo;
			}
		}
	}
}
