﻿using System.Collections.Generic;
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
            var qualities = new List<int> {0, -1 , 1, 49, 50, 51};
            CombinationApprovals.VerifyAllCombinations((name, quality) => DoStuff(name, 0, quality), names, qualities);
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