using System;
using System.Collections.Generic;

#nullable disable

namespace Project2_TCG.Models.Entities
{
    public partial class User
    {
        public User()
        {
            UsersCards = new HashSet<UsersCard>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? Currency { get; set; }

        public virtual ICollection<UsersCard> UsersCards { get; set; }
    }
}
