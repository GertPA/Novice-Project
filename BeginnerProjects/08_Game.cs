//Lets Make a Simple Game 

Random random = new Random();
int PlayerHealth = 5000;
int monsterHealth = 50;
bool swordIn = false;
bool replay = true;

Console.WriteLine("Welcome to The Dungeon Game! Are you ready to embark on a thrilling adventure? \n\t\t\t(Press Enter To play)");
Console.ReadLine();

Console.WriteLine("You awaken to find yourself at a fork in the path, with two diverging routes stretching before you.\nWill you venture left or right? The choice is yours to make.");
string? firstPath = Console.ReadLine();

while (replay)
{
	switch (firstPath)
	{
		//left path
		case "left":
			LeftPath();
			break;


		//right path
		case "right":
			Console.WriteLine("A fearsome monster looms before you, its presence sending shivers down your spine.\n Will you stand your ground and face it in combat, or will you choose the path of caution and attempt to flee?\n The decision is yours to make, but choose wisely, for the outcome may determine your fate.");
			string? userChoice = Console.ReadLine();
			switch (userChoice.ToLower())
			{
				case "fight":
					FightingScene(monsterHealth, PlayerHealth, swordIn);

					break;

				case "run":
					Console.WriteLine("You make a quick decision to flee from the monstrous creature, \nyour heart pounding in your chest as you dart down the nearest escape route. \nWith a surge of adrenaline, you manage to outpace the pursuing beast, \nbreathing a sigh of relief as you leave it far behind. \nCongratulations, you've successfully evaded the encounter for now.");
					LeftPath();
					break;

				default:
					Console.WriteLine("Invalid choice. Please choose 'left' or 'right'.");
					break;
			}

			break;

		default:
			Console.WriteLine("Invalid input");
			break;



	}

	Console.WriteLine("Do you want to replay? (yes/no)"); //will respawn before the last action
	string? replayAnswer = Console.ReadLine().ToLower();

	if (replayAnswer == "no")
	{
		replay = false;
		Console.WriteLine("Thanks for playing!");
	}
	else if (replayAnswer != "yes")
	{
		Console.WriteLine("Invalid input. Exiting game.");
		replay = false;
	}
}
void FightingScene(int monsterHp, int playerHp, bool sword)
{
	//this can be removed 
	Console.WriteLine("You made the bold decision to confront the monster head-on in combat.");

	switch (sword)
	{
		case false:

			while (monsterHp > 0 && playerHp > 0)
			{

				int hitPoints = random.Next(0, 26);
				int hitPointz = random.Next(0, 26);
				monsterHp -= hitPoints;
				playerHp -= hitPointz;

				Console.WriteLine("You hit the monster with your fist you did " + hitPoints + " points of damage the monster has " + monsterHp + " health points");
				Console.WriteLine("The monster hit you with their claws you lost " + hitPointz + " points of damage you have " + playerHp + " health points");
				if (playerHp <= 0)
				{
					Console.WriteLine("As the monstrous claws tear through your chest, a torrent of blood\n pours forth, your life force ebbing away with each weakening heartbeat,\n the grim specter of death looming ever closer, a stark reminder of your imminent defeat."); //rewrite
				}
				else if (monsterHp <= 0)
					Console.WriteLine("As your final blow strikes true, the monster lets out a guttural\n roar of defeat, its once fearsome form crumbling to the ground. Victory is yours,\n but not without its toll—the echoes of battle still ringing in your ears,\n a testament to the fierce struggle that has left you standing triumphant amidst the carnage."); //reweite
			}

			break;

		case true:
			Console.WriteLine("With a fierce battle cry, you lunge forward, the weight of your sword cutting\n through the air with deadly precision. The blade meets the monster's hide\n with a resounding clash, sending shivers down your spine as you feel its\n power. Your strike finds its mark, the force behind it driving deep into the\n creature's flesh. With a final, thunderous roar, the monster falls,\n defeated by your valor and skill. A victorious sense of accomplishment\n washes over you as you stand over your fallen foe, the echoes of battle\n fading into the silence of triumph. Well done, brave warrior.");
			break;
		default:
				}

}

void LeftPath()
{
	Console.WriteLine("You descend down the stairs,each step echoing in the dimly lit chamber. \nAs you reach the bottom, your eyes are drawn to a mysterious chest standing before you.Its weathered \nexterior hints at untold treasures within.Will you dare to open it and unveil its secrets?");
	string? openChest = Console.ReadLine();
	if (openChest.ToLower() == "yes" || openChest.ToLower() == "open")
	{
		bool swordIns = true;
		Console.WriteLine("In the chest, you discover a brand-new sword, looking as pristine\n as if it were just forged. After a moment's thought, you decide to keep it\n —after all, you never know when it might come in handy.");

		Console.WriteLine("As you press on, you encounter a dead end. Would you like to turn back?");
		string? turnBack = Console.ReadLine();


		switch (turnBack)
		{
			case "yes":

				Console.WriteLine("You opt to double back to the uncharted trail, your resolve\n unyielding as you retrace your steps toward the unknown.");
				Console.WriteLine("As you retreat, a menacing figure emerges—a monstrous presence\n blocking your path. Armed with your trusty sword, there's no question: you'll\n confront the creature head-on, ready to wield your weapon in the face of danger.");

				FightingScene(monsterHealth, PlayerHealth, swordIns);
				break;

			case "no":
				Console.WriteLine("The brave adventurer isnt afraid to explore uncharted paths, but you\n chose to not turn back? Unacceptable the adventurer scoffs at you and decides\n to explore what’s left on the right path. ");
				Console.WriteLine("As you retreat, a menacing figure emerges—a monstrous presence\n blocking your path. Armed with your trusty sword, there's no question: you'll\n confront the creature head-on, ready to wield your weapon in the face of danger.");
				FightingScene(monsterHealth, PlayerHealth, swordIns);
				break;
		}

	}
	else
	{
		Console.WriteLine("Deciding to press on, you cautiously make your way down the stairs, each step fraught with anticipation.\n Suddenly, without warning, the floor gives way beneath you, and you plummet into a hidden trap.\n As darkness envelops you, you realize your fate has been sealed");

	}
}
