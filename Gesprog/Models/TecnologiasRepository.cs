using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class TecnologiasRepository
    {
        DbGesprog context;
        List<TECNOLOGIAS> ListaDeTecnologias;
        public TecnologiasRepository()
        {
            this.context = new DbGesprog();
            this.ListaDeTecnologias = new List<TECNOLOGIAS>();
        }

        public List<TECNOLOGIAS> GetAllTecnologias()
        {
            var consulta = from t in context.TECNOLOGIAS
                           select t;

            foreach (var item in consulta.ToList())
            {
                ListaDeTecnologias.Add(new TECNOLOGIAS
                {
                    ID_TECNO = item.ID_TECNO,
                    DESC_TECNO = item.DESC_TECNO
                });
            }
            return ListaDeTecnologias.ToList();
        }
    }
}