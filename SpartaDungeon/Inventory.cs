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
        public List<string> items = new List<string>(); // 장비를 담을 리스트 생성
        private bool inventoryDisplayed = false; // 인벤토리가 아직 한번도 표시 안되었다는 것을 나타내는 변수 생성
        public List<int> selectedItems = new List<int>(); //선택한 아이템의 인덱스를 저장할 리스트
        

        public void ManageMyInven()
        {    //장비 생성
             string[] item = {"천 갑옷", "방어력 + 2", "갑옷이지만 안전은 보장 못합니다.",
                             "뾰족한 창", "공격력 + 3", "찌르기에 특화된 무기.",
                            "낡은 검", "공격력 + 1", "금방이라도 부서질 것 같다."};
            for ( int i = 0; i < item.Length; i++ )
            {
                items.Add(item[i] );  //장비를 리스트에 추가해주기
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
                    Console.WriteLine($"[E] {itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}"); //선택한 아이템 앞엔 [E] 붙여줌
                }
                else
                {
                    Console.WriteLine($"{itemsNum}. {items[i]} \t {items[i + 1]} \t {items[i + 2]}"); // 아니면 그냥 출력
                }
            }
            
            Console.WriteLine();
            Console.WriteLine("착용 또는 해제할 장비 번호를 입력해주세요.");
            Console.Write(">>");

            int selectEquip;  //선택한 장비 변수 생성

            // 사용자가 유효한 번호를 입력할 때까지 반복해서 입력을 받음
            while (true)
            {
                string input = Console.ReadLine();

                // 입력이 숫자인지 확인
                if (int.TryParse(input, out selectEquip))
                {
                    // 입력이 유효한지 확인
                    if (selectEquip >= 1 && selectEquip <= items.Count / 3)
                    {
                        break; // 유효한 입력일 경우 반복문 탈출
                    }
                }

                // 잘못된 입력 메시지 출력
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
                Console.Write(">>");
            }

            // 선택한 아이템의 선택 여부를 반전시킴
            if (selectedItems.Contains(selectEquip))
            {
                selectedItems.Remove(selectEquip); // 선택한 아이템이 이미 선택되어 있으면 선택을 해제함
            }
            else
            {
                selectedItems.Add(selectEquip); // 선택한 아이템이 선택되어 있지 않으면 선택함
            }



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

