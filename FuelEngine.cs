using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        // $G$ CSS-003 (-3) Bad readonly members variable name (should be in the form of r_PamelCase).
        private readonly eFuelType m_FuelType;
       private float m_CurrentFuel;
       private float m_MaxAmountOfFuel;

       public FuelEngine(eFuelType i_FuelType, float i_CurrentFuel, float i_MaxAmountOfFuel)
       {
           m_FuelType = i_FuelType;
           m_CurrentFuel = i_CurrentFuel;
           m_MaxAmountOfFuel = i_MaxAmountOfFuel;
       }
       public eFuelType FuelType
       {
           get { return m_FuelType; }
       }

       public float MaxAmountOfFuel
       {
           get { return m_MaxAmountOfFuel; }
       }
       public float Fuel
       {
           get { return m_CurrentFuel; }
            set
            {
                if (value > m_MaxAmountOfFuel || value < 0)
                {
                    Exception ex = new Exception("value out of range !");
                    throw new ValueOutOfRangeException(ex, 0, m_MaxAmountOfFuel);
                }
                else
                {
                    m_CurrentFuel = value;
                }
            }
       }

       
       public override string ToString()
       {

           string output = string.Format(Environment.NewLine + "Fuel Type : {0} " + Environment.NewLine
                                         + "Current Fuel : {1}" + Environment.NewLine +
                                         "Max amount of fuel : {2} " + Environment.NewLine, m_FuelType, m_CurrentFuel, m_MaxAmountOfFuel);
           return output;
       }
    }
    
}
