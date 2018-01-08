﻿using ColossalFramework;
using ColossalFramework.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealCity
{
    public class pc_CitizenManager:CitizenManager
    {
        public bool CreateUnits_1(out uint firstUnit, ref Randomizer randomizer, ushort building, ushort vehicle, int homeCount, int workCount, int visitCount, int passengerCount, int studentCount)
        {
            firstUnit = 0u;
            workCount = (workCount + 4) / 5;
            visitCount = (visitCount + 4) / 5;
            passengerCount = (passengerCount + 4) / 5;
            studentCount = (studentCount + 4) / 5;
            int num = homeCount + workCount + visitCount + passengerCount + studentCount;
            if (num == 0)
            {
                return true;
            }
            CitizenUnit citizenUnit = default(CitizenUnit);
            uint num2 = 0u;
            for (int i = 0; i < num; i++)
            {
                uint num3;
                if (!this.m_units.CreateItem(out num3, ref randomizer))
                {
                    this.ReleaseUnits(firstUnit);
                    firstUnit = 0u;
                    return false;
                }
                if (i == 0)
                {
                    firstUnit = num3;
                }
                else
                {
                    citizenUnit.m_nextUnit = num3;
                    this.m_units.m_buffer[(int)((UIntPtr)num2)] = citizenUnit;
                }
                citizenUnit = default(CitizenUnit);
                citizenUnit.m_flags = CitizenUnit.Flags.Created;
                if (i < homeCount)
                {
                    citizenUnit.m_flags |= CitizenUnit.Flags.Home;
                    citizenUnit.m_goods = 20000;
                }
                else if (i < homeCount + workCount)
                {
                    citizenUnit.m_flags |= CitizenUnit.Flags.Work;
                }
                else if (i < homeCount + workCount + visitCount)
                {
                    citizenUnit.m_flags |= CitizenUnit.Flags.Visit;
                }
                else if (i < homeCount + workCount + visitCount + passengerCount)
                {
                    citizenUnit.m_flags |= CitizenUnit.Flags.Vehicle;
                }
                else if (i < homeCount + workCount + visitCount + passengerCount + studentCount)
                {
                    citizenUnit.m_flags |= CitizenUnit.Flags.Student;
                }
                citizenUnit.m_building = building;
                citizenUnit.m_vehicle = vehicle;
                num2 = num3;
            }
            this.m_units.m_buffer[(int)((UIntPtr)num2)] = citizenUnit;
            this.m_unitCount = (int)(this.m_units.ItemCount() - 1u);
            return true;
        }


        private void ReleaseCitizenImplementation(uint citizen, ref Citizen data)
        {
            InstanceID id = default(InstanceID);

            if (comm_data.citizen_money[citizen] > 0)
            {
                comm_data.city_bank -= comm_data.citizen_money[citizen];
            }

            if (data.GetCitizenInfo(citizen) != null)
            {
                if ((comm_data.citizen_money[citizen] < 500) && (data.GetCitizenInfo(citizen).m_citizenAI is ResidentAI) && !data.m_flags.IsFlagSet(Citizen.Flags.DummyTraffic) && !data.m_flags.IsFlagSet(Citizen.Flags.MovingIn) && !(data.m_flags == Citizen.Flags.Created))
                {
                    comm_data.Bad_reputation += 1;
                    //DebugLog.LogToFileOnly("comm_data.citizen_money[citizen] = " + comm_data.citizen_money[citizen].ToString());
                    //DebugLog.LogToFileOnly("AI is = " + data.GetCitizenInfo(citizen).m_citizenAI.ToString());
                    //DebugLog.LogToFileOnly("Flag is = " + data.m_flags.ToString());
                }
            }
            comm_data.citizen_money[citizen] = 0;
            id.Citizen = citizen;
            Singleton<InstanceManager>.instance.ReleaseInstance(id);
            if (data.m_instance != 0)
            {
                this.ReleaseCitizenInstance(data.m_instance);
                data.m_instance = 0;
            }
            data.SetHome(citizen, 0, 0u);
            data.SetWorkplace(citizen, 0, 0u);
            data.SetVisitplace(citizen, 0, 0u);
            data.SetVehicle(citizen, 0, 0u);
            data.SetParkedVehicle(citizen, 0);
            data = default(Citizen);
            this.m_citizens.ReleaseItem(citizen);
            this.m_citizenCount = (int)(this.m_citizens.ItemCount() - 1u);
        }

    }
}
