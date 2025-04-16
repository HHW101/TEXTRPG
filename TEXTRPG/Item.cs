using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    //물품 클래스

    interface Item
    {
        public string name { get; set; }
        public string txt { get; set; }
        public float atk { get; set; }
        public float def { get; set; }
        public float hp { get; set; }
        public int gold { get; set; }
       // public bool shop { get; set; }
        public int num { get; set; }
        public string ItemData();

        public void ShowEquip();
     


    }
}
