using HomeBanking.DTOs;
using HomeBanking.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HomeBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase;
    namespace HomeBanking.Controllers

    {
        [Route("api/[controller]")]
        [ApiController]

        public class AccountsController : ControllerBase

        {
            private readonly IAccountRepository _accountRepository;
            public AccountsController(IAccountRepository accountRepository)
            {
                _accountRepository = accountRepository;
            }

            [HttpGet]

            public IActionResult Get()

            {
                try
                {
                    var account = _accountRepository.GetAllAccounts();
                    var accountDTO = account.Select(a => new AccountDTO(a)).ToList();
                    //returns status code 
                    return Ok(accountDTO);
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
                    var account = _accountRepository.FindById(id);
                    var accountDTO = new AccountDTO(account);

                    return Ok(accountDTO);
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            }
        }
    }
}
