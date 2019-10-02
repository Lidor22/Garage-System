using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel()
        {
            m_ManufacturerName = string.Empty;
            m_CurrentAirPressure = 0;
            m_MaxAirPressure = 0;
        }
        
        public string ManufacturerName
        {
            get { return m_ManufacturerName; }
            set { m_ManufacturerName = value; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
            set { m_MaxAirPressure = value; }
        }

        public bool AddAirPressure(float i_AmountOfAirToAdd) 
        {
            bool result = false;
            if ((i_AmountOfAirToAdd + m_CurrentAirPressure) <= m_MaxAirPressure)
            {
                result = true;
                m_CurrentAirPressure += i_AmountOfAirToAdd;
            }

            return result;
        }
    }
}
