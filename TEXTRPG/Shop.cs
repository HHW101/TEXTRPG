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
        string[] info;
        //생성자
        public Shop()
        {
            items = new List<Item>();
            eItems = new HashSet<Item>();

        }
        public string eData()
        {
            string data= "";
           
            foreach (Item item in eItems)
            {
                data += item.num;
                data+=",";
            }
            data=data.TrimEnd(',');
            return data;
       
        }
      
        public void setData(string eN,List<string> arr)
        {
            info = eN.Split(',');
            foreach (string item in arr)
            {
                string[] itemInfo = item.Split(',');
                Item it=null;
                if (int.Parse(itemInfo[0]) == 1)
                {
                    it = new Weapon(int.Parse(itemInfo[1]), itemInfo[2], itemInfo[3], int.Parse(itemInfo[4]), int.Parse(itemInfo[5]));
                    setItem(it);
                }
                else if (int.Parse(itemInfo[0]) == 2)
                {
                    it = new Armor(int.Parse(itemInfo[1]), itemInfo[2], itemInfo[3], int.Parse(itemInfo[4]), int.Parse(itemInfo[5]));
                    setItem(it);
                }

                foreach(string i in info)
                {
                    if (int.Parse(itemInfo[1]) == int.Parse(i))
                        eItems.Add(it);
                }

            }
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
            Item temp = IsBuyed(equip.num);
            if (temp!=null)
                eItems.Remove(temp);
            else
                setItem(equip);
            return equip.gold * 85 / 100;
        }
        public Item IsBuyed(int i)
        {
            foreach (Item item in eItems)
            {
                if (item.num==i)
                    return item;
            }
            return null;
        }

    }
}
