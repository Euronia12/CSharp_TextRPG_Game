using SpartaIVillage.ItemClass;
using SpartaIVillage.SceneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SpartaIVillage.Managers;

namespace SpartaIVillage
{
    internal class MainGame : UIManager
    {
        public static MainGame Instance { get; private set; }
        public DataManager dataManager { get; private set; }
        public PlayerBase player;
        //씬 목록
        public StatusScene status;
        public InventoryScene inventory;
        public StoreScene store;
        public BattleScene battle;
        public RestScene rest;
        public ItemStorage storage;

        public string? strInput = null;
        public MainGame()
        {
            if(Instance == null)
                Instance = this;
            Console.SetWindowSize(150, 50);
            player = new PlayerBase();
            dataManager = new DataManager();
            status = new StatusScene();
            inventory = new InventoryScene();
            store = new StoreScene();
            battle = new BattleScene();
            rest = new RestScene(); 
            storage = new ItemStorage();
        }
          
        //메인 게임 로직
        public void GameStart()
        {
            while (true) 
            { 
                //화면 UI 그리기
                DrawUI(Define.e_SceneState.e_MainScene);
                ChangeScene();
                //0일때 게임 종료
                if (strInput == "0") break;

            }
        }

        //입력에 따른 화면전환
        public void ChangeScene()
        {
            strInput = Console.ReadLine();
            switch (strInput)
            {
                case "0":
                    Console.WriteLine("   --- 게임을 종료합니다. ---   ");
                    Console.WriteLine("지금까지 빅토리아일랜드였습니다.");
                    Thread.Sleep(1000);
                    break;
                case "1":
                    status.OpenStatus(player);
                    break;
                case "2":
                    inventory.OpenInventory(player);
                    break;
                case "3":
                    store.OpenStore(player);
                    break;
                case "4":
                    battle.OpenBattle(player);
                    break;
                case "5":
                    rest.OpenInn(player);
                    break;
                case "6":
                    dataManager.WriteJson(player);
                    Thread.Sleep(1000);
                    break;
                case "7":
                        dataManager.ReadJson();
                        player = dataManager.saveData;
                        Thread.Sleep(1000);
                    break;
                    
                default:
                    Input.InputError();
                    break;
            }
        }
    }
}
