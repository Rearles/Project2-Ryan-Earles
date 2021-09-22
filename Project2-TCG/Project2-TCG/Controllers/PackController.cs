using Microsoft.AspNetCore.Mvc;
using Project2_TCG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2_TCG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackController : ControllerBase
    {
        private ICardRepo _cardRepo;

        public PackController(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        // GET: api/<PackController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PackController>/5
        [HttpGet("{username}")]
        public List<Card> Get(string username) //odds for certain cards to be pulled include 50% common, 25% uncommon, 18% rare, 7% mega rare
        {
            int userId = _cardRepo.GetUserByName(username).Id;

            List<Card> cardsOpened = new List<Card>();
            Random random = new Random();
            int rarityselection;
            for (int i = 0; i < 5; i++)
            {
                rarityselection = random.Next(1, 75);//makes a new random number from 1 to 100
                if (rarityselection >= 1 && rarityselection <= 50)
                {
                    cardsOpened.Add(_cardRepo.GetRandomCardofRarity(1));
                }//checks if the number rarityselection falls into the percent chance of common cards and adds a random common card to pack
                else if (rarityselection >= 51 && rarityselection <= 75)
                {
                    cardsOpened.Add(_cardRepo.GetRandomCardofRarity(2));
                }//checks if the number rarityselection falls into the percent chance of uncommon cards and adds a random uncommon card to pack
                else if (rarityselection >= 76 && rarityselection <= 93)
                {
                    cardsOpened.Add(_cardRepo.GetRandomCardofRarity(3));
                }//checks if the number rarityselection falls into the percent chance of rare cards and adds a random rare card to pack
                else if (rarityselection >= 94 && rarityselection <= 100)
                {
                    cardsOpened.Add(_cardRepo.GetRandomCardofRarity(4));
                }//checks if the number rarityselection falls into the percent chance of mega rare cards and adds a random mega rare card to pack

            }
            foreach (Card c in cardsOpened)
            {
                _cardRepo.AddCardToUsersCollection(userId, c.Id);
            }
            return cardsOpened;
        }
    }
}
