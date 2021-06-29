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
            var students = new List<Student>()
            {
                new Student { First="Svetlana",
                    Last="Omelchenko",
                    Id=111,
                    Street="123 Main Street",
                    City="Seattle",
                    Scores= new List<int> { 97, 92, 81, 60 },
                    TeacherId = 945
                },
                new Student { First="Claire",
                    Last="O’Donnell",
                    Id=112,
                    Street="124 Main Street",
                    City="Redmond",
                    Scores= new List<int> { 75, 84, 91, 39 },
                    TeacherId = 956
                },
                new Student { First="Sven",
                    Last="Mortensen",
                    Id=113,
                    Street="125 Main Street",
                    City="Lake City",
                    Scores= new List<int> { 88, 94, 65, 91 },
                    TeacherId = 956
                },
                new Student { First="Tom",
                    Last="Hanks",
                    Id=134,
                    Street="AtriumWay 12424",
                    City="Nashville",
                    Scores= new List<int> { 88, 94, 65, 91 },
                    TeacherId = 956
                },
                
                new Student { First="Anka",
                    Last="Kolorowanka",
                    Id=423,
                    Street="125 Main Street",
                    City="Salt Lake City",
                    Scores= new List<int> { 88, 94, 65, 91 },
                    TeacherId = 956
                },
            };

            var teachers = new List<Teacher>()
            {
                new Teacher { First="Ann", Last="Beebe", Id=945, City="Seattle" },
                new Teacher { First="Alex", Last="Robinson", Id=956, City="Redmond" },
                new Teacher { First="Michiyo", Last="Sato", Id=972, City="Tacoma" }
            };

            //Query Syntax, Expression Syntax, 
            var query = from teacher in teachers
                        where teacher.City == "Redmond"
                        select teacher;

            var queryExpMeth = teachers.Where<Teacher>(i => i.City == "Seattle");

            var queryStMeth = teachers.Where<Teacher>(FromTacoma);
            
            //GroupJoin
            //https://www.tutorialsteacher.com/linq/linq-joining-operator-groupjoin
            var groupJoin = teachers.GroupJoin(students,  //inner sequence
               
                teacher => teacher.Id, //outerKeySelector 
                student => student.TeacherId,     //innerKeySelector
                    (teacher, studentsGroup) => new // resultSelector 
                    {
                        Teacher = teacher,
                        studentsGroup = studentsGroup
                    }).ToList();
            
            foreach (var item in groupJoin)
            { 
                Console.WriteLine($"{item.Teacher.First} {item.Teacher.Last}");
			
                foreach(var stud in item.studentsGroup)
                    Console.WriteLine($"---{stud.First} {stud.Last}");
            }
            
            //SelectMany
            int[][] arrays = {
                new[] {1, 2, 3},
                new[] {4},
                new[] {5, 6, 7, 8},
                new[] {12, 14}
            };
            
            IEnumerable<int> result2 = arrays.SelectMany(array => array); // Will return { 1, 2, 3, 4, 5, 6, 7, 8, 12, 14 }
            
            List<List<int>> lists = new List<List<int>> {
                new List<int> {1, 2, 3},
                new List<int> {12},
                new List<int> {5, 6, 5, 7},
                new List<int> {10, 10, 10, 12}
            };
            IEnumerable<int> result3 = lists.SelectMany(list => list.Distinct());   // Will return { 1, 2, 3, 12, 5, 6, 7, 10, 12 }

            //Contains vs Any
            //Contains is also an extension method against IEnumerable<T> (although some collections have their own Contains instance method too). As you say, Any is more flexible than Contains because you can pass it a custom predicate, but Contains might be slightly faster because it doesn't need to perform a delegate invocation for each element
            
            //Also note that in your example, Any() is using the == operator which will check for referential equality, while Contains will use IEquatable<T> or the Equals() method, which might be overridden.
            //Contains way better for comparing objects, than Any!
            var myCollection = new List<int>{1,2,3,4};
            var myElement = 3;
            var hasMyElement = myCollection.Contains(myElement);
            var hasMyElement2 = myCollection.Any(currentElement => currentElement == myElement);
            
            //FirstOrDefault vs SingleOrDefault?
            //Whenever you use SingleOrDefault, you clearly state that the query should result in at most a single result. On the other hand, when FirstOrDefault is used, the query can return any amount of results but you state that you only want the first one.
            // I personally find the semantics very different and using the appropriate one, depending on the expected results, improves readability.
            var firstOrDef = myCollection.FirstOrDefault(); //1st elem
            // var singleOrDef = myCollection.SingleOrDefault(); //throw exception!
            var singleOrDef2 = new List<int> {1}.SingleOrDefault(); //1st elem

            //SequenceEqual
            // IList<string> strList1 = new List<string>(){"One", "Two", "Three", "Four", "Three"};
            //
            // IList<string> strList2 = new List<string>(){"One", "Two", "Three", "Four", "Three"};
            //
            // bool isEqual = strList1.SequenceEqual(strList2); // returns true
            // Console.WriteLine(isEqual);

            // IList<string> strList1 = new List<string>(){"One", "Two", "Three", "Four", "Three"};
            //
            // IList<string> strList2 = new List<string>(){ "Two", "One", "Three", "Four", "Three"};
            //
            // bool isEqual = strList1.SequenceEqual(strList2); // returns false
            // Console.WriteLine(isEqual);

        }
    }
}
