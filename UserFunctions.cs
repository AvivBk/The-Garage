using System;
using System.Threading;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserFunctions
    {

        // $G$ NTT-999 (-3) This kind of field should be readonly.
        private Garage m_Garage;

        public UserFunctions()
        {
            m_Garage = new Garage();
        }
        public void ExecuteMenu()
        {

            Gui.PrintMenu();
            int pick = Convert.ToInt32(Console.ReadLine());
            eMenuOptions menuChoice;
            menuChoice = (eMenuOptions)pick;

            while (menuChoice != eMenuOptions.exit)
            {
                try
                {
                    switch (menuChoice)
                    {
                        case eMenuOptions.AddVehicle:
                            addVehicleNavigator();
                            break;
                        case eMenuOptions.ShowAllReg:
                            showAllRegsNavigator();
                            break;
                        case eMenuOptions.ChangeStateOfVehicle:
                            changeStateNavigator();
                            break;
                        case eMenuOptions.FillAirToMax:
                            fillAirNavigator();
                            break;
                        case eMenuOptions.FillFuel:
                            fillFuelNavigator();
                            break;
                        case eMenuOptions.ChargeEnergy:
                            chargeBatteryNavigator();
                            break;
                        case eMenuOptions.ShowVehicleDetails:
                            showVehicleDetailsNavigator();
                            break;
                        case eMenuOptions.exit:
                            break;
                        default:
                          Gui.MyWriteLine("invalid input, choose a number between 1 to 8");
                            break;
                    }
                }
                catch (FormatException formatException)
                {
                    Gui.MyWriteLine(formatException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Gui.MyWriteLine(argumentException.Message);
                }
                catch (ValueOutOfRangeException valueOutOfRangeException)
                {
                    Gui.MyWriteLine(valueOutOfRangeException.Message);
                }
                catch (Exception exception)
                {
                    Gui.MyWriteLine(exception.Message);
                }

                Console.Clear();
                Gui.PrintMenu();
                pick = Convert.ToInt32(Console.ReadLine());
                menuChoice = (eMenuOptions)pick;
            }
        }

        private void showVehicleDetailsNavigator()
        {
            string regNumber = Gui.GetRegNumber();
            string output = m_Garage.ShowVehicleDetails(regNumber);
            Console.WriteLine(output);
            Console.ReadKey();
        }
        private void chargeBatteryNavigator()
        {
            float amount = 0;
            string regNumber = Gui.GetRegNumber();
            amount = Gui.GetAmountToChargeBattery();
            m_Garage.ChargeEnergy(regNumber, amount);
            Gui.Done();
        }
        private void fillFuelNavigator()
        {
            float amount = 0;
            string regNumber = Gui.GetRegNumber();
            eFuelType fuel = Gui.GetFuelTypeAndAmount(ref amount);
            m_Garage.FillFuel(regNumber, fuel, amount);
            Gui.Done();
        }
        private void changeStateNavigator()
        {
            string regNumber = Gui.GetRegNumber();
            eVehicleState toChange = Gui.GetVehicleState();
            GarageItem temp = m_Garage.ChangeStateOfVehicle(regNumber, toChange);
            Gui.ChangeStateVerification(temp);
        }
        private void addVehicleNavigator()
        {
            GarageItem garageItem = Gui.GetGarageItem();
            bool res = m_Garage.AddVehicle(garageItem);
            Gui.AddVehicleVerification(garageItem, res);
        }
        private void showAllRegsNavigator()
        {
            string s = "";
            int UserChose =
                Gui.UserChoosingMessage
                ("Press 1 to show all regs numbers in system, else to show all cars with specific state");

            if (UserChose == 1)
            {
                s += m_Garage.ShowAllReg();
            }
            else
            {
                eVehicleState toShow = Gui.GetVehicleState();
                s += m_Garage.ShowAllRegByState(toShow);
            }
            Gui.MyWriteLine(s);
        }
        private void fillAirNavigator()
        {
            string regNumber = Gui.GetRegNumber();
            GarageItem temp = null;

            int UserChose =
                Gui.UserChoosingMessage
            ("Press 1 to fill up limited amount of air, else filling up to maximum air pressure");

            if (UserChose == 1)
            {
                float amount = Gui.GetAmountToFillWheels();
                try
                {
                    temp = m_Garage.FillAir(regNumber, amount);
                }
                catch (ValueOutOfRangeException ex)
                {
                    throw ex;
                }
            }
            else
            {
                temp = m_Garage.FillAirToMax(regNumber);
            }
            Gui.FillAirVerification(temp);
        }
    }

}
