using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public bool ChargeEnergyIfPossible(float i_EnergyToAdd) 
        {
            bool result = false;
            if (CurrentAmountOfEnergy + i_EnergyToAdd <= MaxAmountOfEnergy)
            {
                result = true;
            }
            else
            {
                throw new ValueOutOfRangeException(MaxAmountOfEnergy - CurrentAmountOfEnergy, 0);
            }

            return result;
        }
    }
}
