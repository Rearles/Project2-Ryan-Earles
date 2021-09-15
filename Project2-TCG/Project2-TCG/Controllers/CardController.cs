using Microsoft.AspNetCore.Mvc;
using Project2_TCG.Models;
using Project2_TCG.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project2_TCG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private ICardRepo _cardRepo;
        private cardgameContext _context;

        public CardController(ICardRepo cardRepo, cardgameContext context)
        {
            _cardRepo = cardRepo;
            _context = context;
        }

        // GET: api/<CardController>
        [HttpGet("{name}")]
        public ActionResult<Models.Card> Get(string name)
        {
            return _cardRepo.SearchCardByName(name);
        }

        //Random Card Search
        [HttpGet]
        public ActionResult<Models.Card> Get()
        {
            return _cardRepo.GetRandomCard();
        }

        // POST api/<CardController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
