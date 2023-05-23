using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Repository;
using BMIApp.Interfaces;
using static System.Formats.Asn1.AsnWriter;
using System.Security.Cryptography;

namespace BMIApp.CRUD
{
    internal class Save
    {
        ILog _log;
        BmiContext _bmiContext;
        public Save(BmiContext bmiContext, ILog log)
        {
            _bmiContext = bmiContext;
            _log = log;

        }

        public void SaveName()
        {

            try
            {
                _log.LogInfo("Ready To Save New Person!");
                Person person = new Person();

                while (true)
                {
                    Console.WriteLine("Pleas write your FirstName: ");
                    person.Name = Console.ReadLine();
                    if (person.Name == "")
                    {
                        Console.WriteLine("Your Name Can Not Be Empty!");
                    }
                    else
                    {
                        break;
                    }
                }
                while (true)
                {

                    Console.WriteLine("Pleas write your LastName:");

                    person.LastName = Console.ReadLine();

                    if (person.LastName == "")
                    {
                        Console.WriteLine(" your last Name is empyty !");
                    }

                    else
                    {
                        break;
                    }
                }


                Console.WriteLine("Pleas write your Telephon:");
                person.Telephon = Console.ReadLine();





                while (true)
                {

                    Console.WriteLine("Pleas write your CodeMeli:");

                    person.CodeMeli = Console.ReadLine();

                    // var code = _bmiContext.People.FirstOrDefault(a => a.CodeMeli == person.CodeMeli);
                    if (person.CodeMeli.Length != 10 && person.CodeMeli == "")
                    {

                        Console.WriteLine("Your Code Should Be 10 Digit or Your Code Meli Can Not Be Empty!");
                    }
                    else if (_bmiContext.People.Any(a => a.CodeMeli == person.CodeMeli))
                    {

                        Console.WriteLine("Your Code Is Not Uniqe");
                    }

                    else
                    {
                        break;
                    }

                    //if (person.CodeMeli.Length != 10)
                    //{
                    //    Console.WriteLine("Your National Code Is Not Valid!");
                    //}
                    //else
                    //{
                    //    break;
                    //}
                }



               





                Console.WriteLine("Pleas write your Age:");
                while (true)
                {
                    var input = Console.ReadLine();
                    int i;
                    var result = int.TryParse(input, out i);
                    if (result)
                    {
                        person.Age = i;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("PLease Enter Digit!");
                    }
                }

                _bmiContext.People.Add(person);
                _bmiContext.SaveChanges();
                Console.WriteLine("Your New Person Added");
                _log.LogInfo("Your Person With National Code : " + person.CodeMeli + " Successfully Added.");

            }
            catch (Exception e)
            {
                Console.WriteLine(" Check the entered information again!");
            }

        }




    }



}






