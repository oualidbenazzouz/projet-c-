using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Partie_Console
{
    public class Path
    {
        private List<City> Cities;

        public Path(List<City> cities) => this.Cities = cities ?? throw new ArgumentNullException(nameof(cities));

        public List<City> ControlCities
        {
            get
            {
                return Cities;
            }
            set
            {
                Cities = value;
            }
        }

        public double ComputeScore
        {
            get
            {
                double score = 0;
                for (int i = 0; i < Cities.Count - 1; i++)
                {
                    City v1 = Cities[i];
                    City v2 = Cities[i + 1];
                    double distance = Math.Sqrt(Math.Pow(v1.X_cord - v2.X_cord, 2) + Math.Pow(v1.Y_cord - v2.Y_cord, 2));
                    score = score + distance;
                }

                return Math.Round(score, 2);
            }

        }

       
        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            for(int i = 0; i< Cities.Count; i++)
            {
                s.Append(Cities[i].CityName + " => ");
            }
            return s.ToString();
        }

    }
}