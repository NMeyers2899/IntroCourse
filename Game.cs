using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        string playerName = "Nicholas";
        float playerHealth = 10;
        float playerAttackPower = 100;

        string enemyName = "Goblin";
        float enemyHealth = 200;
        float enemyAttackPower = 5;

        void Battle()
        {
            string playerChoice;

            Console.WriteLine("The " + enemyName + " stands before you. What shall you do?");

            while(enemyHealth > 0 && playerHealth > 0)
            {
                Console.WriteLine("1. Attack \n2. Run Away");
                playerChoice = Console.ReadLine();

                if (playerChoice == "1" || playerChoice.ToLower() == "attack")
                {
                    Console.WriteLine("You slash out at the " + enemyName + "!");
                    enemyHealth -= playerAttackPower;
                    ClearScreen();

                    if (enemyHealth <= 0)
                        return;

                    Console.WriteLine("The " + enemyName + " lunges at you!");
                    playerHealth -= enemyAttackPower;
                    ClearScreen();
                }
                else if (playerChoice == "2" || playerChoice.ToLower() == "run away")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    ClearScreen();
                }
            }
        }

        void ClearScreen()
        {
            Console.WriteLine("Hit Any Key To Continue");
            Console.ReadKey();
            Console.Clear();
        }

        public void Run()
        {
            Battle();

            if (playerHealth <= 0)
                Console.WriteLine("Game Over");
            else
                Console.WriteLine("You Win!");
        }
    }
}
