using ProgrammingPracticum.Data;
using ProgrammingPracticum.IO.Contracts;

using static ProgrammingPracticum.Constants.Commands;

namespace ProgrammingPracticum
{
    internal class Application
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IDataContext dataContext;
        private readonly IReportBuilder reportBuilder;

        public Application(
            IReader reader,
            IWriter writer,
            IDataContext dataContext,
            IReportBuilder reportBuilder)
        {
            this.reader = reader;
            this.writer = writer;
            this.dataContext = dataContext;
            this.reportBuilder = reportBuilder;
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

        public string HandleCommand(string input)
        {
            if (input.StartsWith(ADD_GALAXY))
            {
                return this.dataContext.AddGalaxy(input);
            }
            
            if (input.StartsWith(ADD_STAR))
            {
                return this.dataContext.AddStar(input);
            }
            
            if (input.StartsWith(ADD_PLANET))
            {
                return this.dataContext.AddPlanet(input);
            }
            
            if (input.StartsWith(ADD_MOON))
            {
                return this.dataContext.AddMoon(input);
            }
            
            if (input.StartsWith(LIST))
            {
                return this.reportBuilder.GetListReport(input);
            }
            
            if (input.StartsWith(PRINT))
            {
                return this.reportBuilder.GetGalaxyReport(input);
            }
            
            if (input.StartsWith(STATS))
            {
                return this.reportBuilder.GetStats();
            }

            return null;
        }
    }
}
