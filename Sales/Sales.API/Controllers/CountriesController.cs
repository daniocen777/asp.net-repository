using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public CountriesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dataContext.Countries.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            // _dataContext.Countries.Add(country);
            _dataContext.Add(country); // marca en la BD (no commit)
            await _dataContext.SaveChangesAsync(); // commit
            return Ok(country);
        }
    }
}
