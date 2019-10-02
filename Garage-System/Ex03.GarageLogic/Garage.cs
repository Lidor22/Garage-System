using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{ 
    public class Garage
    {
        private Dictionary<string, GarageVehicle> m_AllVehicleInGarage;

        public Garage()
        {
            m_AllVehicleInGarage = new Dictionary<string, GarageVehicle>();
        }

        public Dictionary<string, GarageVehicle> AllVehicleInGarage
        {
            get { return m_AllVehicleInGarage; }
        }

        public static Vehicle CreateTheSpecificVehicle(string i_VehicleModel, string i_LicenseNumber, int i_eVehicleType, int i_EngineType)
        {
            return VehicelCreator.createTheSpecificVehicle(i_VehicleModel, i_LicenseNumber, i_eVehicleType, i_EngineType);
        }

        public void AddVehicleToGarage(Vehicle i_VehicleFromUI, string i_OwnersNameFromUI, long i_OwnersPhoneFromUI, eVehicleStatusInGarage i_StatusOfVehicleFromUI)
        {
            m_AllVehicleInGarage.Add(i_VehicleFromUI.VehicleLicensenumber, new GarageVehicle(i_VehicleFromUI, i_OwnersNameFromUI, i_OwnersPhoneFromUI, i_StatusOfVehicleFromUI));
        }

        public bool SearchVehicleInGarage(string i_LicenseNumber)
        {
            bool isVehicleInGarage = true;
            bool resultOfSearch = false;
            GarageVehicle tempPointerToVehicle;
            isVehicleInGarage = m_AllVehicleInGarage.TryGetValue(i_LicenseNumber, out tempPointerToVehicle);
            if (isVehicleInGarage)
            {
                tempPointerToVehicle.StatusOfVehicle = eVehicleStatusInGarage.InProgress;
                resultOfSearch = true;
            }

            return resultOfSearch;
        }

        public bool GetGarageVehicleFromUser(string i_LicenseIdFromUser, out GarageVehicle io_CurrentVehicleFromUser)
        {
            bool searchResult = AllVehicleInGarage.TryGetValue(i_LicenseIdFromUser, out io_CurrentVehicleFromUser);
            return searchResult;
        }
    }
}
