using ProgrammingPracticum.Models.Contracts;
using System.Collections.Generic;

namespace ProgrammingPracticum.Models
{
    internal class CellestialBody<TChild> : ICellestialBody, IParent<TChild>
        where TChild: ICellestialBody
    {
        private readonly Dictionary<string, TChild> children
            = new Dictionary<string, TChild>();

        public CellestialBody(string name)
        {
            this.Name = name;
        }

        public IReadOnlyCollection<TChild> Children => this.children.Values;

        public string Name { get; private set; }

        public void AddChild(TChild child)
        {
            this.children.Add(child.Name, child);
        }

        public TChild GetChild(string name)
        {
            return this.children.GetValueOrDefault(name);
        }
    }
}
