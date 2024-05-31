using HomeBanking.Models;

namespace HomeBanking.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client FindById(long id);
        Client FindByEmail(string email);
        void Save(Client client);

    }
}