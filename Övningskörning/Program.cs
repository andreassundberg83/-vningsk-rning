using System;
using System.Collections.Generic;

namespace Övningskörning
{
    class Program
    {
        static void Main(string[] args)
        {            
            Console.Write("När är du född? (ååååmmdd): ");
            int birthday = CheckIfValidDate(Console.ReadLine());
            Console.WriteLine(GetAgeString(GetAgeInt(birthday)));
            Console.WriteLine(WhatCanBePracticed(birthday));
            Console.ReadKey();          
        }
        /// <summary>
        /// Checks if input is a valid date. Returns and integer.
        /// </summary>
        /// <param name="userInput"></param>
        /// <returns></returns>
        static int CheckIfValidDate(string userInput)
        {
            string str_birthday = "";
            int int_birthday = 0;
            bool loopEnder = false;
            DateTime dt_birthday;
            do
            {
                if (userInput.Length == 8)
                {
                    try
                    {
                        str_birthday = userInput.Insert(4, "-");
                        str_birthday = str_birthday.Insert(7, "-");
                        dt_birthday = DateTime.Parse(str_birthday);
                        int_birthday = Int32.Parse(userInput);
                        loopEnder = DateTime.TryParse(str_birthday, out DateTime dt_test) && Int32.TryParse(userInput, out int int_test);
                        if (dt_birthday > DateTime.Today)
                        {
                            str_birthday = DateTime.Today.ToString("yyyyMMdd");
                            int_birthday = Convert.ToInt32(str_birthday);
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
            
            return int_birthday;

        }
        /// <summary>
        /// Builds a string containing vehicles permitted for driving practice.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        static string WhatCanBePracticed(int birthday)
        {
            string returnValue = "Du får övningsköra följande fordon:\n";
            int age = GetAgeInt(birthday);
            byte ageCategory = GetAgeCategory(age);
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
        /// Calculates age and return an integer.
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns></returns>
        static int GetAgeInt(int birthday)
        {
            string date_to_string = DateTime.Today.ToString("yyyyMMdd");
            int today = Convert.ToInt32(date_to_string);                        
            return (today - birthday);
        }
        /// <summary>
        /// Returns an age category according to your age.
        /// </summary>
        /// <param name="age"></param>
        /// <returns></returns>
        static byte GetAgeCategory(int age)
        {
            byte ageCategory;
            switch (age)
            {
                case < 140900:
                    ageCategory = 0;
                    break;
                case >= 140900 and < 150900:
                    ageCategory = 1;
                    break;
                case >= 150900 and < 160000:
                    ageCategory = 2;
                    break;
                case >= 160000 and < 170600:
                    ageCategory = 3;
                    break;
                case >= 170600 and < 180000:
                    ageCategory = 4;
                    break;
                case >= 180000 and < 190600:
                    ageCategory = 5;
                    break;
                case >= 190600 and < 210000:
                    ageCategory = 7;
                    break;
                case >= 210000 and < 230000:
                    ageCategory = 7;
                    break;
                case >= 750000 and < 1250000:
                    ageCategory = 9;
                    break;
                case >= 1250000:
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
        static string GetAgeString(int age)
        {
            int years = age/10000;
            int months = (age-years*10000) / 100;
            return $"Du är {years} år och {months} månader.";
        }
       
    }
}
