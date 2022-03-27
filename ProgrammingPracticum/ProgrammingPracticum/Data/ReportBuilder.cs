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

            if (entities == "galaxies")
            {
                var galaxiesString = string.Join("\n", this.dataContext.Galaxies.Select(x => x.Name));
                sb.AppendLine(galaxiesString);
            }

            if (entities == "stars")
            {
                var starsString = string.Join("\n", this.dataContext.Stars.Select(x => x.Name));
                sb.AppendLine(starsString);
            }

            if (entities == "planets")
            {
                var planetsString = string.Join("\n", this.dataContext.Planets.Select(x => x.Name));
                sb.AppendLine(planetsString);
            }

            if (entities == "moons")
            {
                var moonsString = string.Join("\n", this.dataContext.Moons.Select(x => x.Name));
                sb.AppendLine(moonsString);
            }

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
    }
}
