using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create my object
            Newtonsoft.Json.Linq.JObject jsonObject = null;

            Console.Write("Enter JSON Object : ");
            string jsonData = Console.ReadLine();

            Console.Write("Enter Serach key : ");
            string searchKey = Console.ReadLine();

            //Print the Json object
            Console.WriteLine(jsonData);

            //Parse the json object
            try
            {
                if( searchKey.IndexOf("/") >= 0 ) 
                {
                    if (isJsonString(jsonData))
                    {
                        jsonObject = JObject.Parse(jsonData);

                        string[] strArray = searchKey.Split('/');

                        Newtonsoft.Json.Linq.JObject jsonObjectData = (JObject)jsonObject[strArray[0]];
                     
                        string lastkey = strArray[strArray.Length - 1];

                        for(int i = 1; i< strArray.Length - 1; i++)
                        {
                            jsonObjectData = (JObject)jsonObjectData[strArray[i]];
                        }

                        Console.WriteLine((string)jsonObjectData[lastkey]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid JSON Object: " + jsonData);
                    }
                    
                } 
                else
                {
                    Console.WriteLine("Invalid Search Key");
                }
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadKey();

        }

        static bool isJsonString(string str)
        {
            try
            {
                JObject.Parse(str);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
