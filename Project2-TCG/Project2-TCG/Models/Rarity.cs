using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Models
{
    public class Rarity
    {
        /// <summary>
        /// empty constructor
        /// </summary>
        public Rarity() { }
        /// <summary>
        /// constructor retrieving rarity from database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rarity"></param>
        public Rarity(int id, string rarity)
        {
            this.Id = id;
            this.RarityName = rarity;
        }
        int Id { get; set; }
        string RarityName { get; set; }
    }
}
