using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaIVillage.Managers;

namespace SpartaIVillage.SceneClass
{
    internal class StatusScene : UIManager
    {
        public StatusScene() 
        {
            
        }

        //스테이터스 확인 UI 및 키 입력
        public void OpenStatus(PlayerBase player)
        {
            int nGetkey = -1;
            do
            {
                nGetkey = -1;
                DrawUI(Define.e_SceneState.e_PlayerStatusScene);
                nGetkey = GetInputKey();
                if(nGetkey != 0)
                    FaultInput();
            } while (nGetkey != 0);
        }
    }
}
