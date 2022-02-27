using System.Collections.Generic;

namespace ProgrammingPracticum.Models.Contracts
{
    internal interface IParent<TChild>
    {
        IReadOnlyCollection<TChild> Children { get; }

        void AddChild(TChild child);

        TChild GetChild(string name);
    }
}
