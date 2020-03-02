using System;
using System.Collections.Generic;
using System.Linq;
namespace Partie_Console
{
    public class Generation

    {
        private string name;
        private int numGeneration;
        private List<Path> listPathPop;
        private List<Path> listPathGen;
        private List<City> Gcities;


        public String NameGeneration
        {
            get
            {
                return this.name;
            }
        }

        public int numberGeneration
        {
            get
            {
                return this.numGeneration;
            }
            set
            {
                this.numGeneration = value;
            }
        }


        public List<Path> GetPopulation
        {
            get
            {
                return this.listPathPop;
            }
        }

        public List<Path> GetGeneration
        {
            get
            {
                return this.listPathGen;
            }
            set
            {
                this.listPathGen = value;
            }
        }

        public Generation(int number, List<Path> paths, string nameG = null)
        {
            this.numGeneration = number;
            this.listPathGen = new List<Path>(paths);
            this.listPathPop = new List<Path>();
            this.name = nameG;
        }

        public Generation(int number, List<City> cities, string nameG = null)
        {
            this.Gcities = cities;
            this.numGeneration = number;
            this.listPathGen = new List<Path>();
            this.listPathPop = new List<Path>();
            this.name = nameG;
            GetFirstGen();
        }

        public int CompPath(Path chemin, List<Path> maListe)
        {
            var count = from c in maListe
                        where c.ToString() == chemin.ToString()
                        select c;
            return count.Count();
        }

        public int CompCities(City c, List<City> cities)
        {
            var counter = from city in cities
                          where city.ToString() == c.ToString()
                          select city;
            return counter.Count();
        }

       

        public void GetFirstGen()
        {
            int generations = 0;
            while (generations != numGeneration)
            {
                Path chemin = new Path(Gcities.OrderBy(a => Guid.NewGuid()).ToList());
                if (CompPath(chemin, listPathGen) == 0)
                {
                    listPathGen.Add(chemin);
                    generations++;
                }

            }
        }

    

        public List<City> CheckifDouble(List<City> cities)
        {
            List<City> list1 = new List<City>();
            foreach (City v in cities)
            {
                if (CompCities(v, cities) == 2)
                {
                    list1.Add(v);
                }
            }
            return list1;
        }


        public List<City> CleanedPath(List<City> listofdoubles, List<City> part1, List<City> list1)
        {
            if (list1 is null)
            {
                throw new ArgumentNullException(nameof(list1));
            }

            foreach (City v in listofdoubles)
            {
                int doublon = list1.LastIndexOf(v);
                foreach (City pd in part1)
                {
                    if (CompCities(pd, list1) == 0)
                    {
                        list1[doublon] = pd;
                        break;
                    }
                }
            }

            return list1;
        }

        public void CrossOver(int num)
        {
            for (int x = 0; x < num; x++)
            {
                int length = listPathGen[0].ControlCities.Count;
                int part = length / 2;
                List<City> CrossCity = new List<City>();
                List<Path> CrossPath = new List<Path>();
                List<City> Part1 = new List<City>();

                Random rand = new Random();
                int paths = 2;
                int rand1 = rand.Next(0, listPathGen.Count);

                Path firstPath = listPathGen[rand1];
                Path SecondPath;
                CrossPath.Add(firstPath);

                while (paths != 1)
                {
                    int rand2 = rand.Next(0, listPathGen.Count);
                    if (rand2 != rand1)
                    {
                        SecondPath = listPathGen[rand2];
                        CrossPath.Add(SecondPath);
                        paths--;
                    }
                }

                for (int i = 0; i < part; i++)
                {
                    CrossCity.Add(CrossPath[0].ControlCities[i]);
                }

                for (int i = part; i < length; i++)
                {
                    CrossCity.Add(CrossPath[1].ControlCities[i]);
                    Part1.Add(CrossPath[0].ControlCities[i]);
                }

                List<City> CitiesDoubled = CheckifDouble(CrossCity);

                List<City> result = CleanedPath(CitiesDoubled, Part1, CrossCity);

                Path resultChemin = new Path(result);

                if (CompPath(resultChemin, listPathPop) == 0)
                {
                    listPathPop.Add(resultChemin);
                }

            }
        }

        public void Mutation(int num)
        {
            int i = 0;
            while (i < num)
            {
                Random r = new Random();
                int rand = r.Next(0, listPathGen.Count);
                Path path1 = listPathGen[rand];
                List<City> cities = new List<City>(path1.ControlCities);
                int numCities = cities.Count;
                int city1 = r.Next(0, numCities);
                int city2 = r.Next(0, numCities);

                while (city2 == city1)
                {
                    city2 = r.Next(numCities);
                }
                List<City> result = Swap(cities, city1, city2);
                Path path = new Path(result);
                if (CompPath(path, listPathPop) == 0)
                {
                    listPathPop.Add(path);
                    i++;
                }
            }
        }



        public void Elite(int num)
        {

            int eliteNumber = num;
            var elite = from e in listPathGen orderby e.ComputeScore select e;

            for (int i = 0; i < eliteNumber; i++)
            {
                if (CompPath(elite.ElementAt(i), listPathPop) == 0)
                {
                    listPathPop.Add(elite.ElementAt(i));
                }
            }
        }

        

        public List<Path> Shortest()
        {
            List<Path> ShortestPath = new List<Path>();
            var elite = from p in listPathPop orderby p.ComputeScore select p;
            for (int i = 0; i < numGeneration; i++)
            {
                ShortestPath.Add(elite.ElementAt(i));
            }
            return ShortestPath;
        }

        public Generation start(int Crossnum, int Mutationnum, int Elitenum, string name)
        {
            CrossOver(Crossnum);
            Mutation(Mutationnum);
            Elite(Elitenum);
            Generation g = new Generation(numGeneration, Shortest(), name);
            return g;
        }

        

        public List<City> Swap(List<City> cities, int i, int j)
        {
            City tmp = cities[i];
            cities[i] = cities[j];
            cities[j] = tmp;
            return cities;
        }

        public double GetBestScore()
        {
            IEnumerable<Path> listeScores = from c in this.listPathGen orderby c.ComputeScore ascending select c;
            return Math.Round(listeScores.FirstOrDefault().ComputeScore, 2);

        }

        public double getAverageScore
        {
            get
            {
                double result = 0;
                foreach (Path p in this.listPathGen)
                {
                    result += p.ComputeScore;
                }
                return Math.Round(result / this.listPathGen.Count, 2);
            }
        }

    }
}