using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    // $G$ DSN-999 (-5) The component that creates the vehicles belongs to the logic

    // $G$ CSS-999 (-3) The Class must have an access modifier.
    class VehicleFactory
    {
        public static Vehicle BuildVehicle(eVehicleTypes i_VehicleTypes, string i_ModelName, string i_RegNumber, float i_PrecentageLeft)
        {
            eVehicleColor vehicleColor;
            eDoorsNumber doorsNumber;
            eLicenseType licenseType;
            int engineCapacity;
            Vehicle vehicle = null;

            switch (i_VehicleTypes)
            {
                case eVehicleTypes.RegularMotorCycle:
                    List<Wheel> wheelsForRegularMotorcycle = GetwheelsList(2, 30f);
                    Engine regularMotorcycleEngine = GetRegularEngine(eFuelType.Octan98, 6f);
                    licenseType = GetLicenseType();
                    engineCapacity = GetEngineCapacity();
                    vehicle = new Motorcycle(i_ModelName, i_RegNumber, i_PrecentageLeft, wheelsForRegularMotorcycle,
                                             regularMotorcycleEngine, licenseType, engineCapacity);
                    break;
                case eVehicleTypes.ElectricMotorCycle:
                    List<Wheel> wheelsForElectricMotorcycle = GetwheelsList(2, 30f);
                    Engine electricMotorcycleEngine = GetElectricEngine(1.8f);
                    licenseType = GetLicenseType();
                    engineCapacity = GetEngineCapacity();
                    vehicle = new Motorcycle(i_ModelName, i_RegNumber, i_PrecentageLeft, wheelsForElectricMotorcycle,
                                             electricMotorcycleEngine, licenseType, engineCapacity);
                    break;
                case eVehicleTypes.ElectricCar:
                    List<Wheel> wheelsForElectricCar = GetwheelsList(4, 32f);
                    Engine ElectricCarEngine = GetElectricEngine(3.2f);
                    vehicleColor = GetVehicleColor();
                    doorsNumber = GetDoorsNumber();
                    vehicle = new Car(i_ModelName, i_RegNumber, i_PrecentageLeft, wheelsForElectricCar,
                                      ElectricCarEngine, vehicleColor, doorsNumber);
                    break;
                case eVehicleTypes.RegularCar:
                    List<Wheel> wheelsForRegularCar = GetwheelsList(4, 32f);
                    Engine RegularCarEngine = GetRegularEngine(eFuelType.Octan95, 45f);
                    vehicleColor = GetVehicleColor();
                    doorsNumber = GetDoorsNumber();
                    vehicle = new Car(i_ModelName, i_RegNumber, i_PrecentageLeft, wheelsForRegularCar,
                                      RegularCarEngine, vehicleColor, doorsNumber);
                    break;

                case eVehicleTypes.Truck:
                    List<Wheel> wheelsForTruck = GetwheelsList(16, 26f);
                    Engine truckEngine = GetRegularEngine(eFuelType.Soler, 120f);
                    bool isDangerous = IsDangerous();
                    float maximalCarryingWheight = MaximalCarryingWheight();
                    vehicle = new Truck(i_ModelName, i_RegNumber, i_PrecentageLeft, wheelsForTruck,
                                        truckEngine, isDangerous, maximalCarryingWheight);
                    break;
            }

            return vehicle;
        }
        public static float MaximalCarryingWheight()
        {
            Console.WriteLine("enter maximal carrying wheight: ");
            float maximalCarryingWheight = float.Parse(Console.ReadLine());

            return maximalCarryingWheight;
        }
        public static bool IsDangerous()
        {
            bool isDangerous;
            Console.WriteLine("is your truck carrying danerous material? 1 = yes | 0 = no ");
            int input = int.Parse(Console.ReadLine());
            if (input == 1)
            { isDangerous = true; }
            else if (input == 0)
            {
                isDangerous = false;
            }
            else
            {
                throw new ArgumentException("Error: input must be either 1 or zero");
            }

            return isDangerous;
        }
        public static int GetEngineCapacity()
        {
            Console.WriteLine("Please enter engine capacity: ");
            int engineCapacity = int.Parse(Console.ReadLine());
            if (engineCapacity < 0)
            {
                throw new ValueOutOfRangeException("Error: engine capacity must be positive number");
            }

            return engineCapacity;
        }
        public static eLicenseType GetLicenseType()
        {
            Console.WriteLine("Please enter license type: 1 = A | 2 = B1 | 3  = AA | 4 = BB");

            int input = int.Parse(Console.ReadLine());
            eLicenseType licenseType;
            licenseType = (eLicenseType)input;

            switch (licenseType)
            {
                case eLicenseType.A:
                    licenseType = eLicenseType.A;
                    break;
                case eLicenseType.B1:
                    licenseType = eLicenseType.B1;
                    break;
                case eLicenseType.AA:
                    licenseType = eLicenseType.AA;
                    break;
                case eLicenseType.BB:
                    licenseType = eLicenseType.BB;
                    break;
                default:
                    throw new ArgumentException("Error: license type is out of options (1-4)");

            }

            return licenseType;
        }
        public static eDoorsNumber GetDoorsNumber()
        {
            Console.WriteLine("Please enter your number of doors: 2 | 3 | 4 | 5");

            int input = int.Parse(Console.ReadLine());
            eDoorsNumber doorsNumber;
            doorsNumber = (eDoorsNumber)input;

            switch (doorsNumber)
            {
                case eDoorsNumber.TwoDoors:
                    doorsNumber = eDoorsNumber.TwoDoors;
                    break;
                case eDoorsNumber.ThreeDoors:
                    doorsNumber = eDoorsNumber.ThreeDoors;
                    break;
                case eDoorsNumber.FourDoors:
                    doorsNumber = eDoorsNumber.FourDoors;
                    break;
                case eDoorsNumber.FiveDoors:
                    doorsNumber = eDoorsNumber.FiveDoors;
                    break;
                default:
                    throw new ArgumentException("Error: number of doors is out of options (1-4)");
            }

            return doorsNumber;
        }
        public static eVehicleColor GetVehicleColor()
        {
            Console.WriteLine("Please enter your Vehicle color: Red = 1 | Silver = 2 | White = 3 | Black = 4");

            int input = int.Parse(Console.ReadLine());
            eVehicleColor vehicleColor;
            vehicleColor = (eVehicleColor)input;

            switch (vehicleColor)
            {
                case eVehicleColor.Red:
                    vehicleColor = eVehicleColor.Red;
                    break;
                case eVehicleColor.Silver:
                    vehicleColor = eVehicleColor.Silver;
                    break;
                case eVehicleColor.White:
                    vehicleColor = eVehicleColor.White;
                    break;
                case eVehicleColor.Black:
                    vehicleColor = eVehicleColor.Black;
                    break;
                default:
                    throw new ArgumentException("Error: vehicle color is out of options (1-4)");

            }

            return vehicleColor;
        }
        public static List<Wheel> GetwheelsList(int i_NumberOfWheels, float i_MaxAirPressure)
        {
            Console.WriteLine("Please enter manufactor wheels name ");
            string manufactorWheelsName = Console.ReadLine();
            if (!(manufactorWheelsName.All(char.IsLetter)))
            {
                throw new FormatException("Error: all elements in manufactor wheel name must be letters");
            }

            Console.WriteLine("Please enter current air pressure ");
            float currAirPressure = float.Parse(Console.ReadLine());
            if (currAirPressure < 0 || currAirPressure > i_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Error: air pressure must be between zero and max possible pressure");
            }

            List<Wheel> forMotorcycle = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                forMotorcycle.Add(new Wheel(manufactorWheelsName, currAirPressure, 30));
            }

            return forMotorcycle;
        }

        // $G$ CSS-013 (-3) Bad variable name (should be in the form of: i_CamelCase).
        public static Engine GetElectricEngine(float i_maxBatteryTime)
        {
            Console.WriteLine("Please enter battery time left: ");
            float batteryTimeLeft = float.Parse(Console.ReadLine());
            if (batteryTimeLeft < 0)
            {
                throw new ValueOutOfRangeException("Error: battery time left can't be negative value");
            }

            Engine engine = new ElectricEngine(batteryTimeLeft, 1.8f);

            return engine;
        }

        public static Engine GetRegularEngine(eFuelType i_FuelType, float i_AmountOfFuel)
        {
            Console.WriteLine("Please enter current amount of fuel: ");
            float currentFuel = float.Parse(Console.ReadLine());
            if (currentFuel < 0)
            {
                throw new ValueOutOfRangeException("Error: current amount of can't be negative value");
            }

            Engine engine = new FuelEngine(i_FuelType, currentFuel, i_AmountOfFuel);

            return engine;
        }
    }
}
