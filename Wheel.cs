using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Wheel // to check if the user adding 1 wheel or the whole 4 !
    {

        // $G$ NTT-999 (-3) This kind of field should be readonly.
        private string m_ManufactorName;
        private float m_AirPressure;

        // $G$ DSN-999 (-4) The "maximum air pressure" field should be readonly member of class wheel.
        private float m_MaxAirPressure;

        public Wheel(string i_ManufactorName, float i_AirPressure, float i_MaxAirPressure)
        {
            m_ManufactorName = i_ManufactorName;
            m_AirPressure = i_AirPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufactorName
        {
            get{ return m_ManufactorName; }
            set { m_ManufactorName = value; }
        }
        public float AirPressure
        {
            get { return m_AirPressure; }
            set
            {
                if (value > m_MaxAirPressure)
                {
                    Exception ex = new Exception("value out of range !");
                    throw new ValueOutOfRangeException(ex, 0, m_MaxAirPressure);
                }
                else
                { m_AirPressure = value; }
            }
        }
        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public void FillAir(float i_AirToAdd)  
        {
            try{ 

                m_AirPressure = m_AirPressure + i_AirToAdd;
            }
            catch(ValueOutOfRangeException ex)
            {
                throw ex;
            }
        }

        public void FillAirToMax()
        {
            m_AirPressure = MaxAirPressure;
        }
        public override string ToString()
        {
            string output = string.Format("Manufactor Name : {0}" + Environment.NewLine + "Air Pressure : {1}" +
                                          Environment.NewLine +
                                          "Max Air Pressure : {2}" + Environment.NewLine,
                m_ManufactorName, m_AirPressure, m_MaxAirPressure);
            return output;
        }
    }
}


