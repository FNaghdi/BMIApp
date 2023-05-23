using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Interfaces;
using BMIApp.Repository;

namespace BMIApp.CRUD
{
    internal class Delete
    {
        ILog _log;
        BmiContext _BmiContext;
        private BmiContext bmiContext;

       

        public Delete(BmiContext bmiContext, ILog log)
        {

            _BmiContext = bmiContext;
            _log = log;
        }


        public void delete()
        {
            while (true)
            {
                Console.WriteLine("Pleas write your Code Meli:");
                string code = Console.ReadLine();

                if (code == "")
                    continue;


                var p = _BmiContext.People.FirstOrDefault(x => x.CodeMeli == code);

                if (p == null)
                    continue;



                _BmiContext.People.Remove(p);
                _BmiContext.SaveChanges();


                _log.LogInfo("This account Deleted!");

            }
        }


    }

}

