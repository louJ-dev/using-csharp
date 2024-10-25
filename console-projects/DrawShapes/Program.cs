using System.Runtime.InteropServices;
using DrawShapes;

public class Program{

    // dont have any idea how this works... just copy pasted it
    // from: https://learn.microsoft.com/en-us/answers/questions/1630444/how-to-make-a-console-application-fullscreen-in-c
    [DllImport("kernel32.dll", ExactSpelling = true)]
    private static extern IntPtr GetConsoleWindow();
    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    private const int SW_MAXIMIZE = 3;

    static void Main(){
        Console.Clear();
        try{
            // tries to force maximize window...
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
        }catch{
            // if theres a problem... 
            for(int i = 30; i > 0; i--){
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

        // part of the thing above...
        IntPtr handle = GetConsoleWindow();
        ShowWindow(handle, SW_MAXIMIZE);

        Console.Clear();
        Console.SetCursorPosition(0, 0);

        const int menu_width = 39;
        const ConsoleColor colorBorder = ConsoleColor.DarkGray;
        
        string[] nameShapes = new string[]{
            "Line", "Stripped Line", "Square",
            "Parallelogram", "Triangle", "Reverse Triangle",
            "Isoceles Triangle", "Reverse Isoceles Triangle", "Hourglass",
            "Diamond", "Zero", "Up Arrow",
            "Down Arrow", "X", "Bow-tie"
        };

        // usable graphics for shapes...
        char[,] graphics = new char[,]{
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'},
            {'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I'},
            {'J', 'K', 'L', 'M', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0'},
            {'1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '$', '%', '^', '&', '*'},
            {'(', ')', '_', '-', '+', '=', '{', '}', '[', ']', '|', '\\', ':', '\"', '\'', '<', '>'},
            {',', '.', '?', '/', '~', '`', ';', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };      

        Console.Title = "Draw Shapes: ";

        int baseSize = 7;
        (int x, int y) indexGraphicA = (16, 3);
        (int x, int y) indexGraphicB = (2, 4);

        CancellationTokenSource source = new CancellationTokenSource(); 

        // Create Menu
        int index = 0; 
        while(true){
            // ***NOTE***
            // [... + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));]
            // all this trailing code some write frunctions is use to clear the board...
            // this needs to be fixed... I couldn't think of another way...
            // my previous attempts gives flickering effect... 

            Console.SetCursorPosition(0, 0);
            // Console.Clear();
            Console.ResetColor();
            
            // draw top border...
            Console.ForegroundColor = colorBorder;
            Console.WriteLine('\u250C' + TextLimiter(string.Empty, Console.WindowWidth - 3, '\u2500') + '\u2510');
            Console.WriteLine('\u2502' + TextLimiter(string.Empty, Console.WindowWidth - 3)+ '\u2502');
            Console.WriteLine('\u251C' + TextLimiter(string.Empty, menu_width, '\u2500') + TextLimiter("\u252C", (Console.WindowWidth - menu_width) - 3, '\u2500') + '\u2518');
            
            // put top info...
            Console.SetCursorPosition(1, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($" Draw [{nameShapes[index]}] w/ size [{baseSize}] and draw delay [{Shapes.drawDelay}]");
            
            // shape list menu...
            Console.SetCursorPosition(0, 3);
            for(int i = 0; i < nameShapes.Length; i++){
                Console.ForegroundColor = colorBorder;
                Console.Write('\u2502');

                string line = " ";
                if(i == index){
                    Console.ForegroundColor = ConsoleColor.Gray; 
                    line += "\u00BB ";
                } else {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }
                Console.Write(TextLimiter(line + nameShapes[i], menu_width));
            
                Console.ForegroundColor = colorBorder; 
                Console.WriteLine('\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            }
             
            // draw character list border...
            Console.WriteLine('\u251C' + TextLimiter(string.Empty, menu_width, '\u2500') + '\u2524' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            int top = Console.CursorTop;
            for(int y = 0; y < graphics.GetLength(0); y++){
                Console.WriteLine('\u2502' + TextLimiter(string.Empty, menu_width, ' ') + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            }

            Console.SetCursorPosition(1, top);

            // show available characters...
            for(int y = 0; y < graphics.GetLength(0); y++){
                Console.CursorLeft = 2;
                if(y != indexGraphicA.y || y != indexGraphicB.y){
                    Console.Write(" ");
                }
                for (int x = 0; x < graphics.GetLength(1); x++){ 
                    if(x == indexGraphicA.x && y == indexGraphicA.y || x == indexGraphicB.x && y == indexGraphicB.y){
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"[{graphics[y, x]}] ");
                    }else{
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(graphics[y, x] + " ");
                    }
                }
                Console.Write('\n');
            }

            // show instructions...
            Console.ForegroundColor = colorBorder;
            Console.WriteLine('\u251C' + TextLimiter(string.Empty, menu_width, '\u2500') + '\u2524' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" UP ARROW     - move pointer up", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" DOWN ARROW   - move pointer down", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" LEFT ARROW   - decrease shape size", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" RIGHT ARROW  - increase shape size", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" W A S D      - move graphicA selector", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" I J K L      - move graphicB selector", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" Q E          - change draw delay", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2502' + TextLimiter(" ENTER        - exit", menu_width) + '\u2502' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
            Console.WriteLine('\u2514' + TextLimiter(string.Empty, menu_width, '\u2500') + '\u2518' + TextLimiter(string.Empty, Console.WindowWidth - (menu_width + 3)));

            // set shape settings...
            Shapes.graphicA = graphics[indexGraphicA.y, indexGraphicA.x];
            Shapes.graphicB = graphics[indexGraphicB.y, indexGraphicB.x];
            Shapes.enableColorChange = true;

            source = new CancellationTokenSource();
            Task draw = new Task(() => DrawSelectedShape(index, baseSize, menu_width + 3, 3, source.Token));
            draw.Start();

            // Process Inputs
            ConsoleKeyInfo input = Console.ReadKey();

            // cancel current draw...
            source.Cancel();
            
            // move menu pointer..
            if(input.Key == ConsoleKey.UpArrow){
                index--;

                // set list boundaries
                if(index < 0){
                    index = 0;
                }
            }else if(input.Key == ConsoleKey.DownArrow){
                index++;

                // set list boundaries
                if(index >= nameShapes.Length){
                    index = nameShapes.Length - 1;
                }
            }

            // increase or decrease shape size...
            if(input.Key == ConsoleKey.RightArrow){
                baseSize++;

                int maxSize = Console.WindowHeight - 4; // - (menu_width + 4); 
                if(baseSize > maxSize){
                    baseSize = maxSize;
                }
            }else if(input.Key == ConsoleKey.LeftArrow){
                baseSize--;
            
                 if(baseSize < 3){
                    baseSize = 3;
                }
            }
            
            // move graphic_selector pointer A...
            if(input.Key == ConsoleKey.W){
                indexGraphicA.y--;
                if(indexGraphicA.y < 0){
                    indexGraphicA.y = 0;
                }
            }else if(input.Key == ConsoleKey.S){
                indexGraphicA.y++;
                if(indexGraphicA.y >= graphics.GetLength(0)){
                    indexGraphicA.y = graphics.GetLength(0) - 1;
                }
            }else if (input.Key == ConsoleKey.D){
                indexGraphicA.x++;
                if(indexGraphicA.x >= graphics.GetLength(1)){
                     indexGraphicA.x = graphics.GetLength(1) - 1;
                }  
            }else if (input.Key == ConsoleKey.A){
                indexGraphicA.x--;
                if(indexGraphicA.x < 0){
                    indexGraphicA.x = 0;
                }
            }
            
            // move graphic_selector pointer B...
            if(input.Key == ConsoleKey.I){
                indexGraphicB.y--;
                if(indexGraphicB.y < 0){
                    indexGraphicB.y = 0;
                }
            }else if(input.Key == ConsoleKey.K){
                indexGraphicB.y++;
                if(indexGraphicB.y >= graphics.GetLength(0)){
                    indexGraphicB.y = graphics.GetLength(0) - 1;
                }
            }else if (input.Key == ConsoleKey.L){
                indexGraphicB.x++;
                if(indexGraphicB.x >= graphics.GetLength(1)){
                     indexGraphicB.x = graphics.GetLength(1) - 1;
                }  
            }else if (input.Key == ConsoleKey.J){
                indexGraphicB.x--;
                if(indexGraphicB.x < 0){
                    indexGraphicB.x = 0;
                }
            }

            if(input.Key == ConsoleKey.Q){
                Shapes.SetDrawDelay(Shapes.drawDelay - 5);
            }else if(input.Key == ConsoleKey.E){
                Shapes.SetDrawDelay(Shapes.drawDelay + 5);
            }

            // exit... 
            if(input.Key == ConsoleKey.Enter){
                break;
            }
        }
        
        // move cursor to bottom of window...
        Console.SetCursorPosition(0, Console.WindowHeight - 2);
        Console.WriteLine("END");
    }

    static void DrawSelectedShape(int index, int baseSize, int posX, int posY, CancellationToken token){
        switch(index){
            case 0:
                Shapes.DrawLine(baseSize, token, posX, posY);
                break;
            case 1:
                Shapes.DrawStripedLine(baseSize, token, posX, posY);
                break;
            case 2:
                Shapes.DrawSquare(baseSize, token, posX, posY);
                break;
            case 3:
                Shapes.DrawParallelogram(baseSize, token, posX, posY);
                break;
            case 4:
                Shapes.DrawTriangle(baseSize, token, posX, posY);
                break;
            case 5:
                Shapes.DrawTriangleRev(baseSize, token, posX, posY);
                break;
            case 6:
                Shapes.DrawIsocelesTriangle(baseSize, token, posX, posY);
                break;
            case 7:
                Shapes.DrawIsocelesTriangleRev(baseSize, token, posX, posY);
                break;
            case 8:
                Shapes.DrawHourGlass(baseSize, token, posX, posY);
                break;
            case 9:
                Shapes.DrawDiamond(baseSize, token, posX, posY);
                break;
            case 10:
                Shapes.DrawZero(baseSize, token, posX, posY);
                break;
            case 11:
                Shapes.DrawArrowUp(baseSize, token, posX, posY);
                break;
            case 12:
                Shapes.DrawArrowDown(baseSize, token, posX, posY);
                break;
            case 13:
                Shapes.DrawX(baseSize, token, posX, posY);
                break;
            case 14:
                Shapes.DrawBowTie(baseSize, token, posX, posY);
                break;
        }
    }

    static string TextLimiter(string text, int lineWidth, char empty=' '){
        string result = string.Empty;
        for (int i = 0; i < lineWidth; i++){
            if(i < text.Length){
                result += text[i];
            }else{
                result += empty;
            }
        }
        return result;
    }
}
