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
    public class LoginController : ControllerBase
    {
        private ICardRepo _cardRepo;

        /// <summary>
        /// Constructor that takes DbContext and the repository as params 
        /// </summary>
        /// <returns></returns>
        public LoginController(ICardRepo cardRepo)
        {
            _cardRepo = cardRepo;
        }

        // POST api/<LoginController>
        [HttpPost]
        public Models.User Post(LoggedInUser user)
        {
            return _cardRepo.LogIn(user.username, user.password);
        }

        // PUT api/<LoginController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LoginController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
