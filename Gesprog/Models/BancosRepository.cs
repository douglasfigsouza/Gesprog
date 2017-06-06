using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gesprog.Models
{
    public class BancosRepository
    {
        DbGesprog context;
        public BancosRepository()
        {
            this.context = new DbGesprog();
        }
        public void Add_Banco(BANCO banco)
        {
            try
            {
                context.BANCO.Add(banco);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}