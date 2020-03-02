using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partie_Console
{
   
    public class Algo
    {

        private int mutation;
        private int crossover;
        private int popLength;
        private int paths;
        private int counter;

        public Algo(int length, int nbPath, int crossOver, int mutation, int elit)
        {
            this.mutation = mutation;
            this.paths = nbPath;
            this.popLength = length;
            this.crossover = crossOver;
            this.elite = elit;
            this.counter = 1;
           
        }

        public Algo()
        {
            this.counter = 1;
            
        }


        public int Mutation
        {
            get { return this.mutation; }
            set
            {
                if (this.mutation != value)
                {
                    this.mutation = value;
                }
            }
        }

        

        public int Crossover
        {
            get { return this.crossover; }
            set
            {
                if (this.crossover != value)
                {
                    this.crossover = value;
                }
            }
        }

        private int elite;

        public int Elite
        {
            get { return this.elite; }
            set
            {
                if (this.elite != value)
                {
                    this.elite = value;
                }
            }
        }

        

  
        public int populationLength
        {
            get { return this.popLength; }
            set
            {
                if (this.popLength != value)
                {
                    this.popLength = value;
                }
            }
        }

        

    
        public int nbrPath
        {
            get { return this.paths; }
            set
            {
                if (this.paths != value)
                {
                    this.paths = value;
                }
            }
        }

        

   
        public int citiesCount
        {
            get { return this.counter; }
            set
            {
                if (this.counter != value)
                {
                    this.counter = value;
                }
            }
        }

    }
}
