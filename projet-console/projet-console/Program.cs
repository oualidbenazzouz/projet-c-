using System;
using System.Collections.Generic;
using System.Threading;

namespace Partie_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            City city1 = new City("Nice", 86.20F, 40.30F);
            City city2 = new City("Montpellier", 192.99F, 420.14F);
            City city3 = new City("Paris", 63.625F, 152.220F);
            City city4 = new City("Toulouse", 170.10F, 96.01F);
            City city5 = new City("Bordeaux", 1.11F, 10.18F);
            City city6 = new City("Monaco", 172.33F, 64.958F);

            List<City> cities = new List<City>();
            cities.Add(city1);
            cities.Add(city2);
            cities.Add(city3);
            cities.Add(city4);
            cities.Add(city5);
            cities.Add(city6);

            Algo Algorithm = new Algo(10, 20, 30, 30, 2);
            Population p = new Population();
            Generation g = new Generation(20, cities);

            p.startAlgorithm(Algorithm.populationLength, Algorithm.nbrPath, cities, Algorithm.Crossover, Algorithm.Mutation, Algorithm.Elite);
        }
    }
}
