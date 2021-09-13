using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Models
{
    public class Card
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public Card() { }
        /// <summary>
        /// constuctor for getting a card from the DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cost"></param>
        /// <param name="att"></param>
        /// <param name="def"></param>
        /// <param name="name"></param>
        /// <param name="col"></param>
        /// <param name="rare"></param>
        public Card(int id, int cost, int att, int def, string name, Color col, Rarity rare)
        {
            this.Id = id;
            this.Cost = cost;
            this.Attack = att;
            this.Defense = def;
            this.Name = name;
            this.Color = col;
            this.Rarity = rare;
        }
        public int Id { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Name { get; set; }
        public Color Color { get; set; }
        public Rarity Rarity { get; set;  }
        /// <summary>
        /// method for getting the image of this card
        /// </summary>
        /// <returns></returns>
        public string GetImage()
        {
            string imgLink = "";
            return imgLink;
        } 
    }
}
