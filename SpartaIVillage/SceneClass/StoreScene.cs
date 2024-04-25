using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaIVillage.Managers;

namespace SpartaIVillage.SceneClass
{
    //상점으로 들어갈 시 작동
    internal class StoreScene : UIManager
    {
        public StoreScene() 
        {
            
        }

        //구매, 판매, 나가기 구현 및 UI드로우
        public void OpenStore(PlayerBase player)
        {
            int nGetkey1 = 0;

            do
            {
                DrawUI(Define.e_SceneState.e_ItemStoreScene);
                nGetkey1 = GetInputKey();
                switch (nGetkey1)
                {
                    case -1:
                        DrawUI(Define.e_SceneState.e_ItemStoreScene);
                        break;
                    case 0:
                        
                        break;
                    case 1:
                        PurchasedItem();
                        nGetkey1 = -1;
                        break;
                    case 2:
                        SaleItem();
                        nGetkey1 = -1;
                        break;
                    default:
                        FaultInput();
                        nGetkey1 = -1;
                        break;
                }
            } while (nGetkey1 != 0);
        }

        //아이템 구매 화면
        public void PurchasedItem()
        {
            int nGetkey2 = 0;
            do
            {
                DrawUI(Define.e_SceneState.e_ItemPurchaseScene);
                nGetkey2 = GetInputKey();
                if (nGetkey2 > 0 && nGetkey2 <= MainGame.Instance.storage.nItemCount)
                {
                    if (MainGame.Instance.storage.dicItems[nGetkey2 - 1].bIsHave == true)
                    {
                        Console.WriteLine("\t이미 구매한 아이템입니다.");
                        nGetkey2 = -1;
                        Thread.Sleep(1000);
                        continue;
                    }

                    if (MainGame.Instance.player.nGold >= MainGame.Instance.storage.dicItems[nGetkey2 - 1].nPrice)
                    {
                        MainGame.Instance.player.GetItem(nGetkey2 - 1);
                        Console.WriteLine("\t구매를 완료하였습니다.");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("\t골드가 부족합니다.");
                        Thread.Sleep(1000);
                    }
                }
                else if(nGetkey2 != 0)
                {
                    nGetkey2 = -1;
                    FaultInput();
                }
            } while (nGetkey2 != 0);
        }

        //아이템 판매 화면
        public void SaleItem()
        {
            int nGetkey2 = 0;
            PlayerBase player = MainGame.Instance.player;
            DrawUI(Define.e_SceneState.e_ItemSaleStore);
            do
            {
                nGetkey2 = GetInputKey();
                DrawUI(Define.e_SceneState.e_ItemSaleStore);
                if (nGetkey2 > 0 && nGetkey2 <= player.Itemlst.Count)
                {
                    Console.WriteLine("\t{0}을/를 정말로 판매하시겠습니까?", player.Itemlst[nGetkey2 - 1]);
                    Console.Write("\t1. 예 \t 2. 아니요\n\t>> ");
                    string nGetKey3 = Console.ReadLine();
                    if (nGetKey3 == "1")
                    {
                        Console.WriteLine("\t{0}을/를 판매하였습니다.", MainGame.Instance.storage.dicItems[player.Itemlst[nGetkey2 - 1]].strName);
                        Console.WriteLine("\t골드를 {0}만큼 획득하였습니다.",(int)(MainGame.Instance.storage.dicItems[player.Itemlst[nGetkey2 - 1]].nPrice * 0.85));
                        //판매 메소드 호출
                        player.SaleItem(nGetkey2 - 1);
                    }
                    else
                    {
                        Console.WriteLine("\t판매를 취소하였습니다.");
                    }
                    Thread.Sleep(2000);
                    DrawUI(Define.e_SceneState.e_ItemSaleStore);
                }
                else if (nGetkey2 != 0)
                {
                    nGetkey2 = -1;
                    FaultInput();
                }

            } while (nGetkey2 != 0);
        }
    }
    
}
