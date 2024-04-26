

namespace SpartaDungeon
{

    public enum ItemType
    {
        WEAPON,
        ARMOR
    }
    internal class Item
    {
        public string Name { get; }   //이름
        public string Desc { get; }   //설명
        public ItemType Type { get; }  // 타입(공격력,방어력)
        public int Atk { get; }   //공격력
        public int Def { get; }   //방어력
        public int Health { get; }  // 체력
        public int Price { get; }  //가격
        public bool isEquipped { get; private set; }  // 장착했는지 안했는지 변경은 무조건 이 클래스 안에서만 하겠다.
        public bool isPurchased { get; private set; } // 아이템 구매 여부

        public Item(string name, string desc, ItemType type, int atk, int def, int health, int price, bool isEquipped = false, bool isPurchased = false) //안적으면 false 안낀걸로 하기
        {
            Name = name;
            Desc = desc;
            Type = type;
            Atk = atk;
            Def = def;
            Health = health;
            this.Price = price;
            this.isEquipped = isEquipped;
            this.isPurchased = isPurchased;
        }
        // 아이템 정보를 보여줄 때 타입이 비슷한게 2개있다
        // 1.인벤토리에서 그냥 내가 어느 아이템을 갖고있는지 보여줄 때
        // 2.장착 관리에서 내가 어떤 아이템을 낄지 말지 결정할 때
        internal void PrintItemStatDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            if (withNumber)  
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write($"{idx} ");
                Console.ResetColor();
            }
            if (isEquipped) //장착 했다면
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
                Console.Write(ConsoleUtility.PadRightForMixedText(Name, 9));
            }
            else
            {
                Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));
            }

            Console.Write(" | ");

            if (Atk != 0)
            {
                Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk}");
            }
            if (Def != 0)
            {
                Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def}");
            }
            if (Health != 0)
            {
                Console.Write($"체  력 {(Health >= 0 ? "+" : "")}{Health}");
            }

            Console.Write(" | ");

            Console.WriteLine(Desc);
        }
        //상점 아이템 관련
        public void PrintStoreItemDescription(bool withNumber = false, int idx = 0)
        {
            Console.Write("- ");
            
            if (withNumber)
            {
                Console.ForegroundColor= ConsoleColor.DarkMagenta;
                Console.Write("{0 }", idx);
                Console.ResetColor();
            }
            else
            {
                Console.Write(ConsoleUtility.PadRightForMixedText(Name, 12));
            }

            Console.Write(" | ");

            if (Atk != 0)
            {
                Console.Write($"공격력 {(Atk >= 0 ? "+" : "")}{Atk}");
            }
            if (Def != 0)
            {
                Console.Write($"방어력 {(Def >= 0 ? "+" : "")}{Def}");
            }
            if (Health != 0)
            {
                Console.Write($"체  력 {(Health >= 0 ? "+" : "")}{Health}");
            }

            Console.Write(" | ");

            Console.Write(ConsoleUtility.PadRightForMixedText(Desc, 12));

            Console.Write(" | ");
            //구매 했는지 여부
            if (isPurchased)
            {
                Console.WriteLine("구매 완료");
            }
            else
            {
                ConsoleUtility.PrintTextHightlights("", Price.ToString(), " G");
            }
        }

        internal void ToggleEquipStatus()
        {
            isEquipped = !isEquipped;
        }

        internal void Purchase()
        {
            isPurchased = true;
        }
    }
}