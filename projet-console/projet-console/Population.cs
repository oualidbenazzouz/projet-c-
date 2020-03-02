using System;
using System.Collections.Generic;
using System.Linq;

namespace Partie_Console
{
    public class Population
    {
        private List<Generation> generations;

        public Population()
        {
            this.generations = new List<Generation>();
        }

        public List<Generation> GetGenerations
        {
            get
            {
                return this.generations;
            }
        }

        public void startAlgorithm(int length, int number, List<City> cities, int nbCross, int nbMutation, int nbElite)
        {
            int count = 1;
            int stop = -1;
            Generation firstPopulation = new Generation(number, cities, "population" + count);
            firstPopulation.start(nbCross, nbMutation, nbElite, "population" + count);
            this.generations.Add(firstPopulation);

            while (stop < length)
            {
                count++;
                this.generations.Add(this.generations.Last().start(nbCross, nbMutation, nbElite, "population" + count));
                if (this.generations.Last().GetGeneration[0].ComputeScore == generations[this.generations.Count - 1].GetGeneration[0].ComputeScore)
                {
                    stop++;
                }
                else
                {
                    stop = 0;
                }
            }

            ResultAffichage();
        }

        public Path BestPath()
        {
            Path path1 = null;
            foreach (Generation g in this.generations)
            {
                foreach (Path p in g.GetGeneration)
                {
                    if (path1 is null)
                    {
                        path1 = p;
                    }
                    else
                    {
                        if (p.ComputeScore < path1.ComputeScore) path1 = p;
                    }
                }
            }
            return path1;
        }

        public void ResultAffichage()
        {
            int i = 1;
            foreach (Generation g in this.generations)
            {
                Console.WriteLine("Generation " + i + ":"+" Best Score: " + g.GetBestScore());
                i++;
            }
            Console.WriteLine("Shortest path is:" + BestPath() + "Score :" + BestPath().ComputeScore.ToString());
        }

        

    }
}