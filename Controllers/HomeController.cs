//HomeController.cs
using Microsoft.AspNetCore.Mvc;
// Health Check (checando se a API tá online ou offline). Precisamos ter um endpoint para receber um status se a API ta online ou não.
namespace Blog.Controllers 
{
    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase {
        [HttpGet("")]
        public IActionResult Get(){ //Health-Check
            return Ok(); //Voce poderia retornar um objeto anônimo como return Ok(new {fruta = "banana");
        }
    }
}