namespace ProgrammingPracticum.Models
{
    internal class Planet : CellestialBody
    {
        public string Type { get; private set; }

        public bool IsHabitable { get; private set; }
    }
}
