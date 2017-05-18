using Gesprog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gesprog.Controllers
{
    public class CidadesController : Controller
    {
        CidadesRepository CidadeRep;
        List<SelectListItem> ListaDeCidades;
        public CidadesController()
        {
            this.CidadeRep = new CidadesRepository();
            this.ListaDeCidades = new List<SelectListItem>();
        }
        // GET: Cidades
        public JsonResult GetCityId(int Id)
        {
            return new JsonResult { Data = CidadeRep.GetCityId(Id), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}