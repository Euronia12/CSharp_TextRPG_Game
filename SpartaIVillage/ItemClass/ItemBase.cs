using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpartaIVillage.Define;

namespace SpartaIVillage.ItemClass
{
    //아이템 정보
    internal class ItemBase
    {
        //public bool bIsEquip = false;
        public string strName;
        public EquipmentType myEquipType;
        public Abilty myAbiltyType;
        public string myAbiltyName;
        public int myAbiltyAmount;
        public string strInfo;
        public int nPrice = 0;
        public bool bIsHave = false;
        public string strSign = "[E]";

        public ItemBase(string name, EquipmentType eType, Abilty aType, int nAbility, string info, int gold)
        {
            strName = name;
            myEquipType = eType;
            strInfo = info;
            myAbiltyType = aType;
            if (myAbiltyType == Abilty.e_Attack)
                myAbiltyName = "공격력";
            else if (myAbiltyType == Abilty.e_Defence)
                myAbiltyName = "방어력";
            else
                myAbiltyName = "";
            myAbiltyAmount = nAbility;
            nPrice = gold;
        }
    }
}
