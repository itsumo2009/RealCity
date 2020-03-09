﻿namespace RealCity.Util
{
    public class MainDataStore
    {
        //constant
        public const int gameExpenseDivide = 100;
        public const float playerIndustryBuildingProductionSpeedDiv = 1f;
        public const int reduceCargoDiv = 2;
        public const int reduceCargoDivShift = 1;
        public const float profitShareRatioInduLevel1 = 0.010f;
        public const float profitShareRatioInduLevel2 = 0.014f;
        public const float profitShareRatioInduLevel3 = 0.016f;
        public const float profitShareRatioInduOther  = 0.015f;
        public const float profitShareRatioCommLevel1 = 0.005f;
        public const float profitShareRatioCommLevel2 = 0.008f;
        public const float profitShareRatioCommLevel3 = 0.012f;
        public const float profitShareRatioCommECO    = 0.002f;
        public const float profitShareRatioCommOther  = 0.001f;
        public const float profitShareRatioCommTou = 0.0005f;

        public const float bossRatioInduLevel1 = 0.04f;
        public const float bossRatioInduLevel2 = 0.05f;
        public const float bossRatioInduLevel3 = 0.06f;
        public const float bossRatioInduOther = 0.05f;
        public const float bossRatioCommLevel1 = 0.25f;
        public const float bossRatioCommLevel2 = 0.28f;
        public const float bossRatioCommLevel3 = 0.32f;
        public const float bossRatioCommECO = 0.30f;
        public const float bossRatioCommOther = 0.40f;
        public const float bossRatioCommTou = 0.10f;

        public const float investRatioInduLevel1 = 0.0004f;
        public const float investRatioInduLevel2 = 0.0006f;
        public const float investRatioInduLevel3 = 0.0008f;
        public const float investRatioInduOther = 0.007f;
        public const float investRatioCommLevel1 = 0.14f;
        public const float investRatioCommLevel2 = 0.20f;
        public const float investRatioCommLevel3 = 0.26f;
        public const float investRatioCommECO = 0.2f;
        public const float investRatioCommOther = 0.25f;
        public const float investRatioCommTou = 0.01f;

        public const int lowWealth = 20000;
        public const int highWealth = 100000;

        public const int maxGoodPurchase = 500;

        public const byte govermentEducation0SalaryFixed = 20;
        public const byte govermentEducation1SalaryFixed = 25;
        public const byte govermentEducation2SalaryFixed = 35;
        public const byte govermentEducation3SalaryFixed = 50;
        public const ushort comm_high_level1 = 5000;
        public const ushort comm_high_level2 = 10000;
        public const ushort comm_high_level3 = 20000;
        public const ushort comm_low_level1 = 10000;
        public const ushort comm_low_level2 = 20000;
        public const ushort comm_low_level3 = 30000;
        public const ushort comm_tourist = 40000;
        public const ushort comm_leisure = 60000;
        public const ushort comm_eco = 30000;
        public const ushort indu_gen_level1 = 6000;
        public const ushort indu_gen_level2 = 8000;
        public const ushort indu_gen_level3 = 10000;
        public const ushort indu_forest = 8000;
        public const ushort indu_farm = 7000;
        public const ushort indu_oil = 10000;
        public const ushort indu_ore = 9000;
        //public const ushort office_gen_levell = 700;
        //public const ushort office_gen_level2 = 800;
        //public const ushort office_gen_level3 = 1000;
        //public const ushort office_high_tech = 900;

        public const ushort residentLowLevel1Rent = 100;
        public const ushort residentLowLevel2Rent = 150;
        public const ushort residentLowLevel3Rent = 200;
        public const ushort residentLowLevel4Rent = 250;
        public const ushort residentLowLevel5Rent = 300;
        public const ushort residentHighLevel1Rent = 60;
        public const ushort residentHighLevel2Rent = 80;
        public const ushort residentHighLevel3Rent = 100;
        public const ushort residentHighLevel4Rent = 120;
        public const ushort residentHighLevel5Rent = 150;


        //start from V6, goverment salary is floating now
        public static int govermentSalary = 100;

        public static int citizenCount = 0;
        public static int familyCount = 0;
        public static int citizenSalaryPerFamily = 0;
        public static long citizenSalaryTotal = 0;
        public static long citizenSalaryTaxTotal = 0;
        public static long citizenExpensePerFamily = 0;
        public static long citizenExpense = 0;

        public static uint totalCitizenDrivingTime = 0;
        public static uint totalCitizenDrivingTimeFinal = 0;
        public static int unfinishedTransitionLost = 0;
        public static int unfinishedTransitionLostFinal = 0;
        public static int minimumLivingAllowance = 0;
        public static int minimumLivingAllowanceFinal = 0;
        public static long publicTransportFee = 0;
        public static long allTransportFee = 0;
        public static byte citizenAverageTransportFee = 0;

        public static uint level2HighWealth = 0;
        public static uint level1HighWealth = 0;
        public static uint level3HighWealth = 0;
        public static uint familyWeightStableHigh = 0;
        public static uint familyWeightStableLow = 0;

        //3 Govement expense
        //other in-game variable
        public static byte update_money_count = 0;
        public static float current_time = 0f;
        public static float prev_time = 0f;

        //new added
        public static float totalFamilyGoodDemand = 0;



        public static void Save(ref byte[] saveData)
        {
            //all 121
            int i = 0;
            //16
            SaveAndRestore.SaveData(ref i, citizenExpensePerFamily, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenExpense, ref saveData);

            //60
            SaveAndRestore.SaveData(ref i, totalCitizenDrivingTime, ref saveData);
            SaveAndRestore.SaveData(ref i, totalCitizenDrivingTimeFinal, ref saveData);
            SaveAndRestore.SaveData(ref i, publicTransportFee, ref saveData);
            SaveAndRestore.SaveData(ref i, allTransportFee, ref saveData);
            SaveAndRestore.SaveData(ref i, level2HighWealth, ref saveData);
            SaveAndRestore.SaveData(ref i, level1HighWealth, ref saveData);
            SaveAndRestore.SaveData(ref i, level3HighWealth, ref saveData);
            SaveAndRestore.SaveData(ref i, familyWeightStableHigh, ref saveData);
            SaveAndRestore.SaveData(ref i, familyWeightStableLow, ref saveData);
            SaveAndRestore.SaveData(ref i, minimumLivingAllowance, ref saveData);
            SaveAndRestore.SaveData(ref i, minimumLivingAllowanceFinal, ref saveData);
            SaveAndRestore.SaveData(ref i, unfinishedTransitionLost, ref saveData);
            SaveAndRestore.SaveData(ref i, unfinishedTransitionLostFinal, ref saveData);

            //4
            SaveAndRestore.SaveData(ref i, govermentSalary, ref saveData);

            //37
            SaveAndRestore.SaveData(ref i, update_money_count, ref saveData);
            SaveAndRestore.SaveData(ref i, current_time, ref saveData);
            SaveAndRestore.SaveData(ref i, prev_time, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenCount, ref saveData);
            SaveAndRestore.SaveData(ref i, familyCount, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenSalaryPerFamily, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenSalaryTotal, ref saveData);
            SaveAndRestore.SaveData(ref i, citizenSalaryTaxTotal, ref saveData);

            SaveAndRestore.SaveData(ref i, totalFamilyGoodDemand, ref saveData);

            if (i != saveData.Length)
            {
                DebugLog.LogToFileOnly($"MainDataStore Save Error: saveData.Length = {saveData.Length} + i = {i}");
            }
        }

        public static void Load(ref byte[] saveData)
        {
            int i = 0;
            SaveAndRestore.LoadData(ref i, saveData, ref citizenExpensePerFamily);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenExpense);


            SaveAndRestore.LoadData(ref i, saveData, ref totalCitizenDrivingTime);
            SaveAndRestore.LoadData(ref i, saveData, ref totalCitizenDrivingTimeFinal);
            SaveAndRestore.LoadData(ref i, saveData, ref publicTransportFee);
            SaveAndRestore.LoadData(ref i, saveData, ref allTransportFee);
            SaveAndRestore.LoadData(ref i, saveData, ref level2HighWealth);
            SaveAndRestore.LoadData(ref i, saveData, ref level1HighWealth);
            SaveAndRestore.LoadData(ref i, saveData, ref level3HighWealth);
            SaveAndRestore.LoadData(ref i, saveData, ref familyWeightStableHigh);
            SaveAndRestore.LoadData(ref i, saveData, ref familyWeightStableLow);
            SaveAndRestore.LoadData(ref i, saveData, ref minimumLivingAllowance);
            SaveAndRestore.LoadData(ref i, saveData, ref minimumLivingAllowanceFinal);
            SaveAndRestore.LoadData(ref i, saveData, ref unfinishedTransitionLost);
            SaveAndRestore.LoadData(ref i, saveData, ref unfinishedTransitionLostFinal);


            SaveAndRestore.LoadData(ref i, saveData, ref govermentSalary);

            SaveAndRestore.LoadData(ref i, saveData, ref update_money_count);
            SaveAndRestore.LoadData(ref i, saveData, ref current_time);
            SaveAndRestore.LoadData(ref i, saveData, ref prev_time);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenCount);
            SaveAndRestore.LoadData(ref i, saveData, ref familyCount);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenSalaryPerFamily);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenSalaryTotal);
            SaveAndRestore.LoadData(ref i, saveData, ref citizenSalaryTaxTotal);

            SaveAndRestore.LoadData(ref i, saveData, ref totalFamilyGoodDemand);

            //avoid save data error:
            if (MainDataStore.citizenCount != 0)
                MainDataStore.govermentSalary = (int)((MainDataStore.citizenSalaryTotal) / MainDataStore.citizenCount);

            if (MainDataStore.govermentSalary > 100)
                MainDataStore.govermentSalary = 100;

            if (i != saveData.Length)
            {
                DebugLog.LogToFileOnly($"MainDataStore Load Error: saveData.Length = {saveData.Length} + i = {i}");
            }
        }
    }
}
