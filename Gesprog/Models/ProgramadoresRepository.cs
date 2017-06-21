using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class ProgramadoresRepository
    {
        DbGesprog context;
        HORARIOS horarios;
        List<HORARIOS> ListaDeHorariosSelecionados;
        


        public ProgramadoresRepository()
        {
            this.context = new DbGesprog();
            this.horarios = new HORARIOS();

        }
        public void add(PROGRAMADORES programador, List<int> ListaDeIdHorarios)
        {
            try
            { 
                context.PROGRAMADORES.Add(programador);
                context.SaveChanges();
                var consulta =  from hr in context.HORARIOS
                                select hr;
                    foreach(var hr in consulta)
                    {
                        foreach (var item in ListaDeIdHorarios) {
                            if (hr.ID_HR == item)
                            {
                                programador.HORARIOS.Add(hr);
                                context.SaveChanges();
                            }
                        }

                    }
 

          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
         
    }
}