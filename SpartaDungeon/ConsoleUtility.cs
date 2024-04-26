

namespace SpartaDungeon
{
    internal class ConsoleUtility
    {
        public static void PrintGameHeader()  // static 으로 설정하면 클래스 자체의 것이라 다른 클래스에서 따로 생성안해도 바로 사용가능
        {
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
            Console.WriteLine("===========================================================================================================================");
            Console.WriteLine("                                                  PRESS ANYKEY TO START                                                    ");
            Console.WriteLine("===========================================================================================================================");
            Console.ReadKey();
        }
        
        public static int PromptMenuChoice(int min, int max)  //메뉴 선택 함수
        {
            while (true) // 유저가 지정한 번호를 맞게 입력할 때 까지 반복시키기
            {
                Console.Write("원하시는 행동을 입력해주세요: ");
                //숫자를 제대로 입력했고,지정한 번호에 맞게 입력했는지 확인하기
                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= min && choice <= max) // TryParse 는 파싱이 될지 안될지 확인 해보는 것
                {
                    return choice;
                }
                Console.WriteLine("잘못된 입력입니다. 다시 입력해주세요.");
            }
        }

        internal static void ShowTitle(string title)      //타이틀을 이쁘게 출력해주기 위해
        {
            Console.ForegroundColor = ConsoleColor.Magenta;   //색 지정해주기
            Console.WriteLine(title);
            Console.ResetColor();
        }
        //string s2 글씨 강조하기
        public static void PrintTextHightlights(string s1, string s2, string s3 = "")      // 텍스트 예쁘게 출력해주기 위해 
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow;      
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        public static int GetPrintableLength(string str)
        {
            int length = 0;
            foreach (char c in str)
            {
                if(char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2;  //한글과 같은 넓은 문자에 대해 길이를 2로 취급
                }
                else
                {
                    length += 1;  //나머지 문자에 대한 길이 1로 취급
                }
            }
            
            return length; 
        }
        public static string PadRightForMixedText(string str, int totalLength)
        {
            // 한글과 영어는 다르다
            //가나다
            //111111
            int currentLenght = GetPrintableLength(str);   //이 글자가 몇글자 인지
            int padding = totalLength - currentLenght;
            return str.PadRight(str.Length + padding);
        }
    }
}