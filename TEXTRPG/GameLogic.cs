using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TEXTRPG
{
    public enum Job
    {
        warrior,
        magician,
        archer
    }
    public enum EquipType
    {
        weapon,
        armor

    }
    internal class GameLogic
    {
        static List<string> shopitems =
        new List<string> { "1,Iron Sword,sword,8,800", "1,fire Sword,powerful sword,8,800" };
        static List<string> pItems =
        new List<string> { "2,Iron armor,armor,8,1000", "1,wood Sword,week sword,12,400" };

        public static bool isGameEnd = false;
        public static bool isGameOver = false;
        Player player;
        Shop shop;



        Dungeon d1 = new Dungeon("Easy Dungeon", 5, 1000);
        Dungeon d2 = new Dungeon("Normal Dungeon", 11, 1700);
        Dungeon d3 = new Dungeon("Hard Dungeon", 17, 2500);
        //게임 종료
        public void gameEnd()
        {
            Console.WriteLine("GAME OVER");
            player.ShowStatus();
            Console.WriteLine("PRESS ANY KEY TO EXIT");
            Console.ReadLine();
        }
        //시작
        public void init()
        {
            Data.Instance().initData();
            Console.WriteLine("TEXT RPG");
            shop = new Shop();
            player = new Player();
            while (true)
            {
                Console.WriteLine("0. NEW GAME 1. LOAD");
                int num = int.Parse(Console.ReadLine());
                if (num == 0)
                {
                    NewGame();
                    break;
                }
                else if (num == 1) {
                    LoadGame();
                    break;
                }
                Console.WriteLine("Invalid input");
            }
           

        }
        //새로 시작
        public void NewGame()
        {
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();


            int a = -1;
            while (true)
            {
                Console.WriteLine("\nSelect your job");
                for (int i = 0; i < Job.GetNames(typeof(Job)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {((Job)i).ToString()}");
                }

                try
                {
                    a = int.Parse(Console.ReadLine()) - 1;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input");
                }
                if (a >= 0 && a < 3)
                {

                    break;
                }
            }
            player.SetStat(name, (Job)a);
          
            player.setPItems(pItems);



           
            shop.setData(shopitems);
            Data.Instance().SaveData(player.playerdata(), player.bagData(), shopitems);


        }
        //로드
        public void LoadGame()
        {

        }
        //스텟 모드
        public void showStat()
        {
            int temp = -1;
            while (temp != 0)
            {
                player.ShowStatus();
                Console.WriteLine("0. Back");
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
            }
        }
        //회복 모드
        public void heal()
        {
            int temp = -1;
            while (temp != 0)
            {
                Console.WriteLine($"Recovery 100 - 500g (Gold: {player.gold})");
                Console.WriteLine("1. Rest");
                Console.WriteLine("0. Back");
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                if (player.gold < 500)
                    Console.WriteLine("Not enough money");

                else if (temp == 1 && player.hp <= 100)
                {
                    player.hp = 100;
                    player.gold -= 500;
                    Console.WriteLine("Recovered");
                }

            }
        }
        //기본 화면
        public void village()
        {
            Console.WriteLine("\nVILLAGE");
            Console.WriteLine("What Will you do next?\n");
            Console.WriteLine("1. Show status 2. Inventory 3. Shop 4.Dungeon 5. Rest 0. Exit");

        }

        //쇼핑 모드
        public void Shopping()
        {
            int temp = -1;
            while (temp != 0)
            {
                Console.WriteLine("Item List");
                shop.ShowInven();
                Console.WriteLine("1.Buy 2. Sell 0. Back");
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                if (temp == 1)
                {
                    while (temp != 0)
                    {
                        shop.ShowEInven();
                        Console.WriteLine("0. Back");
                        try
                        {
                            temp = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        player.buy(shop.Sell(temp - 1, player.gold));

                    }
                }
                if (temp == 2)
                {
                    while (temp != 0)
                    {
                        player.EquipMode();
                        Console.WriteLine("0. Back");
                        try
                        {
                            temp = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        if (temp != 0)
                            player.gold += shop.buy(player.sell(temp - 1));

                    }
                }
            }
        }
        //인벤 모드
        public void invenMode()
        {
            int temp = -1;
            while (temp != 0)
            {
                Console.WriteLine("Item List");
                player.ShowInven();
                Console.WriteLine("1.Equipment 0. Back");
                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                if (temp == 1)
                {
                    while (temp != 0)
                    {
                        player.EquipMode();
                        Console.WriteLine("0. Back");
                        try
                        {
                            temp = int.Parse(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input");
                        }
                        player.EquipItem(temp);
                    }
                }
            }
        }
        //던전 모드
        public void DungeonMode()
        {
            int temp = -1;
            while (temp != 0)
            {
                Console.WriteLine($"Dungeon");
                Console.Write("1. ");
                d1.showInfo();
                Console.Write("2. ");
                d2.showInfo();
                Console.Write("3. ");
                d3.showInfo();
                Console.WriteLine("0. Back");

                try
                {
                    temp = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input");
                }
                switch (temp)
                {
                    case 1:
                        d1.Enter(player);
                        break;
                    case 2:
                        d2.Enter(player);
                        break;
                    case 3:
                        d3.Enter(player);
                        break;
                }
                while (temp != 0)
                {
                    Console.WriteLine("0. Back");
                    try
                    {

                        temp = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input");
                    }
                }
            }
        }



    }
}
