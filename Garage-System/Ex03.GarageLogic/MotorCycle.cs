using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicensType m_LicenseType;
        private int m_EngineVolume;

        public eLicensType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
        }

        public MotorCycle(string i_ModelName, string i_VehicleLicensenumber, int i_EngineType) : base(i_ModelName, i_VehicleLicensenumber, i_EngineType)
        {
            m_VehiclesWheels = new Wheel[2];
            for (int i = 0; i < 2; i++)
            {
                m_VehiclesWheels[i] = new Wheel();
                m_VehiclesWheels[i].MaxAirPressure = 33;
            }
        }

        public override void UpdateEngine()
        {
            if (m_VehicleEngine is ElectricEngine)
            {
                m_VehicleEngine.UpdateSpecificEngine(eFuelType.Electricty, 1.4f);
            }
            else
            {
                m_VehicleEngine.UpdateSpecificEngine(eFuelType.Octan95, 8);
            }
        }

        public override void UpdateSpecificPropeties(string i_LicenseTypeFromUser, string i_EngineVolumeFromUser)
        {
            bool isParseAble = false;
            m_LicenseType = (eLicensType)Enum.Parse(typeof(eLicensType), i_LicenseTypeFromUser);

            if ((int)m_LicenseType > (int)Enum.GetValues(typeof(eLicensType)).Cast<eLicensType>().Last() || m_LicenseType < 0)
            {
                throw new ValueOutOfRangeException(4, 1, "License Type");
            }

            isParseAble = int.TryParse(i_EngineVolumeFromUser, out m_EngineVolume);
            if (isParseAble)
            {
                if (m_EngineVolume < 0 || m_EngineVolume > 10000)
                {
                    throw new ValueOutOfRangeException(10000, 0, "Engine Volume");
                }
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
