﻿using ColossalFramework;
using ColossalFramework.Globalization;
using ColossalFramework.Math;
using UnityEngine;


namespace RealCity
{
    public class pc_CommercialBuildingAI : PrivateBuildingAI
    {
        public override int CalculateProductionCapacity(Randomizer r, int width, int length)
        {
            ItemClass @class = this.m_info.m_class;
            int num = 0;
            if (@class.m_subService == ItemClass.SubService.CommercialEco)
            {
                num = 50;
            }
            if (num != 0)
            {
                num = Mathf.Max(100, width * length * num + r.Int32(100u)) / 100;
            }
            return num;
        }

        public override void ModifyMaterialBuffer(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            switch (material)
            {
                case TransferManager.TransferReason.ShoppingB:
                case TransferManager.TransferReason.ShoppingC:
                case TransferManager.TransferReason.ShoppingD:
                case TransferManager.TransferReason.ShoppingE:
                case TransferManager.TransferReason.ShoppingF:
                case TransferManager.TransferReason.ShoppingG:
                case TransferManager.TransferReason.ShoppingH:
                    break;
                default:
                    if (material != TransferManager.TransferReason.Shopping)
                    {
                        if (material == TransferManager.TransferReason.Goods)
                        {
                            int width = data.Width;
                            int length = data.Length;
                            int num = 4000;
                            int num2 = this.CalculateVisitplaceCount(new Randomizer((int)buildingID), width, length);
                            int num3 = Mathf.Max(num2 * 500, num * 4);
                            int customBuffer = (int)data.m_customBuffer1;
                            amountDelta = Mathf.Clamp(amountDelta, 0, num3 - customBuffer);
                            data.m_customBuffer1 = (ushort)(customBuffer + amountDelta);
                        }
                        else
                        {
                            base.ModifyMaterialBuffer(buildingID, ref data, material, ref amountDelta);
                        }
                        return;
                    }
                    break;
            }
            //do not allow rush hour add 200 demand during 20-4 in the night.
            if (amountDelta == -200 || amountDelta == -50)
            {
                amountDelta = 0;
            }
            //DebugLog.LogToFileOnly("we go in now, find a visit arrive in comm " + Environment.StackTrace);
            int customBuffer2 = (int)data.m_customBuffer2;
            amountDelta = Mathf.Clamp(amountDelta, -customBuffer2, 0);
            caculate_trade_income(buildingID, ref data, material, ref amountDelta);
            data.m_customBuffer2 = (ushort)(customBuffer2 + amountDelta);
            data.m_outgoingProblemTimer = 0;
        }

        public void caculate_trade_income(ushort buildingID, ref Building data, TransferManager.TransferReason material, ref int amountDelta)
        {
            float production_value;
            Citizen.BehaviourData behaviour = default(Citizen.BehaviourData);
            int aliveWorkerCount = 0;
            int totalWorkerCount = 0;
            base.GetWorkBehaviour(buildingID, ref data, ref behaviour, ref aliveWorkerCount, ref totalWorkerCount);
            float num = (float)aliveWorkerCount / 6f;
            if (num < 1f)
            {
                num = 1f;
            }
            switch (data.Info.m_class.m_level)
            {
                case ItemClass.Level.Level1:
                    production_value = 1f * num; break;
                case ItemClass.Level.Level2:
                    production_value = 1.2f * num; break;
                case ItemClass.Level.Level3:
                    production_value = 1.5f * num; break;
                default:
                    production_value = 0f; break;
            }

            switch (data.Info.m_class.m_subService)
            {
                case ItemClass.SubService.CommercialEco:
                    production_value = 1f * num; break;
                case ItemClass.SubService.CommercialLeisure:
                    production_value = 1.8f * num; break;
                case ItemClass.SubService.CommercialTourist:
                    production_value = 2.0f * num; break;
                default:
                    break;
            }

            float trade_tax = 0;
            float final_profit;
            final_profit = pc_PrivateBuildingAI.comm_profit * production_value;
            if (final_profit > 0.95f)
            {
                final_profit = 0.95f;
            }
            float trade_income = amountDelta * final_profit;
            if ((comm_data.building_money[buildingID] - trade_income)> 0)
            {
                trade_tax = -trade_income * 0.3f;
                Singleton<EconomyManager>.instance.AddPrivateIncome((int)trade_tax, ItemClass.Service.Commercial, data.Info.m_class.m_subService, data.Info.m_class.m_level, 111);
            }
            comm_data.building_money[buildingID] = (comm_data.building_money[buildingID] - (trade_income + trade_tax));

        }

        public override string GetLevelUpInfo(ushort buildingID, ref Building data, out float progress)
        {
            comm_data.current_buildingid = buildingID;
            if ((data.m_problems & Notification.Problem.FatalProblem) != Notification.Problem.None)
            {
                progress = 0f;
                return Locale.Get("LEVELUP_IMPOSSIBLE");
            }
            if (this.m_info.m_class.m_subService != ItemClass.SubService.CommercialLow && this.m_info.m_class.m_subService != ItemClass.SubService.CommercialHigh)
            {
                progress = 0f;
                return Locale.Get("LEVELUP_SPECIAL_INDUSTRY");
            }
            if (this.m_info.m_class.m_level == ItemClass.Level.Level3)
            {
                progress = 0f;
                return Locale.Get("LEVELUP_COMMERCIAL_HAPPY");
            }
            if (data.m_problems != Notification.Problem.None)
            {
                progress = 0f;
                return Locale.Get("LEVELUP_DISTRESS");
            }
            if (data.m_levelUpProgress == 0)
            {
                return base.GetLevelUpInfo(buildingID, ref data, out progress);
            }
            if (data.m_levelUpProgress == 1)
            {
                progress = 0.933333337f;
                return Locale.Get("LEVELUP_HIGHRISE_BAN");
            }
            int num = (int)((data.m_levelUpProgress & 15) - 1);
            int num2 = (data.m_levelUpProgress >> 4) - 1;
            if (num <= num2)
            {
                progress = (float)num * 0.06666667f;
                return Locale.Get("LEVELUP_LOWWEALTH");
            }
            progress = (float)num2 * 0.06666667f;
            return Locale.Get("LEVELUP_LOWLANDVALUE");
        }
    }
}
