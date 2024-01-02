using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
namespace Mix_it_up__Go_
{
    class Program
    {
        public static System.Timers.Timer timer = new System.Timers.Timer(30000);
        public static int score = 0;
        public static bool KeepRunning = true;
        //settings
        public static bool sounds = true;
        public static bool visuals = true;
        public static bool cursor = false;
        public static void Main(string[] args)
        {
            //gameplay: timer, settings, leaderboards ig
            //controls: <0> Restart Test, <2> 6 skips, <1> Re-Scramble Word 
            
            //Words 
            List <List<string>> Animals = new List<List<string>>();
            List <List<string>> Country = new List<List<string>>();
            List <List<string>> Food = new List<List<string>>();
            List <List<string>> Names= new List<List<string>>();
            List <List<string>> Random = new List<List<string>>();
            //easy index 0
            Animals.Add(new List<string> { "Lion", "Bee", "Dog", "Cat", "Wolf", "Ant", "Snake", "Tiger", "Bison", "Spider", "Shark", "Whale", "Worm", "Toad", "Frog", "Hawk", "Cow", "Crab", "Crow", "Deer", "Duck", "Owl", "Fox", "Turtle", "Bat", "Squid", "Goat", "Eagle", "Horse", "Eel", "Moth", "Pig", "Sloth" });

            Country.Add(new List<string> { "Yemen", "Turkey", "Spain", "Russia", "Qatar", "Poland", "Peru", "Nepal", "Kenya", "Jordan", "Japan", "Italy", "Israel", "Iraq", "Iran", "India", "Fiji", "Egypt", "Cuba", "China", "Chile", "Brazil", "Brunei" });

            Food.Add(new List<string> { "Sushi", "Pizza", "Milk", "Lamb", "Honey", "Ham", "Eggs", "Curry", "Crab", "Corn", "Clams", "Chips", "Celery", "Cake", "Bread", "Beer", "BBQ", "Bacon" });

            Names.Add(new List<string> {"James", "John", "Anthony", "Kyle", "Noah", "Ethan", "Peter", "Keith", "Bruce", "Billy", "Jesse", "Alan", "Philip", "Mark" });

            Random.Add(new List<string> {"Mouse", "Lamp", "King", "Waste", "Eat", "Labor", "debt", "Arrow", "blue", "lock", "party", "Sense", "Goat", "Gas", "set", "test", "Fuel", "flat", "pipe", "cook" });

            //medium index 1
            Animals.Add(new List<string> {"Penguin", "Butterfly", "Octopus", "Crocodile", "Cheetah", "Dolphin", "Cuckoo", "Monkey", "Ladybug", "Gorillas", "Raccoon", "Leopard", "Giraffe", "Jackal", "Jaguar", "Jellyfish", "Salmon", "Llama", "Lobster", "Lizard", "Gekko", "Camels", "Rabbit", "Sheep", "Panda", "Wasp", "Seal", "Lynx", "Goose", "Beetle", "Ocelot", "Zebra" }); 

            Country.Add(new List<string> {"Mexico", "Ukraine", "Uganda", "Serbia", "Portugal", "Nigeria", "Greece", "Monaco", "Malaysia", "Norway", "Ireland", "Iceland", "Germany", "Austria", "Finland", "France", "Canada", "Denmark", "Belgium", "Australia", "Albania", "Kuwait", "Sweden" });

            Food.Add(new List<string> {"Yogurt", "Waffles", "Spinach", "Grapes", "Garlic", "Cookies", "Coffee", "Chicken", "Burrito", "Lobster", "Almond", "Bagel", "Carrot", "Hotdog", "Cereal", "Beans", "apples"});

            Names.Add(new List<string> {"Michael", "Robert", "Matthew", "Stephen", "Jeremy", "Christian", "Walter", "Gerald", "Harold", "Jordan", "Willie", "Wayne", "Vincent", "Bobby" });

            Random.Add(new List<string> { "Popular", "Farewell", "Imagine", "compose", "species", "Length", "Activity", "packet", "Mention", "Belong", "Cheese", "Queen", "Animal", "Patrol", "Battle", "Fraud", "Steam", "Brown", "Whole", "Guitar"}); 

            //hard index 2
            Animals.Add(new List<string> {"Spinosaurus", "Triceratops", "Velociraptor", "Giganotosaurus", "Axolotl", "Capybara", "Centipede", "Elephants", "Termites", "Lemmings", "Hedgehog", "Caterpillar", "Rattlesnakes", "Rhinoceros", "Kangaroo", "Orangutan", "Muskrat", "Bonobo", "Walrus", "Mammoth", "Millipedes", "Weasel", "Vulture", "Toucan", "Tortoise", "Dugong", "Hornets", "Coyote", "Flamingo", "Beluga", "Iguana", "Peacock" });

            Country.Add(new List<string> { "Zimbabwe", "Tuvalu", "Switzerland", "Romania", "Netherlands", "Kiribati", "Kazakhstan", "Bangladesh", "Bahamas", "Philippines", "Singapore", "Morocco", "Dominica", "Ecuador", "Maldives", "Thailand", "Argentina", "Cambodia", "Georgia", "Colombia", "Mongolia", "Jamaica", "Vietnam" });

            Food.Add(new List<string> { "Zucchini", "Spaghetti", "Pancakes", "Pepperoni", "Milkshake", "Meatballs", "Chowder", "Broccoli", "Artichoke", "Asparagus", "Chocolate", "Cabbage", "Lasagna", "Antelope", "Avocado", "Noodles", "Walnuts"});

            Names.Add(new List<string> {"Christopher", "Nicholas", "Jonathan", "Benjamin", "Alexander", "Raymond", "Zachary", "Douglas", "Lawrence", "Mason", "Eugene", "Richard", "Alexis", "Zhyrus" });

            Random.Add(new List<string> {"Marathon", "Contribution", "Transaction", "Programming", "Assumption", "Disappear", "Correspond", "Catalogue", "Executive", "Bargain", "Diameter", "Neglect", "Memorial", "Computer", "Attraction", "Strange", "Keyboard", "Journal", "Payment", "transformation" }); 

            //meta
            Console.Title = "Mix it up, Go!";
            Console.CursorSize = 100;
            Console.SetWindowSize(Console.WindowWidth, Console.LargestWindowHeight / 2);
            Console.CursorVisible = false;
            
            Start:
            //initialization
            List<string> guessMe = new List<string>();
            string guess = "";
            string scrambled_Words;
            int theme;
            int difficulty;
            int skips = 6;
            int settings;

            //Starting
            Console.SetCursorPosition(1, (Console.WindowHeight/2)-6);
            DisplayHeader();
            Console.SetCursorPosition((Console.WindowWidth/2)-15, (Console.WindowHeight/2)+3);
            Console.WriteLine("Press any key to continue!");
            Console.SetCursorPosition((Console.WindowWidth/2)-7, (Console.WindowHeight/2)+5);
            Console.WriteLine("[0] Settings");
            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight-2);

