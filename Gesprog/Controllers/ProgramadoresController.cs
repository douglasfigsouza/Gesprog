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
        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
        }
        // GET: Programadores
        public ActionResult Add_Programador()
        {
            ViewBag.Estados = EstadosRep.GetEstados();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Programador(PROGRAMADORES programador)
        {
            programador.NOME_PROG = programador.NOME_PROG;
            return View();
        }
    }
   
}