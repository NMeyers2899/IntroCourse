using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    struct Character
    {
        public string Name;
        public float Health;
        public float AttackPower;
    }

    class Game
    {
        Character playerCharacter;

        // Enemy Stats
        string enemyName;
        float enemyHealth;
        float enemyAttackPower;

        /// <summary>
        /// Allows the user to set the name for the player.
        /// </summary>
        void PlayerSetUp()
        {
            // Ask the user what they want their character to be called.
            Console.WriteLine("Hello! What is your name?");
            playerCharacter.Name = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Welcome to your own little adventure, " + playerCharacter.Name);
            ClearScreen();

            // Set up the player's health and attack power.
            playerCharacter.Health = 10;
            playerCharacter.AttackPower = 100;
        }

        /// <summary>
        /// Gives the enemy a name, some health, and attack power.
        /// </summary>
        void InitalizeEnemy(string name, float health, float attackPower)
        {
            enemyName = name;
            enemyHealth = health;
            enemyAttackPower = attackPower;
        }

        /// <summary>
        /// Pits the player against the enemy in a fight to the death.
        /// </summary>
        void Battle()
        {
            // Holds what actions the player chooses to take.
            string playerChoice;

            // While both the enemy and the player are still alive...
            while(enemyHealth > 0 && playerCharacter.Health > 0)
            {
                Console.WriteLine("The " + enemyName + " stands before you. What shall you do?");

                // Display the stats for the player and enemy.
                PrintCharacterStats(playerCharacter.Name, playerCharacter.Health, playerCharacter.AttackPower);
                PrintCharacterStats(enemyName, enemyHealth, enemyAttackPower);

                // Check to see what the player wishes to do.
                Console.WriteLine("1. Attack \n2. Run Away");
                playerChoice = Console.ReadLine();

                // If the player picks the first or attack option...
                if (playerChoice == "1" || playerChoice.ToLower() == "attack")
                {
                    // ...deal damage to the enemy.
                    Console.WriteLine("You slash out at the " + enemyName + "!");
                    enemyHealth -= playerCharacter.AttackPower;
                    ClearScreen();

                    // If the enemy is dead, exit the fight.
                    if (enemyHealth <= 0)
                        return;

                    // If the enemy is still alive, the enemy damages the player.
                    Console.WriteLine("The " + enemyName + " lunges at you!");
                    playerCharacter.Health -= enemyAttackPower;
                    ClearScreen();
                }
                // If the player picks the second or run away option...
                else if (playerChoice == "2" || playerChoice.ToLower() == "run away")
                {
                    // ...set up the player for a game over.
                    playerCharacter.Health = 0;
                    return;
                }
                // If the player inputs anything else, let them know it was an invalid input.
                else
                {
                    Console.WriteLine("Invalid Input");
                    ClearScreen();
                }
            }
        }

        /// <summary>
        /// Asks the user to hit a key. Then clears the screen.
        /// </summary>
        void ClearScreen()
        {
            Console.WriteLine("Hit Any Key To Continue");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Prints out the stats of a character.
        /// </summary>
        void PrintCharacterStats(string name, float health, float attackPower)
        {
            Console.WriteLine(name + "'s Stats");
            Console.WriteLine("Health : " + health + "\nAttack : " + attackPower + "\n");
        }

        /// <summary>
        /// Player must fight a goblin.
        /// </summary>
        void RoomOne()
        {
            Console.WriteLine("Uh oh! Gablins!");

            InitalizeEnemy("Goblin", 200, 2);

            Battle();

            if (playerCharacter.Health <= 0)
                Console.WriteLine("Game Over");
            else
                Console.WriteLine("You Win!");
        }

        public void Run()
        {
            PlayerSetUp();

            RoomOne();
        }
    }
}
