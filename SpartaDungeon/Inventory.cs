using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Inventory
    {
        private static Inventory instance;
        // 인벤토리 싱글톤 상점에서 끌어다 쓰기위해
        public static Inventory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Inventory();
                }
                return instance;
            }
        }
        public List<string> items = new List<string>();
        private bool inventoryDisplayed = false; // 인벤토리가 아직 한번도 표시 안되었다는 것을 나타내는 변수 생성
        public List<int> selectedItems = new List<int>(); //선택한 아이템의 인덱스를 저장할 리스트
        

        public void ManageMyInven()
        {
             string[] item = {"천 갑옷", "방어력 + 2", "갑옷이지만 안전은 보장 못합니다.",
                             "뾰족한 창", "공격력 + 3", "찌르기에 특화된 무기.",
                            "낡은 검", "공격력 + 1", "금방이라도 부서질 것 같다."};
            for ( int i = 0; i < item.Length; i++ )
            {
                items.Add(item[i] );
            }
        }

        public void ShowInventory()   //인벤토리 열기
        {
            Console.Clear();
             if (!inventoryDisplayed) // 인벤토리가 아직 한 번도 표시되지않았는지 검사
            {
                ManageMyInven(); // 인벤토리를 한 번만 초기화
                inventoryDisplayed = true;  // true 바꿔주면서 더 이상 초기화 
            }

            Console.WriteLine("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[장비 이름]   |   [장비 효과]  | [장비 설명]");
            for ( int i = 0;i < items.Count;i += 3)
            {
                int itemsNum = i / 3 + 1;
                bool isSelected = selectedItems.Contains(itemsNum); // 선택한 아이템인지 확인

                if (isSelected)
                {
                    Console.WriteLine($"[E] {itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}");
                }
                else
                {
                    Console.WriteLine($"{itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}");
                }
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();

            Console.WriteLine("원하시는 행동을 입력해주세요(0 ~ 1 중 선택).");
            Console.Write(">>");
            int select = int.Parse(Console.ReadLine());

            if (select == 1)
            {
                Equip();
            }
            else if (select == 0)
            {
                Lobby lobby = new Lobby();
                lobby.StartScene();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            
            

            
        }

        public void Equip() // 인벤토리 - 장착 관리 창
        {
            Console.Clear();
            

            Console.WriteLine("[인벤토리 - 장착 관리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[장비 이름]   |   [장비 효과]  | [장비 설명]");
            
            for (int i = 0; i < items.Count; i += 3)
            {
                int itemsNum = i / 3 + 1;
                bool isSelected = selectedItems.Contains(itemsNum); // 선택한 아이템인지 확인

                if (isSelected)
                {
                    Console.WriteLine($"[E] {itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}");
                }
                else
                {
                    Console.WriteLine($"{itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}");
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("착용할 장비 번호를 입력해주세요.");
            Console.Write(">>");
            int selectEquip = int.Parse(Console.ReadLine());

            selectedItems.Add(selectEquip); // 선택한 아이템의 인덱스를 저장


            Console.WriteLine();
            Console.WriteLine("0. 인벤토리로 이동");
            int exit = int.Parse(Console.ReadLine());

            if (exit == 0)
            {
                ShowInventory();
                
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }      
        }
    }
}

