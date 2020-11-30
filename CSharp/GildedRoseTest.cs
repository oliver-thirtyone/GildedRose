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
            var names = new List<string> {"foo", "Aged Brie"};
            CombinationApprovals.VerifyAllCombinations(DoStuff, names);
        }

        private static string DoStuff(string name)
        {
            IList<Item> items = new List<Item> {new Item {Name = name, SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            var result = items[0].ToString();
            return result;
        }
    }
}