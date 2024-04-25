using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpartaIVillage.Managers;

namespace SpartaIVillage.SceneClass
{
    //여관 휴식 코너
    internal class RestScene : UIManager
    {
        public int nFee = 500;
        public RestScene() 
        {
            
        }

        public void OpenInn(PlayerBase player)
        {
            int nGetkey = -1;
            do
            {
                DrawUI(Define.e_SceneState.e_RestScene);
                nGetkey = GetInputKey();
                switch(nGetkey) 
                { 
                    case 0:

                        break;
                    case 1:
                        Sleep();
                        break;
                    default:
                        FaultInput();
                        nGetkey = -1;
                        break;
                }
            } while (nGetkey != 0);
            
        }

        //휴식시 호출되는 메소드
        public void Sleep()
        {
            //요금보다 많은 돈이 있다면
            if (MainGame.Instance.player.nGold >= nFee)
            {
                //체력 회복
                MainGame.Instance.player.nHealth = MainGame.Instance.player.nMaxHp;
                MainGame.Instance.player.nGold -= nFee;
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("\t캐릭터가 휴식을 취하는 중입니다.");
                    Thread.Sleep(1000);
                }
                Console.WriteLine("\t캐릭터의 체력을 전부 회복하였습니다.");
                Console.WriteLine($"\t(현재 체력 : {MainGame.Instance.player.nHealth} )");
                Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine("\t소지금이 부족합니다.");
                Thread.Sleep(1000);
            }
        }
    }
}
