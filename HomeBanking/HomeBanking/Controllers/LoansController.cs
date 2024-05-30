using HomeBanking.DTOs;
using HomeBanking.Repositories;

using Microsoft.AspNetCore.Mvc;

namespace HomeBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    {
        private readonly ILoanRepository _loanRepository;
        public LoansController(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        [HttpGet]

        public IActionResult Get()

        {
            try
            {
                var loan = _loanRepository.GetAllLoans();
                var loansDTO = loan.Select(c => new LoanDTO(c)).ToList();
                //returns status code 
                return Ok(loansDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                var loan = _loanRepository.FindById(id);
                var loanDTO = new LoanDTO(loan);

                return Ok(loanDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
