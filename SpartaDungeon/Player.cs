using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpartaDungeon
{
    internal class Player
    {
       
        //생성자 이후에 set하지않겠다 -> 읽기전용
        public string Name { get; }  // 이름
        public string Job {  get; }  // 직업
        public int Level { get; }   // 레벨   
        public int Attack { get; }  // 공격력
        public int Defense { get;}  // 방어력
        public int Health { get; }  // 체력
        public int Gold { get; set; }   // 골드 
        //생성자의 용도 = 기본 세팅
        public Player(string name, string job, int level, int attack, int defense, int health, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Attack = attack;
            Defense = defense;
            Health = health;
            Gold = gold;
        }

     
    }

}
