using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class CidadesRepository
    {
        DbGesprog context;
        List<CIDADE> ListaDeCidades;
        public CidadesRepository()
        {
            this.context = new DbGesprog();
            this.ListaDeCidades = new List<CIDADE>();
        }
        public List<CIDADE> GetCityId(int Id)
        {
            var consulta = from c in context.CIDADE
                           join e in context.ESTADO on c.ESTADOID equals e.ESTADOID
                           where e.ESTADOID.Equals(Id)
                           select new
                           {
                               NOME = c.NOME,
                               CIDADEID = c.CIDADEID
                           };
            foreach (var item in consulta.ToList())
            {
                ListaDeCidades.Add(new CIDADE
                {
                    CIDADEID = item.CIDADEID,
                    NOME = item.NOME
                });
            }
            return ListaDeCidades.ToList();
        }
    }
}