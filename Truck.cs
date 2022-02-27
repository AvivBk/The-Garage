using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDangerous;
        private float m_MaxCarryingWeight;
        public Truck(string i_ModelName, string i_RegNumber, float i_precentageLeft, List<Wheel> i_WheelsCollection,
        Engine i_Engine, bool i_IsDangerous, float i_MaxCarryWeight ):
            base(i_ModelName, i_RegNumber, i_precentageLeft, i_WheelsCollection, i_Engine)
        {
            m_IsDangerous = i_IsDangerous;
            m_MaxCarryingWeight = i_MaxCarryWeight;
            
        }

        public bool IsDangerous
        {
            get { return m_IsDangerous; }
            set { m_IsDangerous = value; }
        }

        public float MaxCarryingWeight
        {
            get { return m_MaxCarryingWeight; }
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

            string ouput = string.Format("Truck Details : " + Environment.NewLine + "Model Name : {0}" +
                                         Environment.NewLine +
                                         "Reg number : {1}" + Environment.NewLine + "Percentage Of Engine Left {2}" +
                                         Environment.NewLine + s +
                                         "Is Dangerous : {3}" + Environment.NewLine + "Max Carry weight: {4}" +
                                         Environment.NewLine + s2,
                base.ModelName, base.RegNumber, base.PercentageOfEngLeft, m_IsDangerous, m_MaxCarryingWeight);
            return ouput;
        }
    }
}
