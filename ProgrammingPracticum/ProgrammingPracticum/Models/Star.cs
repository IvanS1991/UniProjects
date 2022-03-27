using ProgrammingPracticum.Constants;
using System.Text;

namespace ProgrammingPracticum.Models
{
    internal class Star : CellestialBody<Planet>
    {
        public Star(string name,  float mass, float diameter, int temperature, float luminosity)
            : base(name)
        {
            this.Temperature = temperature;
            this.Mass = mass;
            this.Diameter = diameter;
            this.Luminosity = luminosity;
        }

        public StarClass? Class => DetermineStarClass();

        public int Temperature { get; private set; }

        public float Mass { get; private set; }

        public float Diameter { get; private set; }

        public float Radius => this.Diameter / 2;

        public float Luminosity { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Class: {this.Class} ({this.Mass:f2}, {this.Radius:f2}, {this.Temperature}, {this.Luminosity:f2})");
            sb.AppendLine($"Planets:");

            sb.AppendLine(this.DisplayChildren('o'));

            return sb.ToString().TrimEnd();
        }

        private StarClass? DetermineStarClass()
        {
            if (this.Temperature >= 30000 && this.Luminosity >= 30000 && this.Mass >= 16 && this.Radius >= 6.6)
            {
                return StarClass.O;
            }

            if (this.Temperature > 10000 && this.Luminosity > 25 && this.Mass > 2.1 && this.Radius > 1.8)
            {
                return StarClass.B;
            }

            if (this.Temperature > 7500 && this.Luminosity > 5 && this.Mass > 1.4 && this.Radius > 1.4)
            {
                return StarClass.A;
            }

            if (this.Temperature > 6000 && this.Luminosity > 1.5 && this.Mass > 1.04 && this.Radius > 1.15)
            {
                return StarClass.F;
            }

            if (this.Temperature > 5200 && this.Luminosity > 0.6 && this.Mass > 0.8 && this.Radius > 0.96)
            {
                return StarClass.G;
            }

            if (this.Temperature > 3700 && this.Luminosity > 0.08 && this.Mass > 0.45 && this.Radius > 0.7)
            {
                return StarClass.K;
            }

            if (this.Temperature >= 2400 && this.Luminosity <= 0.08 && this.Mass >= 0.08 && this.Radius <= 0.7)
            {
                return StarClass.M;
            }

            return null;
        }
    }
}
