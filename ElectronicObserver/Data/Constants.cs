﻿using ElectronicObserver.Utility.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicObserver.Data
{

	public static class Constants
	{

		#region 艦船・装備

		/// <summary>
		/// 艦船の速力を表す文字列を取得します。
		/// </summary>
		public static string GetSpeed(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.Land;
				case 5:
					return ConstantsRes.Slow;
				case 10:
					return ConstantsRes.Fast;
				case 15:
					return "Fast+";
				case 20:
					return "Fastest";
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 射程を表す文字列を取得します。
		/// </summary>
		public static string GetRange(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.None;
				case 1:
					return ConstantsRes.Short;
				case 2:
					return ConstantsRes.Medium;
				case 3:
					return ConstantsRes.Long;
				case 4:
					return ConstantsRes.VeryLong;
				case 5:
					return ConstantsRes.VeryLong + "+";
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 艦船のレアリティを表す文字列を取得します。
		/// </summary>
		public static string GetShipRarity(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.Red;
				case 1:
					return ConstantsRes.Indigo;
				case 2:
					return ConstantsRes.Blue;
				case 3:
					return ConstantsRes.Aqua;
				case 4:
					return ConstantsRes.Silver;
				case 5:
					return ConstantsRes.Gold;
				case 6:
					return ConstantsRes.Rainbow;
				case 7:
					return ConstantsRes.SRainbow;
				case 8:
					return ConstantsRes.Sakura;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 装備のレアリティを表す文字列を取得します。
		/// </summary>
		public static string GetEquipmentRarity(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.Common;
				case 1:
					return ConstantsRes.Rare;
				case 2:
					return ConstantsRes.Holo;
				case 3:
					return ConstantsRes.SHolo;
				case 4:
					return ConstantsRes.SSHolo;
				case 5:
					return ConstantsRes.EXHolo;
				case 6:
					return ConstantsRes.SSHoloPlus;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 装備のレアリティの画像インデックスを取得します。
		/// </summary>
		public static int GetEquipmentRarityID(int value)
		{
			switch (value)
			{
				case 0:
					return 1;
				case 1:
					return 3;
				case 2:
					return 4;
				case 3:
					return 5;
				case 4:
					return 6;
				case 5:
					return 7;
				case 6:
					return 8;
				default:
					return 0;
			}
		}


		/// <summary>
		/// 艦船のボイス設定フラグを表す文字列を取得します。
		/// </summary>
		public static string GetVoiceFlag(int value)
		{

			switch (value)
			{
				case 0:
					return "-";
				case 1:
					return ConstantsRes.Hourly;
				case 2:
					return ConstantsRes.Idle;
				case 3:
					return ConstantsRes.Hourly + " + " + ConstantsRes.Idle;
				case 4:
					return ConstantsRes.SpecialIdle;
				case 5:
					return ConstantsRes.Hourly + " + " + ConstantsRes.SpecialIdle;
				case 6:
					return ConstantsRes.Idle + " + " + ConstantsRes.SpecialIdle;
				case 7:
					return ConstantsRes.Hourly + " + " + ConstantsRes.SpecialIdle;
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 艦船の損傷度合いを表す文字列を取得します。
		/// </summary>
		/// <param name="hprate">現在HP/最大HPで表される割合。</param>
		/// <param name="isPractice">演習かどうか。</param>
		/// <param name="isLandBase">陸上基地かどうか。</param>
		/// <param name="isEscaped">退避中かどうか。</param>
		/// <returns></returns>
		public static string GetDamageState(double hprate, bool isPractice = false, bool isLandBase = false, bool isEscaped = false)
		{

			if ( isEscaped )
				return ConstantsRes.Retreated;
			else if ( hprate <= 0.0 )
				return isPractice ? ConstantsRes.Withdrawn : ( !isLandBase ? ConstantsRes.Sunk : ConstantsRes.Destroyed );
			else if ( hprate <= 0.25 )
				return !isLandBase ? ConstantsRes.CriticalDamage : ConstantsRes.Damaged;
			else if ( hprate <= 0.5 )
				return !isLandBase ? ConstantsRes.ModerateDamage : ConstantsRes.Injured;
			else if ( hprate <= 0.75 )
				return !isLandBase ? ConstantsRes.LightDamage : ConstantsRes.Disorder;
			else if ( hprate < 1.0 )
				return ConstantsRes.Healthy;
			else
				return ConstantsRes.Unhurt;

		}


		/// <summary>
		/// 基地航空隊の行動指示を表す文字列を取得します。
		/// </summary>
		public static string GetBaseAirCorpsActionKind(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.Standby;
				case 1:
					return ConstantsRes.Mission;
				case 2:
					return ConstantsRes.AirDefense;
				case 3:
					return ConstantsRes.TakeCover;
				case 4:
					return ConstantsRes.Rest;
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 艦種略号を取得します。
		/// </summary>
		public static string GetShipClassClassification(ShipTypes shiptype)
		{
			switch (shiptype)
			{
				case ShipTypes.Escort:
					return "DE";
				case ShipTypes.Destroyer:
					return "DD";
				case ShipTypes.LightCruiser:
					return "CL";
				case ShipTypes.TorpedoCruiser:
					return "CLT";
				case ShipTypes.HeavyCruiser:
					return "CA";
				case ShipTypes.AviationCruiser:
					return "CAV";
				case ShipTypes.LightAircraftCarrier:
					return "CVL";
				case ShipTypes.Battlecruiser:
					return "FBB";    // ? FBB, CC?
				case ShipTypes.Battleship:
					return "BB";
				case ShipTypes.AviationBattleship:
					return "BBV";
				case ShipTypes.AircraftCarrier:
					return "CV";
				case ShipTypes.SuperDreadnoughts:
					return "BB";
				case ShipTypes.Submarine:
					return "SS";
				case ShipTypes.SubmarineAircraftCarrier:
					return "SSV";
				case ShipTypes.Transport:
					return "AP";    // ? AO?
				case ShipTypes.SeaplaneTender:
					return "AV";
				case ShipTypes.AmphibiousAssaultShip:
					return "LHA";
				case ShipTypes.ArmoredAircraftCarrier:
					return "CVB";
				case ShipTypes.RepairShip:
					return "AR";
				case ShipTypes.SubmarineTender:
					return "AS";
				case ShipTypes.TrainingCruiser:
					return "CT";
				case ShipTypes.FleetOiler:
					return "AO";
				default:
					return "IX";
			}
		}

		#endregion


		#region 出撃

		/// <summary>
		/// マップ上のセルでのイベントを表す文字列を取得します。
		/// </summary>
		public static string GetMapEventID(int value)
		{

			switch (value)
			{

				case 0:
					return ConstantsRes.StartNode;
				case 1:
					return ConstantsRes.NoNode;
				case 2:
					return "Resources";
				case 3:
					return ConstantsRes.Maelstrom;
				case 4:
					return "Battle";
				case 5:
					return "Boss";
				case 6:
					return ConstantsRes.Imagination;
				case 7:
					return ConstantsRes.AirBattle;
				case 8:
					return ConstantsRes.LargeResourceNode;
				case 9:
					return ConstantsRes.LandNode;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// マップ上のセルでのイベント種別を表す文字列を取得します。
		/// </summary>
		public static string GetMapEventKind(int value)
		{

			switch (value)
			{
				case 0:
					return ConstantsRes.NoBattle;
				case 1:
					return ConstantsRes.DayBattle;
				case 2:
					return ConstantsRes.NightBattle;
				case 3:
					return ConstantsRes.NightDayBattle;
				case 4:
					return ConstantsRes.AirBattle;
				case 5:
					return ConstantsRes.EnemyCombinedFleet;
				case 6:
					return ConstantsRes.AirRaid;
				case 7:
					return ConstantsRes.NightDayBattle;		// 対連合
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 海域難易度を表す文字列を取得します。
		/// </summary>
		public static string GetDifficulty(int value)
		{

			switch (value)
			{
				case -1:
					return ConstantsRes.NoNode;
				case 0:
					return ConstantsRes.Unselected;
				case 1:
					return ConstantsRes.EasyDifficulty;
				case 2:
					return ConstantsRes.MediumDifficulty;
				case 3:
					return ConstantsRes.HardDifficulty;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 海域難易度を表す数値を取得します。
		/// </summary>
		public static int GetDifficulty(string value)
		{

			switch (value)
			{
				case "未選択":
                case "Unselected":
					return 0;
				case "丙":
                case "Easy":
					return 1;
				case "乙":
                case "Medium":
					return 2;
                case "Hard":
				case "甲":
					return 3;
				default:
					return -1;
			}

		}

		/// <summary>
		/// 空襲被害の状態を表す文字列を取得します。
		/// </summary>
		public static string GetAirRaidDamage(int value)
		{
			switch (value)
			{
				case 1:
					return "Resources Damaged";
				case 2:
					return "Resources and Air Squadron Damaged";
				case 3:
					return "Air Squadron Damaged";
				case 4:
					return "No Damage";
				default:
					return "No Air Raid";
			}
		}

		/// <summary>
		/// 空襲被害の状態を表す文字列を取得します。(短縮版)
		/// </summary>
		public static string GetAirRaidDamageShort(int value)
		{
			switch (value)
			{
				case 1:
					return "Resources damaged";
				case 2:
					return "Base and resources";
				case 3:
					return "Base damaged";
				case 4:
					return "No damage";
				default:
					return "-";
			}
		}


		#endregion


		#region 戦闘

		/// <summary>
		/// 陣形を表す文字列を取得します。
		/// </summary>
		public static string GetFormation(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.LineAhead;
				case 2:
					return ConstantsRes.DoubleLine;
				case 3:
					return ConstantsRes.Diamond;
				case 4:
					return ConstantsRes.Echelon;
				case 5:
					return ConstantsRes.LineAbreast;
				case 6:
					return "Vanguard";
				case 11:
					return ConstantsRes.FirstPatrolFormation;
				case 12:
					return ConstantsRes.SecondPatrolFormation;
				case 13:
					return ConstantsRes.ThirdPatrolFormation;
				case 14:
					return ConstantsRes.FourthPatrolFormation;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 陣形を表す数値を取得します。
		/// </summary>
		public static int GetFormation(string value)
		{
			switch (value)
			{
				case "単縦陣":
                case "Line Ahead":
					return 1;
				case "複縦陣":
                case "Double Line":
					return 2;
				case "輪形陣":
                case "Diamond":
					return 3;
				case "梯形陣":
                case "Echelon":
					return 4;
				case "単横陣":
                case "Line Abreast":
					return 5;
				case "警戒陣":
				case "Vanguard":
					return 6;
				case "第一警戒航行序列":
                case "First Cruising Formation":
					return 11;
				case "第二警戒航行序列":
                case "Second Cruising Formation":
					return 12;
				case "第三警戒航行序列":
                case "Third Cruising Formation":
					return 13;
				case "第四警戒航行序列":
                case "Fourth Cruising Formation":
					return 14;
				default:
					return -1;
			}
		}

		/// <summary>
		/// 陣形を表す文字列(短縮版)を取得します。
		/// </summary>
		public static string GetFormationShort(int id)
		{
			switch (id)
			{
				case 1:
					return "LA";
				case 2:
					return "DL";
				case 3:
					return "Rin";
				case 4:
					return "Ech";
				case 5:
					return "LAb";
				case 6:
					return "Van";
				case 11:
					return "ASW";
				case 12:
					return "For";
				case 13:
					return "Rin";
				case 14:
					return "Btl";
				default:
					return "Unk";
			}
		}

		/// <summary>
		/// 交戦形態を表す文字列を取得します。
		/// </summary>
		public static string GetEngagementForm(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.Parallel;
				case 2:
					return ConstantsRes.HeadOn;
				case 3:
					return "Green T";
				case 4:
					return "Red T";
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 交戦形態を表す文字列を取得します。
		/// </summary>
		public static string GetEngagementFormShort(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.Parallel;
				case 2:
					return ConstantsRes.HeadOn;
				case 3:
					return ConstantsRes.TAdvantage;
				case 4:
					return ConstantsRes.TDisadvantage;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 索敵結果を表す文字列を取得します。
		/// </summary>
		public static string GetSearchingResult(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.Success;
				case 2:
					return ConstantsRes.SuccessNoReturn;
				case 3:
					return ConstantsRes.NoReturn;
				case 4:
					return ConstantsRes.Failure;
				case 5:
					return ConstantsRes.SuccessNoPlane;
				case 6:
					return ConstantsRes.FailureNoPlane;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 索敵結果を表す文字列(短縮版)を取得します。
		/// </summary>
		public static string GetSearchingResultShort(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.Success;
				case 2:
					return ConstantsRes.Success + "△";
				case 3:
					return ConstantsRes.NoReturn;
				case 4:
					return ConstantsRes.Failure;
				case 5:
					return ConstantsRes.Success;
				case 6:
					return ConstantsRes.Failure;
				default:
					return ConstantsRes.Unknown;
			}
		}

		/// <summary>
		/// 制空戦の結果を表す文字列を取得します。
		/// </summary>
		public static string GetAirSuperiority(int id)
		{
			switch (id)
			{
				case 0:
					return ConstantsRes.AirParity;
				case 1:
					return ConstantsRes.AirSupremacy;
				case 2:
					return ConstantsRes.AirSuperiority;
				case 3:
					return ConstantsRes.AirDenialNew;
				case 4:
					return ConstantsRes.AirIncapability;
				default:
					return ConstantsRes.Unknown;
			}
		}



		/// <summary>
		/// 昼戦攻撃種別を表す文字列を取得します。
		/// </summary>
		public static string GetDayAttackKind(DayAttackKind id)
		{
			switch (id)
			{
				case DayAttackKind.NormalAttack:
					return "Normal Attack";
				case DayAttackKind.Laser:
					return "Laser Attack";
				case DayAttackKind.DoubleShelling:
					return "DA";
				case DayAttackKind.CutinMainSub:
					return "CI (MG+SG)";
				case DayAttackKind.CutinMainRadar:
					return "CI (MG+Radar)";
				case DayAttackKind.CutinMainAP:
					return "CI (MG+AP)";
				case DayAttackKind.CutinMainMain:
					return "CI (MG+MG)";
				case DayAttackKind.CutinAirAttack:
					return "CI (Carrier)";
				case DayAttackKind.Shelling:
					return "Shelling";
				case DayAttackKind.AirAttack:
					return "Air Attack";
				case DayAttackKind.DepthCharge:
					return "Depth Charge";
				case DayAttackKind.Torpedo:
					return "Torpedo";
				case DayAttackKind.Rocket:
					return "Rocket Artillery";
				case DayAttackKind.LandingDaihatsu:
					return "Amphibious Attack (Daihatsu)";
				case DayAttackKind.LandingTokuDaihatsu:
					return "Amphibious Attack(Toku Daihatsu)";
				case DayAttackKind.LandingDaihatsuTank:
					return "Amphibious Attack(Daihatsu+Tank)";
				case DayAttackKind.LandingAmphibious:
					return ConstantsRes.TankAttack;
				case  DayAttackKind.LandingTokuDaihatsuTank:
					return "Amphibious Attack(Toku Daihatsu+Tank)";
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 夜戦攻撃種別を表す文字列を取得します。
		/// </summary>
		public static string GetNightAttackKind(NightAttackKind id)
		{
			switch (id)
			{
				case NightAttackKind.NormalAttack:
					return "Shelling";
				case NightAttackKind.DoubleShelling:
					return "DA";
				case NightAttackKind.CutinMainTorpedo:
					return "CI (MG+Torp)";
				case NightAttackKind.CutinTorpedoTorpedo:
					return "CI (Torp×2)";
				case NightAttackKind.CutinMainSub:
					return "CI (MG×2+SG)";
				case NightAttackKind.CutinMainMain:
					return "CI (MG×3)";
				case NightAttackKind.CutinAirAttack:
					return "CI (Carrier)";
				case NightAttackKind.CutinTorpedoRadar:
					return "駆逐カットイン(主砲/魚雷/電探)";
				case NightAttackKind.CutinTorpedoPicket:
					return "駆逐カットイン(魚雷/見張員/電探)";
				case NightAttackKind.Shelling:
					return "Shelling";
				case NightAttackKind.AirAttack:
					return ConstantsRes.AirAttack;
				case NightAttackKind.DepthCharge:
					return ConstantsRes.DepthChargeAttack;
				case NightAttackKind.Torpedo:
					return ConstantsRes.TorpedoAttack;
				case NightAttackKind.Rocket:
					return ConstantsRes.RocketAttack;
				case NightAttackKind.LandingDaihatsu:
					return ConstantsRes.DaihatsuAttack;
				case NightAttackKind.LandingTokuDaihatsu:
					return "Amphibious Attack (Toku Daihatsu)";
				case NightAttackKind.LandingDaihatsuTank:
					return "Amphibious Attack (Daihatsu+Tank)";
				case NightAttackKind.LandingAmphibious:
					return ConstantsRes.TankAttack;
				case NightAttackKind.LandingTokuDaihatsuTank:
					return "Amphibious Attack (Toku Daihatsu+Tank)";
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 対空カットイン種別を表す文字列を取得します。
		/// </summary>
		public static string GetAACutinKind(int id)
		{
			switch (id)
			{
				case 0:
					return ConstantsRes.NoNode;
				case 1:
					return ConstantsRes.HA2 + "/" + ConstantsRes.Radar + " (Akizuki)";
				case 2:
					return ConstantsRes.HAGun + "/" + ConstantsRes.Radar + " (Akizuki)";
				case 3:
					return ConstantsRes.HA2 + " (Akizuki)";
				case 4:
					return ConstantsRes.BigGun + "/" + ConstantsRes.Type3 + "/" + ConstantsRes.AADirector + "/" + ConstantsRes.Radar;
				case 5:
					return ConstantsRes.HAAAD + "x2/" + ConstantsRes.Radar;
				case 6:
					return ConstantsRes.BigGun + "/" + ConstantsRes.Type3 + "/" + ConstantsRes.AADirector;
				case 7:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AADirector + "/" + ConstantsRes.Radar;
				case 8:
					return ConstantsRes.HAAAD + "/" + ConstantsRes.Radar;
				case 9:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AADirector;
                case 10:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + "/" + ConstantsRes.Radar + " (Maya)";
				case 11:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + " (Maya)";
				case 12:
					return ConstantsRes.AAGun + "/" + ConstantsRes.AAGun + ConstantsRes.Radar;
				case 14:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + "/" + ConstantsRes.Radar + " (Isuzu)";
				case 15:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + " (Isuzu)";
				case 16:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + "/" + ConstantsRes.Radar + " (Kasumi)";
				case 17:
					return ConstantsRes.HAGun + "/" + ConstantsRes.AAGun + " (Kasumi)";
				case 18:
					return ConstantsRes.AAGun + " (Satsuki)";
				case 19:
					return ConstantsRes.HAGun + " (Non-piercing)/" + ConstantsRes.AAGun + " (Kinu)";
				case 20:
					return ConstantsRes.AAGun + " (Kinu)";
				case 21:
					return ConstantsRes.HAGun + "/" + ConstantsRes.Radar + " (Yura)";
				case 22:
					return ConstantsRes.HAGun + " (Fumizuki)";
				case 23:
					return ConstantsRes.AAGun + "(Unconcentrated)(UIT-25)";
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 勝利ランクを表すIDを取得します。
		/// </summary>
		public static int GetWinRank(string rank)
		{
			switch (rank.ToUpper())
			{
				case "E":
					return 1;
				case "D":
					return 2;
				case "C":
					return 3;
				case "B":
					return 4;
				case "A":
					return 5;
				case "S":
					return 6;
				case "SS":
					return 7;
				default:
					return 0;
			}
		}

		/// <summary>
		/// 勝利ランクを表す文字列を取得します。
		/// </summary>
		public static string GetWinRank(int rank)
		{
			switch (rank)
			{
				case 1:
					return "E";
				case 2:
					return "D";
				case 3:
					return "C";
				case 4:
					return "B";
				case 5:
					return "A";
				case 6:
					return "S";
				case 7:
					return "SS";
				default:
					return ConstantsRes.Unknown;
			}
		}

		#endregion


		#region その他

		/// <summary>
		/// 資源の名前を取得します。
		/// </summary>
		/// <param name="materialID">資源のID。</param>
		/// <returns>資源の名前。</returns>
		public static string GetMaterialName(int materialID)
		{

			switch (materialID)
			{
				case 1:
					return ConstantsRes.Fuel;
				case 2:
					return ConstantsRes.Ammo;
				case 3:
					return ConstantsRes.Steel;
				case 4:
					return ConstantsRes.Baux;
				case 5:
					return ConstantsRes.Flamethrower;
				case 6:
					return ConstantsRes.Bucket;
				case 7:
					return ConstantsRes.DevMat;
				case 8:
					return ConstantsRes.ImpMat;
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 階級を表す文字列を取得します。
		/// </summary>
		public static string GetAdmiralRank(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.FleetAdmiral;
				case 2:
					return ConstantsRes.FourStarAdmiral;
				case 3:
					return ConstantsRes.ViceAdmiral;
				case 4:
					return ConstantsRes.RearAdmiral;
				case 5:
					return ConstantsRes.Captain;
				case 6:
					return ConstantsRes.Commander;
				case 7:
					return ConstantsRes.NoviceCommander;
				case 8:
					return ConstantsRes.LtCmdr;
				case 9:
					return ConstantsRes.ViceLtCmdr;
				case 10:
					return ConstantsRes.NoviceLtCmdr;
				default:
					return ConstantsRes.Admiral;
			}
		}


		/// <summary>
		/// 任務の発生タイプを表す文字列を取得します。
		/// </summary>
		public static string GetQuestType(int id)
		{
			switch (id)
			{
				case 1:     //デイリー
					return ConstantsRes.Daily;
				case 2:     //ウィークリー
					return ConstantsRes.Weekly;
				case 3:     //マンスリー
					return ConstantsRes.Monthly;
				case 4:     //単発
					return "1";
				case 5:     //その他(輸送5/空母3)
					return ConstantsRes.QuestOther;
				default:
					return ConstantsRes.Question;
			}

		}


		/// <summary>
		/// 任務のカテゴリを表す文字列を取得します。
		/// </summary>
		public static string GetQuestCategory(int id)
		{
			switch (id)
			{
				case 1:
					return ConstantsRes.Formation;
				case 2:
					return ConstantsRes.Sortie;
				case 3:
					return ConstantsRes.Practice;
				case 4:
					return ConstantsRes.Expedition;
				case 5:
					return ConstantsRes.Supply;        //入渠も含むが、文字数の関係
				case 6:
					return ConstantsRes.Construction;
				case 7:
					return ConstantsRes.Modernization;
				case 8:
					return ConstantsRes.Sortie;
				case 9:
					return ConstantsRes.Other;
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 遠征の結果を表す文字列を取得します。
		/// </summary>
		public static string GetExpeditionResult(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.Failure;
				case 1:
					return ConstantsRes.Success;
				case 2:
					return ConstantsRes.GreatSuccess;
				default:
					return ConstantsRes.Unknown;
			}
		}


		/// <summary>
		/// 連合艦隊の編成名を表す文字列を取得します。
		/// </summary>
		public static string GetCombinedFleet(int value)
		{
			switch (value)
			{
				case 0:
					return ConstantsRes.NormalFleet;
				case 1:
					return ConstantsRes.TaskForce;
				case 2:
					return ConstantsRes.SurfaceFleet;
				case 3:
					return ConstantsRes.TransportFleet;
				default:
					return ConstantsRes.Unknown;
			}
		}

		#endregion

	}

}
