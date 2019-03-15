using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Assignment_3.Models
{
    public class CheckFever
    {
        public static string Check(double temp, string type)
        {
            string fever = "";

            if (type == "Fahrenheit")
            {
                temp = CheckFahrenheit(temp);
            }
            if (temp >= 38 && temp <= 40)
            {
                fever = "You have a fever!";
            }
            else if (temp > 40)
            {
                fever = "Are you sure you're alive? You're burning up!";
            }
            else if (temp <= 36 && temp >= 34)
            {
                fever = "You have hypothermia!";
            }
            else if (temp < 34)
            {
                fever = "You're practically made of ice! Go seek a doctor!";
            }
            else
            {
                fever = "You do not have fever, hurray!";
            }



            return fever;
        }

        private static double CheckFahrenheit(double temp)
        {
            return (5.0 / 9.0) * (temp - 32);
        }
    }
}
