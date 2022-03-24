namespace ProgrammingPracticum.Data
{
    internal interface IReportBuilder
    {
        string GetStats();

        string GetListReport(string command);

        string GetGalaxyReport(string command);
    }
}
