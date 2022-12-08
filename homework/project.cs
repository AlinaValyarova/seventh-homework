using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;


namespace homework
{
    public class Project
    {
        public static void Main()
        {
            List<Employee> stuff = new List<Employee>();
            List<string> postsWithDupes = new List<string>();
            List<string> accdep = new List<string>();
            Employee Boris = new Employee.Director { name = "Boris", post = "director"};
            stuff.Add(Boris);
            Employee Rashid = new Employee.FinDir { name = "Rashid", post = "financial director" };
            stuff.Add(Rashid);
            Employee Ilham = new Employee.AutoDir { name = "Ilham", post = "Automatisation director" };
            stuff.Add(Ilham);
            Employee Lucas = new AccDep.AccDir { name = "Lucas", post = "Main accountant" };
            stuff.Add(Lucas);
            Employee Orcadi = new InfDep.InfDir { name = "Orcadi", post = "Information Director" };
            stuff.Add(Orcadi);
            Employee Volodya = new InfDep.InfAssDir { name = "Volodya", post = "Information director assistant" };
            stuff.Add(Volodya);
            Employee Ilshat = new SystemDep.SysDir { name = "Ilshat", post = "System director" };
            stuff.Add(Ilshat);
            Employee Ivanuch = new SystemDep.SysAssDir { name = "Ivanych", post = "System assistance director" };
            stuff.Add(Ivanuch);
            Employee Ilya = new SystemDep.SysEmployers { name = "Ilya", post = "system employee" };
            stuff.Add(Ilya);
            Employee Vitya = new SystemDep.SysEmployers { name = "Vitya", post = "system employee" };
            stuff.Add(Vitya);
            Employee Zhenya = new SystemDep.SysEmployers { name = "Zhenya", post = "system employee" };
            stuff.Add(Zhenya);
            Employee Sergey = new DevelopmentDep.DevDir { name = "Sergey", post = "development director" };
            stuff.Add(Sergey);
            Employee Leysan = new DevelopmentDep.DevAssDir { name = "Leysan", post = "development assistance director" };
            stuff.Add(Leysan);
            Employee Marat = new DevelopmentDep.DevEmployers { name = "Marat", post = "development employee" };
            stuff.Add(Marat);
            Employee Diana = new DevelopmentDep.DevEmployers { name = "Diana", post = "development employee" };
            stuff.Add(Diana);
            Employee Ildar = new DevelopmentDep.DevEmployers { name = "Ildar", post = "development employee" };
            stuff.Add(Ildar);
            Employee Anton = new DevelopmentDep.DevEmployers { name = "Anton", post = "development employee" };
            stuff.Add(Anton);
            foreach(Employee a in stuff)
            {
                postsWithDupes.Add(a.post);
            }
            List<string> posts = postsWithDupes.Distinct().ToList();
            Console.WriteLine("Enter your name");
            string tskgiver = Console.ReadLine();
            Console.WriteLine("Enter who should do a task");
            string tskmaker = Console.ReadLine();
            Console.WriteLine("Enter the task");
            string task = Console.ReadLine();
            List<string> tmtg = new List<string>();
            string post;
            foreach(Employee tg in stuff)
            {
                if(tg.name.Equals(tskgiver))
                {
                    post = tg.post;
                    tmtg.Add(post);
                }
            }
            foreach (Employee tm in stuff)
            {
                if (tm.name.Equals(tskmaker))
                {
                    post = tm.post;
                    tmtg.Add(post);
                }
            }
            if (posts.IndexOf(tmtg[0])<=posts.IndexOf(tmtg[1]))
            {
                Console.WriteLine($"{tskmaker} will take the task from {tskgiver}");
            }
            else 
            {
                Console.WriteLine($"{tskmaker} will not take the task from {tskgiver}");
            }






            
            
        }
    }

}
