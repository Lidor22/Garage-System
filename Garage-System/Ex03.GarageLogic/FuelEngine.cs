using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        public bool ChargeEnergyIfPossible(float i_EnergyToAdd, eFuelType i_EngineFuelType) 
        {
            bool resultOfCheck = true;
            if (CurrentAmountOfEnergy + i_EnergyToAdd <= MaxAmountOfEnergy)
            {
                if (m_EngineFuelType.Equals(i_EngineFuelType))
                {
                    return resultOfCheck;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            else
            {
                throw new ValueOutOfRangeException(MaxAmountOfEnergy - CurrentAmountOfEnergy, 0);
            }
        }
    }
}
