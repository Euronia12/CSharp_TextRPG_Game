using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaIVillage
{
    //던전 정보
    internal class Dungeon
    {
        public int nClearCount = 0;
        public int nNeedDef;
        public int nMinDecHp = 20;
        public int nMaxDecHp = 35;
        public int nRewardGold;
        public string strGrade;


        public Dungeon(int needDef, int reward, string grade) 
        {
            
            nNeedDef = needDef;
            nRewardGold = reward;
            strGrade = grade;
        }    
    }

}
