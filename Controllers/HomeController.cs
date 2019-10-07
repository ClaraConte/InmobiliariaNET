using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorioUsuario usuario;
        private readonly DataContext contexto;

        public HomeController(IRepositorioUsuario usuario, DataContext contexto)
        {
            this.usuario = usuario;
            this.contexto = contexto;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Home/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(Login loginView)
        {
            try
            {
                string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: loginView.Clave,
                    salt: System.Text.Encoding.ASCII.GetBytes("SALADA"),
                    prf: KeyDerivationPrf.HMACSHA1,
                    iterationCount: 1000,
                    numBytesRequested: 256 / 8));
                var p = usuario.GetByEmail(loginView.Usuario);
                if (p == null || p.UsuarioClave != hashed)
                {
                    ViewBag.Mensaje = "Datos inválidos";
                    return View();
                }

                String clameName;
                if (p.IdUsuarioTipo.IdUsuarioTipo == 1) { clameName = "Administrador"; }
                else if (p.IdUsuarioTipo.IdUsuarioTipo == 3) { clameName = "Propietario"; }
                else { clameName = "Inquilino"; }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, p.UsuarioEmail),
                    new Claim("FullName", p.UsuarioNombre + " " + p.UsuarioApellido),
                    new Claim(ClaimTypes.Role, clameName),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.StackTrate = ex.StackTrace;
                return View();
            }
        }

        // GET: Home/Login
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }
    }
}