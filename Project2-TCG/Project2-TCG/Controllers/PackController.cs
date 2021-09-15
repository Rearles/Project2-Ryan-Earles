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
        [HttpGet("{numberOfPacks}")]
        public List<Card> Get(int numberOfPacks)
        {
            List<Card> cardsOpened = new List<Card>();
            int totalCards = numberOfPacks * 5;

            for (int i = 0; i < totalCards; i++)
            {
                cardsOpened.Add(_cardRepo.GetRandomCard());
            }

            return cardsOpened;
        }
    }
}
