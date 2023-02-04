using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    /// <summary>
    /// A character that holds some stats.
    /// </summary>
    struct Character
    {
        public string Name;
        public float Health;
        public float AttackPower;
    }

    class Game
    {
        // Declares a player and enemy character.
        Character playerCharacter;
        Character currentEnemy;

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
            playerCharacter.AttackPower = 3;
        }

        /// <summary>
        /// Gives the enemy a name, some health, and attack power.
        /// </summary>
        void InitalizeEnemy(string name, float health, float attackPower)
        {
            currentEnemy.Name = name;
            currentEnemy.Health = health;
            currentEnemy.AttackPower = attackPower;
        }

        /// <summary>
        /// Pits the player against the enemy in a fight to the death.
        /// </summary>
        void Battle()
        {
            // Holds what actions the player chooses to take.
            string playerChoice;

            // While both the enemy and the player are still alive...
            while(currentEnemy.Health > 0 && playerCharacter.Health > 0)
            {
                Console.WriteLine("The " + currentEnemy.Name + " stands before you. What shall you do?");

                // Display the stats for the player and enemy.
                PrintCharacterStats(playerCharacter.Name, playerCharacter.Health, playerCharacter.AttackPower);
                PrintCharacterStats(currentEnemy.Name, currentEnemy.Health, currentEnemy.AttackPower);

                // Check to see what the player wishes to do.
                Console.WriteLine("1. Attack \n2. Run Away");
                playerChoice = Console.ReadLine();
                Console.Clear();

                // If the player picks the first or attack option...
                if (playerChoice == "1" || playerChoice.ToLower() == "attack")
                {
                    // ...deal damage to the enemy.
                    Console.WriteLine("You slash out at the " + currentEnemy.Name + "!");
                    currentEnemy.Health -= playerCharacter.AttackPower;
                    ClearScreen();

                    // If the enemy is dead, exit the fight.
                    if (currentEnemy.Health <= 0)
                        return;

                    // If the enemy is still alive, the enemy damages the player.
                    Console.WriteLine("The " + currentEnemy.Name + " lunges at you!");
                    playerCharacter.Health -= currentEnemy.AttackPower;
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
        /// The first challenge. A riddle, that if solved will grant you a party member.
        /// </summary>
        void RoomOne()
        {
            // Declare and initalize the player's choice and how many guesses they get.
            string playerChoice;
            int numberOfGuesses = 4;

            Console.WriteLine("This guy will join you if you can solve my riddle!");
            ClearScreen();

            // While the player still has guesses, ask them the question and check their answer.
            for(int i = numberOfGuesses; i > 0; i--)
            {
                Console.WriteLine("You have " + i + " guesses left.\n");
                Console.WriteLine("One Knight, a King, and a Queen went into a castle. The King died and two people" +
                    " exited. Who left with the Queen?");

                playerChoice = Console.ReadLine();
                Console.Clear();

                // If the player's choice is 'knight', tell them they've solved it and give them the new party member.
                if(playerChoice.ToLower() == "knight")
                {
                    Console.WriteLine("Oh wow, you are just too smart for me. Here you go.");
                    ClearScreen();
                    return;
                }
            }

            // If they run out of guesses, they do not get a party member and still move on.
            Console.WriteLine("Uh oh, no party member for you.");
            ClearScreen();
            return;
        }

        /// <summary>
        /// Player must fight a goblin.
        /// </summary>
        void RoomTwo()
        {
            Console.WriteLine("Uh oh! Gablins!");

            InitalizeEnemy("Goblin", 6, 2);

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

            RoomTwo();
        }
    }
}
