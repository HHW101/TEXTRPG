using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Bag :PBag
    {
   
        //순서 필요 없으므로로
        //public HashSet<Equip> eItems;
    
        public Bag()
        {
            items = new List<Item>();

            //eItems=new HashSet<Equip>();
        }
        public Item getItem(int i, Inven iv)
        {
            Item item = items[i];
            items.Remove(item);
            if (iv.hasWeapon(item))
                iv.Unequip(item);
            return item;
        }
        public void equ(int i, Inven iv)
        {
            //잘못된 범위 확인인
            if (items.Count <= i || i < 0)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            iv.equipS(items[i]);

        }
      
        public void FindEqi(int w,int m,Inven iv)
        {
            foreach (Item item in items) {
                if (item.num == w){
                    iv.equipS(item);
                }
                if (item.num == m) { 
                    iv.equipS(item);
                }
            }
        }
        public void ShowInven(Inven iv)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                //Console.Write(i+1);
                if (iv.hasWeapon(items[i]))
                    Console.Write("- [E]");
                items[i].ShowEquip();
            }
        }
        //장착 모드에서의 인벤토리 보여주기 
        public void ShowInvenE(Inven iv)
        {
            for (int i = 0; i < items.Count(); i++)
            {
                Console.Write("- ");
                Console.Write(i + 1);
                //장착하고고 있는지 체크하기 
                if (iv.hasWeapon(items[i]))
                    Console.Write(" [E]");
                items[i].ShowEquip();
            }
        }
    }
}
