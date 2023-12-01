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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _dataContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            return Ok(country);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Country country)
        {
            // ctrl + k + s => envolver
            try
            {
                // _dataContext.Countries.Add(country);
                _dataContext.Add(country); // marca en la BD (no commit)
                await _dataContext.SaveChangesAsync(); // commit
                return Ok(country);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                if (dbUpdateConcurrencyException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre");
                }

                return BadRequest(dbUpdateConcurrencyException.Message);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Country country)
        {
            try
            {
                // _dataContext.Countries.Add(country);
                _dataContext.Update(country); // marca en la BD (no commit)
                await _dataContext.SaveChangesAsync(); // commit
                return Ok(country);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                if (dbUpdateConcurrencyException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un país con el mismo nombre");
                }

                return BadRequest(dbUpdateConcurrencyException.Message);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _dataContext.Countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                return NotFound();
            }

            _dataContext.Remove(country); // marca en la BD (no commit)
            await _dataContext.SaveChangesAsync(); // commit

            return NoContent();
        }
    }
}
