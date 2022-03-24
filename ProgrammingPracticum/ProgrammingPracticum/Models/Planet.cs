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

            sb.AppendLine($"o Name: {this.Name}");
            sb.AppendLine($"Type: {this.Type}");
            sb.AppendLine($"Support life: {(this.IsHabitable ? "yes" : "no")}");
            sb.AppendLine("Moons:");

            if (this.Children.Count == 0)
            {
                sb.AppendLine("none");
            }

            foreach (var moon in this.Children)
            {
                sb.AppendLine(moon.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
