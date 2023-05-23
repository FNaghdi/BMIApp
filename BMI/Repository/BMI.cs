using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIApp.Repository
{
    internal class BMI
    {

        public int IDBmi { get; set; }
        public DateTime DateTime { get; set; }
        public double height { get; set; }

        public double Weight { get; set; }

        public double bmi { get; set; }


        public int Idpersons { get; set; }



        public virtual Person? Person { get; set; }
    }
}
