using System;
using System.Text;
namespace Partie_Console
{

    public class City
    {
        private string Name;
        private float xCord;
        private float yCord;

        public City()
        {

        }
        public City(string Name, float x, float y)
        {
            this.Name = Name;
            this.xCord = x;
            this.yCord = y;
        }

        public string CityName
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }

        public float X_cord
        {
            get
            {
                return xCord;
            }
            set
            {
                xCord = value;
            }
        }

 
        public float Y_cord
        {
            get
            {
                return yCord;
            }
            set
            {
                yCord = value;
            }
        }

        public override String ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("the name of city :"+ CityName + "x Cordination :" + X_cord + " y Cordination :" + Y_cord);
            return s.ToString();
        }

    }
}