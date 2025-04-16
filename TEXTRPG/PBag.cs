using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TEXTRPG
{
    internal class PBag
    {
        public List<Item> items;
        public void setData(List<string> arr)
        {
            foreach (string item in arr)
            {
                string[] itemInfo = item.Split(',');
                if (int.Parse(itemInfo[0]) == 1)
                {
                    
                    setItem(new Weapon(int.Parse(itemInfo[1]), itemInfo[2], itemInfo[3], int.Parse(itemInfo[4]), int.Parse(itemInfo[5])));
                }
                if (int.Parse(itemInfo[0]) == 2)
                {
                    setItem(new Armor(int.Parse(itemInfo[1]),itemInfo[2], itemInfo[3], int.Parse(itemInfo[4]), int.Parse(itemInfo[5])));
                }

            }
        }
        public List<string> getData()
        {
            List<string> data = new List<string>();
            foreach (Item item in items)
            {
                data.Add(item.ItemData());
            }
            return data;
        }
        public void setItem(Item equip)
        {
            items.Add(equip);
        }
        public Item getItem(int i)
        {
            Item item = items[i];
            items.Remove(item);
            return item;
        }
        
    }
}
