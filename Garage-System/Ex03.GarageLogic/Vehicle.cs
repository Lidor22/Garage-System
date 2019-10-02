using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
       public abstract class Vehicle
    {
        protected Wheel[] m_VehiclesWheels;
        protected string m_ModelName;
        protected string m_VehicleLicensenumber;
        protected float m_PercentOfEnergyLeft;
        protected Engine m_VehicleEngine;

        public Vehicle(string i_ModelName, string i_VehicleLicensenumber, int i_EngineType)
        {
            m_ModelName = i_ModelName;
            m_VehicleLicensenumber = i_VehicleLicensenumber;
            if (i_EngineType.Equals(1))
            {
                m_VehicleEngine = new FuelEngine();
            }
            else
            {
                m_VehicleEngine = new ElectricEngine();
            }
        }

        public string ModelName
        {
            get { return m_ModelName; }
        }

        public string VehicleLicensenumber
        {
            get { return m_VehicleLicensenumber; }
        }

        public float PercentOfEnergyLeft
        {
            get { return m_PercentOfEnergyLeft; }
            set { m_PercentOfEnergyLeft = value; }
        }

        public Wheel[] VehiclesWheels
        {
            get { return m_VehiclesWheels; }
        }

        public Engine VehicleEngine
        {
            get { return m_VehicleEngine; }
        }

        public abstract void UpdateEngine();

        public void SetEngineCurrentEnergy(float i_CurrentEnergyFromUser)
        {
            m_VehicleEngine.CurrentAmountOfEnergy = i_CurrentEnergyFromUser;
            m_PercentOfEnergyLeft = (i_CurrentEnergyFromUser / m_VehicleEngine.MaxAmountOfEnergy) * 100; // חישוב אחוז האנרגיה שנותר  
        }

        public void UpdateWheels(string i_ManufactureName, float i_WheelsCurrentAirPressure)
        {
            foreach (Wheel wheelToUpdate in m_VehiclesWheels)
            {
                wheelToUpdate.ManufacturerName = i_ManufactureName;
                wheelToUpdate.CurrentAirPressure = i_WheelsCurrentAirPressure;
            }
        }

        public abstract void UpdateSpecificPropeties(string i_FirstPropertie, string i_SecondPropertie);
    }
}
