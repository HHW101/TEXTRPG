using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Armor : Item
    {
        public string name { get; set; }
        public string txt { get; set; }
        public float atk { get; set; }
        public float def { get; set; }
        public float hp { get; set; }
        public int gold { get; set; }

        public Armor()
        {


        }
        public Armor(String nameG, String txtG, float defG, int goldG)
        {
            name = nameG;
            def = defG;
            txt = txtG;
            gold = goldG;

        }
      
        public void ShowEquip()
        {
            Console.WriteLine($" {name} |DEF: {def} | {txt}");
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
