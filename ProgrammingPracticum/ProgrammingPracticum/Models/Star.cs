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

        public StarClass Class
        {
            get
            {
                return StarClass.G;
            }
        }

        public int Temperature { get; private set; }

        public float Mass { get; private set; }

        public float Diameter { get; private set; }

        public float Radius => this.Diameter / 2;

        public float Luminosity { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"- Name: {this.Name}");
            sb.AppendLine($"Class: {this.Class} ({this.Mass}, {this.Radius}, {this.Temperature}, {this.Luminosity})");
            sb.AppendLine("Planets:");

            foreach (var planet in this.Children)
            {
                sb.AppendLine(planet.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
