using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentAmountOfEnergy;
        protected float m_MaxAmountOfEnergy;
        protected eFuelType m_EngineFuelType;

        public eFuelType EngineFuelType
        {
            get { return m_EngineFuelType; }
            set { m_EngineFuelType = value; }
        }

        public float CurrentAmountOfEnergy
        {
            get { return m_CurrentAmountOfEnergy; }
            set { m_CurrentAmountOfEnergy = value; }
        }

        public float MaxAmountOfEnergy
        {
            get { return m_MaxAmountOfEnergy; }
            set { m_MaxAmountOfEnergy = value; }
        }

        public void UpdateSpecificEngine(eFuelType i_FuelType, float i_MaxEnergy)
        {
            m_EngineFuelType = i_FuelType;
            m_MaxAmountOfEnergy = i_MaxEnergy;
        }
    }
}
