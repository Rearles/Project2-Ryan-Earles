using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class UsersCard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CardId { get; set; }
        public int Quantity { get; set; }

        public virtual Card Card { get; set; }
        public virtual User User { get; set; }
    }
}
