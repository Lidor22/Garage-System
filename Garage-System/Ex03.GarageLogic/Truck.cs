using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsTransportingDangerousMaterials;
        private float m_Capacity;

        public bool IsTransportingDangerousMaterials
        {
            get { return m_IsTransportingDangerousMaterials; }
            set { m_IsTransportingDangerousMaterials = value; }
        }

        public float Capacity
        {
            get { return m_Capacity; }
            set { m_Capacity = value; }
        }

        public Truck(string i_ModelName, string i_VehicleLicensenumber, int i_EngineType) : base(i_ModelName, i_VehicleLicensenumber, i_EngineType)
        {
            m_VehiclesWheels = new Wheel[12];
            for (int i = 0; i < 12; i++)
            {
                m_VehiclesWheels[i] = new Wheel();
                m_VehiclesWheels[i].MaxAirPressure = 26;
            }
        }

        public override void UpdateEngine()
        {
            m_VehicleEngine.UpdateSpecificEngine(eFuelType.Soler, 110);
        }

        public override void UpdateSpecificPropeties(string i_TruckCapcityFromUser, string i_IsTransportingDangerousMaterials)
        {
            m_Capacity = float.Parse(i_TruckCapcityFromUser);
            m_IsTransportingDangerousMaterials = bool.Parse(i_IsTransportingDangerousMaterials);
        }
    }
}
