 using SpartaIVillage.ItemClass;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage
{
    internal class PlayerBase
    {
        //public Dictionary<PlayerJob, string> dicJobName = new Dictionary<PlayerJob, string>();
        //장착한 장비 정보<장비타입, 아이템고유넘버>
        public Dictionary<Define.EquipmentType, int> dicEquiment = new Dictionary<Define.EquipmentType, int>();
        //인벤토리 아이템 순서
        public List<int> Itemlst = new List<int>();
        
        public enum PlayerJob
        {
            e_Warrior = 0,
            e_Archer
        }

        //초기화 여부
        public bool bIsInit = false;
        public int nLv {get; set;}
        public string strName { get; set; }
        public string job { get; set; }
        public int nAttack { get; set; }
        public int nAddAttack { get; set; }
        public int nDefence { get; set; }
        public int nAddDefence { get; set; }
        public int nHealth{ get; set;}
        public int nMaxHp{ get; set;}
        public int nGold { get; set;}

        public PlayerBase()
        {
            Init();          
        }

        private void Init()
        {
            if(bIsInit) { return; }
            nLv = 1;
            strName = "DoDo";
            job = "전사";
            nAttack = 10;
            nDefence = 5;
            nHealth = 100;
            nMaxHp = nHealth;
            nGold = 1500;
            bIsInit = true;
            for (int i = 0; i < (int)Define.EquipmentType.e_MaxNumber; i++)
            {
                dicEquiment[(Define.EquipmentType)i] = -1;
            }
        }

        //레벨업 시 호출
        public void LvUp()
        {
            nLv++;
            nDefence++;
            if ((nLv & 1) == 0)
            {
                nAttack++;
            }
        }

        //장착한 아이템인지 체크
        public bool CheckedEquipItem(ItemBase item, int nNumber)
        {
            if (dicEquiment[item.myEquipType] == Itemlst[nNumber])
            {
                return true;
            }
            return false;
        }

        //추후 사용목적으로 작성 체력 증감 시 호출
        public void ChangedHealth(int nAddHealth)
        {
            if (nAddHealth < 0)
            {
                Console.WriteLine("체력이 {0}만큼 감소하였습니다", Math.Abs(nAddHealth));
            }
            else if (nAddHealth > 0)
            {
                Console.WriteLine("체력을 {0}만큼 회복하였습니다", nAddHealth);
            }
            else
            {
                Console.WriteLine("플레이어는 면역입니다.");
            }

            nHealth += nAddHealth;

            if (nHealth > 0)
            {
                Console.WriteLine($"현재 플레이어의 체력은 {nHealth}입니다.");
            }
            else
            {
                Console.WriteLine("플레이어가 사망하였습니다.");
                //게임엔딩으로
            }
        }

        //아이템 장착 및 해제
        public void SetItem(int listNum)
        {
            ItemBase item = MainGame.Instance.storage.dicItems[Itemlst[listNum]];

            if (CheckedEquipItem(item, listNum))
            {
                RemoveEquipItem(item);
                dicEquiment[item.myEquipType] = -1;
            }
            else
            {
                if (dicEquiment[item.myEquipType] != -1)
                    RemoveEquipItem(MainGame.Instance.storage.dicItems[dicEquiment[item.myEquipType]]);
                EquipItem(item);
                dicEquiment[item.myEquipType] = Itemlst[listNum];
            }
            Console.WriteLine("\t[아이템]{0}을/를 장착{1}하였습니다.", item.strName.Replace("  ", ""), CheckedEquipItem(item, listNum) ? " " : " 해제");
            Thread.Sleep(1000);
        }

        //아이템 구매
        public void GetItem(int itemNum)
        {   
            Itemlst.Add(itemNum);
            MainGame.Instance.storage.dicItems[itemNum].bIsHave = true;
            nGold -= MainGame.Instance.storage.dicItems[itemNum].nPrice;
        }

        //아이템 판매
        public void SaleItem(int itemNum)
        {
            MainGame.Instance.storage.dicItems[itemNum].bIsHave = false;
            RemoveEquipItem(MainGame.Instance.storage.dicItems[Itemlst[itemNum]]);
            dicEquiment[MainGame.Instance.storage.dicItems[Itemlst[itemNum]].myEquipType] = -1;
            nGold += (int)(MainGame.Instance.storage.dicItems[Itemlst[itemNum]].nPrice * 0.85);
            Itemlst.RemoveAt(itemNum);
        }

        //장비한 아이템 수치 적용
        public void EquipItem(ItemBase item)
        {
            if (item.myAbiltyType == Define.Abilty.e_Defence)
            {
                nDefence += item.myAbiltyAmount;
                nAddDefence += item.myAbiltyAmount;
            }
            else if (item.myAbiltyType == Define.Abilty.e_Attack)
            {
                nAttack += item.myAbiltyAmount;
                nAddAttack += item.myAbiltyAmount;
            }
        }

        //장비한 아이템 수치 적용 해제
        public void RemoveEquipItem(ItemBase item)
        {
            if (item.myAbiltyType == Define.Abilty.e_Defence)
            {
                nDefence -= item.myAbiltyAmount;
                nAddDefence -= item.myAbiltyAmount;
            }
            else if (item.myAbiltyType == Define.Abilty.e_Attack)
            {
                nAttack -= item.myAbiltyAmount;
                nAddAttack -= item.myAbiltyAmount;
            }
            
        }
    }
}
