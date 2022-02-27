using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {

        // $G$ CSS-002 (-3) Bad members variable name (should be in the form of m_PascalCase).
        private Dictionary<string, GarageItem> garageItems;

        public Garage()
        {
            garageItems = new Dictionary<string, GarageItem>();
        }

        public bool AddVehicle(GarageItem i_ItemToAdd) 
        {
            bool res = false;
            if (!garageItems.ContainsKey(i_ItemToAdd.Vehicle.RegNumber))
            {
                garageItems.Add(i_ItemToAdd.Vehicle.RegNumber, i_ItemToAdd);
                res = true;
            }
            else { throw new FormatException("Error: Reg Number already in system , adding failed"); }
            return res;
        }


        public string ShowAllReg()
        {
            string output = "";
            foreach (var Items in garageItems)
            {
                output += Items.Value.Vehicle.RegNumber.ToString()+Environment.NewLine;
            }
            return output;
        }
        public string ShowAllRegByState(eVehicleState i_State) // need to sort by state?
        {
            string output = "";
            foreach (var Item in garageItems)
            {
                if (Item.Value.State == i_State)
                {
                    output += Item.Value.Vehicle.RegNumber.ToString() + Environment.NewLine;
                }
            }
            return output;
        }
        public GarageItem ChangeStateOfVehicle(string i_RegNumber, eVehicleState i_State)
        {
            if (garageItems.ContainsKey(i_RegNumber))
            {
                garageItems[i_RegNumber].State = i_State;
            }

            return garageItems[i_RegNumber];
        }

        public GarageItem FillAirToMax(string i_RegNumber)
        {
            if (garageItems.ContainsKey(i_RegNumber))
            {
                foreach (var wheel in garageItems[i_RegNumber].Vehicle.Wheels)
                {
                    wheel.FillAirToMax();
                }
            }
            return garageItems[i_RegNumber];
        }

        public GarageItem FillAir(string i_RegNumber, float i_Amount)
        {
            if (garageItems.ContainsKey(i_RegNumber))
            {
                foreach (var wheel in garageItems[i_RegNumber].Vehicle.Wheels)
                {
                    try
                    {
                        wheel.FillAir(i_Amount);
                    }
                    catch(ValueOutOfRangeException ex)
                    {
                        throw ex;
                    }
                }
            }
            return garageItems[i_RegNumber];
        }
        public void FillFuel(string i_RegNumber, eFuelType i_FuelType, float i_AmountToFill)
        {

            if (garageItems.ContainsKey(i_RegNumber))
            {
                if (garageItems[i_RegNumber].Vehicle.GetEngine is FuelEngine)
                {
                    FuelEngine ptr = garageItems[i_RegNumber].Vehicle.GetEngine as FuelEngine;
                    if (ptr.FuelType == i_FuelType)
                    {
                        try
                        {
                            ptr.Fuel += i_AmountToFill;
                        }
                        catch (ValueOutOfRangeException ex)
                        {
                            throw ex;
                        }
                    }
                    else
                    {
                        throw new FormatException("incorrect fuel type ");
                    }
                }
                else
                {
                    throw new FormatException("Vehicle is not fuel type ! ");
                }
            }
            else
            {
                throw new FormatException("Vehicle is not found ");
            }
        }

        public void ChargeEnergy(string i_RegNumber, float i_AmountToFill) // need to check mins or hour issue
        {
            if (garageItems.ContainsKey(i_RegNumber))
            {
                if (garageItems[i_RegNumber].Vehicle.GetEngine is ElectricEngine)
                {
                    ElectricEngine ptr = garageItems[i_RegNumber].Vehicle.GetEngine as ElectricEngine;
                    try
                    {
                        ptr.Battery += i_AmountToFill;

                    }
                    catch (ValueOutOfRangeException ex)
                    {
                        throw ex;
                    }
                }
                else
                {
                    throw new FormatException("Vehicle is not Electric type ! ");
                }
            }
            else
            {
                throw new FormatException("Vehicle is not found ");
            }
        }

        public string ShowVehicleDetails(string i_RegNumber) // no need exceptions 
        {
            string output ="";
            if (garageItems.ContainsKey(i_RegNumber))
            {
                output = garageItems[i_RegNumber].ToString();
            }
            else
            {
                output += "Vehicle isnt found ";
            }
            return output;
        }

    }
}
