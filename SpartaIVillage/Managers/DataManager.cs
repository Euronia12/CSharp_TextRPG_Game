using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpartaIVillage.Managers
{
    internal class DataManager
    {
        //유저의 세이브파일
        public PlayerBase saveData;
        public DataManager() 
        {
            PlayerBase saveData = new PlayerBase();
            ReadJson();            
        }

        //./상대경로 이폴더의 제이슨파일이다.
        string path = @"./data.json";

        //파일 저장하기
        public void WriteJson(PlayerBase userdata)
        {
            string strData = JsonConvert.SerializeObject(userdata);
            Console.WriteLine(File.Exists(path));
            File.WriteAllText(path, strData);
            Console.WriteLine("   데이터 저장에 성공하였습니다...");
        }

        //파일 불러오기
        public void ReadJson()
        {
            if (File.Exists(path))
            {
                string strJson = File.ReadAllText(path);
                saveData = JsonConvert.DeserializeObject<PlayerBase>(strJson);
                Console.WriteLine("   불러오기를 성공하였습니다...");
            }
            else 
            {
                Console.WriteLine("파일이 없습니다.");
                
            }
        }

       

    }
}
