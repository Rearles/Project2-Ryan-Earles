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

        public void AddUser(string username, string password)
        {
            _context.Users.Add(new Entities.User
            {
                Username = username,
                Password = password
            });

            _context.SaveChanges();
        }

        List<Card> ICardRepo.FilterCardsByRarity(Rarity rarity)
        {
            throw new NotImplementedException();
        }

        Color ICardRepo.GetColor(int id)
        {
            throw new NotImplementedException();
        }

        public Card GetRandomCard()
        {
            var cardCount = _context.Cards.Count();
            Random random = new Random();
            int selection = random.Next(1, cardCount);

            var card = _context.Cards.Single(c => c.Id == selection);
            var color = _context.Colors.Single(c => c.Id == card.Color);
            var rarity = _context.Rarities.Single(r => r.Id == card.Rarity);
            Card foundCard = new Card(card.Id, card.Cost, card.Attack, card.Defense, card.Name, color.Color1, rarity.Rarity1);
            return foundCard;
        }
        public Card GetRandomCardofRarity(Rarity rarity)
        {
            
            List<Card> cards = (List<Card>)_context.Cards.Select(x => x.Rarity.ToString() == rarity.ToString()); //grab all cards with the given rarity
            var cardCount = cards.Count();
            Random random = new Random();
            int selection = random.Next(1, cardCount); //choose a random id from those cards selected
            Card foundcard = cards.Find(x => x.Id == selection); //find the card at the selected id
            return foundcard;//return that card
            //find a random card with the rarity above
            //find all cards with the given rarity and select a random one to return
            
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

        public Card SearchCardByName(string searchString)
        {
            var card = _context.Cards.Single(c => c.Name.Equals(searchString));
            var color = _context.Colors.Single(c => c.Id == card.Color);
            var rarity = _context.Rarities.Single(r => r.Id == card.Rarity);

            Card foundCard = new Card(card.Id, card.Cost, card.Attack, card.Defense, card.Name, color.Color1, rarity.Rarity1);
            return foundCard;
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
