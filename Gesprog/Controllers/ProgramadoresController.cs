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
        BANCO banco;
        BancosRepository BancosRep;
        CONTAS_BANCARIAS conta;
        List<string> ListaDeIdsHorarios;
        List<string> ListaDeIdsTecnologias;
        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
            this.HorariosRep = new HorariosRepository();
            this.ProgramadoresRep = new ProgramadoresRepository();
            this.banco = new BANCO();
            this.BancosRep = new BancosRepository();
            this.conta = new CONTAS_BANCARIAS();
            this.ListaDeIdsHorarios = new List<string>();
            this.ListaDeIdsTecnologias = new List<string>();
        }
        // GET: Programadores
        public ActionResult Add_Programador()
        {
            ViewBag.Estados = EstadosRep.GetEstados();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Programador(PROGRAMADORES prog, FormCollection form)
        {

            if (ModelState.IsValid)
            {
                //seta ids dos horarios
                foreach (var item in form["HorariosSelecionados"])
                {

                    ListaDeIdsHorarios.Add(item.ToString());

                }

                foreach (var item in form["Tecnologias"])
                {

                }
                banco.NOME_BANCO = form["programador.Banco"];
                BancosRep.Add_Banco(banco);

                conta.ID_BANCO = banco.ID_BANCO;
                conta.NUM_CONTA = form["programador.Conta"];
                conta.AGENCIA_CONTA = form["programador.Agencia"];
                conta.TIPO_CONTA = form["programador.TipoConta"];


                ProgramadoresRep.add(prog, ListaDeIdsHorarios, conta);

            }
            return View();
        }
        public JsonResult GetHorarios()
        {
            return new JsonResult { Data = HorariosRep.GetAll(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }

}