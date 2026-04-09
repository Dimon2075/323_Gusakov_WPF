using ISIP323_Gusakov_WPF.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISIP323_Gusakov_WPF.Class
{
    public class Game
    {
        private Player player;
        private int turnCount;
        private Random rng;
        private List<Enemy> enemies;
        public Game()
        {
            rng = new Random();
            turnCount = 0;
            player = new Player(100);
            enemies = new List<Enemy>();

        }

        public void Start()
        {
            GamePage.Instance.AddEvent($"Да нанутся голодные игры");
            while (player.Health > 0)
            {
                turnCount++;
                Console.WriteLine($"\n--- Ход {turnCount} ---");
                player.ShowStatus();
                GenerateEvent();
                Console.WriteLine("Продолжай");
            }
        }
        private void GenerateEvent()
        {
            int eventType = rng.Next(0, 4);
            if (eventType == 0)
            {
                Enemy enemy;
                enemy = new Skeleton();
                enemies.Add(enemy);
                GamePage.Instance.AddEvent($"Пришел враг: {enemy.Name}");
                FightEnemy(enemy);
            }
            else if (eventType == 1)
            {
                Enemy enemy;
                enemy = new Mag();
                enemies.Add(enemy);
                GamePage.Instance.AddEvent($"Пришел враг: {enemy.Name}");
                FightEnemy(enemy);
            }
            else if (eventType == 2)
            {
                Enemy enemy;
                enemy = new Goblin();
                enemies.Add(enemy);
                GamePage.Instance.AddEvent($"Пришел враг: {enemy.Name}");
                FightEnemy(enemy);
            }
            else if (turnCount % 10 == 3)
            {
                Enemy boss = GenerateBoss();
                enemies.Add(boss);
                GamePage.Instance.AddEvent($"Появился босс: {boss.Name}");
                FightEnemy(boss);
            }
            else
            {
                OpenChest();
            }

        }
        private void FightEnemy(Enemy enemy)
        {
            
            while (player.IsAlive() && enemy.IsAlive())
            {

                // Первый ход: игрок атакует
                //PlayerTurn(enemy);
                if (!enemy.IsAlive()) break;
                enemy.AttackPlayer(player);

                if (!enemy.IsAlive())
                {
                    GamePage.Instance.AddEvent($"\n*** {enemy.Name} побежден! ***");
                }

                GamePage.Instance.AddEvent("Продолжить атаку");


            }

        }
        //private void PlayerTurn(Enemy enemy)
                    /*player.Attack(enemy);*/
               
                    /*player.Defend();*/
         
        private Enemy GenerateBoss()
        {
            int bossType = rng.Next(4);
            
            switch (bossType)
            {
                case 0: return new VVG();
                case 1: return new Kovalsky();
                case 3: return new ArchmageCPP();
                case 4: return new PestovC();
                default: return null; // или выбросить исключение
            }
        }
        public void OpenChest()
        {
            Console.WriteLine("\n*** Вы нашли сундук! ***");
            Chest chest = new Chest();
            Item item = chest.Open();
            Console.WriteLine($"В сундуке: {item.GetInfo()}");
            if (item is Potion potion)
            {
                Console.WriteLine("Использовать зелье? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    potion.Use(player);
                }
            }
            else if (item is WeaponItem weapon)
            {

                Console.WriteLine($"Текущее оружие: {player.EcipWeapon.GetInfo()}");
                Console.WriteLine("Заменить оружие? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    weapon.Use(player);
                }
            }
            else if (item is ArmorItem armor)
            {
                Console.WriteLine($"Текущие доспехи: {player.EcipArmor}");
                Console.WriteLine("Заменить доспехи? (y/n)");
                if (Console.ReadLine().ToLower() == "y")
                {
                    armor.Use(player);
                }
            }
        }
    }
}
