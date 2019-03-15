using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mvc_Assignment_3.Models;

namespace Mvc_Assignment_3.Controllers
{
    public class GuessingGameController : Controller
    {
        public List<UserGuess> Guesses = new List<UserGuess>();
        //public int RndNumber { get; set; }

        public const string SessionKeyUserNumber = "_UserNumber";
        public const string SessionKeyRndNumber = "_RndNumber";
        public const string SessionKeyUserDetails = "_UserDetails";

        GuessCheck guessCheck = new GuessCheck();
        IUserGuess _userGuess;

        public GuessingGameController(IUserGuess userGuess)
        {
            _userGuess = userGuess;
        }

        [HttpGet]
        public IActionResult Index()
        {
            bool Done = guessCheck.TrueReset();
            if (Done == true)
            {
                _userGuess.RemoveAllValues();
            }
            HttpContext.Session.Clear();

            int RndNumber = guessCheck.RandomNumber();

            if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeyRndNumber)))
            {
                HttpContext.Session.SetInt32("_RndNumber", RndNumber);
            }

            return View(_userGuess.AllGuesses());
        }
        [HttpPost]
        public IActionResult Index(int number)
        {
            if (number != 0)
            {

                int randomNumber = (int)HttpContext.Session.GetInt32("_RndNumber");

                string details = guessCheck.Compare(number, randomNumber);

                _userGuess.NewGuess(details, number);

                HttpContext.Session.SetInt32("_UserNumber", number);
                HttpContext.Session.SetString("_UserDetails", details);
                ViewBag.Random = randomNumber;
            }
            else
            {
                ViewBag.Blank = "Please enter a value before pressing the button.";
            }
            bool Done = guessCheck.Reset();

            if (Done == true)
            {
                return RedirectToAction("Index", "GuessingGame");
            }
            return View(_userGuess.AllGuesses());
        }
    }
}