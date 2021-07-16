using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9____LINQ
{
   public static class StandardOperators
    {
        private static DataBase DataBase = new DataBase();
        public static void Where()
        {
            //WHERE  
            var querySyntax = from developer in DataBase.Developers()
                where developer.Name.StartsWith("S")
                select developer.Name;

            Console.WriteLine("Where in querySyntax------");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine(dev);
            }


            var methodSyntax = DataBase.Developers().Where(d => d.Name.StartsWith("S"));
        
            Console.WriteLine("Where in methodSyntax-----");

            foreach (var dev in methodSyntax)
            {
                Console.WriteLine(dev.Name);
            }
            Console.WriteLine('\n');

        }

        public static void Order()
        {
            //OrderBy Ascending
            var querySyntax = from developer in DataBase.Developers()
                orderby developer.Name
                select developer.Name;

            Console.WriteLine("Order by ascending in querySyntax------");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine(dev);
            }

            var methodSyntax = DataBase.Developers().OrderBy(d => d.Name);

            Console.WriteLine("\nOrder by ascending in methodSyntax------\n");
            foreach (var dev in methodSyntax)
            {
                Console.WriteLine(dev.Name);
            }
            Console.WriteLine('\n');


            //OrderBy Descending


            var querySyntaxDesc = from developer in DataBase.Developers()
                orderby developer.Name descending 
                select developer.Name;

            Console.WriteLine("\nOrder by Descending in querySyntax------\n");

            foreach (var dev in querySyntaxDesc)
            {
                Console.WriteLine(dev);
            }

            var methodSyntaxDesc = DataBase.Developers().OrderByDescending(d => d.Name);

            Console.WriteLine("\nOrder by Descending in methodSyntax------\n");
            foreach (var dev in methodSyntaxDesc)
            {
                Console.WriteLine(dev.Name);
            }
            Console.WriteLine('\n');
        }


        public static void ThenBy()
        {

            //ThenBY
            var querySyntax = from developer in DataBase.Developers()
                orderby developer.ProjectId, developer.Name 
                select developer;

            Console.WriteLine("ThenBY in querySyntax------");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine($"{dev.Name}:{dev.ProjectId}");
            }


            var methodSyntax = DataBase.Developers().OrderBy(d => d.ProjectId).ThenBy(d => d.Name);

            Console.WriteLine("\nThenBy in methodSyntax------\n");
            foreach (var dev in methodSyntax)
            {
                Console.WriteLine($"{dev.Name}:{dev.ProjectId}");
            }
            Console.WriteLine('\n');

        }

        public static void Take()
        {
            //Take

            var querySyntax = (from developer in DataBase.Developers()
                select developer).Take(5);
            var sortedFive = from developer in querySyntax
                orderby developer.Name
                    descending
                select developer;


            Console.WriteLine("\nTake in querySyntax------\n");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine(dev.Name);
            }

            Console.WriteLine("\nTake in sortedFive------\n");

            foreach (var dev in sortedFive)
            {
                Console.WriteLine(dev.Name);
            }

            var methodSyntax = DataBase.Developers().Take(5);
            // var methodSyntax = DataBase.Developers().Take(5).OrderByDescending(d => d.Name);

            Console.WriteLine("\nTake in methodSyntax------\n");

            foreach (var dev in methodSyntax)
            {
                Console.WriteLine(dev.Name);
            }

        }


        public static void Skip()
        {
            //Skip

            var querySyntax = (from developer in DataBase.Developers()
                select developer).Skip(5);

            Console.WriteLine("\nSkip in querySyntax------\n");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine(dev.Name);
            }


            var methodSyntax = DataBase.Developers().Skip(5);

            Console.WriteLine("\nSkip in methodSyntax------\n");

            foreach (var dev in methodSyntax)
            {
                Console.WriteLine(dev.Name);
            }

        }

        public static void Group()
        {
            //Group

            var querySyntax = from developer in DataBase.Developers()
                group developer by developer.ProjectId;

            Console.WriteLine("\nGroup in querySyntax------\n");

            foreach (var dev in querySyntax)
            {
                Console.WriteLine($"projectId: {dev.Key}, Number: {dev.Count()} ");
            }


            var methodSyntax = DataBase.Developers().GroupBy(d => d.ProjectId);

            Console.WriteLine("\nGroup in methodSyntax------\n");

            foreach (var dev in methodSyntax)
            {
                Console.WriteLine($"projectId: {dev.Key}, Number: {dev.Count()} ");
            
            }
        }

        public static void First()
        {
            //First

            var querySyntax = (from developer in DataBase.Developers()
                // where developer.Name.StartsWith("M")
                select developer).First();

            Console.WriteLine("\nFirst in querySyntax------\n");

            Console.WriteLine(querySyntax.Name);
            


            var methodSyntax = DataBase.Developers()
                // .Where(d => d.Name.StartsWith("M"))
                .First();

            Console.WriteLine("\nFirst in methodSyntax------\n");

            Console.WriteLine(methodSyntax.Name);
        }


        public static void FirstOrDefault()
        {
            //FirstOrDefault

            var querySyntax = (from developer in DataBase.Developers()
                where developer.Name.StartsWith("M")
                select developer).FirstOrDefault();

            Console.WriteLine("\nFirstOrDefault in querySyntax------\n");

            Console.WriteLine(querySyntax?.Name);

            //above line equivalent to:

            // if (querySyntax != null)
            // {
            //     Console.WriteLine(querySyntax.Name);
            // }



            var methodSyntax = DataBase.Developers()
                .Where(d => d.Name.StartsWith("M"))
                .FirstOrDefault();

            Console.WriteLine("\nFirstOrDefault in methodSyntax------\n");

            Console.WriteLine(methodSyntax?.Name);
        }


        public static void Join()
        {
            //Join

            var querySyntax = from developer in DataBase.Developers() 
                join project in DataBase.Projects() on developer.ProjectId equals project.Id
                select new {developer = developer.Name, project= project.Name };

            Console.WriteLine("\nJoin in querySyntax------\n");

            foreach (var result in querySyntax)
            {
                Console.WriteLine($"{result.developer}: {result.project}");
            }


            var methodSyntax = DataBase.Developers().Join(DataBase.Projects(),
                d => d.ProjectId, p => p.Id,
                (developer, project) => new {name = developer.Name, project = project.Name});

            Console.WriteLine("\nJoin in methodSyntax------\n");

            foreach (var result in methodSyntax)
            {
                Console.WriteLine($"{result.name}: {result.project}");
            }
        }


        public static void LeftJoin()
        {
            //LeftJoin

            var querySyntax = from developer in DataBase.Developers()
                join project in DataBase.Projects() on developer.ProjectId equals project.Id into group1
                from project in group1.DefaultIfEmpty()
                select new { developer = developer.Name, project = project?.Name ?? "Project not Assigned Yet" };

            Console.WriteLine("\nLeftJoin in querySyntax------\n");

            foreach (var result in querySyntax)
            {
                Console.WriteLine($"{result.developer}: {result.project}");
            }

            
            // Trying Writing in the Method Syntax
        }
    }
}
