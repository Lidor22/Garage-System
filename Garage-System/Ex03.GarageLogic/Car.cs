using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eCarColor m_CarColor;
        private int m_NumberOfDoors;

        public eCarColor CarColor
        {
            get { return m_CarColor; }
            set { m_CarColor = value; }
        }

        public int NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        public Car(string i_ModelName, string i_VehicleLicensenumber, int i_EngineType) : base(i_ModelName, i_VehicleLicensenumber, i_EngineType)
        {
            m_VehiclesWheels = new Wheel[4];
            for (int i = 0; i < 4; i++)
            {
                m_VehiclesWheels[i] = new Wheel();
                m_VehiclesWheels[i].MaxAirPressure = 31;
            }
        }

        public override void UpdateEngine()
        {
            if (m_VehicleEngine is ElectricEngine)
            {
                m_VehicleEngine.UpdateSpecificEngine(eFuelType.Electricty, 1.8f);
            }
            else
            {
                m_VehicleEngine.UpdateSpecificEngine(eFuelType.Octan96, 55);
            }
        }

        public override void UpdateSpecificPropeties(string i_CarColorFromUser, string i_NumberOfDoorsFromUser)
        {
            bool isParseAble = false;
            m_CarColor = (eCarColor)Enum.Parse(typeof(eCarColor), i_CarColorFromUser);
            if ((int)m_CarColor > (int)Enum.GetValues(typeof(eCarColor)).Cast<eCarColor>().Last() || (int)m_CarColor < 0)
            {
                throw new ValueOutOfRangeException(4, 1, "CarColor");
            }

            isParseAble = int.TryParse(i_NumberOfDoorsFromUser, out m_NumberOfDoors);
            if (isParseAble)
            {
                if (m_NumberOfDoors < 2 || m_NumberOfDoors > 5)
                {
                    throw new ValueOutOfRangeException(5, 2, "Number Of Doors");
                }
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
