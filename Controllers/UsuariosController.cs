using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Controllers
{
    [Authorize(Policy = "Administrador")]

    public class UsuariosController : Controller
    {

        private readonly IRepositorioUsuario propietarios;
        private readonly IConfiguration config;
        private readonly IRepositorio<UsuarioTipo> tipo;

        public UsuariosController(IRepositorioUsuario propietarios, IConfiguration config, IRepositorio<UsuarioTipo> tipo)
        {
            this.propietarios = propietarios;
            this.config = config;
            this.tipo = tipo;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            IList<Usuario> clientes = propietarios.GetAll();
            return View(clientes);
        }

        // POST: Usuario/index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BusquedaView busqueda)
        {
            try
            {
                if (busqueda.Criterio != null)
                {
                    IList<Usuario> clientesFiltrados = propietarios.GetByCriterio(busqueda);
                    ViewBag.Busqueda = busqueda.Criterio;
                    ViewBag.Values = clientesFiltrados.Count;
                    return View(clientesFiltrados);
                }
                IList<Usuario> clientes = propietarios.GetAll();
                return View(clientes);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }

        // GET: Usuario/Edit/
        public ActionResult Edit(int id)
        {
            var u = propietarios.GetAllById(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(u);
        }

        // POST: Usuario/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            Usuario user = null;
            try
            {
                user = propietarios.GetAllById(id);
                user.UsuarioNombre = collection["UsuarioNombre"];
                user.UsuarioApellido = collection["UsuarioApellido"];
                user.UsuarioDni = collection["UsuarioDni"];
                user.UsuarioTelefono = collection["UsuarioTelefono"];
                user.UsuarioDomicilio = collection["UsuarioDomicilio"];
                user.UsuarioClave = collection["UsuarioClave"];

                propietarios.Update(user);
                TempData["Mensaje"] = "Los datos se actualizaron con éxito";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(user);
            }
        }

        // GET: Usuario/Add
        public ActionResult Create()
        {
            ViewBag.UsuarioTipo = tipo.GetAll();
            return View();
        }

        // POST: Usuario/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    /*usuario.UsuarioClave = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: usuario.UsuarioClave,
                        salt: System.Text.Encoding.ASCII.GetBytes(config["Salt"]),
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 1000,
                        numBytesRequested: 256 / 8));*/

                    Random rnd = new Random();
                    String salt = rnd.Next(3654, 55678898) + usuario.UsuarioEmail;
                    byte[] encryted = System.Text.Encoding.Unicode.GetBytes(salt);
                    usuario.UsuarioSalt = Convert.ToBase64String(encryted);

                    propietarios.Create(usuario);
                    TempData["Id"] = usuario.IdUsuario;
                    return RedirectToAction(nameof(Index));
                }
                else

                ViewBag.UsuarioTipo = tipo.GetAll();
                return View(usuario);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(usuario);
            }
        }

        // GET: Usuario/Delete/
        public ActionResult Delete(int id)
        {
            var u = propietarios.GetAllById(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(u);
        }

        // POST: Usuario/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario entidad)
        {
            try
            {
                propietarios.Delete(id);
                TempData["Mensaje"] = "El propietario fué borrado";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(entidad);
            }
        }

    }
}