            settings = int.TryParse(Console.ReadKey().KeyChar.ToString(), out settings) ? settings : 1;
            //settings
            if(settings == 0)
            {
                while (true)
                {
                Console.Clear();
                DisplaySettings();
                Console.SetCursorPosition(((Console.WindowWidth - 10) / 2)+13, (Console.WindowHeight/2) - 3);
                Console.WriteLine("<" + sounds +">");

                Console.SetCursorPosition(((Console.WindowWidth - 10) / 2)+13, (Console.WindowHeight/2) - 2);
                Console.WriteLine("<"+visuals+">");

                Console.SetCursorPosition(((Console.WindowWidth - 10) / 2)+13, (Console.WindowHeight/2) - 1);
                Console.WriteLine("<"+cursor+">");

                Thread.Sleep(500);
                Console.SetCursorPosition(((Console.WindowWidth - 10) / 2)+10, (Console.WindowHeight/2) - 4);
                settings = int.TryParse(Console.ReadKey().KeyChar.ToString(), out settings) ? settings : -1;
                if(settings == 1)
                {
                    sounds = Settings(sounds);
                        if (sounds)
                        {
                            Console.Beep();
                        }
                }               
                if(settings == 2)
                {
                    visuals = Settings(visuals);
                        if (visuals)
                        {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Console.ResetColor();

                        }
                }               
                if(settings == 3)
                {
                    cursor = Settings(cursor);
                        if (cursor)
                        {
                            Console.CursorVisible = true;
                        }else
                            Console.CursorVisible = false;
                }               
                if(settings == 4)
                {
                    Console.Clear();
                    Console.CursorVisible = false;
                    goto Start;
                }               
                }
            }

