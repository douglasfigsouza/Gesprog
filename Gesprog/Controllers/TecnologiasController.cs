using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gesprog.Models;

namespace Gesprog.Controllers
{
    public class TecnologiasController : Controller
    {
        TecnologiasRepository TecnologiasRep;
        public TecnologiasController()
        {
            this.TecnologiasRep = new TecnologiasRepository();
        }
        public JsonResult GetAllTecnologias()
        {
            return new JsonResult { Data = TecnologiasRep.GetAllTecnologias(), JsonRequestBehavior=JsonRequestBehavior.AllowGet };
        }
    }
}