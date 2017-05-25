using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class HorariosRepository
    {
        DbGesprog context;
        List<HORARIOS> ListaDeHorarios;
        public HorariosRepository()
        {
            this.context = new DbGesprog();
            this.ListaDeHorarios = new List<HORARIOS>();
        }

        public IEnumerable<HORARIOS> GetAll()
        {
            var consulta = from h in context.HORARIOS
                           select h;
            foreach (var item in consulta.ToList())
            {
                ListaDeHorarios.Add(new HORARIOS
                {
                    ID_HR = item.ID_HR,
                    DESC_HR = item.DESC_HR
                });
            }
            return ListaDeHorarios.ToList();
        }
    }
}