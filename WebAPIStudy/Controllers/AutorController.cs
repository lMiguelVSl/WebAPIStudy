using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIStudy.Data;
using WebAPIStudy.Model;

namespace WebAPIStudy.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutorController : Controller
    {
        private ApplicationDbContext _db;
        public AutorController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Autor>>> GetAutores() //async ya que es con un servicio externo, retorno una lista de tipo autores
        {
            return await _db.Autores.ToListAsync(); 
        }

        [HttpPost]
        public async Task<ActionResult> PostAutor(Autor autor)
        {
            _db.Add(autor); //agregar el autor recibido como parametro
            await _db.SaveChangesAsync(); //guardar en la DB
            return Ok(); //respuesta 200 
        }
    }
}
