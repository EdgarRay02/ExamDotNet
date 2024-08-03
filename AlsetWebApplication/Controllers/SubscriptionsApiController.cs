using AlsetLibrary;
using AlsetLibrary.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AlsetWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionsApiController : ControllerBase
    {
        private readonly ContosoDbContext _context;

        public SubscriptionsApiController(ContosoDbContext context)
        {
            _context = context;
        }

        [HttpPost("Follow")]
        public async Task<IActionResult> Follow(CreateSubscription dto)
        {
            var result = _context.Researchers.FirstOrDefault(e => e.Id == dto.IdResearcher);
           
            Subscription subscription = new Subscription();
            subscription.Email = dto.Email;
            subscription.IdResearcher = dto.IdResearcher;

            _context.Subscriptions.Add(subscription);

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                var s = ex.Message;
            }
            return Ok();
        }
    }
}
