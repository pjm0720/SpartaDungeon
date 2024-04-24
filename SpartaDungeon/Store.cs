using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Store
    {
        
        List<string> sellItem = new List<string>();
        public int itemCost; 
        public void ItemList() 
        {
            string[] sellItems = {"철 갑옷", "방어력 + 5", "착용하면 안전은 보장하지만 무거워서 이동 시 불편할 수 있다.",
                                "철 투구", "방어력 + 5", "머리를 보호해줘요.",
                               "강철 검", "공격력 + 6", "내구성이 튼튼하고 잘 썰리는 검",
                               "석궁   ", "공격력 + 8", "한 발당 데미지는 쌔지만 그만큼 장전이 오래걸려요.",
                                "나무 방패", "방어력 + 4", "날아오는 화살 정도는 막을만 합니다.",
                                "나무 몽둥이", "공격력 + 1", "어디서나 주울 수 있는 몽둥이"};
            for (int i = 0; i < sellItems.Length; i++)
            {
                sellItem.Add(sellItems[i]);
            }
        }
        
                   
        public void ShowStore()
        {
            Console.Clear();
            ItemList();

            Console.WriteLine("[상점]");
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");

            Console.WriteLine();
            Console.WriteLine("[보유 골드]");
            Console.WriteLine(" 1000 G");

            Console.WriteLine();
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < sellItem.Count; i += 3)
            {
                Console.WriteLine($"- {sellItem[i]} \t {sellItem[i + 1]} \t {sellItem[i + 2]} \t");
            }

            Console.WriteLine();
            Console.WriteLine("1. 아이템 구매");
            Console.WriteLine("0. 나가기");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");
            Console.Write(">>");
            int select = int.Parse(Console.ReadLine());

            if (select == 1)
            {
                //구매 페이지 이동
            }
            if (select == 0)
            {
                Lobby lobby = new Lobby();
                lobby.StartScene();
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        public void BuyItem(Player player, int itemPrice)
        {   //플레이어 돈이 아이템 가격보다 많다면
            if (player.Gold >= itemPrice)
            {   // 플레이어 돈에서 아이템 가격 빼주고
                player.Gold -= itemPrice;
                //인벤토리에 구매한 템 넣어주고
                // 아이템 목록에서 구매한 아이템 가격대신 구매 완료 띄워주기
                

            }
        }
    }
}
