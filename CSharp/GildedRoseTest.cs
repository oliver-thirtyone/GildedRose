using System.Collections.Generic;
using ApprovalTests;
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
            var result = DoStuff();
            Approvals.Verify(result);
        }

        private static string DoStuff()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            var result = items[0].ToString();
            return result;
        }
    }
}