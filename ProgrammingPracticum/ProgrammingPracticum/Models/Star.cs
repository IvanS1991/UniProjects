using ProgrammingPracticum.Constants;

namespace ProgrammingPracticum.Models
{
    internal class Star : CellestialBody
    {
        public StarClass Class { get; }

        public int Temperature { get; private set; }

        public float Mass { get; private set; }

        public float Diameter { get; private set; }

        public float Luminosity { get; private set; }
    }
}
