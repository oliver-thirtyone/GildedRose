using System.Collections.Generic;
using ApprovalTests.Combinations;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace GildedRose
{
    [UseReporter(typeof(DiffReporter))]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            var names = new List<string> {"foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert"};
            CombinationApprovals.VerifyAllCombinations(name => DoStuff(name, 0), names);
        }

        private static string DoStuff(string name, int quality)
        {
            IList<Item> items = new List<Item> {new Item {Name = name, SellIn = 0, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            var result = items[0].ToString();
            return result;
        }
    }
}