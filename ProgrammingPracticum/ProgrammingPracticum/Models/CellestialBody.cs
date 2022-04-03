using ProgrammingPracticum.Models.Contracts;
using System.Collections.Generic;
using System.Text;

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
            if (!child.IsValid())
            {
                return;
            }

            this.children.Add(child.Name, child);
        }

        public TChild GetChild(string name)
        {
            return this.children.GetValueOrDefault(name);
        }

        public string DisplayChildren(char bulletStyle)
        {
            var sb = new StringBuilder();


            if (this.Children.Count == 0)
            {
                sb.AppendLine("none");
                bulletStyle = ' ';
            }
            else
            {
                foreach (var child in this.Children)
                {
                    var childDataLines = child.ToString().Split("\n");
                    var childDataString = string.Join($"\n{new string(' ', 5)}", childDataLines);

                    sb.AppendLine(childDataString);
                }
            }

            return $"  {bulletStyle}  {sb.ToString().TrimEnd()}";
        }

        public virtual bool IsValid()
        {
            return true;
        }
    }
}
