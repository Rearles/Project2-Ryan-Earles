using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class Rarity
    {
        public Rarity()
        {
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string Rarity1 { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
