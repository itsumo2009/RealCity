﻿namespace RealCity.Util
{
    public class MainDataStore
    {

        public static int gameExpenseDivide = 100;
        public const float industialPriceAdjust = 1f;
        public const float commericalPriceAdjust = 2f;
        public static float landPrice = 1f;
        public const byte govermentEducation0Salary = 50;
        public const byte govermentEducation1Salary = 55;
        public const byte govermentEducation2Salary = 65;
        public const byte govermentEducation3Salary = 80;
        public static int citizenCount = 0;
        public static int familyCount = 0;
        public static int citizenSalaryPerFamily = 0;
        public static long citizenSalaryTotal = 0;
        public static long citizenSalaryTaxTotal = 0;
        public const ushort residentLowLevel1Rent = 300;
        public const ushort residentLowLevel2Rent = 420;
        public const ushort residentLowLevel3Rent = 570;
        public const ushort residentLowLevel4Rent = 750;
        public const ushort residentLowLevel5Rent = 1050;
        public const ushort residentHighLevel1Rent = 240;
        public const ushort residentHighLevel2Rent = 330;
        public const ushort residentHighLevel3Rent = 450;
        public const ushort residentHighLevel4Rent = 600;
        public const ushort residentHighLevel5Rent = 780;
        public static long citizenExpensePerFamily = 0;
        public static long citizenExpense = 0;

        public static ushort[] vehicleTransferTime = new ushort[16384];
        public static bool[] isVehicleCharged = new bool[16384];
        public static uint temp_total_citizen_vehical_time = 0;//temp use
        public static uint temp_total_citizen_vehical_time_last = 0;//temp use
        public static uint total_citizen_vehical_time = 0;
        public static long public_transport_fee = 0;
        public static long all_transport_fee = 0;
        public static byte citizen_average_transport_fee = 0;

        //1.3 income-expense
        public static float[] family_money = new float[524288];
        public static ushort[] familyGoods = new ushort[524288];
        public static uint family_profit_money_num = 0;
        public static uint family_loss_money_num = 0;
        public static uint family_very_profit_money_num = 0;
        public static uint family_weight_stable_high = 0;
        public static uint family_weight_stable_low = 0;


        //2 building
        //2.1 building expense

        public const byte comm_high_level1 = 20;
        public const byte comm_high_level2 = 25;
        public const byte comm_high_level3 = 30;

        public const byte comm_low_level1 = 30;
        public const byte comm_low_level2 = 35;
        public const byte comm_low_level3 = 40;

        public const byte comm_tourist = 100;
        public const byte comm_leisure = 50;
        public const byte comm_eco = 45;

        public const byte indu_gen_level1 = 10;
        public const byte indu_gen_level2 = 15;
        public const byte indu_gen_level3 = 20;

        public const byte indu_forest = 10;
        public const byte indu_farm = 15;
        public const byte indu_oil = 20;
        public const byte indu_ore = 20;

        public const byte office_gen_levell = 190;
        public const byte office_gen_level2 = 210;
        public const byte office_gen_level3 = 240;

        public const byte office_high_tech = 255;


        //2.3 process building 
        public static float[] building_money = new float[49152];
        //move to buildingAI



        //3 govement expense
        public static int minimumLivingAllowance = 0;
        public static int resettlement = 0;
        public static int minimumLivingAllowanceFinal = 0;
        public static int resettlementFinal = 0;


        //public static int HealthCare = 0;
        public static int PoliceDepartment = 0;
        public static int Education = 0;
        public static int Monument = 0;
        public static int FireDepartment = 0;
        public static int Disaster = 0;
        public static int PublicTransport_bus = 0;
        public static int PublicTransport_tram = 0;
        public static int PublicTransport_ship = 0;
        public static int PublicTransport_train = 0;
        public static int PublicTransport_plane = 0;
        public static int PublicTransport_metro = 0;
        public static int PublicTransport_taxi = 0;
        public static int PublicTransport_cablecar = 0;

        //4 outside connection
        public static byte outside_situation_index = 0;
        //other in-game variable
        public static byte update_money_count = 0;
        public static bool is_updated = false;
        public static float current_time = 0f;
        public static float prev_time = 0f;
        public static ushort last_buildingid = 0;
        public static uint last_citizenid = 0;

        public static long temp_public_transport_fee = 0;
        public static byte lastLanguage = 255;

        public static bool notUsed = false;
        public static bool isHellMode = false;

        public static ushort Extractor_building = 0;
        public static ushort Extractor_building_final = 0;

        //public static ushort tourist_num = 0;
        //public static ushort tourist_num_final = 0;

        //public static long tourist_transport_fee_num = 0;
        //public static long tourist_transport_fee_num_final = 0;

        public static bool is_weekend = false;
        public static bool have_toll_station = false;
        public static bool haveCityResourceDepartment = false;

        public static bool isFoodsGetted = false;
        public static bool isCoalsGetted = false;
        public static bool isLumbersGetted = false;
        public static bool isPetrolsGetted = false;
        public static bool isFoodsGettedFinal = false;
        public static bool isCoalsGettedFinal = false;
        public static bool isLumbersGettedFinal = false;
        public static bool isPetrolsGettedFinal = false;
        public static int allFoods = 0;
        public static int allLumbers = 0;
        public static int allPetrols = 0;
        public static int allCoals = 0;
        public static ushort allVehicles = 0;
        public static ushort allVehiclesFinal = 0;

        // reserved some for futher used
        public static int[] building_buffer1 = new int[49152];
        public static ushort[] building_buffer2 = new ushort[49152];
        public static ushort[] building_buffer3 = new ushort[49152];
        public static ushort[] building_buffer4 = new ushort[49152];

        public static int allFoodsFinal = 0;
        public static int allLumbersFinal = 0;
        public static int allPetrolsFinal = 0;
        public static int allCoalsFinal = 0;

        public static bool haveCityResourceDepartmentFinal = false;
        

        public static bool[] isBuildingWorkerUpdated = new bool[49152];
        public static bool[] isBuildingReleased = new bool[49152];

        //public static byte[] saveData = new byte[2867364];
        public static byte[] saveData = new byte[3932402];
        public static float[] citizenMoney = new float[1048576];
        public static byte[] saveData1 = new byte[4194304];

        public static bool[] isCitizenFirstMovingIn = new bool[1048576];
        public static byte[] saveData2 = new byte[1048576];
        //public static byte[] saveData = new byte[3063935];


        public static void data_init()
        {
            for (int i = 0; i < MainDataStore.building_buffer1.Length; i++)
            {
                building_money[i] = 0;
                building_buffer2[i] = 0;
                building_buffer1[i] = 0;
                building_buffer3[i] = 0;
                building_buffer4[i] = 0;
                isBuildingWorkerUpdated[i] = false;
                isBuildingReleased[i] = false;
            }

            for (int i = 0; i < MainDataStore.isVehicleCharged.Length; i++)
            {
                vehicleTransferTime[i] = 0;
                isVehicleCharged[i] = false;
            }
            for (int i = 0; i < MainDataStore.family_money.Length; i++)
            {
                family_money[i] = 0f;
                familyGoods[i] = 0;
            }
            for (int i = 0; i < MainDataStore.citizenMoney.Length; i++)
            {
                citizenMoney[i] = 0f;
                isCitizenFirstMovingIn[i] = false;
            }
        }

        public static void save()
        {
            int i = 0;

            // 2*8 + 2*16384 + 16384 + 3*4 + 2*8 = 49196
            SaveAndRestore.save_long(ref i, citizenExpensePerFamily, ref saveData);
            SaveAndRestore.save_long(ref i, citizenExpense, ref saveData);
            SaveAndRestore.save_ushorts(ref i, vehicleTransferTime, ref saveData);
            SaveAndRestore.save_bools(ref i, isVehicleCharged, ref saveData);
            SaveAndRestore.save_uint(ref i, temp_total_citizen_vehical_time, ref saveData);
            SaveAndRestore.save_uint(ref i, temp_total_citizen_vehical_time_last, ref saveData);
            SaveAndRestore.save_uint(ref i, total_citizen_vehical_time, ref saveData);
            SaveAndRestore.save_long(ref i, public_transport_fee, ref saveData);
            SaveAndRestore.save_long(ref i, all_transport_fee, ref saveData);

            // (4+1)*524288 = 2621440       // 2670636
            SaveAndRestore.save_floats(ref i, family_money, ref saveData);
            //saveandrestore.save_bytes(ref i, citizen_very_profit_time_num, ref saveData);
            SaveAndRestore.save_ushorts(ref i, familyGoods, ref saveData);
            //saveandrestore.save_bytes(ref i, citizen_loss_time_num, ref saveData);

            //5*4 = 20      //2670656
            SaveAndRestore.save_uint(ref i, family_profit_money_num, ref saveData);
            SaveAndRestore.save_uint(ref i, family_loss_money_num, ref saveData);
            SaveAndRestore.save_uint(ref i, family_very_profit_money_num, ref saveData);
            SaveAndRestore.save_uint(ref i, family_weight_stable_high, ref saveData);
            SaveAndRestore.save_uint(ref i, family_weight_stable_low, ref saveData);

            //49152*2 = 196608  // 2867264
            SaveAndRestore.save_floats(ref i, building_money, ref saveData);

            //20*4 = 80    //2867344
            SaveAndRestore.save_int(ref i, gameExpenseDivide, ref saveData);
            SaveAndRestore.save_int(ref i, minimumLivingAllowance, ref saveData);
            SaveAndRestore.save_int(ref i, resettlement, ref saveData);
            SaveAndRestore.save_int(ref i, minimumLivingAllowanceFinal, ref saveData);
            SaveAndRestore.save_int(ref i, resettlementFinal, ref saveData);
            SaveAndRestore.save_float(ref i, landPrice, ref saveData);
            SaveAndRestore.save_int(ref i, PoliceDepartment, ref saveData);
            SaveAndRestore.save_int(ref i, Education, ref saveData);
            SaveAndRestore.save_int(ref i, Monument, ref saveData);
            SaveAndRestore.save_int(ref i, FireDepartment, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_bus, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_tram, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_ship, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_plane, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_metro, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_train, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_taxi, ref saveData);
            SaveAndRestore.save_int(ref i, PublicTransport_cablecar, ref saveData);
            SaveAndRestore.save_int(ref i, Disaster, ref saveData);

            //11      //2867355
            SaveAndRestore.save_byte(ref i, outside_situation_index, ref saveData);
            SaveAndRestore.save_byte(ref i, update_money_count, ref saveData);
            SaveAndRestore.save_bool(ref i, is_updated, ref saveData);
            SaveAndRestore.save_float(ref i, current_time, ref saveData);
            SaveAndRestore.save_float(ref i, prev_time, ref saveData);

            //28       //2867397
            SaveAndRestore.save_int(ref i, citizenCount, ref saveData);
            SaveAndRestore.save_int(ref i, familyCount, ref saveData);
            SaveAndRestore.save_int(ref i, citizenSalaryPerFamily, ref saveData);
            SaveAndRestore.save_long(ref i, citizenSalaryTotal, ref saveData);
            SaveAndRestore.save_long(ref i, citizenSalaryTaxTotal, ref saveData);

            //9        //2867406
            SaveAndRestore.save_long(ref i, temp_public_transport_fee, ref saveData);
            byte tmp = 0;
            SaveAndRestore.save_byte(ref i, tmp, ref saveData);

            //32 + 2 + 7 + 16 + 4 = 61     //2867467

            SaveAndRestore.save_bool(ref i, notUsed, ref saveData);
            SaveAndRestore.save_bool(ref i, isHellMode, ref saveData);
            SaveAndRestore.save_bool(ref i, isCoalsGetted, ref saveData);
            SaveAndRestore.save_bool(ref i, isFoodsGetted, ref saveData);
            SaveAndRestore.save_bool(ref i, isLumbersGetted, ref saveData);
            SaveAndRestore.save_bool(ref i, isPetrolsGetted, ref saveData);
            SaveAndRestore.save_bool(ref i, isCoalsGettedFinal, ref saveData);
            SaveAndRestore.save_bool(ref i, isFoodsGettedFinal, ref saveData);
            SaveAndRestore.save_bool(ref i, isLumbersGettedFinal, ref saveData);
            SaveAndRestore.save_bool(ref i, isPetrolsGettedFinal, ref saveData);
            SaveAndRestore.save_int(ref i, allCoals, ref saveData);
            SaveAndRestore.save_int(ref i, allFoods, ref saveData);
            SaveAndRestore.save_int(ref i, allLumbers, ref saveData);
            SaveAndRestore.save_int(ref i, allPetrols, ref saveData);
            SaveAndRestore.save_ushort(ref i, allVehicles, ref saveData);
            SaveAndRestore.save_ushort(ref i, allVehiclesFinal, ref saveData);


            // 16 + 4 + 4 + 16 + 1 + 12 + 26 = 79    //2867546
            SaveAndRestore.save_ushort(ref i, Extractor_building, ref saveData);
            SaveAndRestore.save_ushort(ref i, Extractor_building_final, ref saveData);

            //saveandrestore.save_ushort(ref i, tourist_num, ref saveData);
            //saveandrestore.save_ushort(ref i, tourist_num_final, ref saveData);

            //saveandrestore.save_long(ref i, tourist_transport_fee_num, ref saveData);
            //saveandrestore.save_long(ref i, tourist_transport_fee_num_final, ref saveData);


            SaveAndRestore.save_bool(ref i, is_weekend, ref saveData);



            // 4 + 8 + 5 + 2 + 8 =27
            SaveAndRestore.save_bool(ref i, have_toll_station, ref saveData);
            SaveAndRestore.save_bool(ref i, haveCityResourceDepartment, ref saveData);
            SaveAndRestore.save_ints(ref i, building_buffer1, ref saveData);
            SaveAndRestore.save_ushorts(ref i, building_buffer2, ref saveData);
            SaveAndRestore.save_ushorts(ref i, building_buffer3, ref saveData);
            SaveAndRestore.save_ushorts(ref i, building_buffer4, ref saveData);

            SaveAndRestore.save_int(ref i, allFoodsFinal, ref saveData);
            SaveAndRestore.save_int(ref i, allLumbersFinal, ref saveData);
            SaveAndRestore.save_int(ref i, allPetrolsFinal, ref saveData);
            SaveAndRestore.save_int(ref i, allCoalsFinal, ref saveData);

            SaveAndRestore.save_bool(ref i, haveCityResourceDepartmentFinal, ref saveData);
            SaveAndRestore.save_bools(ref i, isBuildingWorkerUpdated, ref saveData);


            DebugLog.LogToFileOnly("(save)saveData in comm_data is " + i.ToString());

            i = 0;
            SaveAndRestore.save_floats(ref i, citizenMoney, ref saveData1);

            i = 0;
            SaveAndRestore.save_bools(ref i, isCitizenFirstMovingIn, ref saveData1);
        }

        public static void load()
        {
            int i = 0;
            citizenExpensePerFamily = SaveAndRestore.load_long(ref i, saveData);
            citizenExpense = SaveAndRestore.load_long(ref i, saveData);
            vehicleTransferTime = SaveAndRestore.load_ushorts(ref i, saveData, vehicleTransferTime.Length);
            isVehicleCharged = SaveAndRestore.load_bools(ref i, saveData, isVehicleCharged.Length);
            temp_total_citizen_vehical_time = SaveAndRestore.load_uint(ref i, saveData);
            temp_total_citizen_vehical_time_last = SaveAndRestore.load_uint(ref i, saveData);
            total_citizen_vehical_time = SaveAndRestore.load_uint(ref i, saveData);
            public_transport_fee = SaveAndRestore.load_long(ref i, saveData);
            all_transport_fee = SaveAndRestore.load_long(ref i, saveData);
            family_money = SaveAndRestore.load_floats(ref i, saveData, family_money.Length);
            familyGoods = SaveAndRestore.load_ushorts(ref i, saveData, familyGoods.Length);
            family_profit_money_num = SaveAndRestore.load_uint(ref i, saveData);
            family_loss_money_num = SaveAndRestore.load_uint(ref i, saveData);
            family_very_profit_money_num = SaveAndRestore.load_uint(ref i, saveData);
            family_weight_stable_high = SaveAndRestore.load_uint(ref i, saveData);
            family_weight_stable_low = SaveAndRestore.load_uint(ref i, saveData);
            building_money = SaveAndRestore.load_floats(ref i, saveData, building_money.Length);
            gameExpenseDivide = SaveAndRestore.load_int(ref i, saveData);
            if (gameExpenseDivide == 0)
            {
                gameExpenseDivide = 1;
            }
            minimumLivingAllowance = SaveAndRestore.load_int(ref i, saveData);
            resettlement = SaveAndRestore.load_int(ref i, saveData);
            minimumLivingAllowanceFinal = SaveAndRestore.load_int(ref i, saveData);
            resettlementFinal = SaveAndRestore.load_int(ref i, saveData);
            landPrice = SaveAndRestore.load_float(ref i, saveData);
            PoliceDepartment = SaveAndRestore.load_int(ref i, saveData);
            Education = SaveAndRestore.load_int(ref i, saveData);
            Monument = SaveAndRestore.load_int(ref i, saveData);
            FireDepartment = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_bus = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_tram = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_ship = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_plane = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_metro = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_train = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_taxi = SaveAndRestore.load_int(ref i, saveData);
            PublicTransport_cablecar = SaveAndRestore.load_int(ref i, saveData);
            Disaster = SaveAndRestore.load_int(ref i, saveData);
            outside_situation_index = SaveAndRestore.load_byte(ref i, saveData);
            update_money_count = SaveAndRestore.load_byte(ref i, saveData);
            is_updated = SaveAndRestore.load_bool(ref i, saveData);
            is_updated = false;
            current_time = SaveAndRestore.load_float(ref i, saveData);
            prev_time = SaveAndRestore.load_float(ref i, saveData);
            citizenCount = SaveAndRestore.load_int(ref i, saveData);
            familyCount = SaveAndRestore.load_int(ref i, saveData);
            citizenSalaryPerFamily = SaveAndRestore.load_int(ref i, saveData);
            citizenSalaryTotal = SaveAndRestore.load_long(ref i, saveData);
            citizenSalaryTaxTotal = SaveAndRestore.load_long(ref i, saveData);
            temp_public_transport_fee = SaveAndRestore.load_long(ref i, saveData);
            byte tmp = SaveAndRestore.load_byte(ref i, saveData);
            notUsed = SaveAndRestore.load_bool(ref i, saveData);
            isHellMode = SaveAndRestore.load_bool(ref i, saveData);
            isCoalsGetted = SaveAndRestore.load_bool(ref i, saveData);
            isFoodsGetted = SaveAndRestore.load_bool(ref i, saveData);
            isLumbersGetted = SaveAndRestore.load_bool(ref i, saveData);
            isPetrolsGetted = SaveAndRestore.load_bool(ref i, saveData);
            isCoalsGettedFinal = SaveAndRestore.load_bool(ref i, saveData);
            isFoodsGettedFinal = SaveAndRestore.load_bool(ref i, saveData);
            isLumbersGettedFinal = SaveAndRestore.load_bool(ref i, saveData);
            isPetrolsGettedFinal = SaveAndRestore.load_bool(ref i, saveData);
            allCoals = SaveAndRestore.load_int(ref i, saveData);
            allFoods = SaveAndRestore.load_int(ref i, saveData);
            allLumbers = SaveAndRestore.load_int(ref i, saveData);
            allPetrols = SaveAndRestore.load_int(ref i, saveData);
            allVehicles = SaveAndRestore.load_ushort(ref i, saveData);
            allVehiclesFinal = SaveAndRestore.load_ushort(ref i, saveData);
            Extractor_building = SaveAndRestore.load_ushort(ref i, saveData);
            Extractor_building_final = SaveAndRestore.load_ushort(ref i, saveData);
            is_weekend = SaveAndRestore.load_bool(ref i, saveData);
            have_toll_station = SaveAndRestore.load_bool(ref i, saveData);
            haveCityResourceDepartment = SaveAndRestore.load_bool(ref i, saveData);
            building_buffer1 = SaveAndRestore.load_ints(ref i, saveData, building_buffer1.Length);
            building_buffer2 = SaveAndRestore.load_ushorts(ref i, saveData, building_buffer2.Length);
            building_buffer3 = SaveAndRestore.load_ushorts(ref i, saveData, building_buffer3.Length);
            building_buffer4 = SaveAndRestore.load_ushorts(ref i, saveData, building_buffer4.Length);
            allCoalsFinal = SaveAndRestore.load_int(ref i, saveData);
            allFoodsFinal = SaveAndRestore.load_int(ref i, saveData);
            allLumbersFinal = SaveAndRestore.load_int(ref i, saveData);
            allPetrolsFinal = SaveAndRestore.load_int(ref i, saveData);
            haveCityResourceDepartmentFinal = SaveAndRestore.load_bool(ref i, saveData);
            isBuildingWorkerUpdated = SaveAndRestore.load_bools(ref i, saveData, isBuildingWorkerUpdated.Length);
            DebugLog.LogToFileOnly("saveData in MainDataStore is " + i.ToString());
        }

        public static void load1()
        {
            int i = 0;
            citizenMoney = SaveAndRestore.load_floats(ref i, saveData1, citizenMoney.Length);
            DebugLog.LogToFileOnly("saveData1 in MainDataStore is " + i.ToString());
        }

        public static void load2()
        {
            int i = 0;
            isCitizenFirstMovingIn = SaveAndRestore.load_bools(ref i, saveData1, isCitizenFirstMovingIn.Length);
            DebugLog.LogToFileOnly("saveData2 in MainDataStore is " + i.ToString());
        }
    }
}