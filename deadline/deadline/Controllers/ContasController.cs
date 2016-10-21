using deadline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace deadline.Controllers
{
    public class ContasController : Controller
    {
        ContasRepository _contasRepository = new ContasRepository();
        // GET: Contas
        public ActionResult Index()
        {
            ViewBag.maior = _contasRepository.GetMax();
            ViewBag.menor = _contasRepository.GetMin();
            ViewBag.totalMedia = _contasRepository.GetMedia();
            ViewBag.totalPagar = _contasRepository.GetTotal();
            var contas = _contasRepository.getAll();
            return View(contas);
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contas conta)
        {
            if (ModelState.IsValid)
            {
                _contasRepository.create(conta);
                return RedirectToAction("Index");
            }
            return View();
        }
        #endregion

        #region Delete
        public ActionResult Delete(int id)
        {
            _contasRepository.Delete(id);
            return RedirectToAction("index");
        }
        #endregion

        #region Edit
        public ActionResult Edit(int id)
        {
            var conta = _contasRepository.getOne(id);
            return View(conta);
        }

        [HttpPost]
        public ActionResult Edit(Contas contas)
        {
            if (ModelState.IsValid)
            {
                _contasRepository.Edit(contas);
                return RedirectToAction("index");
            }
            return View(contas);
        }
        #endregion

        [HttpPost]
        public ActionResult Date(DateTime data_inicio, DateTime data_final)
        {
            var conta =_contasRepository.searchByDate(data_inicio, data_final);
            return View(conta);
        }
        public ActionResult Date()
        {
            return View();
        }
    }
}