using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void QualityDown()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(3, Items[0].Quality);
        }

        [Test]
        public void AgedBrie()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
            Assert.AreEqual(0, Items[0].SellIn);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
            Assert.AreEqual(-1, Items[0].SellIn);
        }

        [Test]
        public void Max50()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(50, Items[0].Quality);
        }

        [Test]
        public void Sulfuras()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(5, Items[0].Quality);
            Assert.AreEqual(5, Items[0].SellIn);
        }

        [Test]
        public void Backstage()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 5 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(6, Items[0].Quality);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
            Items[0].SellIn = 5;
            Items[0].Quality = 5;
            app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(8, Items[0].Quality);
            Items[0].SellIn = 0;
            Items[0].Quality = 5;
            app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(0, Items[0].Quality);
        }

    }
}
