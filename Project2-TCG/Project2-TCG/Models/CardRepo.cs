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
        public Card GetRandomCardofRarity(int id)
        {
            List<Card> cards = (List<Card>)_context.Cards.Select(x => x.Rarity == id); //grab all cards with the given rarity
            var cardCount = cards.Count();//get the ids 
            Random random = new Random();
            int selection = random.Next(1, cardCount); //choose a random id from those cards selected
            Card foundcard = cards.Find(x => x.Id == selection); //find the card at the selected id
            return foundcard;//return that card
            
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

        List<Card> ICardRepo.GetUsersCards(int userId)//grab all cards from Card/User join at the userid
        {
            List<Card> cards = new List<Card>();//models
            List<UsersCard> userscards = (List<UsersCard>)_context.UsersCards.Select(x => x.UserId == userId);//models.entity
            foreach (UsersCard u in userscards)
            {
                    //u.card is models.entities.card and cards is models.card so take every aspect of a UsersCard.Card and put it into a Models.Card
                    Card card = new Card(u.Card.Id, u.Card.Cost, u.Card.Attack, u.Card.Defense, u.Card.Name, u.Card.Rarity.ToString(), u.Card.Color.ToString());
                    for (int i = 1; i <= u.Quantity; i++)//this adds quantity of cards to the user.
                    {
                        cards.Add(card);
                    }
            }
            return cards;
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
