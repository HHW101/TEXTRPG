using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Shop :PBag
    {
       
        public HashSet<Item> eItems;
        //생성자
        public Shop()
        {
            items = new List<Item>();
            eItems = new HashSet<Item>();

        }
        
        public void ShowInven()
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Console.Write("- ");
                if (eItems.Contains(items[i]))
                    Console.Write("Sold Out| ");
                else
                    Console.Write($"{items[i].gold}| ");
                items[i].ShowEquip();

            }
        }
        public void ShowEInven()
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Console.Write("- ");
                Console.Write(i + 1);
                if (eItems.Contains(items[i]))
                    Console.Write("Sold Out| ");
                else
                    Console.Write($"{items[i].gold}| ");
                //가지고 있는지 체크하기 
                items[i].ShowEquip();

            }
        }
   
    

        public Item Sell(int i, int goldG)
        {
            if (i < 0 || i >= items.Count())
            {
                Console.WriteLine("Invalid input");
                return null;
            }
            if (eItems.Contains(items[i]))
            {
                Console.WriteLine("Already purchased");
                return null;
            }
            if (goldG - items[i].gold < 0)
            {
                Console.WriteLine("Not enough money");
                return null;
            }
            eItems.Add(items[i]);
            return items[i];
        }
  
        public int buy(Item equip)
        {
            if (equip == null)
                return 0;
            if (eItems.Contains(equip))
                eItems.Remove(equip);
            else
                setItem(equip);
            return equip.gold * 85 / 100;
        }

    }
}
