using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp
{
    public class GildedRose
    {
        IList<Item> Items;

        const string AGEDBRIE = "Aged Brie";
        const string BACKSTAGE = "Backstage passes to a TAFKAL80ETC concert";
        const string SULFURAS = "Sulfuras, Hand of Ragnaros";
        public GildedRose(IList<Item> Items)
        {
            CheckRepeatItems(Items);
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            Items.Where(x => x.Name != AGEDBRIE && x.Name != BACKSTAGE && x.Name != SULFURAS && x.Quality > 0).ToList().ForEach(x => x.Quality -= 1 );
            Items.Where(x => (x.Name == AGEDBRIE || x.Name == BACKSTAGE) && x.Quality < 50).ToList().ForEach(x => x.Quality += 1);
            Items.Where(x => x.Name == BACKSTAGE && x.Quality < 50 && x.SellIn < 11).ToList().ForEach(x => x.Quality += 1);
            Items.Where(x => x.Name == BACKSTAGE && x.Quality < 50 && x.SellIn < 6).ToList().ForEach(x => x.Quality += 1);
            Items.Where(x => x.Name != SULFURAS).ToList().ForEach(x => x.SellIn -= 1);
            Items.Where(x => x.SellIn < 0 && x.Name == AGEDBRIE && x.Quality < 50).ToList().ForEach(x => x.Quality += 1);
            Items.Where(x => x.SellIn < 0 && x.Name != AGEDBRIE && x.Name != BACKSTAGE && x.Name != SULFURAS && x.Quality > 0).ToList().ForEach(x => x.Quality -= 1);
            Items.Where(x => x.SellIn < 0 && x.Name == BACKSTAGE).ToList().ForEach(x => x.Quality = 0);
        }

        private void CheckRepeatItems(IList<Item> Items)
        {
            if (Items.Count != Items.Select(i => i.Name.ToUpper()).Distinct().Count())
            {
                throw new Exception("Repeat items");
            }
        }
    }
}
