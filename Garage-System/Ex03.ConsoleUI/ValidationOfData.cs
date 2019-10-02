using System;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public static class ValidationOfData
    {
        public static eEngineType GetTypeOfEngine()
        {
            string vehicleTypeToCheck = Console.ReadLine();
            while (true)
            {
                try
                {
                    eEngineType eTypeOfEngineFromUser = (eEngineType)Enum.Parse(typeof(eEngineType), vehicleTypeToCheck);
                    if ((int)eTypeOfEngineFromUser > (int)Enum.GetValues(typeof(eEngineType)).Cast<eEngineType>().Last())
                    {
                        throw new ValueOutOfRangeException(2, 1);
                    }

                    return eTypeOfEngineFromUser;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0} , please enter electric(1)/fuel(2)", ex.Message);
                    vehicleTypeToCheck = Console.ReadLine();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    vehicleTypeToCheck = Console.ReadLine();
                }
            }
        }

        public static eVehicleType GetTypeOfVehicle()
        {
            string vehicleTypeToCheck = Console.ReadLine();
            while (true)
            {
                try
                {
                    eVehicleType eTypeOfVehicleFromUser = (eVehicleType)Enum.Parse(typeof(eVehicleType), vehicleTypeToCheck);
                    if ((int)eTypeOfVehicleFromUser > (int)Enum.GetValues(typeof(eVehicleType)).Cast<eVehicleType>().Last())
                    {
                        throw new ValueOutOfRangeException(3, 1);
                    }

                    return eTypeOfVehicleFromUser;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},please enter car(1)/truck(2)/motorcycle(3)", ex.Message);
                    vehicleTypeToCheck = Console.ReadLine();
                }
                catch(ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    vehicleTypeToCheck = Console.ReadLine();
                }
            }
        }

        public static eCarColor GetCarColor()
        {
            string vehicleColorToCheck = Console.ReadLine();
            while (true)
            {
                try
                {
                    eCarColor eColorOfCarFromUser = (eCarColor)Enum.Parse(typeof(eCarColor), vehicleColorToCheck);
                    if ((int)eColorOfCarFromUser > (int)Enum.GetValues(typeof(eCarColor)).Cast<eCarColor>().Last())
                    {
                        throw new ValueOutOfRangeException(4, 1);
                    }

                    return eColorOfCarFromUser;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},Please enter car color red(1),blue(2),black(3),grey(4)", ex.Message);
                    vehicleColorToCheck = Console.ReadLine();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    vehicleColorToCheck = Console.ReadLine();
                }
            }
        }

        public static eLicensType GetLicenseType()
        {
            string typeOfLicenseFromUser = Console.ReadLine();
            while (true)
            {
                try
                {
                    eLicensType eLicenseType = (eLicensType)Enum.Parse(typeof(eLicensType), typeOfLicenseFromUser);
                    if ((int)eLicenseType > (int)Enum.GetValues(typeof(eLicensType)).Cast<eLicensType>().Last())
                    {
                        throw new ValueOutOfRangeException(4, 1);
                    }

                    return eLicenseType;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},please enter A(1)/A1(2)/A2(3)/B(4)", ex.Message);
                    typeOfLicenseFromUser = Console.ReadLine();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    typeOfLicenseFromUser = Console.ReadLine();
                }
            }
        }

        public static eVehicleStatusInGarage GetStatusOnGarage()
        {
            string vechileStatusFromUser = Console.ReadLine();
            while (true)
            {
                try
                {
                    eVehicleStatusInGarage eStatusOnGarage = (eVehicleStatusInGarage)Enum.Parse(typeof(eVehicleStatusInGarage), vechileStatusFromUser);
                    if ((int)eStatusOnGarage > (int)Enum.GetValues(typeof(eVehicleStatusInGarage)).Cast<eVehicleStatusInGarage>().Last())
                    {
                        throw new ValueOutOfRangeException(3, 1);
                    }

                    return eStatusOnGarage;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},please enter InProgress(1)/Fixed(2)/Paid(3)", ex.Message);
                    vechileStatusFromUser = Console.ReadLine();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    vechileStatusFromUser = Console.ReadLine();
                }
            }
        }

        public static eFuelType GetFuelType()
        {
            string fuelTypeFromUser = Console.ReadLine();
            while (true)
            {
                try
                {
                    eFuelType eFuelTypeOfVehicle = (eFuelType)Enum.Parse(typeof(eFuelType), fuelTypeFromUser);
                    if ((int)eFuelTypeOfVehicle > (int)Enum.GetValues(typeof(eFuelType)).Cast<eFuelType>().Last())
                    {
                        throw new ValueOutOfRangeException(4, 1);
                    }

                    return eFuelTypeOfVehicle;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(@"Wrong input due to {0},please enter Soler(1)/Octan95(2)/Octan96(3)/octan98(4)/Electricty(5)", ex.Message);
                    fuelTypeFromUser = Console.ReadLine();
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    fuelTypeFromUser = Console.ReadLine();
                }
            }
        }

        public static float GetFloatFromUser()
        {
            while (true)
            {
                try
                {
                    return float.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to ' {0} '. please enter again :", ex.Message);
                }
            }
        }

        public static bool GetBoolFromUser()
        {
            while (true)
            {
                try
                {
                    return bool.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to ' {0} '. please enter again :", ex.Message);
                }
            }
        }

        public static string GetStringFromUser()
        {
            string fromUser;
            while (true)
            {
                try
                {
                    fromUser = Console.ReadLine();
                    if (fromUser.Equals(string.Empty))
                    {
                        throw new FormatException("string is empty.Please enter a valid input");
                    }

                    return fromUser;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to ' {0} '. please enter again :", ex.Message);
                }
            }
        }

        public static int GetIntFromUser()
        {
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to ' {0} '. please enter again :", ex.Message);
                }
            }
        }

        public static long GetLongIntFromUser()
        {
            while (true)
            {
                try
                {
                    return long.Parse(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(@"Input invalid due to ' {0} '. please enter again :", ex.Message);
                }
            }
        }

        public static int GetIntFromUserWithinRange(int i_MaxNumber, int i_MinNumber)
        {
            float checkedCommand;
            checkedCommand = GetFloatFromUser(); 
            while (true)
            {
                try
                {
                    CheckIfWithingRange(checkedCommand, i_MaxNumber, i_MinNumber);
                    return (int)checkedCommand;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    checkedCommand = GetIntFromUser();
                }
            }
        }

        public static float GetFloatFromUserWithinRange(float i_MaxNumber, float i_MinNumber)
        {
            float checkedCommand;
            checkedCommand = GetFloatFromUser(); 
            while (true)
            {
                try
                {
                    CheckIfWithingRange(checkedCommand, i_MaxNumber, i_MinNumber);
                    return checkedCommand;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    checkedCommand = GetFloatFromUser();
                }
            }
        }

        public static void CheckIfWithingRange(float i_ValueToSet, float i_MaxValuePossibe, float i_MinValuePossible)
        {
            if (i_ValueToSet > i_MaxValuePossibe || i_ValueToSet < i_MinValuePossible)
            {
                throw new ValueOutOfRangeException(i_MaxValuePossibe, i_MinValuePossible);
            }
        }

        public static float GetTheAirPressure(Vehicle i_CurrentVehicle)
        {
            float airPressure = GetFloatFromUser();
            float maxAirPressure = i_CurrentVehicle.VehiclesWheels[0].MaxAirPressure;
            while (true)
            {
                try
                {
                    CheckIfWithingRange(airPressure, maxAirPressure, 0);
                    return airPressure;
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                    airPressure = GetFloatFromUser();
                }
            }
        }
    }
}
