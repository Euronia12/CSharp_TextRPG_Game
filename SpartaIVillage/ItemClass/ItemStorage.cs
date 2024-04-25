using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage.ItemClass
{
    //아이템 정보 저장 클래스
    internal class ItemStorage 
    {
        public Dictionary<int, ItemBase> dicItems = new Dictionary<int, ItemBase>();
        public int nItemCount = 0;
        public ItemStorage()
        {
            Init();
        }

        public void Init()
        {
            dicItems[nItemCount++] = new ItemBase("돼지치기 막대    ", Define.EquipmentType.e_Weapon_Main, Define.Abilty.e_Attack,  5,  "초보자용 시작 무기. 돼지치기가 사용하는 막대이다.", 1000);
            dicItems[nItemCount++] = new ItemBase("붉은 채찍        ", Define.EquipmentType.e_Weapon_Main, Define.Abilty.e_Attack,  15, "누구나 사용할 수 있는 무기, 생각보다 아플지도...?", 5000);
            dicItems[nItemCount++] = new ItemBase("글라디우스       ", Define.EquipmentType.e_Weapon_Main, Define.Abilty.e_Attack,  25, "어딘가의 영웅이쓰던 무기의 레플리카, 원본에 비해 떨어지지만 강하다.", 10000);
            dicItems[nItemCount++] = new ItemBase("사각 나무 방패   ", Define.EquipmentType.e_Weapon_Sub , Define.Abilty.e_Defence, 5,  "초보자용 방패, 유명항구에서 대량판매하고 있다.", 2500);
            dicItems[nItemCount++] = new ItemBase("냄비 뚜껑        ", Define.EquipmentType.e_Weapon_Sub , Define.Abilty.e_Defence, 10, "양은 냄비의 뚜껑 모양의 방패이다. 냄뚜로 유명하다.", 5000);
            dicItems[nItemCount++] = new ItemBase("노가다 목장갑    ", Define.EquipmentType.e_Gloves     , Define.Abilty.e_Defence, 2,  "누구나 쉽게 착용할 수 있는 장갑", 1000);
            dicItems[nItemCount++] = new ItemBase("기합의 머리띠    ", Define.EquipmentType.e_Helmet     , Define.Abilty.e_Defence, 5,  "일인 전승으로 대대로 물려받은 머리띠 ",3000);
            dicItems[nItemCount++] = new ItemBase("머리위의 떡 반개 ", Define.EquipmentType.e_Helmet     , Define.Abilty.e_Defence, 10,"보름달이 뜬 날 토끼가 정성스레 빚은 떡이다." ,6000);
            dicItems[nItemCount++] = new ItemBase("레드빈의 모자    ", Define.EquipmentType.e_Helmet     , Define.Abilty.e_Defence, 15, "아이들이 좋아하는 캐릭터 모양의 모자이다.", 15000);
            dicItems[nItemCount++] = new ItemBase("파란색 가운      ", Define.EquipmentType.e_Armor      , Define.Abilty.e_Defence, 10, "여관 숙소에서 제공하는 한벌옷", 10000);
            dicItems[nItemCount++] = new ItemBase("가고일의 돌갑옷  ", Define.EquipmentType.e_Armor      , Define.Abilty.e_Defence, 20, "단단한 암석으로 만들어진 갑옷. 다구리에 강하다.", 20000);
            dicItems[nItemCount++] = new ItemBase("워모그의 갑옷    ", Define.EquipmentType.e_Armor      , Define.Abilty.e_Defence, 30, "입기만해도 든든해지는 갑옷", 30000);
            dicItems[nItemCount++] = new ItemBase("아이젠           ", Define.EquipmentType.e_Boots      , Define.Abilty.e_Defence, 3,  "눈길에도 안심!", 2000);
            dicItems[nItemCount++] = new ItemBase("판금 장화        ", Define.EquipmentType.e_Boots      , Define.Abilty.e_Defence, 7,  "매우 무거운 신발이다." ,8000);
            dicItems[nItemCount++] = new ItemBase("헤르메스의 발걸음", Define.EquipmentType.e_Boots      , Define.Abilty.e_Defence, 10, "이단 점프가 가능할수도??", 12000);
        }
    }
}
