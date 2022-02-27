namespace ProgrammingPracticum.Models
{
    internal class Moon : CellestialBody<Moon>
    {
        public Moon(string name)
            : base(name)
        { }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
