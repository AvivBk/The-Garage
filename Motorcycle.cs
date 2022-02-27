using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
   public class Motorcycle:Vehicle
   {
       private eLicenseType m_licenseType;
       private int m_EngineCapacity;
       public Motorcycle(string i_ModelName, string i_RegNumber, float i_precentageLeft, List<Wheel> i_WheelsCollection,
           Engine i_Engine, eLicenseType i_licenseType, int i_EngineCapacity) :
           base(i_ModelName, i_RegNumber, i_precentageLeft, i_WheelsCollection, i_Engine)
       {
           m_licenseType = i_licenseType;
           m_EngineCapacity = i_EngineCapacity;
       }

       public override string ToString()
       {
           string s = base.GetEngine.ToString();
           string s2 = Environment.NewLine + "Wheels :" + Environment.NewLine;
           int Wheelscount = 1;
           foreach (var Wheel in base.Wheels) // a string for wheels info 
           {
               s2 += "wheel number : "+ Wheelscount + Environment.NewLine +Wheel.ToString() + Environment.NewLine; ;
               Wheelscount++;
           }

            string ouput = string.Format("Motorcycle Details : " + Environment.NewLine + "Model Name : {0}" +
                                        Environment.NewLine +
                                        "Reg number : {1}" + Environment.NewLine + "Percentage Of Engine Left : {2}" +
                                        Environment.NewLine + s +
                                        "License Type : {3}" + Environment.NewLine + "Max Carry weight: {4}" +
                                        Environment.NewLine+s2,
                base.ModelName, base.RegNumber, base.PercentageOfEngLeft, m_licenseType , m_EngineCapacity);
            return ouput;
       }

       public eLicenseType License
       {
           get { return m_licenseType; }
           set { m_licenseType = value; }
       }

       public int EngineCapacity
       {
           get { return m_EngineCapacity; }
           set { m_EngineCapacity = value; }
       }

    }
}
