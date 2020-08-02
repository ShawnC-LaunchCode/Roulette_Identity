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

        public RouletteController(RouletteDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            context = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()//everything to display to user 
        {
            var userId = _userManager.GetUserId(User);
            //generate name and bank from User



            int spinNumber = 25;//TODO make this random

       

            RouletteViewModel viewModel = new RouletteViewModel
            {
                //Bets = bets,
                Bets = bets,
                BetAmount = 10,
                Player = new User("Shawn", 5000),
                LastSpinNumber = spinNumber

            };

            return View(viewModel);
        }


        [HttpPost]
        public IActionResult PlaceBet(int betAmount, string betType)
        {
            Bet bet = new Bet
            {
                Amount = betAmount,
                Type = betType
            };

            bets.Add(bet);
           
            return Redirect("/Roulette");
        }

        [HttpPost]
        public IActionResult ResetBets()
        {
            bets.Clear();
            return Redirect("/Roulette");
        }
    }
}
