using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose
{
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> items = new List<Item> {new Item {Name = "foo", SellIn = 0, Quality = 0}};
            var app = new GildedRose(items);
            app.UpdateQuality();
            Assert.That(items[0].Name, Is.EqualTo("foo"));
        }
    }
}