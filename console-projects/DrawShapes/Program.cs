using System.Runtime.InteropServices;
using DrawShapes;

public class Program{


    // ****from the internet****
    // dont have any idea how this works... just copy pasted it
    // from: https://learn.microsoft.com/en-us/answers/questions/1630444/how-to-make-a-console-application-fullscreen-in-c
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int SW_MAXIMIZE = 3;

    
    static void Main(){
        Console.Title = "Draw Shapes: ";
        try{
            // part of the code from the internet....
            IntPtr handle = GetConsoleWindow();
            ShowWindow(handle, SW_MAXIMIZE);

            // tries to force maximize window...
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }catch{
            // if theres a problem... 
            for(int i = 15; i > 0; i--){
                Console.Clear();
                if(i % 2 == 0){
                    Console.WriteLine($"        0            [{i}]");
                    Console.WriteLine("      -|-       ");
                    Console.WriteLine("       | l      ");
                    Console.WriteLine("       |>       ");
                    Console.WriteLine("      \'|       ");
                    Console.WriteLine("PLEASE MAXIMIZE WINDOW");
                    Thread.Sleep(150);
                }else{
                    Console.WriteLine($"          0          [{i}]");
                    Console.WriteLine("        -|-     ");
                    Console.WriteLine("      - |   -   ");
                    Console.WriteLine("       / \\     ");
                    Console.WriteLine("      /   |     ");
                    Console.WriteLine("PLEASE MAXIMIZE WINDOW");
                    Thread.Sleep(225);
                }
            }
        } 
    
        DrawShapeProgram program = new DrawShapeProgram();
        program.Run();

        Console.SetCursorPosition(0, Console.WindowHeight - 1);
    }
}
