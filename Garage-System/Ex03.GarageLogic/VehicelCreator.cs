using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.GarageLogic
{
    public static class VehicelCreator
    {
        public static Vehicle createTheSpecificVehicle(string i_VehicleModel, string i_LicenseNumber, int i_VehicleType, int i_EngineType)
        {
            Vehicle newVehicle = null;
            switch (i_VehicleType)
            {
                case 1:
                    newVehicle = new Car(i_VehicleModel, i_LicenseNumber, i_EngineType);
                    break;
                case 2:
                    newVehicle = new MotorCycle(i_VehicleModel, i_LicenseNumber, i_EngineType);
                    break;
                case 3:
                    newVehicle = new Truck(i_VehicleModel, i_LicenseNumber, 1);
                    break;
            }

            return newVehicle;
        }
    }
}
