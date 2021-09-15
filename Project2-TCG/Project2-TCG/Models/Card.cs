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
        public Card(int id, int cost, int att, int def, string name, string col, string rare)
        {
            this.Id = id;
            this.Cost = cost;
            this.Attack = att;
            this.Defense = def;
            this.Name = name;
            this.Color = col;
            this.Rarity = rare;
        }

        public Card(int id, int cost, int attack, int defense, string name)
        {
            this.Id = id;
            this.Cost = cost;
            this.Attack = attack;
            this.Defense = defense;
            this.Name = name;
        }

        public int Id { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Rarity { get; set;  }
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
