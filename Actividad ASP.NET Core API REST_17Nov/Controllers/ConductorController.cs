using Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities;
using Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities.DBContext;
using Actividad_ASP.NET_Core_API_REST_17Nov.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad_ASP.NET_Core_API_REST_17Nov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {
        private readonly ConduCarDBContext _context;

        // GET: api/<ConductorController>
        public ConductorController(ConduCarDBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConductorDTO>>> Get()
        {
            var conductor = await _context.Conductor.Select(x =>
            new ConductorDTO
            {
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                MatriculaID = x.MatriculaID,
                FechaExpedicion = x.Matricula.FechaExpedicion,
                ValidaHasta = x.Matricula.ValidaHasta
            }).ToListAsync();
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }

        // GET api/<ConductorController>/5
        [HttpGet("{identificacion}")]
        public async Task<ActionResult<ConductorDTO>> Get(string identificacion)
        {
            var conductor = await _context.Conductor.Select(x =>
            new ConductorDTO
            {
                Identificacion = x.Identificacion,
                Nombre = x.Nombre,
                Apellidos = x.Apellidos,
                Direccion = x.Direccion,
                Telefono = x.Telefono,
                Email = x.Email,
                FechaNacimiento = x.FechaNacimiento,
                Activo = x.Activo,
                MatriculaID = x.MatriculaID,
                FechaExpedicion = x.Matricula.FechaExpedicion,
                ValidaHasta = x.Matricula.ValidaHasta
            }).FirstOrDefaultAsync(x => x.Identificacion == identificacion);
            if (conductor == null)
            {
                return NotFound();
            }
            else
            {
                return conductor;
            }
        }

        // POST api/<ConductorController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(ConductorDTO conductor)
        {
            var entity = new Conductor()
            {
                Identificacion = conductor.Identificacion,
                Nombre =conductor.Nombre,
                Apellidos = conductor.Apellidos,
                Direccion = conductor.Direccion,
                Telefono = conductor.Telefono,
                Email = conductor.Email,
                FechaNacimiento = conductor.FechaNacimiento,
                Activo = conductor.Activo,
                MatriculaID = conductor.MatriculaID,
            };
            _context.Conductor.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        // PUT api/<ConductorController>/5
        [HttpPut("{identificacion}")]
        public async Task<HttpStatusCode> Put(ConductorDTO conductordto)
        {
            var entity = await _context.Conductor.FirstOrDefaultAsync(v => v.Identificacion ==
            conductordto.Identificacion);

            entity.Identificacion = conductordto.Identificacion;
            entity.Nombre = conductordto.Nombre;
            entity.Apellidos = conductordto.Apellidos;
            entity.Direccion = conductordto.Direccion;
            entity.Telefono = conductordto.Telefono;
            entity.Email = conductordto.Email;
            entity.FechaNacimiento = conductordto.FechaNacimiento;
            entity.Activo = conductordto.Activo;
            entity.MatriculaID = conductordto.MatriculaID;

            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        // DELETE api/<ConductorController>/5
        [HttpDelete("{identificacion}")]
        public async Task<HttpStatusCode> Delete(string identificacion)
        {
            var entity = new Conductor()
            {
                Identificacion = identificacion
            };
            _context.Conductor.Attach(entity);
            _context.Conductor.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
