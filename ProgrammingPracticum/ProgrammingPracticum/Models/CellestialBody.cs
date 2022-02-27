using System.Collections.Generic;

namespace ProgrammingPracticum.Models
{
    internal class CellestialBody
    {
        private readonly Dictionary<string, CellestialBody> children
            = new Dictionary<string, CellestialBody>();

        public string Name { get; private set; }

        public void AddChild(CellestialBody child)
        {
            this.children.Add(child.Name, child);
        }
    }
}
