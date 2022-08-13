using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Turnos.Models;


namespace Turnos.Controllers
{
   
    public class EspecialidadController : Controller
    {
        private readonly ILogger<EspecialidadController> _logger;

        private readonly TurnosContext _context;

        public EspecialidadController(ILogger<EspecialidadController> logger, TurnosContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            return  View(await _context.Especialidad.ToListAsync());
        }

        
        public async Task<IActionResult> Edit (int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var especialidad = await _context.Especialidad.FindAsync(id);
            
            if(especialidad == null)
            {
                return NotFound();
            }

            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Edit (int id,[Bind("Id,Descripcion")] Especialidad especialidad)
        {
            if(id != especialidad.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid)
            {
                _context.Update(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        
        public async Task<IActionResult> Delete (int? id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.Id == id);

            if (especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete (int id)
        {
            var especialidad = await _context.Especialidad.FindAsync(id);
            _context.Especialidad.Remove(especialidad);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("Id, Descripcion")]Especialidad especialidad)
        {
            if(ModelState.IsValid)
            {
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}