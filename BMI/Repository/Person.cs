using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMIApp.Repository
{
    internal class Person
    {
        public int  IDperson { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string Telephon { get; set; }

        public string CodeMeli { get; set; }

        public int Age { get; set; }

       



        public virtual ICollection<BMI> bmi { get; } = new List<BMI>();

    }
}
