namespace TypingGame;

public class TypingGameMain
{
    string word;
    int pointer;

    public TypingGameMain(){
        word = "Can you type this fast? Try again: 3, 2, 1... Go!";
        pointer = 0;
    }

    public void Run(){
        Console.Clear();
        Console.ResetColor();
        Console.Title = "Typing Game: ";
        Console.SetCursorPosition(0, 0);

        Loop();
    }

    public void Loop(){
        ConsoleKeyInfo input = new ConsoleKeyInfo();
        while(true){
            Console.Clear();
            for(int i = 0; i < word.Length; i++){
                if(i > pointer){
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }else if(i == pointer){
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }else{
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                Console.Write(word[i]);
            }
            Console.WriteLine("\n" + input.KeyChar);
            
            if(pointer >= word.Length){
                break;
            } 
            
            while(!Console.KeyAvailable){
                // wait...
            }
            
            if(Console.KeyAvailable){
                input = Console.ReadKey(true);
                if(input.KeyChar == word[pointer]){
                    pointer++;
                }

                if(input.Key == ConsoleKey.Escape){
                    break;
                }
            }
        }

        GameOver();
    }

    public void GameOver(){
        Console.WriteLine("cleared...");
    }
}
