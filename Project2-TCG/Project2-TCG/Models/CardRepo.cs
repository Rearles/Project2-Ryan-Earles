using Project2_TCG.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2_TCG.Models
{
    /// <summary>
    /// implementation of ICardRepo
    /// </summary>
    public class CardRepo : ICardRepo
    {
        private cardgameContext _context;

        public CardRepo(cardgameContext context)
        {
            _context = context;
        }

        User ICardRepo.AddUser()
        {
            throw new NotImplementedException();
        }

        List<Card> ICardRepo.FilterCardsByRarity(Rarity rarity)
        {
            throw new NotImplementedException();
        }

        Color ICardRepo.GetColor(int id)
        {
            throw new NotImplementedException();
        }

        Card ICardRepo.GetRandomCard()
        {
            throw new NotImplementedException();
        }

        Rarity ICardRepo.GetRarity(int id)
        {
            throw new NotImplementedException();
        }

        User ICardRepo.GetUserByName(string name)
        {
            var user = _context.Users.Single(u => u.Username.Equals(name));

            User foundUser = new User(user.Username, user.Password);

            return foundUser;
        }

        List<Card> ICardRepo.GetUsersCards(int userId)
        {
            throw new NotImplementedException();
        }

        List<Card> ICardRepo.OpenPack(int numPacks)
        {
            throw new NotImplementedException();
        }

        List<Card> ICardRepo.SearchCardByName(string searchString)
        {
            throw new NotImplementedException();
        }

        void ICardRepo.UpdateUserCurrency(User user)
        {
            throw new NotImplementedException();
        }

        public User SearchUserById(int id)
        {
            var user = _context.Users.Single(u => u.Id == id);

            User foundUser = new User(user.Username, user.Password);

            return foundUser;
        }
    }
}
