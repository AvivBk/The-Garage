using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricEngine :Engine
    {
    private float m_BatteryTimeLeft;
    private readonly float m_MaxBaterryTime;

    public ElectricEngine(float i_BatteryTimeLeft, float i_MaxBaterryTime)
    {
        m_BatteryTimeLeft = i_BatteryTimeLeft;
        m_MaxBaterryTime = i_MaxBaterryTime;
    }

    public float MaxBattery
    {
        get { return m_MaxBaterryTime; }
    }
    public float Battery
    {
        get { return m_BatteryTimeLeft; }
            set {
                if (value > m_MaxBaterryTime)
                {
                    Exception ex = new Exception("value out of range !");
                    throw new ValueOutOfRangeException(ex, 0, m_MaxBaterryTime);
                }
                else
                {
                    m_BatteryTimeLeft = value;
                }
            }
    }

    public override string ToString()
    {
        string output = string.Format(Environment.NewLine + "electric engine : " + Environment.NewLine + "Battery time left : {0}" +
                                      Environment.NewLine +
                                      "Maximum battery time : {1}" + Environment.NewLine,
            m_BatteryTimeLeft,
            m_MaxBaterryTime);
        return output;
    }

    }
}
