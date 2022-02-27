using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProgrammingPracticum.IO.Contracts;
using ProgrammingPracticum.Models;
using ProgrammingPracticum.Models.Contracts;

using static ProgrammingPracticum.Constants.Commands;

namespace ProgrammingPracticum
{
    internal class Application
    {
        private readonly Dictionary<string, Galaxy> galaxies = new Dictionary<string, Galaxy>();
        private readonly IReader reader;
        private readonly IWriter writer;

        public Application(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine();

                if (input == EXIT)
                {
                    return;
                }

                var result = this.HandleCommand(input);

                if (result != null)
                {
                    this.writer.WriteLine(result);
                }
            }
        }

        private IReadOnlyCollection<TChild> GetChildren<TChild>(IReadOnlyCollection<IParent<TChild>> parents)
        {
            return parents.Aggregate(new List<TChild>(), (acc, parent) =>
            {
                acc.AddRange(parent.Children);
                return acc;
            });
        }

        private string GetStats()
        {
            var galaxies = this.galaxies.Values;
            var stars = this.GetChildren(galaxies);
            var planets = this.GetChildren(stars);
            var moons = this.GetChildren(planets);

            var sb = new StringBuilder();

            sb.AppendLine("--- Stats ---");
            sb.AppendLine($"Galaxies: {galaxies.Count}");
            sb.AppendLine($"Stars: {stars.Count}");
            sb.AppendLine($"Planets: {planets.Count}");
            sb.AppendLine($"Moons: {moons.Count}");

            return sb.ToString().Trim();
        }

        private string AddGalaxy(string command)
        {
            return null;
        }

        private string AddStar(string command)
        {
            return null;
        }

        private string AddPlanet(string command)
        {
            return null;
        }

        private string AddMoon(string command)
        {
            return null;
        }

        private string GetListReport(string command)
        {
            return "";
        }

        private string GetGalaxyReport(string command)
        {
            return "";
        }

        public string HandleCommand(string input)
        {
            if (input.StartsWith(ADD_GALAXY))
            {
                return this.AddGalaxy(input);
            }
            
            if (input.StartsWith(ADD_STAR))
            {
                return this.AddStar(input);
            }
            
            if (input.StartsWith(ADD_PLANET))
            {
                return this.AddPlanet(input);
            }
            
            if (input.StartsWith(ADD_MOON))
            {
                return this.AddMoon(input);
            }
            
            if (input.StartsWith(LIST))
            {
                return this.GetListReport(input);
            }
            
            if (input.StartsWith(PRINT))
            {
                return this.GetGalaxyReport(input);
            }
            
            if (input.StartsWith(STATS))
            {
                return this.GetStats();
            }

            return null;
        }
    }
}
