using ProgrammingPracticum.Models;
using ProgrammingPracticum.Models.Contracts;
using System.Collections.Generic;

namespace ProgrammingPracticum.Data
{
    internal interface IDataContext
    {
        IReadOnlyCollection<Galaxy> Galaxies { get; }

        string AddGalaxy(string command);

        string AddStar(string command);

        string AddPlanet(string command);

        string AddMoon(string command);

        IReadOnlyCollection<TChild> GetChildren<TChild>(IReadOnlyCollection<IParent<TChild>> parents)
            where TChild : ICellestialBody;
    }
}
