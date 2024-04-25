using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpartaIVillage.Managers;

namespace SpartaIVillage.SceneClass
{
    //전투 및 던전 관련 클래스
    internal class BattleScene : UIManager
    {
        public List<Dungeon> dungeons = new List<Dungeon>();
        Dungeon easyLv;
        Dungeon normalLv;
        Dungeon hardLv;
        public Dungeon nowDungeon;
        //던전 클리어 여부
        public bool bIsClear = false;
        //던전 상호작용 전 데이터 저장 후 변동사항 표기 시 활용
        public int nPastHp = 0;
        public int nPastGold = 0;

        public BattleScene() 
        {
            dungeons.Add(easyLv = new Dungeon(5, 1000, "쉬운  "));
            dungeons.Add(normalLv = new Dungeon(11, 1700, "일반  "));
            dungeons.Add(hardLv = new Dungeon(17, 2500, "어려운"));
        }

        public void OpenBattle(PlayerBase player)
        {
            int nGetkey = -1;
            do
            {
                bIsClear = false;
                DrawUI(Define.e_SceneState.e_BattleScene);
                nGetkey = GetInputKey();
                if (nGetkey > 0 && nGetkey <= dungeons.Count)
                {
                    nowDungeon = dungeons[nGetkey - 1];
                    GoInDungeon(player, dungeons[nGetkey - 1]);
                }
                else if (nGetkey != 0) 
                {
                    FaultInput();
                    nGetkey = -1;
                }
            } while (nGetkey != 0);
        }

        //랜덤 값 구해주는 메소드
        public int RandomValue(int nMin, int nMax)
        {
            Random random = new Random();
            return random.Next(nMin, nMax);
        }
        
        //방어력 비교 후 차를 리턴하는 메소드
        public int CompareDef(int nP_Defence, int nD_Defence)
        {
            return nP_Defence - nD_Defence;
        }

        //던전 클리어시 호출되는 메소드
        public void DungeonClear(PlayerBase player, Dungeon dungeon, int nGap)
        {
            bIsClear = true;
            //플레이어가 입을 데미지 설정
            int nDamage = RandomValue(dungeon.nMinDecHp - nGap, dungeon.nMaxDecHp - nGap);
            if (nDamage > 0)
            {
                player.nHealth -= nDamage;
            }
            else if(nDamage > player.nMaxHp)
            {
                player.nHealth = 0;
            }
            //획득할 골드 설정
            player.nGold += dungeon.nRewardGold + (int)(dungeon.nRewardGold * RandomValue(player.nAttack, player.nAttack * 2) / 100);
            dungeon.nClearCount++;
            //플레이어 레벨업
            player.LvUp();
        }

        //던전 입장 시 결과 판정을 위한 메소드
        public void JudgmentResult(PlayerBase player, Dungeon dungeon)
        {
            nPastGold = player.nGold;
            nPastHp = player.nHealth;
            int nGap = CompareDef(player.nDefence, dungeon.nNeedDef);
            
            if (nGap >= 0)
            {
                DungeonClear(player, dungeon, nGap);
            }
            else if(nGap < 0) 
            {
                int nChance = RandomValue(0, 10);
                if (nChance < 4)
                {
                    player.nHealth -= player.nMaxHp / 2;
                }
                else
                {
                    DungeonClear(player, dungeon, nGap);
                }
            }

        }

        //던전 결과를 보여 주기 위한 화면 드로우
        public void GoInDungeon(PlayerBase player, Dungeon dungeon)
        {
            JudgmentResult(player, dungeon);
            int nGetkey2 = -1;
            do
            {
                nGetkey2 = -1;
                DrawUI(Define.e_SceneState.e_BattleManagedScene);
                nGetkey2 = GetInputKey();
                if (nGetkey2 != 0)
                {
                    FaultInput();
                }
            } while (nGetkey2 != 0);

        }
    }
}
