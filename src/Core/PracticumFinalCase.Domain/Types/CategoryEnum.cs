using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumFinalCase.Domain.Types
{
    public enum CategoryEnum
    {
        [Description(Category.StationeryOffice)]
        StationeryOffice = 1,

        [Description(Category.Grocery)]
        Grocery = 2,

        [Description(Category.Electronic)]
        Electronic = 3,

        [Description(Category.Fashion)]
        Fashion = 4,

        [Description(Category.SportOutdoor)]
        SportOutdoor = 5,

    }

    public class Category
    {
        public static List<string> Categories = new() { StationeryOffice, Grocery, Electronic, Fashion, SportOutdoor };
        public const string StationeryOffice = "Ofis-Kırtasiye";
        public const string Grocery = "Süpermarket";
        public const string Electronic = "Elektronik";
        public const string Fashion = "Moda";
        public const string SportOutdoor = "Spor-Outdoor";
    }
}
