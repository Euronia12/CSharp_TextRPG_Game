using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaIVillage.Managers;

namespace SpartaIVillage.SceneClass
{
    //인벤토리 구현
    internal class InventoryScene : UIManager
    {
        public InventoryScene() 
        {
            
        }

        public void OpenInventory(PlayerBase player)
        {
            // -1로 항상 입력받을 키값 초기화
            int nGetkey1 = -1;
            do
            {
                DrawUI(Define.e_SceneState.e_InventoryScene);
                nGetkey1 = GetInputKey();
                switch (nGetkey1)
                {
                    case -1:
                        DrawUI(Define.e_SceneState.e_InventoryScene);
                        break;
                    case 0:
                        break;
                    case 1:
                        OpenManagedInventory();
                        break;
                    default:
                        FaultInput();
                        nGetkey1 = -1;
                        break;
                }

            } while (nGetkey1 != 0);
        }

        public void OpenManagedInventory()
        {
            int nGetkey2 = -1;
            do
            {
                //화면 그리기
                DrawUI(Define.e_SceneState.e_InventoryManagedScene);
                nGetkey2 = GetInputKey();
                //입력받은 값이 0보다 크고 리스트의 길이보다 작거나 같을 때
                if (nGetkey2 > 0 && nGetkey2 <= MainGame.Instance.player.Itemlst.Count)
                {
                    MainGame.Instance.player.SetItem(nGetkey2- 1);
                }
                else if (nGetkey2 != 0)
                {
                    //잘못 입력 UI ㅍ기
                    FaultInput();
                    nGetkey2 = -1;
                }
            } while (nGetkey2 != 0);
        }
    }
}