            Console.Clear();
            //Choose a Theme
            Theme:
            while (true)
            {
                DisplayHeader();
                DisplayTheme();
                theme= int.TryParse(Console.ReadKey().KeyChar.ToString(), out theme) ? theme: -1;
                if (theme > 0 && theme < 6)
                    break;
                else
                {
                        if (sounds){
                            Console.Beep();
                        }
                    Console.Clear();

                }

            }
            Console.Clear();

            //Choose a Difficulty
            while (true)
            {
                DisplayHeader();
                DisplayDifficulty();
                difficulty = int.TryParse(Console.ReadKey().KeyChar.ToString(), out difficulty) ? difficulty: -1;
                if (difficulty > 0 && difficulty < 4)
                    break;
                else if(difficulty == 4)
                {
                    Console.Clear();
                    goto Theme;
                }
                else
                {
                        if (sounds){
                            Console.Beep();
                        }
                    Console.Clear();

                }
            }


            //condition for theme and difficulty
            switch (theme)
            {
                case 1: 
                    if(difficulty == 1) 
                    {
                        guessMe = new List<string>(Animals[0]);
                    }
                    else if(difficulty == 2) 
                    {
                        guessMe = new List<string>(Animals[1]);
                    }
                    else if(difficulty == 3) 
                    {
                        guessMe = new List<string>(Animals[2]);
                    }
                    break;
                case 2:
                    if(difficulty == 1) 
                    {
                        guessMe = new List<string>(Country[0]);
                    }
                    else if(difficulty == 2) 
                    {
                        guessMe = new List<string>(Country[1]);
                    }
                    else if(difficulty == 3) 
                    {
                        guessMe = new List<string>(Country[2]);
                    }
                    break;
                 case 3:
                    if(difficulty == 1) 
                    {
                        guessMe = new List<string>(Food[0]);
                    }
                    else if(difficulty == 2) 
                    {
                        guessMe = new List<string>(Food[1]);
                    }
                    else if(difficulty == 3) 
                    {
                        guessMe = new List<string>(Food[2]);
                    }
                    break;
                case 4:
                    if(difficulty == 1) 
                    {
                        guessMe = new List<string>(Names[0]);
                    }
                    else if(difficulty == 2) 
                    {
                        guessMe = new List<string>(Names[1]);
                    }
                    else if(difficulty == 3) 
                    {
                        guessMe = new List<string>(Names[2]);
                    }
                    break;

                case 5:
                    if(difficulty == 1) 
                    {
                        guessMe = new List<string>(Random[0]);
                    }
                    else if(difficulty == 2) 
                    {
                        guessMe = new List<string>(Random[1]);
                    }
                    else if(difficulty == 3) 
                    {
                        guessMe = new List<string>(Random[2]);
                    }
                    break;

            }
            Console.Clear();

            //Press to start
            Console.SetCursorPosition(0, (Console.WindowHeight/2)-15);
            DisplayHeader();

            Console.SetCursorPosition((Console.WindowWidth/2)-12, (Console.WindowHeight/2)-4);
            Console.WriteLine("Rules:");

