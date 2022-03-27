using ProgrammingPracticum.Models;
using System.Collections.Generic;

namespace ProgrammingPracticum.Data
{
    internal interface IDataContext
    {
        IReadOnlyCollection<Galaxy> Galaxies { get; }
        IReadOnlyCollection<Star> Stars { get; }
        IReadOnlyCollection<Planet> Planets { get; }
        IReadOnlyCollection<Moon> Moons { get; }

        string AddGalaxy(string command);

        string AddStar(string command);

        string AddPlanet(string command);

        string AddMoon(string command);
    }
}
