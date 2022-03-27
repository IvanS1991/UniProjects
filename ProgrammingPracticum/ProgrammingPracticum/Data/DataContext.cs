using ProgrammingPracticum.Models;
using ProgrammingPracticum.Models.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

using static ProgrammingPracticum.Constants.Commands;

namespace ProgrammingPracticum.Data
{
    internal class DataContext : IDataContext
    {
        private readonly Dictionary<string, Galaxy> galaxies = new Dictionary<string, Galaxy>();

        public string AddGalaxy(string command)
        {
            var regex = new Regex($"^{ADD_GALAXY} \\[([^]]+)\\] (\\w+) (.+)$");
            var match = regex.Match(command);

            var name = match.Groups[1].Value;
            var type = match.Groups[2].Value;
            var age = match.Groups[3].Value;

            var galaxy = new Galaxy(name, type, age);

            this.galaxies.Add(name, galaxy);

            return null;
        }

        public IReadOnlyCollection<Galaxy> Galaxies => this.galaxies.Values;

        public IReadOnlyCollection<Star> Stars => this.GetChildren(this.Galaxies);

        public IReadOnlyCollection<Planet> Planets => this.GetChildren(this.Stars);

        public IReadOnlyCollection<Moon> Moons => this.GetChildren(this.Planets);

        public string AddStar(string command)
        {
            var regex = new Regex($"^{ADD_STAR} \\[([^]]+)\\] \\[([^]]+)\\] ([0-9.]+) ([0-9.]+) ([0-9]+) ([0-9.]+)$");
            var match = regex.Match(command);

            var galaxyName = match.Groups[1].Value;
            var starName = match.Groups[2].Value;
            var mass = float.Parse(match.Groups[3].Value);
            var diameter = float.Parse(match.Groups[4].Value);
            var temperature = int.Parse(match.Groups[5].Value);
            var luminosity = float.Parse(match.Groups[6].Value);

            if (this.galaxies.TryGetValue(galaxyName, out Galaxy galaxy))
            {
                var star = new Star(starName, mass, diameter, temperature, luminosity);

                galaxy.AddChild(star);
            }

            return null;
        }

        public string AddPlanet(string command)
        {
            var regex = new Regex($"^{ADD_PLANET} \\[([^]]+)\\] \\[([^]]+)\\] (\\w+) (\\w+)$");
            var match = regex.Match(command);

            var starName = match.Groups[1].Value;
            var planetName = match.Groups[2].Value;
            var planetType = match.Groups[3].Value;
            var supportLife = match.Groups[4].Value;

            var star = this.Stars.FirstOrDefault(x => x.Name == starName);

            if (star != null)
            {
                var planet = new Planet(planetName, planetType, supportLife == "yes");

                star.AddChild(planet);
            }

            return null;
        }

        public string AddMoon(string command)
        {
            var regex = new Regex($"^{ADD_MOON} \\[([^]]+)\\] \\[([^]]+)\\]$");
            var match = regex.Match(command);

            var planetName = match.Groups[1].Value;
            var moonName = match.Groups[2].Value;
            var supportLife = match.Groups[4].Value;

            var planet = this.Planets.FirstOrDefault(x => x.Name == planetName);

            if (planet != null)
            {
                var moon = new Moon(moonName);

                planet.AddChild(moon);
            }

            return null;
        }

        private IReadOnlyCollection<TChild> GetChildren<TChild>(IReadOnlyCollection<IParent<TChild>> parents)
            where TChild : ICellestialBody
        {
            return parents.Aggregate(new List<TChild>(), (acc, parent) =>
            {
                acc.AddRange(parent.Children);
                return acc;
            });
        }
    }
}
