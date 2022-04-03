using ProgrammingPracticum.Constants;
using System;
using System.Linq;
using System.Text;

namespace ProgrammingPracticum.Models
{
    internal class Planet : CellestialBody<Moon>
    {
        public Planet(string name, string type, bool IsHabitable) : base(name)
        {
            this.Type = type;
            this.IsHabitable = IsHabitable;
        }

        public string Type { get; private set; }

        public bool IsHabitable { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Name: {this.Name}");
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Support life: {(this.IsHabitable ? "yes" : "no")}");
            sb.AppendLine($"Moons:");

            sb.AppendLine(this.DisplayChildren('*'));

            return sb.ToString().TrimEnd();
        }

        public override bool IsValid()
        {
            var validPlanetTypes = new string[]
            {
                "terrestrial",
                "giant planet",
                "ice giant",
                "mesoplanet",
                "mini-neptune",
                "planetar",
                "super-earth",
                "super-jupiter",
                "sub-earth",
            };

            return validPlanetTypes.Any(x => x == this.Type);
        }
    }
}
