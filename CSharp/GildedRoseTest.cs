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
            var names = new List<string> {"foo", "Aged Brie", "Backstage passes to a TAFKAL80ETC concert", "Sulfuras, Hand of Ragnaros"};
            var sellIns = new List<int> {-1, 0, 1};
            var qualities = new List<int> {-1, 0, 1};
            CombinationApprovals.VerifyAllCombinations(DoStuff, names, sellIns, qualities);
        }

        private static string DoStuff(string name, int sellIn, int quality)
        {
            IList<Item> items = new List<Item> {new Item {Name = name, SellIn = sellIn, Quality = quality}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            var result = items[0].ToString();
            return result;
        }
    }
}