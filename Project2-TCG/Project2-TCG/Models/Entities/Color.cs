using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class Color
    {
        public Color()
        {
            Cards = new HashSet<Card>();
        }

        public int Id { get; set; }
        public string Color1 { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
