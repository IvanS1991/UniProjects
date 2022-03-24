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
            var galaxies = this.dataContext.Galaxies;
            var stars = this.dataContext.GetChildren(galaxies);
            var planets = this.dataContext.GetChildren(stars);
            var moons = this.dataContext.GetChildren(planets);

            var sb = new StringBuilder();

            sb.AppendLine("--- Stats ---");
            sb.AppendLine($"Galaxies: {galaxies.Count}");
            sb.AppendLine($"Stars: {stars.Count}");
            sb.AppendLine($"Planets: {planets.Count}");
            sb.AppendLine($"Moons: {moons.Count}");
            sb.AppendLine("--- End of stats ---");

            return sb.ToString().Trim();
        }

        public string GetListReport(string command)
        {
            var regex = new Regex($"^{LIST} (\\w+)$");
            var match = regex.Match(command);

            var entities = match.Groups[1].Value;

            var galaxies = this.dataContext.Galaxies;
            var stars = this.dataContext.GetChildren(galaxies);
            var planets = this.dataContext.GetChildren(stars);
            var moons = this.dataContext.GetChildren(planets);

            var sb = new StringBuilder();

            sb.AppendLine($"--- List of all researched {entities} ---");

            if (entities == "galaxies")
            {
                var galaxiesString = string.Join("\n", galaxies.Select(x => x.Name));
                sb.AppendLine(galaxiesString);
            }

            if (entities == "stars")
            {
                var starsString = string.Join("\n", stars.Select(x => x.Name));
                sb.AppendLine(starsString);
            }

            if (entities == "planets")
            {
                var planetsString = string.Join("\n", planets.Select(x => x.Name));
                sb.AppendLine(planetsString);
            }

            if (entities == "moons")
            {
                var moonsString = string.Join("\n", moons.Select(x => x.Name));
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
