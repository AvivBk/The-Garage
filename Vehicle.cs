using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_ModelName;
        private string m_RegNumber;
        private float m_PercentageOfEngLeft;
        private List<Wheel> WheelsCollection;
        private Engine m_Engine;

        public Vehicle(string i_ModelName, string i_RegNumber, float i_precentageLeft, List<Wheel> i_WheelsCollection,
        Engine i_Engine)
        {
            m_ModelName = i_ModelName;
            m_RegNumber = i_RegNumber;
            m_PercentageOfEngLeft = i_precentageLeft;
            WheelsCollection = i_WheelsCollection;
            m_Engine = i_Engine;
        }

        public Engine GetEngine
        {
            get { return m_Engine; }
        }

        public List<Wheel> Wheels
        {
            get { return WheelsCollection; }
        }

        public Wheel wheel(int i_Index)
        {
            return Wheels[i_Index];
        }

        public void addWheel(Wheel i_ToAdd)
        {
            Wheels.Add(i_ToAdd);
        }
        public float PercentageOfEngLeft
        {
            get { return m_PercentageOfEngLeft; }
            set { m_PercentageOfEngLeft = value; }
        }

        public string RegNumber
        {
            get { return m_RegNumber; }
            set { m_RegNumber = value; }
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public override abstract string ToString();
        public override bool Equals(object? obj)
        {
            bool equals = false;
            if (obj != null)
            {
                if (obj is Vehicle)
                {
                    Vehicle m = obj as Vehicle; 
                    equals = RegNumber == m.RegNumber;
                }
            }
            return equals;
        }



        
    }
}
