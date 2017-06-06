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
        List<HORARIOS> ListaDeHorarios;
        ProgramadoresRepository ProgramadoresRep;

        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
            this.HorariosRep = new HorariosRepository();
            this.ListaDeHorarios = new List<HORARIOS>();
            this.ProgramadoresRep = new ProgramadoresRepository();
        }
        // GET: Programadores
        public ActionResult Add_Programador()
        {
            ViewBag.Estados = EstadosRep.GetEstados();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Programador(PROGRAMADORES programador, FormCollection form)
        {
            ModelState.Clear();
            if(ModelState.IsValid)
            {
                foreach (var item in form["HorariosSelecionados"])
                {
                    ListaDeHorarios.Add(new HORARIOS {
                        ID_HR = Convert.ToInt32(item)
                    });
                }
                ProgramadoresRep.add(programador, ListaDeHorarios);

            }
            return View();
        }
        public JsonResult GetHorarios()
        {
            return new JsonResult {Data=HorariosRep.GetAll(),JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }
    }
   
}