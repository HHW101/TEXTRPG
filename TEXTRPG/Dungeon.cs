using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Dungeon
    {
        int level;
        string name;
        float requiredDef;
        int rewardG;
        string txt;
        public Dungeon(String nam, float req, int rwG)
        {
            name = nam;
            requiredDef = req;
            rewardG = rwG;

        }
        public void Enter(Player player)
        {
            float dmg = ClearD(player.def + player.addDef);
            if (dmg < 0)
            {
                Console.WriteLine("FAIL");
                player.Demaged((-dmg) / 2);
                return;
            }
            int gold = clearG(player.atk + player.addAtk);
            Console.WriteLine($"CLEAR {name}");
            Console.WriteLine($"Result");
            Console.WriteLine($"HP {player.hp}->{player.hp - dmg}");
            Console.WriteLine($"Gold {player.gold}->{player.gold + gold}");

            player.Demaged(dmg);
            player.gold += gold;

        }
        public void showInfo()
        {
            Console.WriteLine($"{name}  | DEF Required {requiredDef}");
        }
        public float ClearD(float def)
        {
            float dmg = 0;
            Random rand = new Random();
            dmg = rand.Next((int)(20 - (def - requiredDef)), (int)(36 - (def - requiredDef)));

            if (dmg <= 0)
                return 0;
            if (requiredDef > def)
            {
                int x = rand.Next(0, 10);
                if (x < 4)
                    return -dmg;

            }
            return dmg;
        }
        public int clearG(float atk)
        {
            float gold = rewardG;
            Random rand = new Random();
            gold += (rand.Next(1, 3) * atk / 100 * gold);
            return (int)gold;
        }
    }

}
