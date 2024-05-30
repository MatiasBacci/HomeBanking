using HomeBanking.Models;

namespace HomeBanking.Repositories
{
    public interface ILoanRepository
    {
        IEnumerable<Loan> GetAllLoans();
        void Save(Loan loan);
        Loan FindById(long id);
    }
}
