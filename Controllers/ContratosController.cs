using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    [Authorize(Policy = "Administrador")]
    public class ContratosController : Controller
    {
        private readonly IRepositorioUsuario inquilino;
        private readonly IRepositorioInmueble inmueble;
        private readonly IRepositorioContrato contrato;
        private readonly IRepositorio<ContratoGarantia> contratoGarantia;

        public ContratosController(IRepositorioUsuario inquilino, IRepositorioInmueble inmueble, IRepositorioContrato contrato, IRepositorio<ContratoGarantia> contratoGarantia)
        {
            this.inquilino = inquilino;
            this.inmueble = inmueble;
            this.contrato = contrato;
            this.contratoGarantia = contratoGarantia;
   
        }
        public ActionResult Index()
        {
            IList<Contrato> contratos = contrato.GetAll();
            ViewBag.Values = contratos.Count;
            return View(contratos);
        }

        // POST: Contrato/index/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(BusquedaView busqueda)
        {
            try
            {
                if (busqueda.Criterio != null || busqueda.Tipo > 3)
                {
                    IList<Inmueble> inmueblesDisponiblesFiltrados = inmueble.GetByCriterio(busqueda);
                    ViewBag.Busqueda = (busqueda.Tipo > 3) ? "" : busqueda.Criterio;
                    ViewBag.Values = inmueblesDisponiblesFiltrados.Count;
                    ViewBag.Tipo = busqueda.Tipo;
                    return View(inmueblesDisponiblesFiltrados);
                }
                IList<Inmueble> inmueblesDisponible = inmueble.GetAll();
                return View(inmueblesDisponible);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }
        // GET: Contrato/Add
        public ActionResult CreateIndex()
        {
            IList<Inmueble> inmuebles = inmueble.GetByStatus(0);
            ViewBag.Values = inmuebles.Count;
            return View(inmuebles);
        }

        public ActionResult Create(int id)
        {   
            //Esta consula deberia devolver todos los garantes asociados al inquilino
            IList<Usuario> userInquilinos = inquilino.GetByType(2);
            IList<Usuario> userGarantes = inquilino.GetByType(4);
            ViewBag.UsuariosInquilinos = userInquilinos;
            ViewBag.UsuariosGarantes = userGarantes;
            ViewBag.Inmueble = inmueble.GetAllById(id);
            return View();
        }
        public ActionResult Renovar(int id)
        {
            Contrato contr = contrato.GetAllById(id);
            return View(contr); 
        }
        // POST: Contrato/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Renovar( Contrato contr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Renovar contrato
                    TempData["Id"] = contrato.Create(contr);

                    //Desactiva propiedad
                    Inmueble propiedad = inmueble.GetAllById(contr.IdInmueble); ;
                    propiedad.InmuebleEstado = 1;
                    inmueble.Update(propiedad);

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(contr);
            }

        }
        // POST: Contrato/Add

        public ActionResult Rescindir(int id)
        {
            Contrato contr = contrato.GetAllById(id);
            try
            {
                Decimal monto;
                var TiempoTranscurrido = contr.ContratoFechaFin - contr.ContratoFechaInicio;
                monto = (TiempoTranscurrido.Days / 30 < 6)?contr.ContratoPrecio * 2 : contr.ContratoPrecio;

                ViewBag.Tiempo = TiempoTranscurrido;
                ViewBag.Multa = monto;
                
                return View(contr);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(contr);
            }
        }
        public ActionResult Recindir(Contrato contr)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Recinde contrato cambiando estado
                    contr.ContratoEstado = 0;
                   // contr.ContratoFechaFin = DateTime.Today;
                    TempData["Id"] = contrato.Update(contr);

                    //Activa la propiedad
                    Inmueble propiedad = inmueble.GetAllById(contr.IdInmueble);

                    propiedad.InmuebleEstado = 0;
                    inmueble.Update(propiedad);

                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(contr);
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contrato contratoUser, int[] garantia = null)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //Crea contrato
                    
                    TempData["Id"] = contrato.Create(contratoUser);

                    //Guarda los garantes

                    foreach (var data in garantia) {
                        ContratoGarantia item = new ContratoGarantia
                        {
                            IdContrato = (Int32)TempData["Id"],
                            IdUsuario = data,
                        };
                        contratoGarantia.Create(item);
                    }
                    //Desactiva propiedad
                    Inmueble propiedad =  inmueble.GetAllById(contratoUser.IdInmueble); ;
                    propiedad.InmuebleEstado = 1;
                    inmueble.Update(propiedad);

                   // contratoGarantia.Create(garant);
                    return RedirectToAction(nameof(Index));
                }
                else

                return View(contratoUser);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View(contratoUser);
            }
        }

        // GET: Contrato/Delete/
        public ActionResult Delete(int id)
        {
            var u = inmueble.GetAllById(id);
            if (TempData.ContainsKey("Mensaje"))
                ViewBag.Mensaje = TempData["Mensaje"];
            if (TempData.ContainsKey("Error"))
                ViewBag.Error = TempData["Error"];
            return View(u);
        }
    }
}