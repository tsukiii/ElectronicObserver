﻿using ElectronicObserver.Data.Battle.Phase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data.Battle {

	/// <summary>
	/// 連合艦隊(機動部隊)昼戦
	/// </summary>
	public class BattleCombinedNormalDay : BattleDay {

		public override void LoadFromResponse( string apiname, dynamic data ) {
			base.LoadFromResponse( apiname, (object)data );

			BaseAirAttack = new PhaseBaseAirAttack( this, "基地航空隊攻撃" );
			AirBattle = new PhaseAirBattle( this, "航空戦" );
			Support = new PhaseSupport( this, "支援攻撃" );
			OpeningASW = new PhaseOpeningASW( this, "先制対潜", true );
			OpeningTorpedo = new PhaseTorpedo( this, "先制雷撃", 0 );
			Shelling1 = new PhaseShelling( this, "第一次砲撃戦", 1, "1", true );
			Torpedo = new PhaseTorpedo( this, "雷撃戦", 2 );
			Shelling2 = new PhaseShelling( this, "第二次砲撃戦", 3, "2", false );
			Shelling3 = new PhaseShelling( this, "第三次砲撃戦", 4, "3", false );


			BaseAirAttack.EmulateBattle( _resultHPs, _attackDamages );
			AirBattle.EmulateBattle( _resultHPs, _attackDamages );
			Support.EmulateBattle( _resultHPs, _attackDamages );
			OpeningASW.EmulateBattle( _resultHPs, _attackDamages );
			OpeningTorpedo.EmulateBattle( _resultHPs, _attackDamages );
			Shelling1.EmulateBattle( _resultHPs, _attackDamages );
			Torpedo.EmulateBattle( _resultHPs, _attackDamages );
			Shelling2.EmulateBattle( _resultHPs, _attackDamages );
			Shelling3.EmulateBattle( _resultHPs, _attackDamages );

		}


		public override string APIName {
			get { return "api_req_combined_battle/battle"; }
		}

		public override string BattleName {
			get { return "連合艦隊-機動部隊 昼戦"; }
		}

		public override BattleData.BattleTypeFlag BattleType {
			get { return BattleTypeFlag.Day | BattleTypeFlag.Combined; }
		}


		public override IEnumerable<PhaseBase> GetPhases() {
			yield return Initial;
			yield return Searching;
			yield return BaseAirAttack;
			yield return AirBattle;
			yield return Support;
			yield return OpeningASW;
			yield return OpeningTorpedo;
			yield return Shelling1;
			yield return Torpedo;
			yield return Shelling2;
			yield return Shelling3;
		}

	}

}
