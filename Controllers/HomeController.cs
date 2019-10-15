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

        [Authorize(Policy = "Administrador")]
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
                var user = usuario.GetByEmail(loginView.Usuario);
                if (user == null || user.UsuarioClave != hashed)
                {
                    ViewBag.Mensaje = "Datos inválidos";
                    return View();
                }

                String claimName;
                if (user.Tipo.IdUsuarioTipo == 1) { claimName = user.Tipo.UsuarioTipoRol; }
                else if (user.Tipo.IdUsuarioTipo == 3) { claimName = user.Tipo.UsuarioTipoRol; }
                else { claimName = user.Tipo.UsuarioTipoRol; }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UsuarioEmail),
                    new Claim("FullName", user.UsuarioNombre + " " + user.UsuarioApellido),
                    new Claim(ClaimTypes.Role, claimName),
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

                if (claimName == "propietario") { 
                     return RedirectToAction("AdminPropietarioIndex");
                }
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

        public ActionResult Restringido()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return View(claims);
        }

        [Authorize(Policy = "Propietario")]
        public ActionResult AdminPropietarioIndex()
        {
            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            return View();
        }
    }

}