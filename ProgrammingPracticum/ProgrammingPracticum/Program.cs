using ProgrammingPracticum.Data;
using ProgrammingPracticum.IO;
using System;
using System.Text;
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
            // Set culture/encoding
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            Console.OutputEncoding = Encoding.UTF8;

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