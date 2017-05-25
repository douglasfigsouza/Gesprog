using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gesprog.Models;

namespace Gesprog.Controllers
{
    public class ProgramadoresController : Controller
    {
        EstadosRepository EstadosRep;
        HorariosRepository HorariosRep;
        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
            this.HorariosRep = new HorariosRepository();
        }
        // GET: Programadores
        public ActionResult Add_Programador()
        {
            ViewBag.Estados = EstadosRep.GetEstados();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Programador(PROGRAMADORES programador, PostedHorarios postedHorarios)
        {
            foreach(var item in postedHorarios.HorariosIds)
            {
                string id = item;
            }
            programador.NOME_PROG = programador.NOME_PROG;
            return View();
        }
        public PartialViewResult Horarios()
        {

                return PartialView("_Horarios",GetHorariosInitialModel());
        }
        private HorariosViewModel GetHorariosInitialModel()
        {
            var model = new HorariosViewModel();
            var selectedHorarios = new List<HORARIOS>();

            model.AvailableHorarios = HorariosRep.GetAll();
            model.SelectedHorarios = selectedHorarios;

            return model;
        }
    }
   
}