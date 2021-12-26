using System;
using System.Collections.Generic;
using System.Linq;

namespace ScrapingApartments.Common
{
    public static class ListExtension
    {
        public static IEnumerable<Uri> Randomize(this List<Uri> source)
        {
            Random rnd = new Random();
            return source.OrderBy((item) => rnd.Next());
        }
    }
}
