using CookingShowdownCode.Enum;
using StardewValley.Inventories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingShowdownCode.Helper
{
    public class ConsumeCounter
    {
        private Dictionary<KeyValuePair<String, int>, int> map = new();

        public ConsumeCounter(Inventory items)
        {
            addItems(items);
        }

        public void Count(Inventory items)
        {
            removeItems(items);

        }

        private void addItems(Inventory items)
        {
            foreach (var item in items)
            {
                if (item == null)
                    continue;
                var pair = KeyValuePair.Create(item.ItemId, item.Quality);

                if (map.ContainsKey(pair))
                {
                    map[pair] += item.Stack;
                    continue;
                }
                else
                {
                    map.TryAdd(pair, item.Stack);
                }
            }
        }

        private void removeItems(Inventory items)
        {
            foreach (var item in items)
            {
                if (item == null)
                    continue;
                var pair = KeyValuePair.Create(item.ItemId, item.Quality);

                if (map.ContainsKey(pair))
                {
                    map[pair] -= item.Stack;
                    if (map[pair] <= 0)
                        map.Remove(pair);
                }
            }
        }

        public List<ItemStack> getConsumeItems()
        {
            var list = new List<ItemStack>();
            foreach (var item in map)
            {
                list.Add(new ItemStack(item.Key.Key, item.Key.Value, item.Value));
            }
            return list;
        }
    }

    public class ItemStack
    {
        public String itemId {  get; }
        public QualityEnum quality { get; }
        public int num { get; }

        public ItemStack(String itemId, int quality, int num)
        {
            this.itemId = itemId;
            this.quality = QualityEnumExtensions.from(quality);
            this.num = num;
        }

        public ItemStack(String itemId, QualityEnum quality, int num)
        {
            this.itemId = itemId;
            this.quality = quality;
            this.num = num;
        }
    }
}
