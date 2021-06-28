using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq_Codecool
{
    class Program
    {
        public static bool FromTacoma(Teacher teacher)
        {
            return teacher.City == "Tacoma";
        }

        static void Main(string[] args)
        {
            List<Student> students = new List<Student>()
            {
                new Student { First="Svetlana",
                    Last="Omelchenko",
                    ID=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> { 97, 92, 81, 60 } },
                new Student { First="Claire",
                    Last="O’Donnell",
                    ID=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> { 75, 84, 91, 39 } },
                new Student { First="Sven",
                    Last="Mortensen",
                    ID=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> { 88, 94, 65, 91 } },
            };

            List<Teacher> teachers = new List<Teacher>()
            {
                new Teacher { First="Ann", Last="Beebe", ID=945, City="Seattle" },
                new Teacher { First="Alex", Last="Robinson", ID=956, City="Redmond" },
                new Teacher { First="Michiyo", Last="Sato", ID=972, City="Tacoma" }
            };

            var query = from teacher in teachers
                        where teacher.City == "Redmond"
                        select teacher;

            var queryExpMeth = teachers.Where<Teacher>(i => i.City == "Seattle");

            var queryStMeth = teachers.Where<Teacher>(FromTacoma);

        }
    }
}
