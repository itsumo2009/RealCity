﻿using System;
using ColossalFramework;
using RealCity.Util;
using RealCity.UI;
using RealCity.CustomData;

namespace RealCity.CustomAI
{
    public static class RealCityResidentAI
    {
        public static uint preCitizenId = 0;
        public static int familyCount = 0;
        public static int citizenCount = 0;
        public static uint familyVeryProfitMoneyCount = 0;
        public static uint familyProfitMoneyCount = 0;
        public static uint familyLossMoneyCount = 0;
        public static int citizenSalaryCount = 0;
        public static int citizenExpenseCount = 0;
        public static int citizenSalaryTaxTotal = 0;
        public static float tempCitizenSalaryTaxTotal = 0f;
        public static uint familyWeightStableHigh = 0;
        public static uint familyWeightStableLow = 0;

        public static void Load(ref byte[] saveData)
        {
            int i = 0;
            SaveAndRestore.LoadData(ref i, saveData, ref preCitizenId);
            SaveAndRestore.LoadData(ref i, saveData, ref familyCount);
            SaveAndRestore.LoadData(ref i, saveData, ref familyVeryProfitMoneyCount);
            SaveAndRestore.LoadData(ref i, saveData, ref familyProfitMoneyCount);
            SaveAndRestore.LoadData(ref i, saveData, ref familyLossMoneyCount);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenSalaryCount);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenExpenseCount);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenSalaryTaxTotal);
            SaveAndRestore.LoadData(ref i, saveData, ref tempCitizenSalaryTaxTotal);
            SaveAndRestore.LoadData(ref i, saveData, ref familyWeightStableHigh);
            SaveAndRestore.LoadData(ref i, saveData, ref familyWeightStableLow);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenCount);

            if (i != saveData.Length)
            {
                DebugLog.LogToFileOnly($"RealCityResidentAI Load Error: saveData.Length = {saveData.Length} + i = {i}");
            }
        }

        public static void Save(ref byte[] saveData)
        {
            int i = 0;

            //48
            SaveAndRestore.SaveData(ref i, preCitizenId, ref saveData);
            SaveAndRestore.SaveData(ref i, familyCount, ref saveData);
            SaveAndRestore.SaveData(ref i, familyVeryProfitMoneyCount, ref saveData);
            SaveAndRestore.SaveData(ref i, familyProfitMoneyCount, ref saveData);
            SaveAndRestore.SaveData(ref i, familyLossMoneyCount, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenSalaryCount, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenExpenseCount, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenSalaryTaxTotal, ref saveData);
            SaveAndRestore.SaveData(ref i, tempCitizenSalaryTaxTotal, ref saveData);
            SaveAndRestore.SaveData(ref i, familyWeightStableHigh, ref saveData);
            SaveAndRestore.SaveData(ref i, familyWeightStableLow, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenCount, ref saveData);

            if (i != saveData.Length)
            {
                DebugLog.LogToFileOnly($"RealCityResidentAI Save Error: saveData.Length = {saveData.Length} + i = {i}");
            }
        }

        public static float ProcessSalaryLandPriceAdjust(ushort workBuilding)
        {
            DistrictManager districtMan = Singleton<DistrictManager>.instance;
            ushort district = districtMan.GetDistrict(Singleton<BuildingManager>.instance.m_buildings.m_buffer[workBuilding].m_position);
            float localSalaryIdex = (districtMan.m_districts.m_buffer[district].GetLandValue() + 50f) / 50f;
            float citySalaryIdex = (districtMan.m_districts.m_buffer[0].GetLandValue() + 50f) / 50f;
            return (localSalaryIdex + citySalaryIdex) / 2f;
        }

        public static bool isGoverment(ushort buildingID)
        {
            bool isGoverment = false;
            Building buildingData = Singleton<BuildingManager>.instance.m_buildings.m_buffer[buildingID];
            switch (buildingData.Info.m_class.m_service)
            {
                case ItemClass.Service.Disaster:
                case ItemClass.Service.PoliceDepartment:
                case ItemClass.Service.Education:
                case ItemClass.Service.Road:
                case ItemClass.Service.Garbage:
                case ItemClass.Service.HealthCare:
                case ItemClass.Service.Beautification:
                case ItemClass.Service.Monument:
                case ItemClass.Service.Water:
                case ItemClass.Service.Electricity:
                case ItemClass.Service.FireDepartment:
                case ItemClass.Service.PlayerIndustry:
                case ItemClass.Service.PublicTransport:
                case ItemClass.Service.PlayerEducation:
                case ItemClass.Service.Museums:
                case ItemClass.Service.VarsitySports:
                    isGoverment = true; break;
            }
            return isGoverment;
        }

        public static int ProcessCitizenSalary(uint citizenId, bool checkOnly)
        {
            int salary = 0;
            if (citizenId != 0u)
            {
                Citizen.Flags tempFlag = Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizenId].m_flags;
                if ((tempFlag & Citizen.Flags.Student) != Citizen.Flags.None || (tempFlag & Citizen.Flags.Sick) != Citizen.Flags.None)
                {
                    return salary;
                }
                ushort workBuilding = Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizenId].m_workBuilding;
                if (workBuilding != 0u)
                {
                    Building buildingData = Singleton<BuildingManager>.instance.m_buildings.m_buffer[workBuilding];
                    int aliveWorkCount = 0;
                    int totalWorkCount = 0;
                    Citizen.BehaviourData behaviour = default(Citizen.BehaviourData);
                    BuildingUI.GetWorkBehaviour(workBuilding, ref buildingData, ref behaviour, ref aliveWorkCount, ref totalWorkCount);
                    if (!isGoverment(workBuilding))
                    {
                        switch (buildingData.Info.m_class.m_service)
                        {
                            case ItemClass.Service.Commercial:
                            case ItemClass.Service.Industrial:
                                if (BuildingData.buildingMoney[workBuilding] > 0 && totalWorkCount != 0)
                                {
                                    salary = (int)(BuildingData.buildingMoney[workBuilding] * 0.04f / totalWorkCount);
                                    break;
                                }
                                break;
                            case ItemClass.Service.Office:
                                if (BuildingData.buildingMoney[workBuilding] > 0 && totalWorkCount != 0)
                                {
                                    salary = (int)(BuildingData.buildingMoney[workBuilding] / totalWorkCount);
                                }
                                break;
                            default: break;
                        }
                        if (!checkOnly)
                        {
                            BuildingData.buildingMoney[workBuilding] -= salary;
                        }
                    }
                    else
                    {
                        //Goverment
                        int salaryMax = 0;
                        switch (Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizenId].EducationLevel)
                        {
                            case Citizen.Education.Uneducated:
                                salaryMax = MainDataStore.govermentEducation0Salary;
                                salary = MainDataStore.govermentEducation0SalaryFixed; break;
                            case Citizen.Education.OneSchool:
                                salaryMax = MainDataStore.govermentEducation1Salary;
                                salary = MainDataStore.govermentEducation1SalaryFixed; break;
                            case Citizen.Education.TwoSchools:
                                salaryMax = MainDataStore.govermentEducation2Salary;
                                salary = MainDataStore.govermentEducation2SalaryFixed; break;
                            case Citizen.Education.ThreeSchools:
                                salaryMax = MainDataStore.govermentEducation3Salary;
                                salary = MainDataStore.govermentEducation3SalaryFixed; break;
                        }
                        int allWorkCount = 0;
                        //Update to see if there is building workplace change.
                        //If a building have 10 workers and have 100 workplacecount, we assume that the other 90 vitual workers are from outside
                        //Which will give addition cost
                        allWorkCount = TotalWorkCount(workBuilding, buildingData, false, false);
                        if (totalWorkCount > allWorkCount)
                        {
                            Singleton<CitizenManager>.instance.m_citizens.m_buffer[citizenId].SetWorkplace(citizenId, 0, 0u);
                        }
                        float vitualWorkersRatio = (totalWorkCount != 0) ? (allWorkCount / (float)totalWorkCount) : 1f;

                        //Budget offset for Salary
                        int budget = Singleton<EconomyManager>.instance.GetBudget(buildingData.Info.m_class);
                        salary = (int)(salary * budget / 100f);

                        //LandPrice offset for Salary
                        float landPriceOffset = ProcessSalaryLandPriceAdjust(workBuilding);
                        salary = (int)(salary * landPriceOffset);
                        salary = Math.Max(salary, salaryMax);
#if Debug
                        DebugLog.LogToFileOnly("DebugInfo: LandPrice offset for Salary is " + landPriceOffset.ToString());
#endif
                        if (!checkOnly)
                        {
                            var m_class = Singleton<BuildingManager>.instance.m_buildings.m_buffer[workBuilding].Info.m_class;
                            Singleton<EconomyManager>.instance.FetchResource((EconomyManager.Resource)16, (int)(salary * vitualWorkersRatio), m_class);
                        }
                    }
                }
            }

            return UniqueFacultyAI.IncreaseByBonus(UniqueFacultyAI.FacultyBonus.Science, salary);
        }//public


        public static int TotalWorkCount(ushort buildingID, Building data, bool checkOnly, bool update)
        {
            int totalWorkCount = 0;
            //For performance
#if FASTRUN
            update = false;
#endif
            if (BuildingData.isBuildingWorkerUpdated[buildingID] && !update)
            {
                totalWorkCount = BuildingData.buildingWorkCount[buildingID];
            }
            else
            {
                if (data.Info.m_buildingAI is LandfillSiteAI)
                {
                    LandfillSiteAI buildingAI = data.Info.m_buildingAI as LandfillSiteAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is ExtractingFacilityAI)
                {
                    ExtractingFacilityAI buildingAI = data.Info.m_buildingAI as ExtractingFacilityAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is ProcessingFacilityAI)
                {
                    ProcessingFacilityAI buildingAI = data.Info.m_buildingAI as ProcessingFacilityAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is PoliceStationAI)
                {
                    PoliceStationAI buildingAI = data.Info.m_buildingAI as PoliceStationAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is FireStationAI)
                {
                    FireStationAI buildingAI = data.Info.m_buildingAI as FireStationAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is HospitalAI)
                {
                    HospitalAI buildingAI = data.Info.m_buildingAI as HospitalAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is CargoStationAI)
                {
                    CargoStationAI buildingAI = data.Info.m_buildingAI as CargoStationAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is TransportStationAI)
                {
                    TransportStationAI buildingAI = data.Info.m_buildingAI as TransportStationAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is CemeteryAI)
                {
                    CemeteryAI buildingAI = data.Info.m_buildingAI as CemeteryAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MedicalCenterAI)
                {
                    MedicalCenterAI buildingAI = data.Info.m_buildingAI as MedicalCenterAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MonumentAI)
                {
                    MonumentAI buildingAI = data.Info.m_buildingAI as MonumentAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is DepotAI)
                {
                    DepotAI buildingAI = data.Info.m_buildingAI as DepotAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is HelicopterDepotAI)
                {
                    HelicopterDepotAI buildingAI = data.Info.m_buildingAI as HelicopterDepotAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MaintenanceDepotAI)
                {
                    MaintenanceDepotAI buildingAI = data.Info.m_buildingAI as MaintenanceDepotAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is FirewatchTowerAI)
                {
                    FirewatchTowerAI buildingAI = data.Info.m_buildingAI as FirewatchTowerAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is DoomsdayVaultAI)
                {
                    DoomsdayVaultAI buildingAI = data.Info.m_buildingAI as DoomsdayVaultAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is DisasterResponseBuildingAI)
                {
                    DisasterResponseBuildingAI buildingAI = data.Info.m_buildingAI as DisasterResponseBuildingAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is HadronColliderAI)
                {
                    HadronColliderAI buildingAI = data.Info.m_buildingAI as HadronColliderAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is SchoolAI)
                {
                    SchoolAI buildingAI = data.Info.m_buildingAI as SchoolAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is PowerPlantAI)
                {
                    PowerPlantAI buildingAI = data.Info.m_buildingAI as PowerPlantAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is SnowDumpAI)
                {
                    SnowDumpAI buildingAI = data.Info.m_buildingAI as SnowDumpAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is WarehouseAI)
                {
                    WarehouseAI buildingAI = data.Info.m_buildingAI as WarehouseAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is WaterFacilityAI)
                {
                    WaterFacilityAI buildingAI = data.Info.m_buildingAI as WaterFacilityAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is SaunaAI)
                {
                    SaunaAI buildingAI = data.Info.m_buildingAI as SaunaAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is PostOfficeAI)
                {
                    PostOfficeAI buildingAI = data.Info.m_buildingAI as PostOfficeAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is RadioMastAI)
                {
                    RadioMastAI buildingAI = data.Info.m_buildingAI as RadioMastAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is SpaceElevatorAI)
                {
                    SpaceElevatorAI buildingAI = data.Info.m_buildingAI as SpaceElevatorAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is SpaceRadarAI)
                {
                    SpaceRadarAI buildingAI = data.Info.m_buildingAI as SpaceRadarAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MainIndustryBuildingAI)
                {
                    MainIndustryBuildingAI buildingAI = data.Info.m_buildingAI as MainIndustryBuildingAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is AuxiliaryBuildingAI)
                {
                    AuxiliaryBuildingAI buildingAI = data.Info.m_buildingAI as AuxiliaryBuildingAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is ShelterAI)
                {
                    ShelterAI buildingAI = data.Info.m_buildingAI as ShelterAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is HeatingPlantAI)
                {
                    HeatingPlantAI buildingAI = data.Info.m_buildingAI as HeatingPlantAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MainCampusBuildingAI)
                {
                    MainCampusBuildingAI buildingAI = data.Info.m_buildingAI as MainCampusBuildingAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is MuseumAI)
                {
                    MuseumAI buildingAI = data.Info.m_buildingAI as MuseumAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is UniqueFactoryAI)
                {
                    UniqueFactoryAI buildingAI = data.Info.m_buildingAI as UniqueFactoryAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is UniqueFacultyAI)
                {
                    UniqueFacultyAI buildingAI = data.Info.m_buildingAI as UniqueFacultyAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is VarsitySportsArenaAI)
                {
                    VarsitySportsArenaAI buildingAI = data.Info.m_buildingAI as VarsitySportsArenaAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else if (data.Info.m_buildingAI is LibraryAI)
                {
                    LibraryAI buildingAI = data.Info.m_buildingAI as LibraryAI;
                    totalWorkCount = buildingAI.m_workPlaceCount0 + buildingAI.m_workPlaceCount1 + buildingAI.m_workPlaceCount2 + buildingAI.m_workPlaceCount3;
                }
                else
                {
                    if (!checkOnly)
                    {
                        DebugLog.LogToFileOnly("Error: find unknow building = " + data.Info.m_buildingAI.ToString());
                    }
                }

                BuildingData.isBuildingWorkerUpdated[buildingID] = true;
                BuildingData.buildingWorkCount[buildingID] = totalWorkCount;
            }
            return totalWorkCount;
        }     
    }
}
