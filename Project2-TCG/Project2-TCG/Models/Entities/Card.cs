using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class Card
    {
        public Card()
        {
            UsersCards = new HashSet<UsersCard>();
        }

        public int Id { get; set; }
        public int Cost { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int? Color { get; set; }
        public int? Rarity { get; set; }
        public string Name { get; set; }

        public virtual Color ColorNavigation { get; set; }
        public virtual Rarity RarityNavigation { get; set; }
        public virtual ICollection<UsersCard> UsersCards { get; set; }
    }
}
