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

        
        [HttpGet("list")]
        public async Task<ActionResult<List<Autor>>> GetAutores() //async ya que es con un servicio externo, retorno una lista de tipo autores
        {
            return await _db.Autores.ToListAsync(); 
        }

        [HttpGet("first")] //api/autores/first
        public async Task<ActionResult<Autor>> FirstAutor()
        {
            return await _db.Autores.FirstOrDefaultAsync(); //ge the first autor that found 
        }

        [HttpPost]
        public async Task<ActionResult> PostAutor(Autor autor)
        {
            _db.Add(autor); //agregar el autor recibido como parametro
            await _db.SaveChangesAsync(); //guardar en la DB
            return Ok(); //respuesta 200 
        }

        [HttpPut]
        public async Task<ActionResult> PutAutor(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("The Id doesn't match"); //error 400
            }
            var exist = await _db.Autores.AnyAsync(); //find 
            if (!exist) //Doesn't exist 
            {
                return NotFound();
            }
            _db.Update(autor);
            await _db.SaveChangesAsync();
            return Ok(); //200
        }
    }
}
