using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Roulette_Identity.Areas.Identity.Data;
using Roulette_Identity.ViewModels;
using Roulette_Identity.Models;


namespace Roulette_Identity.Controllers
{
    public class RouletteController : Controller

    {
        private RouletteDbContext context;
        private readonly UserManager<IdentityUser> _userManager;
        private static List<Bet> bets = new List<Bet>();
        private static int LastSpin = 0;
        private static User user = new User("Shawn", 5000);

        public RouletteController(RouletteDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()//everything to display to user 
        {
            var userId = _userManager.GetUserId(User);
            //TODO generate name and bank from User

            RouletteViewModel viewModel = new RouletteViewModel
            {
                Bets = bets,
                BetAmount = 10,
                Player = user,
                LastSpinNumber = LastSpin
            };
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult PlaceBet(int betAmount, string betType)
        {
            if (betAmount <= user.Bank)
            {

                user.Bank -= betAmount;
                Bet bet = new Bet
                {
                    Amount = betAmount,
                    Type = betType
                };

                bets.Add(bet);
            }
           
            return Redirect("/Roulette");
        }

        [HttpPost]
        public IActionResult ResetBets()
        {
            bets.Clear();
            return Redirect("/Roulette");
        }

        [HttpPost]
        public IActionResult SpinWheel()
        {
            LastSpin = NewNumber();

            return Redirect("/Roulette");
        }

        public int NewNumber()
        {
            Random rnd = new Random();
            int next = rnd.Next(0, 37);
            return next;
        }
    }
}
