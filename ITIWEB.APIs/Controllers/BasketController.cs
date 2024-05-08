using Core.Entities;
using Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ITIWEB.APIs.Controllers
{

    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(string id)
        {
            var basket = await _basketRepository.GetBasketAsync(id);
            return Ok(basket ?? new CustomerBasket(id));
        }
        [HttpPost()]
        public async Task<ActionResult<CustomerBasket>> PostBasketById(CustomerBasket basket)
        {
          var UpdateOrCreatedBasket = await _basketRepository.UpdateBasketAsync(basket);
            return Ok(UpdateOrCreatedBasket);
        }
        [HttpDelete()]
        public async Task<ActionResult<CustomerBasket>> DeleteBasketById(string id)
        {
            var DeleteBasket = await _basketRepository.DeleteBasketAsync(id);
            return Ok(DeleteBasket);
        }
    }
}
