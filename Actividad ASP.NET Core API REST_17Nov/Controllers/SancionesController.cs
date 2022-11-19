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
    public class SancionesController : ControllerBase
    {
        // GET: api/<SancionesController>
        private readonly ConduCarDBContext _context;

        public SancionesController(ConduCarDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SancionesDTO>>> Get()
        {
            var sancion = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                ID = x.ID,
                FechaActual = x.FechaActual,
                ConductorID = x.ConductorID,
                Nombre = x.Conductor.Nombre,
                Apellidos = x.Conductor.Apellidos,
                Sancion = x.Sancion,
                Observacion = x.Observacion,
                Valor = x.Valor
            }).ToListAsync();
            if (sancion == null)
            {
                return NotFound();
            }
            else
            {
                return sancion;
            }
        }

        // GET api/<SancionesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SancionesDTO>> Get(int id)
        {
            var sancion = await _context.Sanciones.Select(x =>
            new SancionesDTO
            {
                ID = x.ID,
                FechaActual = x.FechaActual,
                ConductorID = x.ConductorID,
                Nombre = x.Conductor.Nombre,
                Apellidos = x.Conductor.Apellidos,
                Sancion = x.Sancion,
                Observacion = x.Observacion,
                Valor = x.Valor
            }).FirstOrDefaultAsync(x => x.ID == id);
            if (sancion == null)
            {
                return NotFound();
            }
            else
            {
                return sancion;
            }
        }

        // POST api/<SancionesController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(SancionesDTO sanciones)
        {
            var entity = new Sanciones()
            {
                FechaActual = sanciones.FechaActual,
                ConductorID = sanciones.ConductorID,
                Sancion = sanciones.Sancion,
                Observacion = sanciones.Observacion,
                Valor = sanciones.Valor,
            };
            _context.Sanciones.Add(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.Created;
        }

        // PUT api/<SancionesController>/5
        [HttpPut("{id}")]
        public async Task<HttpStatusCode> Put(SancionesDTO sanciondto)
        {
            var entity = await _context.Sanciones.FirstOrDefaultAsync(v => v.ID ==
            sanciondto.ID);
            entity.FechaActual = sanciondto.FechaActual;
            entity.ConductorID = sanciondto.ConductorID;
            entity.Sancion = sanciondto.Sancion;
            entity.Observacion = sanciondto.Observacion;
            entity.Valor = sanciondto.Valor;

            await _context.SaveChangesAsync();
            return HttpStatusCode.Accepted;
        }

        // DELETE api/<SancionesController>/5
        [HttpDelete("{id}")]
        public async Task<HttpStatusCode> Delete(int id)
        {
            var entity = new Sanciones()
            {
                ID = id
            };
            _context.Sanciones.Attach(entity);
            _context.Sanciones.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
