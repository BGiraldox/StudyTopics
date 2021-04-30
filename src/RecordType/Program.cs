using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Linq;

namespace RecordType
{
    public class Program
    {
        public record Persona(int edad, string nombre);

        public record DailyTemperature(double HighTemp, double LowTemp);

        private static void Main(string[] args)
        {
            try
            {
                var persona = new Persona(1, "Pepe");
            }
            catch (Exception ex)
            {
                Console.WriteLine("error keyword");
            }
        }
    }
}