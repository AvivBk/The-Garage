using System;
using System.Collections.Generic;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class Gui
    {
        public static void PrintMenu()
        {
            Console.WriteLine("Welcome To The Garage");
            Console.WriteLine("Please choose from the options below:");
            Console.WriteLine("1 - Add a new vehicle");
            Console.WriteLine("2 - Show all registrations numbers in garage");
            Console.WriteLine("3 - Change a state of a vehicle");
            Console.WriteLine("4 - Fill air to a vehicle to a maximum pressure");
            Console.WriteLine("5 - Fill fuel to a fuel type engine car");
            Console.WriteLine("6 - Charge energy to an electric engine type of car");
            Console.WriteLine("7 - Show vehicle details");
            Console.WriteLine("8 - Exit");
        }
        // $G$ CSS-999 (-3) Missing blank line
        public static eVehicleTypes GetVehicleType()
        {
            Console.WriteLine("Which type of vehicle would you like to add?");
            Console.WriteLine("1 - Regular Motorcycle");
            Console.WriteLine("2 - Electric Motorcycle");
            Console.WriteLine("3 - Regular car");
            Console.WriteLine("4 - Electric car");
            Console.WriteLine("5 - Truck");

            int pick = Convert.ToInt32(Console.ReadLine());
            if (pick < 1 || pick > 5)
            {
                throw new ValueOutOfRangeException("Error: in vehicle type, argument must be between 1 to 5");
            }

            eVehicleTypes menuChoice;
            menuChoice = (eVehicleTypes)pick;
            return menuChoice;

        }
        public static GarageItem GetGarageItem()
        {
            Console.WriteLine("What is your name?");
            string ownerName = Console.ReadLine();
            if(!(ownerName.All(char.IsLetter)))
            {
                throw new FormatException("Error: all elements in owner name must be letters");
            }

            Console.WriteLine("What is your phone number?");
            string ownerNumber = Console.ReadLine();
            if (!(ownerNumber.All(char.IsDigit)))
            {
                throw new FormatException("Error: all elements in owner phone number must be numbers");
            }

            eVehicleTypes vehicleTypes = GetVehicleType();

            Vehicle vehicle = GetVehicle(vehicleTypes);

            GarageItem garageItem = new GarageItem(ownerName, ownerNumber, vehicle);

            return garageItem;
        }

        // $G$ CSS-013 (-3) Bad variable name (should be in the form of: i_CamelCase).
        public static Vehicle GetVehicle(eVehicleTypes VehicleTypes)
        {

            Console.WriteLine("Please enter model name: ");
            string modelName = Console.ReadLine();
            if (!(modelName.All(char.IsLetter)))
            {
                throw new FormatException("Error: all elements in model name must be letters");
            }

            Console.WriteLine("Please enter registration number: ");
            string regNumber = Console.ReadLine();
            if (!(regNumber.All(char.IsDigit)))
            {
                throw new FormatException("Error: all elements in registration number must be numbers");
            }

            Console.WriteLine("Please enter percentage of energy left: ");
            float precentageLeft = float.Parse(Console.ReadLine());
            if (precentageLeft < 0 || precentageLeft > 100)
            {
                throw new ValueOutOfRangeException("Error: percentage value must be between 0 to 100");
            }

           return VehicleFactory.BuildVehicle(VehicleTypes, modelName, regNumber, precentageLeft);

        }
        
        public static string GetRegNumber()
        {
            Console.WriteLine("Please enter the Reg number to update : ");
            return Console.ReadLine();
        }

        public static eVehicleState GetVehicleState() 
        {
            Console.WriteLine("Please enter the vehicle state  : 1 = In Repair, 2 =  Repaired, 3= Paid");
            int res = int.Parse(Console.ReadLine());
            eVehicleState val = (eVehicleState)res;
            switch (val)
            {
                case eVehicleState.InRepair:
                    val = eVehicleState.InRepair;
                    break;
                case eVehicleState.Repaired:
                    val = eVehicleState.Repaired;
                    break;
                case eVehicleState.Paid:
                    val = eVehicleState.Paid;
                    break;
            }
            return val;
        }
        public static void ChangeStateVerification(GarageItem i_Curr)
        {
            if (i_Curr != null)
            {
                string output2 = string.Format("vehicle number :{0} " + Environment.NewLine +
                                               "changed To :{1}" + Environment.NewLine,
                    i_Curr.Vehicle.RegNumber, i_Curr.State);
                Console.WriteLine(output2);
            }
            else
            {
                Console.WriteLine("Cannot find Vehicle ");
            }

            Console.ReadKey();
        }
        public static float GetAmountToFillWheels()
        {
            Console.WriteLine("please enter the amount of pressure  you would like to fill up : ");
            float res = float.Parse(Console.ReadLine());
            return res; 
        }
        public static float GetAmountToChargeBattery()
        {
            Console.WriteLine("please enter the time (in hours) you would like to fill up :");
            float res = float.Parse(Console.ReadLine());
            return res; 
        }

        // $G$ CSS-015 (-3) Bad variable name (should be in the form of: ref io_CamelCase).
        public static eFuelType GetFuelTypeAndAmount(ref float r_Amount)
        {
            Console.WriteLine("please enter the fuel type you would like to fill up :");
            Console.WriteLine("0 = Solar, 1 = octan 95 , 2 = octan 96, 3 = octan 98");
            int input = int.Parse(Console.ReadLine());
            eFuelType fuel = (eFuelType) input;

            switch (fuel)
            {
                case eFuelType.Octan95:
                    fuel = eFuelType.Octan95;
                    break;
                case eFuelType.Octan96:
                    fuel = eFuelType.Octan96;
                    break;
                case eFuelType.Octan98:
                    fuel = eFuelType.Octan98;
                    break;
            }
            Console.WriteLine("please enter the amount of fuel to fill up in litters (?) :");
            r_Amount = float.Parse(Console.ReadLine());
            return fuel;
        }
        public static void FillAirVerification(GarageItem i_Curr)
        {
            if (i_Curr != null)
            {
                float temp = i_Curr.Vehicle.Wheels[0].AirPressure;
                string output = string.Format("vehicle number :{0} " + Environment.NewLine +
                                              "all wheels as filled to : {1}" + Environment.NewLine,
                                                i_Curr.Vehicle.RegNumber,temp);
                Console.WriteLine(output);
            }
            else
            {
                Console.WriteLine("Cannot find Vehicle ");
            }
            Console.ReadKey();
        }

        public static void AddVehicleVerification(GarageItem i_Curr, bool res)
        {
            string output = "";
            if (res)
            {
                 output +=
                    string.Format("Hi {0}" + Environment.NewLine + "vehicle reg number : {1}  added Successfully "+Environment.NewLine,
                        i_Curr.OwnerName, i_Curr.Vehicle.RegNumber);
            }
            else
            {
                output += (" failed ");
            }
            Console.WriteLine(output);
            Console.ReadKey();
        }

        public static void Done()
        {
            Console.WriteLine("Done ! "+ Environment.NewLine+"press enther to continue..");
            Console.ReadKey();
        }

        public static int UserChoosingMessage(string i_ToAskFor)
        {
            Console.WriteLine(i_ToAskFor);
            int UserChose = int.Parse(Console.ReadLine());
            return UserChose;
        }
       
        public static void MyWriteLine(string i_ToPrint)
        {
            Console.WriteLine(i_ToPrint);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
