using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIStudy.Data;
using WebAPIStudy.Model;
using WebAPIStudy.Services;

namespace WebAPIStudy.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutorController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly IService service;
        private readonly ServiceTransient serviceTransient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public AutorController(ApplicationDbContext db, IService service,
            ServiceTransient serviceTransient, ServiceScoped serviceScoped,
            ServiceSingleton serviceSingleton) //injecting the services
        {
            _db = db;
            this.service = service;
            this.serviceTransient = serviceTransient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        [HttpGet("GUID")]
        public ActionResult ObtenerGuids()
        {
            return Ok(new //returning the guid from each service fron the Iservice class 
            {
                AutorControllerTransient = serviceTransient.Guid,
                AutorControllerScoped = serviceScoped.Guid,
                AutorControllerSingleton = serviceSingleton.Guid
            });
        }
        [HttpGet("list")]
        public async Task<ActionResult<List<Autor>>> GetAutores() //async ya que es con un servicio externo, retorno una lista de tipo autores
        {
            return await _db.Autores.ToListAsync(); 
        }

        [HttpGet("first")] //api/autores/first
        public async Task<ActionResult<Autor>> FirstAutor()
        {
            return await _db.Autores.FirstOrDefaultAsync(); //get the first autor that found 
        }

        [HttpPost]
        public async Task<ActionResult> PostAutor(Autor autor)
        {
            var ExistName = await _db.Autores.AnyAsync( x => x.Nombre == autor.Nombre ); //si existe el mismo nombre de autor 
            
            if (ExistName) //controller validation 
            {
                return BadRequest($"he name already exist");//400
            }

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