            Console.SetCursorPosition((Console.WindowWidth/2)-12, (Console.WindowHeight/2)-3);
            Console.WriteLine("You have 30 seconds to guess!");

            Console.SetCursorPosition((Console.WindowWidth/2)-12, (Console.WindowHeight/2)-2);
            Console.WriteLine("<Esc> to Skip Word");

            Console.SetCursorPosition((Console.WindowWidth/2)-12, (Console.WindowHeight/2)-1);
            Console.WriteLine("<Tab> to Scramble Word");

            Console.SetCursorPosition((Console.WindowWidth/2)-12, (Console.WindowHeight/2)+5);
            Console.WriteLine("Press any key to start!");

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight-2);
            Console.ReadKey();
            Console.Clear();

            // display score
            Console.SetCursorPosition((Console.WindowWidth) / 8, 10);
            Console.WriteLine("Score: {0}", score);




            //timer
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            // display scrambled words
            foreach (string word in guessMe)
            {
                if(KeepRunning == false)
                {
                    break;
                }
                //score
                Console.SetCursorPosition((Console.WindowWidth) / 8, 10);
                Console.WriteLine("Score: {0}", score);

                //skips
                Console.SetCursorPosition((Console.WindowWidth) / 4, 10);
                Console.WriteLine("Skips: {0}", skips) ;


                scrambled_Words = ScrambleWords(word);

                while (KeepRunning)
                {
                   if(guess.ToLower().Replace(" ", "") == word.ToLower())
                    {
                        break;
                    }
                    Console.SetCursorPosition(0, 0);
                    DisplayHeader();

                    //center text 
                    Console.SetCursorPosition((Console.WindowWidth - scrambled_Words.Length) / 2, (Console.WindowHeight / 2) - 3);

                    Console.WriteLine(scrambled_Words);
                    Console.WriteLine("\n\n");

                    //center text 
                    Console.SetCursorPosition((Console.WindowWidth - (scrambled_Words.Length) / 2) / 2, (Console.WindowHeight / 2) - 1);


                    if (cursor)
                    {
                        Console.CursorVisible = true;
                    }
                    guess = Input();

                    if(KeepRunning == false)
                    {
                        break;
                    }                   

                    if (guess == "skip")
                    {
                        if (skips != 0)
                        {
                            skips--;
                            Console.Clear();
                            break;
                        }
                    }
                    if (guess == "scramble")
                    {
                        scrambled_Words = ScrambleWords(word);
                    }


                    //correct guess 
                    if (guess.ToLower().Replace(" ", "") == word.ToLower())
                    {
                        if (visuals)
                        {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Clear();
                        Thread.Sleep(150);
                        Console.ResetColor();

                        }
                        else
                        {
                        Thread.Sleep(150);
                        }

                        Console.Clear();
                        score++;

                    }
                    //incorrect guess
                    if (guess.ToLower().Replace(" ", "") != word.ToLower() && guess != "scramble")
                    {
                        if (visuals)
                        {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Thread.Sleep(150);
                        Console.ResetColor();

                        }
                        else
                        {
                        Thread.Sleep(150);

                        }
                        Console.Clear();
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth) / 8, 8);
                        Console.WriteLine("Score: {0}", score);
                        Console.SetCursorPosition((Console.WindowWidth) / 4, 8);
                        Console.WriteLine("Skips: {0}", skips);
                    }

                }
            }
            timer.Stop();
            Console.Clear();
            //game over
            Console.SetCursorPosition(1, (Console.WindowHeight/2)-10);
            DisplayGameOver();

            Console.SetCursorPosition((Console.WindowWidth/2)-10, (Console.WindowHeight/2)+1);
            Console.WriteLine("Score: {0}", score);

            Console.SetCursorPosition((Console.WindowWidth/2)-10, (Console.WindowHeight/2)+5);
            Console.WriteLine("<Tab> Play Again!");
            Console.SetCursorPosition((Console.WindowWidth/2)-10, (Console.WindowHeight/2)+6);
            Console.WriteLine("<Esc> Quit!");

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight-2);
            Thread.Sleep(3000);
            bool playAgain = PlayAgain();
            if (playAgain)
            {
                Console.Clear();
                KeepRunning = true;
                score = 0;
                goto Start;
            }else
                Environment.Exit(0);

            //Console.Clear();
            //Console.ReadKey();
        }
        // output scrambled word
        public static string ScrambleWords(string word)
        {
            string scrambled_Words;
            //prevent scrambling into the same word
            do
            {
                scrambled_Words = "";
                List<int> uniqueNumber = UniqueNumber(word.Length);

                //scramble the word
                for (int i = 0; i < word.Length; i++)
                {
                    scrambled_Words += " " + word[uniqueNumber[i]];
                }

            }while(scrambled_Words.Replace(" ", "") == word);
            return scrambled_Words.ToLower();
        }
        public static List<int> UniqueNumber(int number)
        {
            var rand = new Random();

            List<int> randomList = new List<int>();
            int unique;

            //generate random number w/o repeating 
            for (int i = 0; i < number; i++)
            {
                do
                {
                    unique = rand.Next(number);
                } while (randomList.Contains(unique));
                randomList.Add(unique);
            }
            return randomList;

        }
        public static void DisplayDifficulty()
        {
            Console.SetCursorPosition((Console.WindowWidth - 12) / 2, (Console.WindowHeight/2) - 4);
            Console.WriteLine("Difficulty: ");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 3);
            Console.WriteLine("[1] Easy");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 2);
            Console.WriteLine("[2] Medium");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 1);
            Console.WriteLine("[3] Hard");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) + 1);
            Console.WriteLine("[4] Go Back");

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight-2);
        }
        public static void DisplayTheme()
        {
            Console.SetCursorPosition((Console.WindowWidth - 7) / 2, (Console.WindowHeight/2) - 4);
            Console.WriteLine("Theme: ");

            Console.SetCursorPosition((Console.WindowWidth - 11) / 2, (Console.WindowHeight/2) - 3);
            Console.WriteLine("[1] Animals");

            Console.SetCursorPosition((Console.WindowWidth - 11) / 2, (Console.WindowHeight/2) - 2);
            Console.WriteLine("[2] Country");

            Console.SetCursorPosition((Console.WindowWidth - 11) / 2, (Console.WindowHeight/2) - 1);
            Console.WriteLine("[3] Food");

            Console.SetCursorPosition((Console.WindowWidth - 11) / 2, (Console.WindowHeight/2) - 0);
            Console.WriteLine("[4] Names");

            Console.SetCursorPosition((Console.WindowWidth - 11) / 2, (Console.WindowHeight/2) - (-1));
            Console.WriteLine("[5] Random");

            Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight-2);
                    
        }
        //not working
        public static void DisplaySettings()
        {
            DisplayHeader();
            // enable sounds, enable visuals, enable cursor , controls???
            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 4);
            Console.WriteLine("Settings: ");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 3);
            Console.WriteLine("[1] Sounds:");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 2);
            Console.WriteLine("[2] Visuals:");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - 1);
            Console.WriteLine("[3] Cursor:");

            Console.SetCursorPosition((Console.WindowWidth - 10) / 2, (Console.WindowHeight/2) - (-1));
            Console.WriteLine("[4] Go Back");

        }
        public static void DisplayHeader()
        {
            Console.WriteLine(@"
         .___  ___.  __  ___   ___     __  .___________.    __    __  .______          _______   ______    __  
         |   \/   | |  | \  \ /  /    |  | |           |   |  |  |  | |   _  \        /  _____| /  __  \  |  | 
         |  \  /  | |  |  \  V  /     |  | `---|  |----`   |  |  |  | |  |_)  |      |  |  __  |  |  |  | |  | 
         |  |\/|  | |  |   >   <      |  |     |  |        |  |  |  | |   ___/       |  | |_ | |  |  |  | |  | 
         |  |  |  | |  |  /  .  \     |  |     |  |        |  `--'  | |  |     __    |  |__| | |  `--'  | |__| 
         |__|  |__| |__| /__/ \__\    |__|     |__|         \______/  | _|    (_ )    \______|  \______/  (__) ");
            DisplayBorder(); 
       }
         public static void DisplayBorder(){ 
            Console.SetCursorPosition(0, 0);

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int a = 0; a < Console.WindowWidth; a++)
            {
                Console.SetCursorPosition(a,0);
                Console.Write("#");
            }
            for (int b = 0; b < Console.WindowHeight; b++)
            {
                Console.SetCursorPosition(0, b);
                Console.WriteLine("#");

            }

            for (int c = 0; c < Console.WindowHeight; c++)
            {
                Console.SetCursorPosition(Console.WindowWidth-1, c);
                Console.WriteLine("#");
            }
            for (int d = 0; d < Console.WindowWidth; d++)
            {
                Console.SetCursorPosition(d,Console.WindowHeight-1);
                Console.Write("#");
            }
            Console.SetCursorPosition(0,0);
            Console.ResetColor();

         }
        public static void DisplayGameOver()
        {
            Console.WriteLine(@"
              _______      ___      .___  ___.  _______      ______   ____    ____  _______ .______      
             /  _____|    /   \     |   \/   | |   ____|    /  __  \  \   \  /   / |   ____||   _  \     
            |  |  __     /  ^  \    |  \  /  | |  |__      |  |  |  |  \   \/   /  |  |__   |  |_)  |    
            |  | |_ |   /  /_\  \   |  |\/|  | |   __|     |  |  |  |   \      /   |   __|  |      /     
            |  |__| |  /  _____  \  |  |  |  | |  |____    |  `--'  |    \    /    |  |____ |  |\  \----.
             \______| /__/     \__\ |__|  |__| |_______|    \______/      \__/     |_______|| _| `._____|
                                                                                                                                                                             
");
            DisplayBorder();
                
        }
        private static string Input()
        {
            string retString = " ";

            int curIndex = 0;
            while (KeepRunning){
                ConsoleKeyInfo readKeyResult = Console.ReadKey(true);
                
                // handle Esc
                if (readKeyResult.Key == ConsoleKey.Escape)
                {
                    retString = "skip";
                    break;
                }

                // handle Tab
                if (readKeyResult.Key == ConsoleKey.Tab)
                {
                    retString = "scramble";
                    break;
                }

                // handle Enter
                if (readKeyResult.Key == ConsoleKey.Enter)
                {
                    break;
                }

                // handle backspace
                if (readKeyResult.Key == ConsoleKey.Backspace)
                {
                    if (curIndex > 0)
                    {
                        retString = retString.Remove(retString.Length - 1);
                        Console.Write(readKeyResult.KeyChar);
                        Console.Write(' ');
                        Console.Write(readKeyResult.KeyChar);
                        curIndex--;
                    }
                }
                else
                // handle all other keypresses
                {
                    retString += readKeyResult.KeyChar;
                    Console.Write(readKeyResult.KeyChar);
                    curIndex++;
                }
            }
            return retString;
        }
        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            KeepRunning = false;
            keybd_event((byte)0x0D, 0, 0, 0);
        }
        public static bool PlayAgain()
        {
            while (true)
            {
                ConsoleKeyInfo readKeyResult = Console.ReadKey(true);
                // handle Esc
                if (readKeyResult.Key == ConsoleKey.Escape)
                {
                    return false;
                }

                // handle Tab
                if (readKeyResult.Key == ConsoleKey.Tab)
                {
                    return true;
                }
            }
        }
        public static bool Settings(bool b)
        {
            if (b == true)
            {
                return false;
            }
            else{
                return true; 
            }
        }
        //auto enter
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
    }
}
