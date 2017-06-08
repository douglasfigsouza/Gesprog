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
            try
            { 
                context.PROGRAMADORES.Add(programador);
                context.SaveChanges();

                HORARIOS hr = new HORARIOS { ID_HR = 1, DESC_HR = "Morning (from 08:00 to 12:00) / Manhã (de 08:00 ás 12:00)" };
                        
                programador.HORARIOS.Add(hr);
                context.SaveChanges();
          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
         
    }
}