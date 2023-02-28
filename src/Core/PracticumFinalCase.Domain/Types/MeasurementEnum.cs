using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Domain.Types
{
    public enum MeasurementEnum
    {
        [Description(Measurement.Gram)]
        Gram = 1,

        [Description(Measurement.Kilogram)]
        Kilogram = 2,

        [Description(Measurement.Milliliter)]
        Millititer = 3,

        [Description(Measurement.Liter)]
        Liter = 4,

        [Description(Measurement.Unit)]
        Unit = 5,
    }

    public class Measurement
    {
        public static List<string> Measurements = new() { Gram, Kilogram, Milliliter, Liter, Unit };
        public const string Gram = "Gram";
        public const string Kilogram = "Kilogram";
        public const string Milliliter = "Milliliter";
        public const string Liter = "Liter";
        public const string Unit = "Unit";
    }
}
