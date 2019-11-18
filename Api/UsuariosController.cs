using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Api
{
    [Route("api/[controller]")]

  
    public class UsuariosController : Controller
    {

        private readonly DataContext contexto;
        private readonly IConfiguration config;

        public UsuariosController(DataContext contexto, IConfiguration config)
        {
            this.contexto = contexto;
            this.config = config;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(new
                {
                    Mensaje = "Éxito",
                    Error = 0,
                    Resultado = new
                    {
                        Clave = "Key",
                        Valor = "Value"
                    },
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var usuario = User.Identity.Name;
                return Ok(contexto.Usuario.Single(e => e.IdUsuario == id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Post(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    // Verifica el usuario en las claims
                    usuario.IdUsuario = contexto.Usuario.Single(e => e.UsuarioEmail== User.Identity.Name).IdUsuario;
                    contexto.Usuario.Add(usuario);

                    //no olvidar guardar los cambios entity framework
                    contexto.SaveChanges();
                    return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, usuario);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


       /* [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Inmueble entidad)
        { //Asno traquin ***** para evitar distintos objetos con mismo id , al momento de hacer el update
            try
            {
                if (ModelState.IsValid && contexto.Inmuebles.AsNoTracking().Include(e => e.Duenio).FirstOrDefault(e => e.Id == id && e.Duenio.Email == User.Identity.Name) != null)
                {
                    entidad.Id = id;
                    contexto.Inmuebles.Update(entidad);
                    contexto.SaveChanges();
                    return Ok(entidad);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }*/

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}