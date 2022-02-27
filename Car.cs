using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        eVehicleColor m_VehicleColor;
        eDoorsNumber m_DoorsNumber;

        public Car(string i_ModelName, string i_RegNumber, float i_precentageLeft, List<Wheel> i_WheelsCollection, Engine i_Engine,
            eVehicleColor i_VehicleColor, eDoorsNumber i_DoorsNumber): 
            base( i_ModelName,  i_RegNumber,  i_precentageLeft, i_WheelsCollection, i_Engine)
        {
            m_VehicleColor = i_VehicleColor;
            m_DoorsNumber = i_DoorsNumber;
        }
        public override string ToString()
        {
            string s = base.GetEngine.ToString();
            string s2 = Environment.NewLine + "Wheels :" + Environment.NewLine;
            int Wheelscount = 1;
            foreach (var Wheel in base.Wheels) // a string for wheels info 
            {
                s2 += "wheel number : " + Wheelscount + Environment.NewLine + Wheel.ToString() + Environment.NewLine; ;
                Wheelscount++;
            }

            string ouput = string.Format("Car Details : " + Environment.NewLine + "Model Name : {0}" +
                                         Environment.NewLine +
                                         "Reg number : {1}" + Environment.NewLine + "Percentage Of Engine Left {2}" +
                                         Environment.NewLine + s +
                                         "Color : {3}" + Environment.NewLine + "Number of doors: {4}" +
                                         Environment.NewLine+s2,
                base.ModelName, base.RegNumber, base.PercentageOfEngLeft, m_VehicleColor, m_DoorsNumber);
            return ouput;
        }

        public eVehicleColor Color
        {
            get { return m_VehicleColor; }
            set { m_VehicleColor = value; }
        }

        public eDoorsNumber DoorsNumber
        {
            get { return m_DoorsNumber; }
            set { m_DoorsNumber = value; }
        }
    }
}
