using HomeBanking.Models;

namespace HomeBanking.Repositories
{
    public interface ICardRepository
    {
        IEnumerable<Card> GetAllCards();
        void Save(Card card);
        Card FindById(long id);
    }
}
