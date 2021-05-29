using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class AutorController : Controller
    {
        private readonly AutorRepository _autorRepository;
        public AutorController()
        {
            _autorRepository = new AutorRepository();
        }

        // GET: AutorController
        public ActionResult Index(
            string busca = null)
        {
            var autores = _autorRepository.GetAll(busca);

            ViewData["Busca"] = busca;
            
            return View(autores);
        }

        // GET: AutorController/Details/5
        public ActionResult Details(int id)
        {
            var autor = _autorRepository.GetById(id);

            if (autor == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(autor);
        }

        // GET: AutorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AutorModel autorModel)
        {
            try
            {
                _autorRepository.Add(autorModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Edit/5
        public ActionResult Edit(int id)
        {
            var autor = _autorRepository.GetById(id);

            return View(autor);
        }

        // POST: AutorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AutorModel autorModel)
        {
            try
            {
                _autorRepository.Update(autorModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AutorController/Delete/5
        public ActionResult Delete(int id)
        {
            var autor = _autorRepository.GetById(id);

            return View(autor);
        }

        // POST: AutorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(int id)
        {
            try
            {
                _autorRepository.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(nameof(Delete));
            }
        }
    }
}
