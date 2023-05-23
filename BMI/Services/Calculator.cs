using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMIApp.Repository;
using BMIApp.Interfaces;

namespace BMIApp.Services
{
    internal class Calculator : ICalculator
    {
        ILog _log;
        BMI bmii = new BMI();
        BmiContext _bmiContext;
        private BmiContext bmiContext;


        public Calculator(BmiContext bmiContext, ILog log)
        {

            _bmiContext = bmiContext;
            _log = log;
        }
        public double Calculate()

        {
            while (true)
            {
                Console.WriteLine("Pleas write your CodeMeli:");
                var code = Console.ReadLine();

                bmii.DateTime = DateTime.Now;




                var p2 = from ii in _bmiContext.People
                         where ii.CodeMeli == code
                         select ii;
                var myPerson = p2.FirstOrDefault();

                if (myPerson == null)
                {
                    continue;
                }



                bmii.Idpersons = myPerson.IDperson;
                break;

            }


            Console.WriteLine("Pleas write your Weight: ");

            var w = Console.ReadLine();
            bmii.Weight = double.Parse(w);

            Console.WriteLine("Pleas write your height: ");

            var h = Console.ReadLine();
            bmii.height = double.Parse(h);



            double bmiCalculator = (bmii.Weight / ((bmii.height/100) * (bmii.height/100)));
            bmii.bmi = bmiCalculator;

            Console.WriteLine("Your BMI is:" + bmiCalculator);
            Console.WriteLine("If it is below 18.5, the person is losing weight.");
            Console.WriteLine("If it is between 18.5 and 24.9, the person is in the healthy weight range and the weight is ideal");
            Console.WriteLine("If it is between 25 and 29.9, the person is overweight.");
            Console.WriteLine("If it is between 30 and 34.9, the person is obese.");
            Console.WriteLine("If it is above 35, the person suffers from obesity.");



            _bmiContext.Bmis.Add(bmii);
            _bmiContext.SaveChanges();
            _log.LogInfo("your BMI in this time save in data base!");
            return bmiCalculator;


        }


    }
}
