using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace TEXTRPG
{
    class Weapon : Item
    {
        public string name { get; set; }
        public string txt { get; set; }
        public float atk { get; set; }
        public float def { get; set; }
        public float hp { get; set; }
        public int gold { get; set; }

        public Weapon()
        {

        }
      
        public Weapon(String nameG, String txtG,float atkG, int goldG)
        {
            name = nameG;
            atk = atkG;
            txt = txtG;
            gold = goldG;
        }
        public void ShowEquip()
        {
            Console.WriteLine($" {name} |ATK: {atk} | {txt}");
        }
        public string ItemData()
        {
            string data;
            StringBuilder sb = new StringBuilder();
            sb.Append("0,");
            sb.Append(name);
            sb.Append(",");
            sb.Append(txt);
            sb.Append(',');
            sb.Append(def);
            sb.Append(",");
            sb.Append(gold);
            data = sb.ToString();
            return data;
        }
    }
}
