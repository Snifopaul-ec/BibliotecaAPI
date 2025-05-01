using BibliotecaAPI.Data;
using BibliotecaAPI.Models;
using BibliotecaAPI.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaAPI.Controllers
{
    //formato ruta: localhost:8080/api/persona
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly BibliotecaContext dbContext;

        public PersonaController(BibliotecaContext dbContext)
        {
            this.dbContext = dbContext;
        }

       
        [HttpGet]
        public IActionResult GetAllPersona()
        {
            var allPersonas = dbContext.Personas.ToList();

            return Ok(allPersonas);
        }

        [HttpPost]
        public IActionResult AddPersona(AddPersonaDto addPersonaDto)
        {
            var personaEntidad = new Persona()
            {
                Nombres = addPersonaDto.Nombres,
                Apellidos = addPersonaDto.Apellidos,
                Cedula = addPersonaDto.Cedula,
                Telefono = addPersonaDto.Telefono
            };


            dbContext.Personas.Add(personaEntidad);
            dbContext.SaveChanges();

            return Ok(personaEntidad);
        }
            /*
            // GET api/<PersonaController>/5
            [HttpGet("{id}")]
            public string Get(int id)
            {
                return "value";
            }
            // POST api/<PersonaController>
            [HttpPost]
            public void Post([FromBody] string value)
            {
            }
            // PUT api/<PersonaController>/5
            [HttpPut("{id}")]
            public void Put(int id, [FromBody] string value)
            {
            }
            // DELETE api/<PersonaController>/5
            [HttpDelete("{id}")]
            public void Delete(int id)
            {
            }*/
        }
}
