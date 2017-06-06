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

        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
            this.HorariosRep = new HorariosRepository();
            this.ListaDeHorarios = new List<HORARIOS>();
            this.ProgramadoresRep = new ProgramadoresRepository();
            this.banco = new BANCO();
            this.BancosRep = new BancosRepository();
            this.conta = new CONTAS_BANCARIAS();
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
                programador.ID_PROG = programador.ID_PROG;
                programador.CIDADEID = programador.CIDADEID;
                programador.NOME_PROG = programador.NOME_PROG;
                programador.CPF_PROG = programador.CPF_PROG;
                programador.FONE_PROG = programador.FONE_PROG;
                programador.SKYPE_PROG = programador.SKYPE_PROG;
                programador.LINKEDIN_PROG = programador.LINKEDIN_PROG;
                programador.EMAIL_PROG = programador.EMAIL_PROG;
                programador.PORTIFOLIO_PROG = programador.PORTIFOLIO_PROG;
                programador.DISPHRTRDIA_PROG = programador.DISPHRTRDIA_PROG;
                programador.PRETSAL_PROG = programador.PRETSAL_PROG;
                programador.LINKCRUD_PROG = programador.LINKCRUD_PROG;

                foreach (var item in form["HorariosSelecionados"])
                {
                    ListaDeHorarios.Add(new HORARIOS {
                        ID_HR = Convert.ToInt32(item)
                    });
                }
                banco.NOME_BANCO = form["programador.Banco"];
                BancosRep.Add_Banco(banco);

                conta.ID_BANCO = banco.ID_BANCO;
                conta.NUM_CONTA = form["programador.Conta"];
                conta.AGENCIA_CONTA = form["programador.Agencia"];
                conta.TIPO_CONTA = form["programador.TipoConta"];


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