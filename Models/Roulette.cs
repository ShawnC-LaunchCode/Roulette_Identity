using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Roulette_Identity.Models
{
    public class Roulette
    {
        public int NewNumber()
        {
            Random rnd = new Random();
            int next = rnd.Next(0, 37);
            return next;
        }
    }
}
