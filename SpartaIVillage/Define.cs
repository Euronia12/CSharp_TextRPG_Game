using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage
{
    internal class Define
    {
        //enum 타입 정의 클래스
        public enum e_SceneState 
        {
            e_MainScene = 0,
            e_PlayerStatusScene,
            e_InventoryScene,
            e_InventoryManagedScene,
            e_ItemStoreScene,
            e_ItemPurchaseScene,
            e_ItemSaleStore,
            e_BattleScene,
            e_BattleManagedScene,
            e_RestScene
        }

        public enum EquipmentType
        {
            e_Weapon_Main = 0,
            e_Weapon_Sub,
            e_Helmet,
            e_Armor,
            e_Gloves,
            e_Boots,
            e_MaxNumber
        }

        public enum Abilty
        {
            e_Attack = 0,
            e_Defence
        }

        public enum DungeonGrade
        {
            e_Easy = 0,
            e_Normal,
            e_Hard
        }
    }
}
