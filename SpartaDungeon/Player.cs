using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Player
    {
        Lobby lobby = new Lobby();
        public string Name { get; }  // 이름
        public string Job {  get; }  // 직업
        public int Level { get; }   // 레벨
        public int Damage { get; }  // 공격력
        public int Defense { get; }  // 방어력
        public int Health { get; }  // 체력
        public int Gold { get; }   // 골드

        public Player(string _name, string _job, int _level, int _damage, int _defense, int _health, int _gold)
        {
            Name = _name;
            Job = _job;
            Level = _level;
            Damage = _damage;
            Defense = _defense;
            Health = _health;
            Gold = _gold;
        }
        public void ShowPlayerInfo()
        {
            Console.Clear();

            Console.WriteLine("[상태보기]");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");

            Console.WriteLine();

            Console.WriteLine($"Lv. {Level}");
            Console.WriteLine($"{Name}\t ({Job})");
            Console.WriteLine($"공격력: {Damage}");
            Console.WriteLine($"방어력: {Defense}");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"Gold: {Gold} G");

            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine();

            bool isSuccess;
            do      // 0을 입력할 때 까지 반복
            {
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                int select = int.Parse( Console.ReadLine());

                if(select == 0)
                {
                    lobby.StartScene();
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                isSuccess = select == 0;
            }
            while(!isSuccess);          
        }
    }
}
