using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project2_TCG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private ICardRepo _cardRepo;

        /// <summary>
        /// Constructor that takes the cardRepo as a param and sets it to a local variable
        /// </summary>
        /// <returns></returns>
        public GameController(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }
        /// <summary>
        /// Gets a single card, mainly for drawing cards based on difficulty
        /// </summary>
        /// <param name="rarityid"></param>
        /// <returns List of Card></returns>
        // GET: GameController
        [HttpGet("{Card}")]
        public Card GetCard(string difficulty) //1 common, 2 uncommon, 3 rare, 4 mega rare.
        {
            Card card = new Card();
            Random random = new Random();
            int selection = random.Next(1, 100);
            if (difficulty == "Easy")//if its easy a lot of percent chance for common, some chance for uncommon, a small chance for rare and mega rare
            {
                //70% towards common, 15% towards uncommon, 10% towards rare 5% mega rare
                if (selection >= 1 && selection <= 70)
                {
                    card = _cardRepo.GetRandomCardofRarity(1);
                }
                else if (selection >= 71 && selection <= 85)
                {
                    card = _cardRepo.GetRandomCardofRarity(2);
                }
                else if (selection >= 86 && selection <= 95)
                {
                    card = _cardRepo.GetRandomCardofRarity(3);
                }
                else if (selection >= 95 && selection <= 100)
                {
                    card = _cardRepo.GetRandomCardofRarity(4);
                }

            }
            else if (difficulty == "Medium") //if its medium the percent moves towards more uncommon, more rare, more mega rare
            {
               
                //20% common, 25% towards uncommon, 20% rare, 25% mega rare
                if (selection >= 1 && selection <= 20)
                {
                    card = _cardRepo.GetRandomCardofRarity(1);
                }
                else if (selection >= 21 && selection <= 45)
                {
                    card = _cardRepo.GetRandomCardofRarity(2);
                }
                else if (selection >= 46 && selection <= 65)
                {
                    card = _cardRepo.GetRandomCardofRarity(3);
                }
                else if (selection >= 66 && selection <= 100)
                {
                    card = _cardRepo.GetRandomCardofRarity(4);
                }

            }
            else if (difficulty == "Hard") //if its hard, most likely a selected card will be rare or mega rare
            {
                //5% common, 10% uncommon, 25% rare, 60% mega rare
                if (selection >= 1 && selection <= 5)
                {
                    card = _cardRepo.GetRandomCardofRarity(1);
                }
                else if (selection >= 6 && selection <= 15)
                {
                    card = _cardRepo.GetRandomCardofRarity(2);
                }
                else if (selection >= 16 && selection <= 40)
                {
                    card = _cardRepo.GetRandomCardofRarity(3);
                }
                else if (selection >= 41 && selection <= 100)
                {
                    card = _cardRepo.GetRandomCardofRarity(4);
                }

            }
            return card;
        }
        [HttpGet("{List<Card>}")]
        public List<Card> GetHand(int numtimes, string difficulty)
        {
            Random random = new Random();
            int selection = random.Next(1, 100);
            List<Card> cards = new List<Card>();
            for (int i = 0; i < numtimes; i++)
            {
                if (difficulty == "Easy")//if its easy a lot of percent chance for common, some chance for uncommon, a small chance for rare and mega rare
                {
                    //70% towards common, 15% towards uncommon, 10% towards rare 5% mega rare
                    if (selection >= 1 && selection <= 70)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(1));
                    }
                    else if (selection >= 71 && selection <= 85)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(2));
                    }
                    else if (selection >= 86 && selection <= 95)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(3));
                    }
                    else if (selection >= 95 && selection <= 100)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(4));
                    }

                }
                else if (difficulty == "Medium") //if its medium the percent moves towards more uncommon, more rare, more mega rare
                {

                    //20% common, 25% towards uncommon, 20% rare, 25% mega rare
                    if (selection >= 1 && selection <= 20)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(1));
                    }
                    else if (selection >= 21 && selection <= 45)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(2));
                    }
                    else if (selection >= 46 && selection <= 65)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(3));
                    }
                    else if (selection >= 66 && selection <= 100)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(4));
                    }

                }
                else if (difficulty == "Hard") //if its hard, most likely a selected card will be rare or mega rare
                {
                    //5% common, 10% uncommon, 25% rare, 60% mega rare
                    if (selection >= 1 && selection <= 5)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(1));
                    }
                    else if (selection >= 6 && selection <= 15)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(2));
                    }
                    else if (selection >= 16 && selection <= 40)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(3));
                    }
                    else if (selection >= 41 && selection <= 100)
                    {
                        cards.Add(_cardRepo.GetRandomCardofRarity(4));
                    }

                }
            }
            return cards;
        }
        [HttpGet("{currency}")]
        public void UpdateCurrency(User user, int currency, bool plusminus)
        {
            _cardRepo.UpdateUserCurrency(user, currency, plusminus);
        }
    }
}
