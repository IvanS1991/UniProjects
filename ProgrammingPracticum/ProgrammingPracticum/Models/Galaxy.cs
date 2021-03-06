using ProgrammingPracticum.Constants;
using System;
using System.Linq;
using System.Text;

namespace ProgrammingPracticum.Models
{
    internal class Galaxy : CellestialBody<Star>
    {
        public Galaxy(string name, string type, string age)
            : base(name)
        {
            this.Type = type;
            this.Age = age;
        }

        public string Type { get; private set; }

        public string Age { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"--- Data for {this.Name} galaxy ---");
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Age: {this.Age}");
            sb.AppendLine($"Stars:");

            sb.AppendLine(this.DisplayChildren('-'));

            sb.AppendLine($"--- End of data for {this.Name} galaxy ---");

            return sb.ToString().TrimEnd();
        }

        public override bool IsValid()
        {
            var validGalaxyTypes = new string[]
            {
                "elliptical",
                "lenticular",
                "spiral",
                "irregular"
            };

            return validGalaxyTypes.Any(x => x == this.Type);
        }
    }
}
