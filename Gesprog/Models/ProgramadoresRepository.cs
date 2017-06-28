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
        public void add(PROGRAMADORES programador, List<string> ListaDeHorarios,CONTAS_BANCARIAS conta)
        {
            try
            {
                //add programador
                context.PROGRAMADORES.Add(programador);
                context.SaveChanges();

                //add os melhores horarios para se trabalhar
                var consulta = from hr in context.HORARIOS
                               select hr;
                foreach(var item in ListaDeHorarios)
                {
                    foreach (var hr in consulta.ToList())
                    {
                        if (Convert.ToInt32(item) == hr.ID_HR)
                        {
                            programador.HORARIOS.Add(hr);
                            context.SaveChanges();
                        }
                    }
                }

                //add a conta bancaria do programador
                programador.CONTAS_BANCARIAS.Add(conta);
                context.SaveChanges();


          
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
         
    }
}