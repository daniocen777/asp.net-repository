using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private DataContext _dataContext;

        public CategoriesController(DataContext dataContext)
        {
             _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _dataContext.Categories.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Category category)
        {
            // ctrl + k + s => envolver
            try
            {
                // _dataContext.Countries.Add(country);
                _dataContext.Add(category); // marca en la BD (no commit)
                await _dataContext.SaveChangesAsync(); // commit
                return Ok(category);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                if (dbUpdateConcurrencyException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre");
                }

                return BadRequest(dbUpdateConcurrencyException.Message);
            }
            catch (Exception exeption)
            {
                return BadRequest(exeption.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Category category)
        {
            try
            {
                // _dataContext.Countries.Add(country);
                _dataContext.Update(category); // marca en la BD (no commit)
                await _dataContext.SaveChangesAsync(); // commit
                return Ok(category);
            }
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                if (dbUpdateConcurrencyException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una categoría con el mismo nombre");
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
            var category = await _dataContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            _dataContext.Remove(category); // marca en la BD (no commit)
            await _dataContext.SaveChangesAsync(); // commit

            return NoContent();
        }
    }
}
