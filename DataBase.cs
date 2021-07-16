using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9____LINQ
{
   public class DataBase
    {
        public IEnumerable<Developer> Developers()
        {

            return new List<Developer>()
            {
                new Developer{Id = 1, Name = "Chinese Chikky", ProjectId = 1},
                new Developer{Id = 2, Name = "Scientific Sammy", ProjectId = 2},
                new Developer{Id = 3, Name = "Strategic Sammy", ProjectId = 3},
                new Developer{Id = 4, Name = "calculative Chinedu", ProjectId = 3},
                new Developer{Id = 5, Name = "sincere Shola ", ProjectId = 2},
                new Developer{Id = 6, Name = "Terrible Tochukwu", ProjectId = 1},
                new Developer{Id = 7, Name = "Daring Dara", ProjectId = 3},
                new Developer{Id = 8, Name = "Underrated Uriel", ProjectId = 2},
                new Developer{Id = 9, Name = "Adventurous Alex", ProjectId = 4},
                new Developer{Id = 10, Name = "Logical Loveth", ProjectId = 2},
                new Developer{Id = 11, Name = "Knowledgeable Kc", ProjectId = 1},
                new Developer{Id = 12, Name = "Friendly Francis", ProjectId = 4},
                new Developer{Id = 13, Name = "Kinetic Kachi", ProjectId = 1},
                new Developer{Id = 14, Name = "Simple Sunday", ProjectId = 4},
                new Developer{Id = 15, Name = "Random Person", ProjectId = 5},
                new Developer{Id = 16, Name = "Optimistic Obinna", ProjectId = 3},
                new Developer{Id = 17, Name = "Generous Gideon", ProjectId = 1},

            };
        }


        public IEnumerable<Project> Projects()
        {
            return new List<Project>()
            {
                new Project{Id = 1, Name = "Cypto-Wallet"},
                new Project{Id = 2, Name = "E-commerce"},
                new Project{Id = 3, Name = "DBMS"},
                new Project{Id = 4, Name = "HMS"}

            };
        }
    }
}
