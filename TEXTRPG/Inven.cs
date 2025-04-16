using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEXTRPG
{
    class Inven
    {
        Item weapon;
        Item armor;
        public bool hasWeapon(Item equip)
        {
            return (weapon == equip || armor == equip);
        }
        public int getweaponID()
        {
            if (weapon == null)
                return -1;
            return weapon.num;
        }
        public int getArmorID()
        {
            if (armor == null)
                return -1;
            return armor.num;
        }
        public float[] sumAdd()
        {
            //클래스로 구별
            float[] sum = { 0, 0 };
            if (weapon != null)
                sum[0] = weapon.atk;
            if (armor != null)
                sum[1] = armor.def;
            return sum;
        }
        public void Unequip(Item equip)
        {
            if (equip is Weapon)
                weapon = null;
            if (equip is Armor)
                armor = null;
        }
        public void equipS(Item equip)
        {
            if (equip is Weapon)
            {
                if (weapon == equip)
                    weapon = null;
                else
                    weapon = equip;
            }
            if (equip is Armor)
                if (armor == equip)
                    armor = null;
                else
                    armor = equip;
        }
    }
}
