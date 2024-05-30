using HomeBanking.DTOs;
using HomeBanking.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardRepository _cardRepository;
        public CardsController(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        [HttpGet]

        public IActionResult Get()

        {
            try
            {
                var cards = _cardRepository.GetAllCards();
                var cardsDTO = cards.Select(c => new CardDTO(c)).ToList();
                //returns status code 
                return Ok(cardsDTO);
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
                var card = _cardRepository.FindById(id);
                var cardDTO = new CardDTO(card);

                return Ok(cardDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
