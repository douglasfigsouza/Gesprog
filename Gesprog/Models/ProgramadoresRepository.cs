using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class ProgramadoresRepository
    {
        DbGesprog context;

        public ProgramadoresRepository()
        {
            this.context = new DbGesprog();
        }
        public void add(PROGRAMADORES programador, List<HORARIOS> ListaDeHorarios)
        {
            context.PROGRAMADORES.Add(programador);
            context.SaveChanges();
            programador.ID_PROG = programador.ID_PROG;

            programador.HORARIOS = ListaDeHorarios;
            context.HORARIOS.Add(programador);
            context.SaveChanges();
        }
         
    }
}