using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Models
{
    public class User
    {
        /// <summary>
        /// empty constuctor
        /// </summary>
        public User () { }
        /// <summary>
        /// constructor for creating a new user
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        public User(string name, string pass) {
            this.Username = name;
            this.Password = pass;
            this.Currency = 0;
        }
        /// <summary>
        /// constuctor for getting user from database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="pass"></param>
        /// <param name="currency"></param>
        public User(int id, string name, string pass, int currency, List<Card> collection)
        {
            this.Id = id;
            this.Username = name;
            this.Password = pass;
            this.Currency = currency;
            this.Collection = collection;
        }
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Currency { get; set; }
        public List<Card> Collection { get; set; }
    }
}
