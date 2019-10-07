using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Inmobiliaria.Controllers
{
    [Authorize(Policy = "Administrador")]

    public class PropietariosController : Controller
    {

        private readonly IRepositorioUsuario propietarios;
        private readonly IConfiguration config;

        public PropietariosController(IRepositorioUsuario propietarios, IConfiguration config)
        {
            this.propietarios = propietarios;
            this.config = config;
        }

        // GET: Propietario
        public ActionResult Index()
        {
            var lista = propietarios.GetByType(3);
        
            return View(lista);
        }

        // GET: Propietario/Edit/5
        public ActionResult Edit(int id)
        {
            var u = propietarios.GetAllById(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(u);
        }

        // POST: Propietario/Edit/2
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

    }
}