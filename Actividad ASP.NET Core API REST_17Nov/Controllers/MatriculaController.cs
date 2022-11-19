using Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities;
using Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities.DBContext;
using Actividad_ASP.NET_Core_API_REST_17Nov.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Actividad_ASP.NET_Core_API_REST_17Nov.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        // GET: api/<MatriculaController>
        private readonly ConduCarDBContext _context;

        public MatriculaController(ConduCarDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MatriculaDTO>>> Get()
        {
            var matricula = await _context.Matricula.Select(x =>
            new MatriculaDTO
            {
                ID = x.ID,
                Numero = x.Numero,
                FechaExpedicion = x.FechaExpedicion,
                ValidaHasta = x.ValidaHasta,
                Activo = x.Activo,
            }).ToListAsync();
            if (matricula == null)
            {
               return NotFound();
            }
            else
            {
               return matricula;
            }
        }

        // GET api/<MatriculaController>/5
        [HttpGet("{numero}")]
        public async Task<ActionResult<MatriculaDTO>> Get(string numero)
        {
            try
            {
                var matricula = await _context.Matricula.Select(x =>
                new MatriculaDTO
                {
                    ID = x.ID,
                    Numero = x.Numero,
                    FechaExpedicion = x.FechaExpedicion,
                    ValidaHasta = x.ValidaHasta,
                    Activo = x.Activo,
                }).FirstOrDefaultAsync(x => x.Numero == numero);
                if (matricula == null)
                {
                    return NotFound();
                }
                else
                {
                    return matricula;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<MatriculaController>
        [HttpPost]
        public async Task<HttpStatusCode> Post(MatriculaDTO matricula)
        {
            try
            {
                var entity = new Matricula()
                {
                    Numero = matricula.Numero,
                    FechaExpedicion = matricula.FechaExpedicion,
                    ValidaHasta = matricula.ValidaHasta,
                    Activo = matricula.Activo,
                };
                _context.Matricula.Add(entity);
                await _context.SaveChangesAsync();
                return HttpStatusCode.Created;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // PUT api/<MatriculaController>/5
        [HttpPut("{numero}")]
        public async Task<HttpStatusCode> Put(MatriculaDTO matriculadto)
        {
            try
            {
                var entity = await _context.Matricula.FirstOrDefaultAsync(v => v.Numero ==
                matriculadto.Numero);
                entity.Numero = matriculadto.Numero;
                entity.FechaExpedicion = matriculadto.FechaExpedicion;
                entity.ValidaHasta = matriculadto.ValidaHasta;
                entity.Activo = matriculadto.Activo;

                await _context.SaveChangesAsync();
                return HttpStatusCode.Accepted;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        // DELETE api/<MatriculaController>/5
        [HttpDelete("{numero}")]
        public async Task<HttpStatusCode> Delete(string numero)
        {
            var entity = new Matricula()
            {
                Numero = numero
            };
            _context.Matricula.Attach(entity);
            _context.Matricula.Remove(entity);
            await _context.SaveChangesAsync();
            return HttpStatusCode.OK;
        }
    }
}
