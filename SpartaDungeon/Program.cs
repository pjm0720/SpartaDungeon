using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    public class GameManager
    {
        private Player player;
        private List<Item> inventory;

        private List<Item> storeInventory;


        public GameManager()
        {
            InitializeGame();
        }

        private void InitializeGame()  // 게임을 실행시킬 함수
        {
            player = new Player("모험가", "전사", 1, 10, 5, 100, 1500);

            inventory = new List<Item>();  //인벤토리에 아이템 리스트로 생성
            
            inventory.Add(new Item("천 갑옷", "갑옷인데 안전은 보장못합니다.", ItemType.ARMOR, 0, 2, 0, 450));
            inventory.Add(new Item("뾰족한 창", "찌르기에 특화된 무기.", ItemType.WEAPON, 3, 0, 0, 800));
            inventory.Add(new Item("낡은 검", "곧 부서질 것 같다.", ItemType.WEAPON, 2, 0, 0, 450));
          
            storeInventory = new List<Item>();

            storeInventory.Add(new Item("철 갑옷", "튼튼한 갑옷.", ItemType.ARMOR, 0, 5, 0, 1200));
            storeInventory.Add(new Item("철 투구", "머리를 보호해준다.", ItemType.ARMOR, 0, 5, 0, 1100));
            storeInventory.Add(new Item("강철 검", "날카로운 검.", ItemType.WEAPON, 6, 0, 0, 1600));

        }

        public void StartGame()
        {
            Console.Clear();
            ConsoleUtility.PrintGameHeader();
            MainMenu();
        }

        private void MainMenu()
        {   
            // 구성
            //0. 화면정리
            Console.Clear();
            //1. 번호를 선택하는 멘트를 날려줌
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이 곳에서 던전으로 들어가기 전 활동을 하실 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine();

            //2. 선택한 결과를  검증함
            int choice = ConsoleUtility.PromptMenuChoice(1, 3);
            //3. 선택한 결과에 따라 이동시켜줌
            switch (choice)
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    InventoryMenu();
                    break;
                case 3:
                    StoreMenu();
                    break;
            }
            MainMenu();
        }

        public void StatusMenu()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■상태보기■");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            ConsoleUtility.PrintTextHightlights("Lv. ", player.Level.ToString("00"));   //두글자로만 표시되게 해주기
            Console.WriteLine();
            Console.WriteLine($"{player.Name} ( {player.Job} )");
            // 능력치 강화분을 표현하도록 변경
            int bonusAtk = inventory.Select(item => item.isEquipped ? item.Atk : 0).Sum(); //아이템이 장착됫으면 공격력을 더해주고 아니면 0 삼항연산자 활용
            int bonusDef = inventory.Select(item => item.isEquipped ? item.Def : 0).Sum();
            int bonusHp = inventory.Select(item => item.isEquipped ? item.Health : 0).Sum();
            ConsoleUtility.PrintTextHightlights("공격력 : ", (player.Attack + bonusAtk).ToString(), bonusAtk > 0 ? $" (+{bonusAtk})" : "");
            ConsoleUtility.PrintTextHightlights("방어력 : ", (player.Attack + bonusDef).ToString(), bonusDef > 0 ? $" (+{bonusDef})" : "");
            ConsoleUtility.PrintTextHightlights("체  력 : ", (player.Attack + bonusHp).ToString(), bonusHp > 0 ? $" (+{bonusHp})" : "");

            ConsoleUtility.PrintTextHightlights("골  드 :", player.Gold.ToString());
            Console.WriteLine();

            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine();

            switch (ConsoleUtility.PromptMenuChoice(0, 0))
            {
                case 0:
                    MainMenu();
                    break;
            }
        }

        public void InventoryMenu()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■인벤토리■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");

            for (int i = 0; i < inventory.Count; i++)
            {
                inventory[i].PrintItemStatDescription();  //아이템의 스탯 설명
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    EquipMenu();
                    break;
            }
        }

        private void EquipMenu()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■인벤토리 - 장착 관리 ■");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < inventory.Count;i++)
            {
                inventory[i].PrintItemStatDescription(true, i + 1);  // 나가기는 0번 고정 나머지는 1번부터 배정
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int KeyInput = ConsoleUtility.PromptMenuChoice(0, inventory.Count);

            switch (KeyInput)
            {
                case 0:
                    InventoryMenu();
                    break;
                default:
                    inventory[KeyInput - 1].ToggleEquipStatus();
                    EquipMenu();
                    break;
            }
        }

        public void StoreMenu()
        {
            Console.Clear();

            ConsoleUtility.ShowTitle("■ 상점 ■");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            ConsoleUtility.PrintTextHightlights("", player.Gold.ToString(), " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < storeInventory.Count;i++)
            {
                storeInventory[i].PrintStoreItemDescription();
            }
            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            switch (ConsoleUtility.PromptMenuChoice(0, 1))
            {
                case 0:
                    MainMenu();
                    break;
                case 1:
                    PurchaseMenu();
                    break;

            }

        }

        private void PurchaseMenu(string? prompt = null)
        {
            if (prompt != null)
            {
                //1초간 메세지를 띄운 다음에 다시 진행
                Console.Clear();
                ConsoleUtility.ShowTitle(prompt);
                Thread.Sleep(1000);
            }

            Console.Clear();

            ConsoleUtility.ShowTitle("■ 상점 ■");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            ConsoleUtility.PrintTextHightlights("", player.Gold.ToString(), " G");
            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < storeInventory.Count; i++)
            {
                storeInventory[i].PrintStoreItemDescription(true, i + 1);
            }
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            int keyInput = ConsoleUtility.PromptMenuChoice(0, storeInventory.Count);

            switch (keyInput)
            {
                case 0:
                    StoreMenu();
                    break;
                default:
                    //1. 이미 구매한 경우
                    if (storeInventory[keyInput - 1].isPurchased) // index 맞추기
                    {
                        PurchaseMenu("이미 구매한 아이템입니다.");
                    }
                    //2. 돈이 충분해서 살 수 있는 경우
                    else if (player.Gold >= storeInventory[keyInput - 1].Price)
                    {
                        player.Gold -= storeInventory[keyInput - 1].Price;
                        storeInventory[keyInput - 1].Purchase();
                        inventory.Add(storeInventory[keyInput - 1]);
                        PurchaseMenu();
                    }
                    //3. 돈이 부족해서 살 수 없는 경우
                    else
                    {
                        PurchaseMenu("골드가 부족합니다.");
                    }
                    break;
            }
        }

        
    }
    internal class Program
    {
        public static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();  // 게임을 전반적으로 관리해줄 게임매니저 생성
            gameManager.StartGame();     // 게임 실행
        }
    }
}
