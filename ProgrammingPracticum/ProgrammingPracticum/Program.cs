using ProgrammingPracticum.Models;
using System;

namespace ProgrammingPracticum
{
    public class Program
    {
        public static void Main()
        {
            var galaxy = new Galaxy("Milky Way", "elliptical", "13.2B");
            var star = new Star("Sun", 0.99f, 1.98f, 5778, 1.00f);
            var planet = new Planet("Earth", "terrestrial", true);
            var moon = new Moon("Moon");

            galaxy.AddChild(star);
            galaxy.GetChild(star.Name).AddChild(planet);
            galaxy.GetChild(star.Name).GetChild(planet.Name).AddChild(moon);

            Console.WriteLine(galaxy);
        }
    }
}