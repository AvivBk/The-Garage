using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageItem
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private Vehicle m_Vehicle;
        private eVehicleState m_VehicleState = eVehicleState.InRepair;


        public GarageItem(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            m_Vehicle = i_Vehicle;
        }

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
        }

        public eVehicleState State
        {
            get { return m_VehicleState; }
            set { m_VehicleState = value; }
        }

        public string OwnerPhone
        {
            get { return m_OwnerPhoneNumber; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
        }

        public override string ToString()
        {
            string sVehicle = m_Vehicle.ToString();
            string output = string.Format("Owner Name : {0}" + Environment.NewLine + "Owner Phone number : {1}" +
                                          Environment.NewLine + "Vehicle state : {2}" + Environment.NewLine + sVehicle +
                                          Environment.NewLine
                , m_OwnerName, m_OwnerPhoneNumber, m_VehicleState);
            return output;
        }
    }

}
