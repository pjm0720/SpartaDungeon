using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Inventory
    {
        public List<string> items = new List<string>();
        public void ManageMyInven()
        {
            string[] item = {"- 천 갑옷", "방어력 + 2", "갑옷이지만 안전은 보장 못합니다.",
                             "- 나무 활", "공격력 + 2", "살살 다룰 것! 세게 당기면 부서질 수도?",
                            "- 낡은 검", "공격력 + 1", "금방이라도 부서질 것 같다."};
            for ( int i = 0; i < item.Length; i++ )
            {
                items.Add(item[i] );
            }
        }

        public void ShowInventory()
        {
            Console.Clear();
            ManageMyInven();

            Console.WriteLine("[인벤토리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            Console.WriteLine("[장비 이름]   |   [장비 효과]  | [장비 설명]");
            for ( int i = 0;i < items.Count;i += 3)
            {
                Console.WriteLine(items[i] + "\t" + items[i +1] + "\t" + items[i + 2]);
            }
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");

            Console.WriteLine();
            bool isSuccess;
            do
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    Inventory inven = new Inventory();
                    inven.Equip();
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

                isSuccess = select == 1 && select == 0;
            }
            while(!isSuccess);
            
            

            
        }

        public void Equip()
        {
            Console.Clear();
            ManageMyInven();

            Console.WriteLine("[인벤토리 - 장착 관리]");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");

            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");


        }
    }
}

