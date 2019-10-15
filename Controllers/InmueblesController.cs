using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Inmobiliaria.Controllers
{
    [Authorize(Policy = "Administrador")]
    public class InmueblesController : Controller
    {
        private readonly IRepositorioUsuario propietario;
        private readonly IRepositorio<InmuebleTipo> inmuebleTipo;
        private readonly IRepositorio<InmuebleUso> inmuebleUso;
        private readonly IRepositorioInmueble inmueble;

        public InmueblesController(IRepositorioUsuario propietario, IRepositorioInmueble inmueble, IRepositorio<InmuebleTipo> inmuebleTipo, IRepositorio<InmuebleUso> inmuebleUso)
        {
            this.propietario = propietario;
            this.inmuebleTipo = inmuebleTipo;
            this.inmuebleUso = inmuebleUso;
            this.inmueble = inmueble;
        }
        public ActionResult Index()
        {
            IList<Inmueble> inmuebles = inmueble.GetAll();
            ViewBag.Values = inmuebles.Count;
            return View(inmuebles);
        }

        // POST: Inmueble/index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BusquedaView busqueda)
        {
            try
            {
                if (busqueda.Criterio != null || busqueda.Tipo > 3)
                {
                    IList<Inmueble> clientesFiltrados = inmueble.GetByCriterio(busqueda);
                    ViewBag.Busqueda = (busqueda.Tipo > 3)?"": busqueda.Criterio;
                    ViewBag.Values = clientesFiltrados.Count;
                    ViewBag.Tipo = busqueda.Tipo;
                    return View(clientesFiltrados);
                }
                IList<Inmueble> inmuebles = inmueble.GetAll();
                return View(inmuebles);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
        // GET: Inmueble/Add
        public ActionResult Create()
        {
            ViewBag.Usuario = propietario.GetByType(3);
            ViewBag.InmuebleTipo = inmuebleTipo.GetAll();
            ViewBag.InmuebleUso = inmuebleUso.GetAll();
            return View();
        }

        // POST: Inmueble/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inmueble propiedad)
        {
            try
            {
                propiedad.InmuebleEstado = 0;
                if (ModelState.IsValid)
                {
                    inmueble.Create(propiedad);
                    TempData["Id"] = propiedad.IdInmueble;
                    return RedirectToAction(nameof(Index));
                }
                else

                ViewBag.Usuario = propietario.GetByType(3);
                ViewBag.InmuebleTipo = inmuebleTipo.GetAll();
                ViewBag.InmuebleUso = inmuebleUso.GetAll();

                return View(propiedad);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(propiedad);
            }
        }

        // GET: Inmueble/Delete/
        public ActionResult Delete(int id)
        {
            var u = inmueble.GetAllById(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(u);
        }

        // POST: Inmueble/Delete/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Inmueble entidad)
        {
            try
            {
                inmueble.Delete(id);
                TempData["Mensaje"] = "El Inmueble fué borrado";
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
