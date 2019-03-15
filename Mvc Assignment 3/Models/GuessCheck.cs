using Mvc_Assignment_3.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Assignment_3.Models
{
    public class GuessCheck : IUserGuess
    {
        public bool Done { get; set; }

        public List<UserGuess> Guesses = new List<UserGuess>();
        private string idNumber = "Guess nr: ";
        private int idCount = 1;

        //public GuessCheck()
        //{
        //    Guesses.Add(new UserGuess() { Id = 0, Details = "Your guess was too low! Your guess was: ", Guess = 0 });
        //}

        public List<UserGuess> AllGuesses()
        {
            return Guesses;
        }

        public UserGuess NewGuess(string details, int guess)
        {
            UserGuess userGuess = new UserGuess() { IdNumber = idNumber, Id = idCount, Details = details, Guess = guess };
            idCount++;
            Guesses.Add(userGuess);
            return userGuess;
        }

        public string Compare(int? userGuess, int RndNumber)
        {
            string answer = "";

            if (userGuess == RndNumber)
            {
                answer = "Congratulations! You guessed correctly! The number was: ";
                Done = true;
            }
            else if (userGuess > RndNumber)
            {
                answer = "Your guess was too big, please try again! Your guess was: ";
            }
            else
            {
                answer = "Your guess was too small, please try again! Your guess was: ";
            }

            return answer;
        }

        public int RandomNumber()
        {
            Random random = new Random();
            int Number = random.Next(1, 101);
            return Number;
        }

        public bool Reset()
        {
            return Done;
        }

        public bool TrueReset()
        {
            bool Done = true;
            return Done;
        }

        public List<UserGuess> RemoveAllValues()
        {
           Guesses.Clear();
            return Guesses;
        }
    }
}
