using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Interfaces;
using BMIApp.Repository;
using BMIApp.Services;

namespace BMIApp.CRUD
{
    internal class Edit
    {
        BmiContext _BmiContext;

        ILog _log;
        private BmiContext bmiContext;

      

        public Edit(BmiContext bmiContext, ILog log)
        {
            _BmiContext = bmiContext;
            _log = log;

        }
        public void editMember()
        {
            _log.LogInfo(" Ready to edit persone!");
            Console.WriteLine("Pleas write your CodeMeli:");
            var code = Console.ReadLine();

            var p = _BmiContext.People.FirstOrDefault(x => x.CodeMeli == code);
            if (p == null)
            {
                Console.WriteLine("Your Person Not Exists!");
                return;
            }

            while (true)
            {
                Console.WriteLine("Please Choose Your Action!");
                Print.PrintEditMenu();


                var action = Console.ReadLine();

                if (action == "1")
                {
                    Console.WriteLine("Pleas write your Name:");

                    p.Name = Console.ReadLine();
                }
                else if (action == "2")
                {
                    Console.WriteLine("Pleas write your LastName:");

                    p.LastName = Console.ReadLine();

                }
                else if (action == "3")
                {
                    var orignalCodeMeli = p.CodeMeli;
                    Console.WriteLine("Pleas write your Code Melli:");
                    while (true)
                    {
                        p.CodeMeli = Console.ReadLine();
                        if (p.CodeMeli.Length != 10)
                        {

                            Console.WriteLine("Your Code Should Be 10 Digit");
                        }
                        else if (_BmiContext.People.Any(a => a.CodeMeli == p.CodeMeli) && p.CodeMeli!=orignalCodeMeli)
                        {
                            Console.WriteLine("Your Code Is Not Uniqe");
                        }

                       
                        else
                        {
                            break;
                        }
                    }


                }
                else if (action == "4")
                {
                    Console.WriteLine("Pleas write your Age:");
                    var m = Console.ReadLine();
                    p.Age = int.Parse(m);

                }

                else if (action == "5")
                {
                    Console.WriteLine("Pleas write your phone:");
                    p.Telephon = Console.ReadLine();
                }
                else if (action == "6")
                {
                    break;
                }
            }
            _BmiContext.SaveChanges();
            _log.LogInfo("Edit Person Save" + p.CodeMeli + "save information");

            Console.WriteLine("Your editPerson save. ");



        }
    }
}
