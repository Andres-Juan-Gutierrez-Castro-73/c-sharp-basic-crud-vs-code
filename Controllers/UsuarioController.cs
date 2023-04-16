using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using c_sharp_mvc_crud_basic.Data;
using c_sharp_mvc_crud_basic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace c_sharp_mvc_crud_basic.Controllers
{
    public class UsuarioController : Controller
    {
        public readonly DbCon _context;

        public UsuarioController(DbCon con)
        {
            _context = con;
        }

        public IActionResult Index()
        {
            var usuarios = _context.ObtenerUsuariosSP().ToList();
            return View(usuarios);
        }
        
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Usuario usuario)
        {
            if (ModelState.IsValid && usuario.Nombre is not null)
            {
                _context.CrearUsuarioSP(usuario.Nombre, usuario.Edad);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Actualizar(int id)
        {
            var usuario = _context.OpetenerUsuarioPorIdSP(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Actualizar(Usuario usuario)
        {
            if(ModelState.IsValid && usuario.Nombre is not null && usuario.Id_Usuario > 0)
            {
                _context.ActualizarUsuarioSP(usuario.Id_Usuario, usuario.Nombre, usuario.Edad);
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Eliminar(int id)
        {
            var usuario = _context.OpetenerUsuarioPorIdSP(id);
            return View(usuario);
        }

        [HttpPost]
        public IActionResult Eliminar(Usuario usuario)
        {
            if(usuario.Id_Usuario > 0)
            {
                _context.EliminarUsuarioSP(usuario.Id_Usuario);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}