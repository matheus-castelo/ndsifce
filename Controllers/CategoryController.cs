using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // Método GET para listar todas as categorias
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context
        )
        {
            var categories = await context.Categories.ToListAsync();
            return Ok(categories);
        }

        // Método GET para buscar uma categoria por ID
        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context
        )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category); // Retorna a categoria com status 200 OK
        }

        // Método POST para criar uma nova categoria
        [HttpPost("v1/categories")]
        public async Task<IActionResult> CreateAsync(
        [FromBody] Category model,
        [FromServices] BlogDataContext context
    )
        {
            try
            {
                await context.Categories.AddAsync(model);
                await context.SaveChangesAsync();

                // Corrigindo a URL de forma relativa, para garantir que ela seja gerada corretamente
                return Created($"v1/categories/{model.Id}", model);
            }
            catch (DbUpdateException ex){
                return StatusCode(500,"Não foi possível incluir a categoria");
           
            }
            catch (Exception e)
            {
                return StatusCode(500, "Falha interna no servidor"); //Utiliza objeto StatusCode
            }
        }


        // Método PUT para atualizar uma categoria existente
        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> UpdateAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context
        )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category); // Apenas retorna a categoria com status 200 OK
        }

        // Método DELETE para excluir uma categoria
        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context
        )
        {
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

            context.Categories.Remove(category);
            await context.SaveChangesAsync();

            return Ok(); // Simplesmente retorna status 200 OK após a exclusão
        }
    }
}
