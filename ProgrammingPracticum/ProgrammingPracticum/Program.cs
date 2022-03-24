using ProgrammingPracticum.Data;
using ProgrammingPracticum.IO;
using System.Threading;

namespace ProgrammingPracticum
{
    public class Program
    {
        public static void Main()
        {
            Setup().Run();
        }

        private static Application Setup()
        {
            // Set invariant culture to handle decimal dot/comma
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

            // Dependencies
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var dataContext = new DataContext();
            var reportBuilder = new ReportBuilder(dataContext);
            
            // Application
            var application = new Application(reader, writer, dataContext, reportBuilder);

            return application;
        }
    }
}