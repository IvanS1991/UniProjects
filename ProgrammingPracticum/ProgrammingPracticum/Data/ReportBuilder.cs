using ProgrammingPracticum.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using static ProgrammingPracticum.Constants.Commands;

namespace ProgrammingPracticum.Data
{
    internal class ReportBuilder : IReportBuilder
    {
        private readonly IDataContext dataContext;

        public ReportBuilder(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public string GetStats()
        {
            var sb = new StringBuilder();

            sb.AppendLine("--- Stats ---");
            sb.AppendLine($"Galaxies: {this.dataContext.Galaxies.Count}");
            sb.AppendLine($"Stars: {this.dataContext.Stars.Count}");
            sb.AppendLine($"Planets: {this.dataContext.Planets.Count}");
            sb.AppendLine($"Moons: {this.dataContext.Moons.Count}");
            sb.AppendLine("--- End of stats ---");

            return sb.ToString().Trim();
        }

        public string GetListReport(string command)
        {
            var regex = new Regex($"^{LIST} (\\w+)$");
            var match = regex.Match(command);

            var entities = match.Groups[1].Value;

            var sb = new StringBuilder();

            sb.AppendLine($"--- List of all researched {entities} ---");

            IReadOnlyCollection<ICellestialBody> cellestialBodies = null;

            if (entities == "galaxies")
            {
                cellestialBodies = this.dataContext.Galaxies;
            } else if (entities == "stars")
            {
                cellestialBodies = this.dataContext.Stars;
            } else if (entities == "planets")
            {
                cellestialBodies = this.dataContext.Planets;
            } else if (entities == "moons")
            {
                cellestialBodies = this.dataContext.Moons;
            }

            sb.AppendLine(this.StringifyList(cellestialBodies, x => x.Name));
            sb.AppendLine($"--- End of {entities} list ---");

            return sb.ToString().Trim();
        }

        public string GetGalaxyReport(string command)
        {
            var regex = new Regex($"^{PRINT} \\[([^]]+)\\]$");
            var match = regex.Match(command);

            var galaxyName = match.Groups[1].Value;
            var galaxy = this.dataContext.Galaxies.FirstOrDefault(x => x.Name == galaxyName);

            if (galaxy != null)
            {
                return galaxy.ToString();
            }

            return null;
        }

        private string StringifyList(IReadOnlyCollection<ICellestialBody> cellestialBodies, Func<ICellestialBody, string> mapperFn)
        {
            if (cellestialBodies.Count == 0)
            {
                return "none";
            }

            return string.Join("\n", cellestialBodies.Select(mapperFn));
        }
    }
}
