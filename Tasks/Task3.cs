using System;
using System.Collections.Generic;
using System.Linq;


namespace Tasks
{
    /*
     *  Write Arr program that gets the data from the oscar.csv file and figures out
print name of the actor who has more Oscars from the others
print name of the actor who is the oldest actor or actress who got the Oscar, in what year and for what movie
print the name of the actor who got the more than Oscar in row
please note that the CSV file's data are ordered like this ( "Index", "Year", "Age", "Name", "Movie" ).
*/
    public class Oscar
    {
        public int Index;
        public int Year;
        public int Age;
        public string Name;
        public string Movie;

        public Oscar(int Index, int Age, int Year, string Name, string Movie)
        {

            this.Index = Index;
            this.Age = Age;
            this.Year = Year;
            this.Name = Name;
            this.Movie = Movie;
        }

    }
    public class OscarFunctionality
    {
        string path;
        public List<Oscar> OscarObjects;
        // add path to .csv upon initilzing
        public OscarFunctionality(string path)
        {
            this.path = path;
            this.OscarObjects = new List<Oscar>();
            Console.WriteLine("number of objects: " + initilize());
            Console.WriteLine(MostOscarsHolder());
            OldestOscarHolder();
        }
        //most oscars holder
        private int initilize()
        {
            var lines = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split(',');
                // object init. -> list<oscar>
                Oscar o = new Oscar(
                    Int32.Parse(line[0]), // index
                    Int32.Parse(line[2]), // year
                    Int32.Parse(line[1]), // age
                    line[3], //name
                    line[4] // Movie Name
                    );

                OscarObjects.Add(o);
            }
            return OscarObjects.Count();
        }
        //most oscars holder :D
        private string MostOscarsHolder()
        {
            Dictionary<string, int> table = new Dictionary<string, int>();
            foreach (var Oscar in OscarObjects)
            {
                if (table.ContainsKey(Oscar.Name))
                {
                    table[Oscar.Name] += 1; ;
                }
                else
                {
                    table.Add(Oscar.Name, 1);
                }
            }

            int MaxOscars = table.Values.Max();
            string MostOscarsHolder = "";
            foreach (var record in table.Keys)
            {
                if (table[record] == MaxOscars)
                {
                    MostOscarsHolder = record;
                    break;
                }
            }
            return MostOscarsHolder;
        }
        //oldest oscar holder
        private void OldestOscarHolder()
        {
            int oldest = 0; // arbitrary
            string name = "";
            int year = 0;
            string movie = "";
            foreach (var oscar in OscarObjects)
            {
                if (oscar.Age > oldest)
                {
                    oldest = oscar.Age;
                    name = oscar.Name;
                    year = oscar.Year;
                    movie = oscar.Movie;
                }
            }
            Console.WriteLine("oldest actor: {0} with the age of {1} in the year of {2} in the movie {3}", name, oldest, year, movie);


        }

    }
}

