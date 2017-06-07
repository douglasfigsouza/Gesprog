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
        public ActionResult Add_Programador(PROGRAMADORES prog, FormCollection form)
        {

            if(ModelState.IsValid)
            {
                prog.ID_PROG = prog.ID_PROG;
                prog.CIDADEID =Convert.ToInt32(form["Cidadeid"]);
                prog.NOME_PROG = prog.NOME_PROG;
                prog.CPF_PROG = prog.CPF_PROG;
                prog.FONE_PROG = prog.FONE_PROG;
                prog.SKYPE_PROG = prog.SKYPE_PROG;
                prog.LINKEDIN_PROG = prog.LINKEDIN_PROG;
                prog.EMAIL_PROG = prog.EMAIL_PROG;
                prog.PORTIFOLIO_PROG = prog.PORTIFOLIO_PROG;
                prog.DISPHRTRDIA_PROG =form["DISPHRTRDIA_PROG"];
                prog.PRETSAL_PROG = prog.PRETSAL_PROG;
                prog.LINKCRUD_PROG = prog.LINKCRUD_PROG;

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


                ProgramadoresRep.add(prog, ListaDeHorarios);

            }
            return View();
        }
        public JsonResult GetHorarios()
        {
            return new JsonResult {Data=HorariosRep.GetAll(),JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }
    }
   
}