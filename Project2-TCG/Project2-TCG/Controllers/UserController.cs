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
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Instance of DbContext
        /// </summary>
        private cardgameContext _context;
        private ICardRepo _cardRepo;

        /// <summary>
        /// Constructor that takes DbContext and the repository as params 
        /// </summary>
        /// <returns></returns>
        public UserController(cardgameContext context, ICardRepo cardRepo)
        {
            _context = context;
            _cardRepo = cardRepo;
        }

        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        //Get: api/<UserController>
        [HttpGet("collection/{username}")]
        public List<Models.Card> GetCollection(string username)
        {
            int userId = _cardRepo.GetUserByName(username).Id;
            return _cardRepo.GetUsersCards(userId);
        }

        // GET api/<UserController>/5
        [HttpGet("{name}")]
        public string Username(string name)
        {
            var user = _cardRepo.GetUserByName(name);
            return user.Username.ToString();
        }

        // POST api/<UserController>
        [HttpPost]
        public CreatedUser Post([FromBody] CreatedUser user)
        {
            return _cardRepo.AddUser(user.username, user.password);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
