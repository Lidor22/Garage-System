using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UI
    {
        private Garage m_HadarAndKochGarage;
        private string[] m_InputStringsArray;

        public UI()
        {
            string colorMenuToPrint = string.Format(
        @"Please enter car color(press the number):
1.Red
2.Blue
3.Black
4.Grey");
            string numberOfDoors = "Please enter number of doors(2-5):";
            string firstMotorPropetie = "Please enter Type of license A(1)/A1(2)/A2(3)/B(4):";
            string secondMotorPropetie = "Please enter volume of engine:";
            string firstTruckPropertie = "Please enter truck capacity:";
            string secondTruckPropertie = "Does your truck transport dangerous materials(True / False):";
            m_HadarAndKochGarage = new Garage();
            m_InputStringsArray = new string[6] { colorMenuToPrint, numberOfDoors, firstMotorPropetie, secondMotorPropetie, firstTruckPropertie, secondTruckPropertie };
        }

        public void ManageGarage()
        {
            string liencenseIDFromUser = string.Empty;
            bool isVehicleInGarage = false;
            GarageVehicle currentGarageToDealWith = null;
            Console.WriteLine("Welcome to our garage!");
            string firstMenuToPrint = string.Format(
 @"please enter your choice:
1.Enter a new vehicle to the garage.
2.Execute an action on an existing vehicle.
3.Desplay the list of vehicle license numbers.
4.Close the garage.");
            Console.WriteLine(firstMenuToPrint);
            int inputFromUser = ValidationOfData.GetIntFromUserWithinRange(4, 1);
            while (inputFromUser != 4)
            {
                switch (inputFromUser)
                {
                    case 1:
                        {
                            createNewVehicle();
                            break;
                        }

                    case 2:
                        liencenseIDFromUser = getLicenseNumberFromUser();
                        isVehicleInGarage = m_HadarAndKochGarage.GetGarageVehicleFromUser(liencenseIDFromUser, out currentGarageToDealWith);
                        if (isVehicleInGarage)
                        {
                            performActionOnVehicle(currentGarageToDealWith);
                        }
                        else
                        {
                            Console.WriteLine("Vehicle can not be found on our Garage.");
                        }

                        break;
                    case 3:
                        displayAllVehiclesLicenseNumber();
                        break;
                }

                Console.WriteLine(firstMenuToPrint);
                inputFromUser = ValidationOfData.GetIntFromUserWithinRange(4, 1);
            }
        }

        private void performActionOnVehicle(GarageVehicle i_CurrentGarageToDealWith)
        {
            string secondMenuToPrint = string.Format(
@"Choose an option to execute:
1.Change vehicle status.
2.Maximize the air pressure of your vehicle.
3.Powered by fuel your vehicle.
4.Chagre an electric vehicle.
5.Display vechile details by license number.");
            Console.WriteLine(secondMenuToPrint);
            int secondInputFromUSer = ValidationOfData.GetIntFromUserWithinRange(5, 1);
            switch (secondInputFromUSer)
            {
                case 1:
                    changeStatusOfVehicle(i_CurrentGarageToDealWith);
                    break;
                case 2:
                    fillMaxAirOfVehicle(i_CurrentGarageToDealWith);
                    break;
                case 3:
                    fillEnergyOfVehicle(i_CurrentGarageToDealWith, true);
                    break;
                case 4:
                    fillEnergyOfVehicle(i_CurrentGarageToDealWith, false);
                    break;
                case 5:
                    displayFullDetailsOfVehicle(i_CurrentGarageToDealWith);
                    break;
            }
        }

        private void createNewVehicle()
        {
            int EngineType = 1;
            bool isVehicleAlreadtInGarage = false;
            Console.WriteLine("Please enter the license number:");
            string licenseNumber = ValidationOfData.GetStringFromUser();
            isVehicleAlreadtInGarage = m_HadarAndKochGarage.SearchVehicleInGarage(licenseNumber);
            if (!isVehicleAlreadtInGarage)
            {
                Console.WriteLine("Please enter the vehicle model:");
                string vehicleModel = ValidationOfData.GetStringFromUser();
                string vehicleMenuToPrint = string.Format(
@"Please enter the type of vehicle:
1.Car
2.Motorcycle
3.Truck");
                Console.WriteLine(vehicleMenuToPrint);
                int TypeOfVehicleFromUser = ValidationOfData.GetIntFromUserWithinRange(3, 1);
                if (TypeOfVehicleFromUser != 3)
                {
                    string enginMenuToPrint = string.Format(
 @"Please enter the type of Engine(press the number):
1.Fuel
2.Electric");

                    Console.WriteLine(enginMenuToPrint);
                    EngineType = ValidationOfData.GetIntFromUserWithinRange(2, 1);
                }

                Vehicle newVehicleToGarage = Garage.CreateTheSpecificVehicle(vehicleModel, licenseNumber, TypeOfVehicleFromUser, EngineType);
                Console.WriteLine("Please enter the wheels manufacture name:");
                string manufactureName = ValidationOfData.GetStringFromUser();
                Console.WriteLine("Please enter the wheels current air pressure:");
                float wheelsCurrentAirPressure = ValidationOfData.GetTheAirPressure(newVehicleToGarage);
                updateVehicleProperties(TypeOfVehicleFromUser, newVehicleToGarage, manufactureName, wheelsCurrentAirPressure);
                Console.WriteLine("Please enter your phone number:");
                long phoneNumber = ValidationOfData.GetLongIntFromUser();
                Console.WriteLine("Please enter your name:");
                string ownerName = ValidationOfData.GetStringFromUser();
                m_HadarAndKochGarage.AddVehicleToGarage(newVehicleToGarage, ownerName, phoneNumber, eVehicleStatusInGarage.InProgress);
            }
            else
            {
                Console.WriteLine("Vehicle with the same license number is already in our garage.Please try again.");
            }
        }

        private void updateVehicleProperties(int i_TypeOfVehicleFromUser, Vehicle i_NewVehicleToGarage, string i_ManufactureName, float i_WheelsCurrentAirPressure)
        {
            int firstIndex, secondIndex = 0;
            getTwoIndexesOfCommands(i_TypeOfVehicleFromUser, out firstIndex, out secondIndex);

            while (true)
            {
                try
                {
                    Console.WriteLine(m_InputStringsArray[firstIndex]);
                    string firstPropertie = ValidationOfData.GetStringFromUser();
                    Console.WriteLine(m_InputStringsArray[secondIndex]);
                    string secondPropertie = ValidationOfData.GetStringFromUser();
                    i_NewVehicleToGarage.UpdateSpecificPropeties(firstPropertie, secondPropertie);
                    updateEngineProperties(i_NewVehicleToGarage);
                    i_NewVehicleToGarage.UpdateWheels(i_ManufactureName, i_WheelsCurrentAirPressure);
                    return;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to '{0}'.please enter again:", ex.Message);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},please enter again:", ex.Message);
                }
            }
        }

        private void updateEngineProperties(Vehicle i_NewVehicleToGarage)
        {
            i_NewVehicleToGarage.UpdateEngine();
            Console.WriteLine("Please enter the amount of energy left:");
            float energyLeftInEngine = ValidationOfData.GetFloatFromUserWithinRange(i_NewVehicleToGarage.VehicleEngine.MaxAmountOfEnergy, 0);
            i_NewVehicleToGarage.SetEngineCurrentEnergy(energyLeftInEngine);
        }

        private void displayAllVehiclesLicenseNumber()
        {
            bool isStatusNeeded = false;
            Console.WriteLine("Would you like to filter the vehicles by their status ? - true/false");
            isStatusNeeded = ValidationOfData.GetBoolFromUser();
            if (isStatusNeeded)
            {
                Console.WriteLine("Please enter the Vehicles status you would like to watch - InProgress(1)/Fixed(2)/Paid(3):");
                eVehicleStatusInGarage statusToSearch = ValidationOfData.GetStatusOnGarage();
                displayByStatus(statusToSearch);
            }
            else
            {
                displayAllVehicles();
            }
        }

        private void changeStatusOfVehicle(GarageVehicle i_SearchvihicleInGarage)
        {
            Console.WriteLine("Please enter the Vehicles new status you would like to set:");
            eVehicleStatusInGarage statusToUpdate = ValidationOfData.GetStatusOnGarage();
            i_SearchvihicleInGarage.ChangeCarStatus(statusToUpdate);
            Console.WriteLine("The new status is: {0}", statusToUpdate);
        }

        private void fillMaxAirOfVehicle(GarageVehicle i_SearchvihicleInGarage)
        {
            i_SearchvihicleInGarage.FillAirInWheelsToMax();
        }

        private void fillEnergyOfVehicle(GarageVehicle i_SearchvihicleInGarage, bool i_IsRefuelNeed)
        {
            bool isSuccesfull = false;
            eFuelType fuelToRefill;
            eEngineType engineType;
            if (i_IsRefuelNeed)
            {
                Console.WriteLine("Please enter the fuel type you would like to fill in - Soler(1)/Octan95(2)/Octan96(3)/octan98(4) :");
                fuelToRefill = ValidationOfData.GetFuelType();
                engineType = eEngineType.Fuel;
            }
            else
            {
                fuelToRefill = eFuelType.Electricty;
                engineType = eEngineType.Electric;
            }

            Console.WriteLine("Please enter how many energy would you like to fill in:");
            float amountOfEnergy = ValidationOfData.GetFloatFromUserWithinRange(i_SearchvihicleInGarage.VehicleInGarage.VehicleEngine.MaxAmountOfEnergy, 0); // to change it to within range
            try
            {
                isSuccesfull = i_SearchvihicleInGarage.FillFuelToMax(i_SearchvihicleInGarage.VehicleInGarage, engineType, fuelToRefill, amountOfEnergy);
            }
            catch (ValueOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException)
            {
                Console.WriteLine(@"The fuel type entered {0} doesn't match the fuel type required .", fuelToRefill);
            }
            catch (Exception)
            {
                Console.WriteLine(@"The energy type entered {0} doesn't match to the vehicle engine .", fuelToRefill);
            }

            if (isSuccesfull)
            {
                printTheResult(isSuccesfull);
            }
        }

        private void displayFullDetailsOfVehicle(GarageVehicle i_SearchvihicleInGarage)
        {
            string infoForUSer = i_SearchvihicleInGarage.GatherInformationAboutTheVehicle();
            Console.WriteLine(infoForUSer);
        }

        private string getLicenseNumberFromUser()
        {
            Console.WriteLine("Please enter the Vehicles license number:");
            string licenseNumberFromUser = ValidationOfData.GetStringFromUser();
            return licenseNumberFromUser;
        }

        private void printTheResult(bool i_ResultOfMethods)
        {
            if (i_ResultOfMethods)
            {
                Console.WriteLine("Refueled succesfully.");
            }
        }

        private void displayAllVehicles()
        {
            foreach (KeyValuePair<string, GarageVehicle> searchInGarage in m_HadarAndKochGarage.AllVehicleInGarage)
            {
                Console.WriteLine(searchInGarage.Key);
            }
        }

        private void displayByStatus(eVehicleStatusInGarage i_StatusToDisplay)
        {
            foreach (KeyValuePair<string, GarageVehicle> searchInGarage in m_HadarAndKochGarage.AllVehicleInGarage)
            {
                if (searchInGarage.Value.StatusOfVehicle.Equals(i_StatusToDisplay))
                {
                    Console.WriteLine(searchInGarage.Key);
                }
            }
        }

        private void getTwoIndexesOfCommands(int i_TypeOfVehicleFromUser, out int io_FirstIndex, out int io_SecondIndex)
        {
            if (i_TypeOfVehicleFromUser == 1)
            {
                io_FirstIndex = 0;
                io_SecondIndex = 1;
            }
            else if (i_TypeOfVehicleFromUser == 2)
            {
                io_FirstIndex = 2;
                io_SecondIndex = 3;
            }
            else
            {
                io_FirstIndex = 4;
                io_SecondIndex = 5;
            }
        }
    }
}