using System;
using System.Collections.Generic;

namespace Övningskörning
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("När är du född? (ååååmmdd): ");
            DateTime birthday = CheckIfValidDate(Console.ReadLine());
            GetAge(birthday, out int years, out int months);
            Console.WriteLine(GetAgeString(years, months));
            Console.WriteLine(WhatCanBePracticed(years, months));
            Console.ReadKey();          
        }
        /// <summary>
        /// Checks if input is a valid date. Returns and integer.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        static DateTime CheckIfValidDate(string userInput)
        {            
            bool loopEnder = false;
            DateTime dt_birthday = DateTime.Today;
            do
            {
                if (userInput.Length == 8)
                {
                    try
                    {
                        userInput = userInput.Insert(4, "-");
                        userInput = userInput.Insert(7, "-");                        
                        loopEnder = DateTime.TryParse(userInput, out dt_birthday);
                        if (dt_birthday > DateTime.Today)
                        {
                            dt_birthday = DateTime.Today;
                            
                        }                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.Write("Mata in årtal enligt följande 'ååååmmdd' : ");
                        userInput = (Console.ReadLine());
                        continue;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Felaktig inmatning.");
                    Console.Write("Mata in årtal enligt följande 'ååååmmdd' : ");
                    userInput = (Console.ReadLine());
                }

            } while (loopEnder == false);
            
            return dt_birthday;

        }
        /// <summary>
        /// Builds a string containing vehicles permitted for driving practice.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        static string WhatCanBePracticed(int years, int months)
        {
            string returnValue = "Du får övningsköra följande fordon:\n";            
            byte ageCategory = GetAgeCategory(years, months);
            List<string> typeOfVehicle = new List<string>()
            {
                "Moped klass I (EU-Moped)\n",
                "Lätt motorcykel\n",
                "Personbil\n",
                "Medelstor motorcykel\nTung motorcykel (i trafikskola)\nPersonbil med lätt släpvagn\nLätt lastbil\n",
                "Personbil med tungt släp och lastbil med tungt släp\n",
                "Tung motorcykel (om du haft körkort för medelstor motorcykel i minst 1 år och 6 månader)\n",
                "Buss och buss med släp\n",
                "Tung motorcykel med obegränsad effekt\n",
                "\nMed tanke på din ålder borde du överväga om det är lämpligt att övningsköra."
            };
            if (ageCategory <1)
            {
                returnValue = "Du är för ung för att övningsköra.";
            }
            else if (ageCategory > 9)
            {
                returnValue = "Du antagligen redan död eller så är du en vampyr, i vilket fall borde du inte övningsköra!";
            }
            else
            {
                for (int i = 0; i < ageCategory; i++)
                {
                    if (i == 3 && ageCategory > 7) continue;
                    if (i == 5 && ageCategory > 7) continue;
                    returnValue += typeOfVehicle[i];
                }
            }
            
            return returnValue;
        }
        /// <summary>
        /// Calculates age and returns an integer.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        static void GetAge(DateTime birthday, out int years, out int months)
        {
            years = DateTime.Today.Year - birthday.Year;
            months = DateTime.Today.Month - birthday.Month;
            int days = DateTime.Today.Day - birthday.Day;
            if (days == 0 && months == 0)
            {
                Console.WriteLine("Grattis på födelsedagen!");
            }
            if (days < 0)
            {
                months--;
            }
            if (months < 0)
            {
                years--;
                months += 12;
            }
        }
        /// <summary>
        /// Returns an age category according to your age.
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        static byte GetAgeCategory(int years, int months)
        {
            byte ageCategory;
            switch (years)
            {
                case < 14:
                    ageCategory = 0;
                    break;
                case 14:
                    if (months >= 9) ageCategory = 1; else ageCategory = 0;
                    break;
                case 15:
                    if (months >= 9) ageCategory = 2; else ageCategory = 1;
                    break;
                case 16:
                    ageCategory = 3;
                    break;
                case 17:
                    if (months >= 6) ageCategory = 4; else ageCategory = 3;
                    break;
                case 18:
                    ageCategory = 5;
                    break;
                case 19:
                    if (months >= 6) ageCategory = 6; else ageCategory = 5;
                    break;
                case 20:
                    ageCategory = 6;
                    break;
                case 21:
                case 22:
                    ageCategory = 7;
                    break;
                case >= 75 and <= 125:
                    ageCategory = 9;
                    break;
                case > 125:
                    ageCategory = 10;
                    break;       
                default:
                    ageCategory = 8;
                    break;
            }
            return ageCategory;
        }
        /// <summary>
        /// Builds a string with age in years and months.
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        static string GetAgeString(int years, int months)
        {                                    
            return $"Du är {years} år och {months} månader.";
        }
       
    }
}
