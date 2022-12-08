using System;
using System.Collections.Generic;
using System.Text;

namespace homework
{
    public class Employee
    {
        public string name;
        public string post;
        public class Director : Employee { }

        public class FinDir : Employee { }

        public class AutoDir : Employee { }



    }
}
