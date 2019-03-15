using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc_Assignment_3.Models
{
    public interface IUserGuess
    {
        UserGuess NewGuess(string details, int Guess);

        List<UserGuess> AllGuesses();

        List<UserGuess> RemoveAllValues();
    }
}
