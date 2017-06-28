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
        ProgramadoresRepository ProgramadoresRep;
        BANCO banco;
        BancosRepository BancosRep;
        CONTAS_BANCARIAS conta;
        HORARIOS horarios;
        NIVEL_DE_CONHECIMENTO NivelConhecimentoTecnologias;
        TecnologiasRepository TecnologiasRep;
        public ProgramadoresController()
        {
            this.EstadosRep = new EstadosRepository();
            this.HorariosRep = new HorariosRepository();
            this.ListaDeHorarios = new List<HORARIOS>();
            this.ProgramadoresRep = new ProgramadoresRepository();
            this.banco = new BANCO();
            this.BancosRep = new BancosRepository();
            this.conta = new CONTAS_BANCARIAS();
            this.horarios = new HORARIOS();
            this.horarios.ListaDeHorarios = new List<HORARIOS>();
            this.TecnologiasRep = new TecnologiasRepository();
            this.NivelConhecimentoTecnologias = new NIVEL_DE_CONHECIMENTO();
            this.NivelConhecimentoTecnologias.ListaDeNiveisDeConhecimento = new List<NIVEL_DE_CONHECIMENTO>();
        }
        // GET: Programadores
        public ActionResult Add_Programador()
        {
            ViewBag.Estados = EstadosRep.GetEstados();
            return View();
        }
        [HttpPost]
        public ActionResult Add_Programador(PROGRAMADORES prog, FormCollection form,IList<HORARIOS> ListaDeHorarios, IList<NIVEL_DE_CONHECIMENTO> ListaDeNiveisDeConhecimento)
        {
            foreach (var item in ListaDeNiveisDeConhecimento)
            {
                if (item.Checked == true)
                {
                    item.NIVEL = item.NIVEL;
                }
            }
            foreach (var item in ListaDeHorarios)
            {
                if (item.Checked == true)
                {
                    item.ID_HR = item.ID_HR;
                    item.DESC_HR = item.DESC_HR;
                }
            }
            ModelState.Clear();
            if(ModelState.IsValid)
            {
                //seta ids dos horarios
                foreach (var item in form["HorariosSelecionados"])
                {

                    ListaDeIdsHorarios.Add(item.ToString());

                }

                foreach (var item in form["HorariosSelecionados"])
                {
                    ListaDeHorarios.Add(new HORARIOS {
                        ID_HR = Convert.ToInt32(item)
                    });
                }
                banco.NOME_BANCO = form["programador.Banco"];
                //BancosRep.Add_Banco(banco);

                conta.ID_BANCO = banco.ID_BANCO;
                conta.NUM_CONTA = form["programador.Conta"];
                conta.AGENCIA_CONTA = form["programador.Agencia"];
                conta.TIPO_CONTA = form["programador.TipoConta"];


                //ProgramadoresRep.add(prog, ListaDeIdsHorarios);

            }
            return View();
        }
        public PartialViewResult GetHorarios()
        {
            horarios.ListaDeHorarios = HorariosRep.GetAll();
            return PartialView("_Horarios",horarios);
        }
        public PartialViewResult GetTecnologias()
        {
            foreach (var item in TecnologiasRep.GetAllTecnologias().ToList())
            {

                NivelConhecimentoTecnologias.ListaDeNiveisDeConhecimento.Add(new NIVEL_DE_CONHECIMENTO {
                    DESC_TECNO = item.DESC_TECNO,
                    ID_TECNO=item.ID_TECNO
                    
                });
            }

            return PartialView("_Tecnologias", NivelConhecimentoTecnologias);
        }
        //public JsonResult GetHorarios()
        //{
        //    return new JsonResult {Data=HorariosRep.GetAll(),JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        //}
    }

}