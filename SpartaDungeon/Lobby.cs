namespace SpartaDungeon
{
    internal class Lobby
    {
        public void StartScene()
        {
            Console.Clear();

            Player player = new Player("모험가", "전사", 1, 10, 5, 100, 1500);  //플레이어 클래스 객체 생성
            Inventory inven = new Inventory();
            Store store = new Store();

            Console.WriteLine("  ______                               __                     _______                                                        ");
            Console.WriteLine(" /      \\                             /  |                   /       \\                                                       ");
            Console.WriteLine("/$$$$$$  | ______   ______   ______  _$$ |_    ______        $$$$$$$  |__    __ _______   ______   ______   ______  _______  ");
            Console.WriteLine("$$ \\__$$/ /      \\ /      \\ /      \\/ $$   |  /      \\       $$ |  $$ /  |  /  /       \\ /      \\ /      \\ /      \\/       \\ ");
            Console.WriteLine("$$      \\/$$$$$$  |$$$$$$  /$$$$$$  $$$$$$/   $$$$$$  |      $$ |  $$ $$ |  $$ $$$$$$$  /$$$$$$  /$$$$$$  /$$$$$$  $$$$$$$  |");
            Console.WriteLine(" $$$$$$  $$ |  $$ |/    $$ $$ |  $$/  $$ | __ /    $$ |      $$ |  $$ $$ |  $$ $$ |  $$ $$ |  $$ $$    $$ $$ |  $$ $$ |  $$ |");
            Console.WriteLine("/  \\__$$ $$ |__$$ /$$$$$$$ $$ |       $$ |/  /$$$$$$$ |      $$ |__$$ $$ \\__$$ $$ |  $$ $$ \\__$$ $$$$$$$$/$$ \\__$$ $$ |  $$ |");
            Console.WriteLine("$$    $$/$$    $$/$$    $$ $$ |       $$  $$/$$    $$ |      $$    $$/$$    $$/$$ |  $$ $$    $$ $$       $$    $$/$$ |  $$ |");
            Console.WriteLine(" $$$$$$/ $$$$$$$/  $$$$$$$/$$/         $$$$/  $$$$$$$/       $$$$$$$/  $$$$$$/ $$/   $$/ $$$$$$$ |$$$$$$$/ $$$$$$/ $$/   $$/ ");
            Console.WriteLine("         $$ |                                                                           /  \\__$$ |                           ");
            Console.WriteLine("         $$ |                                                                           $$    $$/                            ");
            Console.WriteLine("         $$/                                                                             $$$$$$/                             ");

            Console.WriteLine();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이 곳에서 던전으로 들어가기 전 활동을 하실 수 있습니다.");

            Console.WriteLine();

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");

            Console.WriteLine();
            bool isSuccess;
            do
            {
                Console.WriteLine("원하시는 행동을 입력해주세요(1~3 중 선택).");
                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    //캐릭터 정보창 이동
                    player.ShowPlayerInfo();
                }
                else if (select == 2)
                {
                    //인벤토리 창으로 이동
                    inven.ShowInventory();
                }
                else if (select == 3)
                {
                    // 상점 창으로 이동
                    store.ShowStore();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                isSuccess = select >= 1 && select <= 3;
            }
            while(!isSuccess);
   
        }
        static void Main(string[] args)
        {
            Lobby lobby = new Lobby();
            lobby.StartScene();
        }
    }
}
