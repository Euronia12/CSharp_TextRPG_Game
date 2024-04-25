using SpartaIVillage.ItemClass;
using SpartaIVillage.SceneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage.Managers
{
    // 모든 화면에 그려질 대부분의 UI를 그리기 위한 매니저
    public enum InputKey
    {
        e_Exit = 0
    }

    internal class UIManager
    {
        PlayerBase myPlayer;
        public int GetInputKey()
        {
            int nKey = -1;
            Console.WriteLine("\t0. 나가기 ");
            Console.Write("\n\t원하시는 행동을 입력해주세요.\n\t>> ");

            string? strInputKey = Console.ReadLine();
            bool bIsSuccess = int.TryParse(strInputKey, out nKey);
            if (!bIsSuccess)
            {
                FaultInput();
            }
            return nKey;
        }

        public void FaultInput()
        {
            Console.WriteLine("\n\t잘못 입력하셨습니다.");
            Thread.Sleep(1000);
        }

        public void DrawUI(Define.e_SceneState scene)
        {
            myPlayer = MainGame.Instance.player;
            Console.Clear();
            switch (scene)
            {
                case Define.e_SceneState.e_MainScene:
                    DrawMain();
                    break;
                case Define.e_SceneState.e_PlayerStatusScene:
                    DrawStatus();
                    break;
                case Define.e_SceneState.e_InventoryScene:
                    DrawInventory();
                    break;
                case Define.e_SceneState.e_InventoryManagedScene:
                    DrawManagedInventory();
                    break;
                case Define.e_SceneState.e_ItemStoreScene:
                    DrawItemStore();
                    break;
                case Define.e_SceneState.e_ItemPurchaseScene:
                    DrawItemPurchasedStore();
                    break;
                case Define.e_SceneState.e_ItemSaleStore:
                    DrawItemSaleStore();
                    break;
                case Define.e_SceneState.e_BattleScene:
                    DrawBattle();
                    break;
                case Define.e_SceneState.e_BattleManagedScene:
                    DrawBattleResult();
                    break;
                case Define.e_SceneState.e_RestScene:
                    DrawInn();
                    break;
                default:
                    DrawMain();
                    break;
            }
        }


        private void DrawMain()
        {
            Console.WriteLine("-----------------------------------------------------------------\r\n\r\n __      ___      _                _____     _                 _ \r\n \\ \\    / (_)    | |              |_   _|   | |               | |\r\n  \\ \\  / / _  ___| |_ ___  _   _    | |  ___| | __ _ _ __   __| |\r\n   \\ \\/ / | |/ __| __/ _ \\| | | |   | | / __| |/ _` | '_ \\ / _` |\r\n    \\  /  | | (__| || (_) | |_| |  _| |_\\__ \\ | (_| | | | | (_| |\r\n     \\/   |_|\\___|\\__\\___/ \\__, | |_____|___/_|\\__,_|_| |_|\\__,_|\r\n                            __/ |                                \r\n                           |___/                                 \r\n\n-----------------------------------------------------------------\r\n");
            Console.WriteLine("\n\n  빅토리 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("  이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("  1. 캐릭터 정보 확인");
            Console.WriteLine("  2. 인벤토리 확인");
            Console.WriteLine("  3. 상점 입장하기");
            Console.WriteLine("  4. 던전 입장하기");
            Console.WriteLine("  5. 여관 입장하기");
            Console.WriteLine("  6. 게임 저장하기");
            Console.WriteLine("  7. 게임 불러오기");
            Console.WriteLine("  0. 게임 종료하기");
            Console.Write("\n  원하시는 행동을 입력해주세요.\n  >> ");
        }

        private void DrawStatus()
        {
            Console.Clear();
            Console.WriteLine("\r\n\n\n\t .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------. \r\n\t| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |\r\n\t| |    _______   | || |  _________   | || |      __      | || |  _________   | || | _____  _____ | || |    _______   | |\r\n\t| |   /  ___  |  | || | |  _   _  |  | || |     /  \\     | || | |  _   _  |  | || ||_   _||_   _|| || |   /  ___  |  | |\r\n\t| |  |  (__ \\_|  | || | |_/ | | \\_|  | || |    / /\\ \\    | || | |_/ | | \\_|  | || |  | |    | |  | || |  |  (__ \\_|  | |\r\n\t| |   '.___`-.   | || |     | |      | || |   / ____ \\   | || |     | |      | || |  | '    ' |  | || |   '.___`-.   | |\r\n\t| |  |`\\____) |  | || |    _| |_     | || | _/ /    \\ \\_ | || |    _| |_     | || |   \\ `--' /   | || |  |`\\____) |  | |\r\n\t| |  |_______.'  | || |   |_____|    | || ||____|  |____|| || |   |_____|    | || |    `.__.'    | || |  |_______.'  | |\r\n\t| |              | || |              | || |              | || |              | || |              | || |              | |\r\n\t| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |\r\n\t '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' \r\n");
            Console.WriteLine("\n\n\t상태보기\n\t캐릭터의 정보가 표시됩니다.");
            Console.WriteLine($"\n\tLv. {myPlayer.nLv.ToString("D2")}");
            Console.Write($"\t{myPlayer.strName} ");
            Console.WriteLine($" ( {myPlayer.job} )");
            Console.WriteLine("\t공격력 : {0} ( + {1})", myPlayer.nAttack, myPlayer.nAddAttack);
            Console.WriteLine("\t방어력 : {0} ( + {1})", myPlayer.nDefence, myPlayer.nAddDefence);
            Console.WriteLine("\t체  력 : {0} / {1}", myPlayer.nHealth, myPlayer.nMaxHp);
            Console.WriteLine($"\t보유 골드 : {myPlayer.nGold} G");
            Console.WriteLine($"\n\n");
        }

        private void DrawInventory()
        {

            Console.WriteLine("\r\n\t                                                ___                                      \r\n\t .-.                                            (   )                                     \r\n\t( __)  ___ .-.    ___  ___    .--.    ___ .-.    | |_       .--.    ___ .-.     ___  ___  \r\n\t(''\") (   )   \\  (   )(   )  /    \\  (   )   \\  (   __)    /    \\  (   )   \\   (   )(   ) \r\n\t | |   |  .-. .   | |  | |  |  .-. ;  |  .-. .   | |      |  .-. ;  | ' .-. ;   | |  | |  \r\n\t | |   | |  | |   | |  | |  |  | | |  | |  | |   | | ___  | |  | |  |  / (___)  | |  | |  \r\n\t | |   | |  | |   | |  | |  |  |/  |  | |  | |   | |(   ) | |  | |  | |         | '  | |  \r\n\t | |   | |  | |   | |  | |  |  ' _.'  | |  | |   | | | |  | |  | |  | |         '  `-' |  \r\n\t | |   | |  | |   ' '  ; '  |  .'.-.  | |  | |   | ' | |  | '  | |  | |          `.__. |  \r\n\t | |   | |  | |    \\ `' /   '  `-' /  | |  | |   ' `-' ;  '  `-' /  | |          ___ | |  \r\n\t(___) (___)(___)    '_.'     `.__.'  (___)(___)   `.__.    `.__.'  (___)        (   )' |  \r\n\t                                                                                 ; `-' '  \r\n\t                                                                                  .__.'   \r\n\t");
            Console.WriteLine("\n\t인벤토리\n\t보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\t[아이템 목록]");
            for (int i = 0; i < myPlayer.Itemlst.Count; i++)
            {
                ItemBase item = MainGame.Instance.storage.dicItems[myPlayer.Itemlst[i]];
                Console.WriteLine("\t{0} {1}\t| {2} + {3} |  {4}", "-", myPlayer.CheckedEquipItem(item, i) ? item.strSign + item.strName : item.strName, item.myAbiltyName, item.myAbiltyAmount, item.strInfo);
            }

            Console.WriteLine("\n\n\t1. 장착 관리");
        }

        private void DrawManagedInventory()
        {
            Console.WriteLine("\r\n\t                                                ___                                      \r\n\t .-.                                            (   )                                     \r\n\t( __)  ___ .-.    ___  ___    .--.    ___ .-.    | |_       .--.    ___ .-.     ___  ___  \r\n\t(''\") (   )   \\  (   )(   )  /    \\  (   )   \\  (   __)    /    \\  (   )   \\   (   )(   ) \r\n\t | |   |  .-. .   | |  | |  |  .-. ;  |  .-. .   | |      |  .-. ;  | ' .-. ;   | |  | |  \r\n\t | |   | |  | |   | |  | |  |  | | |  | |  | |   | | ___  | |  | |  |  / (___)  | |  | |  \r\n\t | |   | |  | |   | |  | |  |  |/  |  | |  | |   | |(   ) | |  | |  | |         | '  | |  \r\n\t | |   | |  | |   | |  | |  |  ' _.'  | |  | |   | | | |  | |  | |  | |         '  `-' |  \r\n\t | |   | |  | |   ' '  ; '  |  .'.-.  | |  | |   | ' | |  | '  | |  | |          `.__. |  \r\n\t | |   | |  | |    \\ `' /   '  `-' /  | |  | |   ' `-' ;  '  `-' /  | |          ___ | |  \r\n\t(___) (___)(___)    '_.'     `.__.'  (___)(___)   `.__.    `.__.'  (___)        (   )' |  \r\n\t                                                                                 ; `-' '  \r\n\t                                                                                  .__.'   \r\n\t");
            Console.WriteLine("\n\t인벤토리 - 장착 관리\n\t보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine("\n\t[아이템 목록]");
            for (int i = 0; i < myPlayer.Itemlst.Count; i++)
            {
                ItemBase item = MainGame.Instance.storage.dicItems[myPlayer.Itemlst[i]];
                Console.WriteLine("\t{0} {1}\t| {2} + {3} |  {4}", (i + 1).ToString("D2"), myPlayer.CheckedEquipItem(item, i) ? item.strSign + item.strName : item.strName, item.myAbiltyName, item.myAbiltyAmount, item.strInfo);
            }
        }

        private void DrawItemStore()
        {
            Console.WriteLine("\r\n\t  ___  ____  __ _  ____  ____   __   __      ____  ____  __  ____  ____ \r\n\t / __)(  __)(  ( \\(  __)(  _ \\ / _\\ (  )    / ___)(_  _)/  \\(  _ \\(  __)\r\n\t( (_ \\ ) _) /    / ) _)  )   //    \\/ (_/\\  \\___ \\  )( (  O ))   / ) _) \r\n\t \\___/(____)\\_)__)(____)(__\\_)\\_/\\_/\\____/  (____/ (__) \\__/(__\\_)(____)\r\n");
            Console.WriteLine("\n\t잡화점\n\t게임에 필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine($"\t[보유 골드]\t{myPlayer.nGold} G");
            Console.WriteLine("\n\t[아이템 목록]");
            for (int i = 0; i < MainGame.Instance.storage.nItemCount; i++)
            {
                ItemBase item = MainGame.Instance.storage.dicItems[i];
                Console.WriteLine("\t- {0}      | {1} + {2} |  {3}  | {4}", item.strName, item.myAbiltyName, item.myAbiltyAmount, item.strInfo, item.bIsHave ? "구매완료" : item.nPrice + " G");
            }
            Console.WriteLine("\n\n\t1. 아이템 구매");
            Console.WriteLine("\t2. 아이템 판매");
        }

        private void DrawItemPurchasedStore()
        {
            Console.WriteLine("\r\n\t  ___  ____  __ _  ____  ____   __   __      ____  ____  __  ____  ____ \r\n\t / __)(  __)(  ( \\(  __)(  _ \\ / _\\ (  )    / ___)(_  _)/  \\(  _ \\(  __)\r\n\t( (_ \\ ) _) /    / ) _)  )   //    \\/ (_/\\  \\___ \\  )( (  O ))   / ) _) \r\n\t \\___/(____)\\_)__)(____)(__\\_)\\_/\\_/\\____/  (____/ (__) \\__/(__\\_)(____)\r\n");
            Console.WriteLine("\n\t잡화점 - 아이템 구매\n\t게임에 필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine($"\t[보유 골드]\t{myPlayer.nGold} G");
            Console.WriteLine("\n\t[아이템 목록]");
            for (int i = 0; i < MainGame.Instance.storage.nItemCount; i++)
            {
                ItemBase item = MainGame.Instance.storage.dicItems[i];
                Console.WriteLine("\t{0}. {1}      | {2} + {3} |  {4}  | {5}", (i + 1).ToString("D2"), item.strName, item.myAbiltyName, item.myAbiltyAmount, item.strInfo, item.bIsHave ? "구매완료" : item.nPrice + " G");
            }
        }

        private void DrawItemSaleStore()
        {
            Console.WriteLine("\r\n\t  ___  ____  __ _  ____  ____   __   __      ____  ____  __  ____  ____ \r\n\t / __)(  __)(  ( \\(  __)(  _ \\ / _\\ (  )    / ___)(_  _)/  \\(  _ \\(  __)\r\n\t( (_ \\ ) _) /    / ) _)  )   //    \\/ (_/\\  \\___ \\  )( (  O ))   / ) _) \r\n\t \\___/(____)\\_)__)(____)(__\\_)\\_/\\_/\\____/  (____/ (__) \\__/(__\\_)(____)\r\n");
            Console.WriteLine("\n\t잡화점 - 아이템 판매\n\t게임에 필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine($"\t[보유 골드]\t{myPlayer.nGold} G");
            Console.WriteLine("\n\t[아이템 목록]");
            for (int i = 0; i < myPlayer.Itemlst.Count; i++)
            {
                ItemBase item = MainGame.Instance.storage.dicItems[myPlayer.Itemlst[i]];
                Console.WriteLine("\t{0} {1}\t| {2} + {3} |  {4}  | {5} G", (i + 1).ToString("D2"), myPlayer.CheckedEquipItem(item, i) ? item.strSign + item.strName : item.strName, item.myAbiltyName, item.myAbiltyAmount, item.strInfo, (int)(item.nPrice * 0.85));
            }
        }

        private void DrawBattle()
        {
            BattleScene bs = MainGame.Instance.battle;
            Console.WriteLine("\n\n\t던전입장\n\t이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            for (int i = 0; i < bs.dungeons.Count; i++)
            {
                Console.WriteLine("\t{0}. {1}  던전  | 방어력 {2} 이상 권장", i + 1, bs.dungeons[i].strGrade, bs.dungeons[i].nNeedDef.ToString("D2"));
            }

        }

        private void DrawBattleResult()
        {
            BattleScene bs = MainGame.Instance.battle;
            if (bs.bIsClear)
            {
                Console.WriteLine("\n\n\t던전 클리어!");
                Console.WriteLine("\t축하합니다!!");
                Console.WriteLine("\t{0}던전을 클리어 하셨습니다.", bs.nowDungeon.strGrade);
                Console.WriteLine("\n\t[ 탐험 결과 ]");
                Console.WriteLine("\t체력 : {0} -> {1}", bs.nPastHp, myPlayer.nHealth);
                Console.WriteLine("\t보유 골드 : {0} -> {1}", bs.nPastGold, myPlayer.nGold);
            }
            else
            {
                Console.WriteLine("\n\n\t던전 공략 실패!");
                Console.WriteLine("\n\n\n\t[ 탐험 결과 ]");
                Console.WriteLine("\t체력 : {0} -> {1}", bs.nPastHp, myPlayer.nHealth);
                Console.WriteLine("\t보유 골드 : {0} -> {1}\n", bs.nPastGold, myPlayer.nGold);
            }
        }

        private void DrawInn()
        {
            Console.WriteLine("\n\n\t빅토리 여관에 방문을 환영합니다.\n\t이곳에서는 숙박을 통해 체력을 회복할 수 있습니다.");
            Console.WriteLine($"\t[보유 골드]\t{myPlayer.nGold} G");
            Console.WriteLine("\n\t[아이템 목록]");
            Console.WriteLine($"\n\t1. 휴식하기 (- {MainGame.Instance.rest.nFee} G)");
        }

    }
}
