using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Player
    {
        //스탯 저장장
        public string name;
        public float atk, def, hp, addAtk, addDef;
        public Job job;
        public int lvl, gold;
        //인벤토리 구현
        public Bag bag;
        public Inven iv;
        int wn=-1,an=-1;
        //생성자
        public Player()
        {
          
            bag = new Bag();
            iv = new Inven();
        }
        public void SetStat(string getName,Job _job)
        {
            name = getName;
            lvl = 1;
            atk = 10; def = 5; hp = 100; gold = 1500;
            addAtk = 0; addDef = 0;
            job = _job;
        }
       
        public void setPItems(List<string> itms)
        {
            bag.setData(itms);
            bag.FindEqi(wn, an, iv);
        }
        public void levelup()
        {
            lvl++;
            atk += 0.5f;
            def += 1;

        }
  
        public void Demaged(float x)
        {
            hp -= x;
            if (hp <= 0)
                GameManager.isGameOver = true;
        }
        public string playerdata()
        {
            string data;
            StringBuilder sb = new StringBuilder();
            sb.Append(lvl);
            sb.Append(",");
            sb.Append(name);
            sb.Append(",");
            sb.Append((int)job);
            sb.Append(",");
            sb.Append(hp);
            sb.Append(",");
            sb.Append(atk);
            sb.Append(",");
            sb.Append(def);
            sb.Append(",");
            sb.Append(gold);
            sb.Append(",");
            sb.Append(iv.getweaponID());
            sb.Append(",");
            sb.Append(iv.getArmorID());
            data = sb.ToString();
             
            return data;
        }
        public void LoadPlayer(string data)
        {
            string[] datas= data.Split(new char[] { ',' });
            if (datas.Length <7)
            {
                Console.WriteLine("FAIL LOAD");
                return;
            }
            lvl = int.Parse(datas[0]);
            name = datas[1];
            job = (Job)int.Parse(datas[2]);
            hp = float.Parse(datas[3]);
            atk = float.Parse(datas[4]);
            def = float.Parse(datas[5]);
            gold = int.Parse(datas[6]);
            wn = int.Parse(datas[7]);
            an = int.Parse(datas[8]);

        }

        //스테이터스 보여주기
        public void ShowStatus()
        {
            float[] sum = iv.sumAdd();
            addAtk=sum[0];
            addDef =sum[1];
            Console.WriteLine($"lv. {lvl:D2}");
            Console.WriteLine($"{name} ({job.ToString()})");
            Console.WriteLine($"HP: {hp:F2}");
            Console.WriteLine($"ATK: {atk:F2} (+{addAtk:F2})");
            Console.WriteLine($"DEF: {def:F2} (+{addDef:F2})");
            Console.WriteLine($"GOLD: {gold}G");
        }
        //가방을 통해 인벤토리 
        public void ShowInven()
        {
            bag.ShowInven(iv);
        }
        //장착모드시시
        public void EquipMode()
        {
            bag.ShowInvenE(iv);
        }
        public void EquipItem(int i)
        {
            bag.equ(i - 1, iv);
            float[] sum = iv.sumAdd();
            addAtk = sum[0];
            addDef = sum[1];
        }
        //구매 기능...
        public bool buy(Item item)
        {

            if (item == null)
                return false;
            bag.setItem(item);
            gold -= item.gold;
            return true;

        }
        public List<string> bagData()
        {
            return bag.getData();
        }
        public Item sell(int n)
        {
            if (n >= bag.items.Count() || n < 0)
                return null;
            return bag.getItem(n, iv);
        }

    }
}
