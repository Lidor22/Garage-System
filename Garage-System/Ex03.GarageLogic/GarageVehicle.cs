using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageVehicle
    {
        private Vehicle m_VehicleInGarage;
        private string m_OwnersName;
        private long m_OwnersPhone;
        private eVehicleStatusInGarage m_StatusOfVehicle;

        public GarageVehicle(Vehicle i_VehicleToGarage, string i_OwnersName, long i_OwnersPhone, eVehicleStatusInGarage i_StatusOfVehicle)
        {
            m_VehicleInGarage = i_VehicleToGarage;
            m_OwnersName = i_OwnersName;
            m_OwnersPhone = i_OwnersPhone;
            m_StatusOfVehicle = i_StatusOfVehicle;
        }

        public Vehicle VehicleInGarage
        {
            get { return m_VehicleInGarage; }
        }

        public eVehicleStatusInGarage StatusOfVehicle
        {
            get { return m_StatusOfVehicle; }
            set { m_StatusOfVehicle = value; }
        }

        public void ChangeCarStatus(eVehicleStatusInGarage i_NewStatusFromUser)
        {
            m_StatusOfVehicle = i_NewStatusFromUser;
        }

        public void FillAirInWheelsToMax()
        {
            foreach (Wheel wheelToFill in m_VehicleInGarage.VehiclesWheels)
            {
                wheelToFill.AddAirPressure(wheelToFill.MaxAirPressure - wheelToFill.CurrentAirPressure);
            }
        }

        public bool FillFuelToMax(Vehicle i_VehicleToActOn, eEngineType i_EngineTypeBasedOnMethodUse, eFuelType i_TypeOfFuelToAdd, float i_AmountOfFuel)
        {
            bool resultOfFuel = false;
            switch (i_EngineTypeBasedOnMethodUse)
            {
                case eEngineType.Fuel:
                    FuelEngine currentFuelEngine = m_VehicleInGarage.VehicleEngine as FuelEngine;
                    resultOfFuel = currentFuelEngine.ChargeEnergyIfPossible(i_AmountOfFuel, i_TypeOfFuelToAdd);
                    break;
                case eEngineType.Electric:
                    ElectricEngine currentElectricEngine = m_VehicleInGarage.VehicleEngine as ElectricEngine;
                    resultOfFuel = currentElectricEngine.ChargeEnergyIfPossible(i_AmountOfFuel);
                    break;
            }

            if (resultOfFuel)
            {
                i_VehicleToActOn.PercentOfEnergyLeft = 100;
                i_VehicleToActOn.VehicleEngine.CurrentAmountOfEnergy = i_VehicleToActOn.VehicleEngine.MaxAmountOfEnergy;
            }

            return resultOfFuel;
        }

        public string GatherInformationAboutTheVehicle()
        {
            eEngineType engineType;
            if (m_VehicleInGarage.VehicleEngine is ElectricEngine)
            {
                engineType = eEngineType.Electric;
            }
            else
            {
                engineType = eEngineType.Fuel;
            }

            string theInformationWeGathered = string.Empty;
            theInformationWeGathered = string.Format(
@"The vehicle license number is :{0}.
The vehicle model is :{1}.
The vehicle owners name is :{2}.
The vehicle current status in garage is :{3}.
The vehicle Wheeals maniufacture is :{4}.
The wheels air pressure is set to :{5}.
The vehicle energy type is :{6}.
The amount of energy left in the car is :{7}.",
m_VehicleInGarage.VehicleLicensenumber,
m_VehicleInGarage.ModelName,
m_OwnersName,
m_StatusOfVehicle,
m_VehicleInGarage.VehiclesWheels[0].ManufacturerName,
m_VehicleInGarage.VehiclesWheels[0].CurrentAirPressure,
engineType,
m_VehicleInGarage.VehicleEngine.CurrentAmountOfEnergy);
            return theInformationWeGathered;
        }
    }
}
