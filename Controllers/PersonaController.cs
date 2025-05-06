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

        [HttpGet]
        // con guid 
        //[Route("{id:guid}")]
        //con Int
        [Route("{id:int}")]
        public IActionResult GetPersonaById(int id)
        {
            var persona = dbContext.Personas.Find(id);
            
            if (persona == null)
            {
                return NotFound();
            }
            return Ok(persona);
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

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdatePersona(int id, UpdatePersonaDto updatePersonaDto )
        {
            var persona = dbContext.Personas.Find(id);

            if(persona is null)
            {
                return NotFound();
            }

            persona.Nombres = updatePersonaDto.Nombres;
            persona.Apellidos = updatePersonaDto.Apellidos;
            persona.Cedula = updatePersonaDto.Cedula;
            persona.Telefono = updatePersonaDto.Telefono;

            dbContext.SaveChanges();

            return Ok(persona);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeletePersona(int id)
        {
            var persona = dbContext.Personas.Find(id);
            if (persona is null)
            {
                return NotFound();
            }
            // Verificar si la persona tiene usuarios asociados
            dbContext.Personas.Remove(persona);
            dbContext.SaveChanges();

            return Ok(persona);
        }

    }
}
