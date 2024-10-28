using System.Diagnostics;

namespace DrawShapes;

public class DrawShapeProgram{
    private static int menu_width;
    private static ConsoleColor colorBorder;
    private static string[] nameShapes;
    private static char[,] graphics; 

    static DrawShapeProgram(){
        menu_width = 39;
        colorBorder = ConsoleColor.DarkGray;
        
        nameShapes = new string[]{
            "Line", "Stripped Line", "Square",
            "Parallelogram", "Triangle", "Reverse Triangle",
            "Isoceles Triangle", "Reverse Isoceles Triangle", "Hourglass",
            "Diamond", "Zero", "Up Arrow",
            "Down Arrow", "X", "Bow-tie"
        };
        
        graphics = new char[,]{
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q'},
            {'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'F', 'G', 'H', 'I'},
            {'J', 'K', 'L', 'M', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '0'},
            {'1', '2', '3', '4', '5', '6', '7', '8', '9', '!', '@', '#', '$', '%', '^', '&', '*'},
            {'(', ')', '_', '-', '+', '=', '{', '}', '[', ']', '|', '\\', ':', '\"', '\'', '<', '>'},
            {',', '.', '?', '/', '~', '`', ';', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };

    }

    private int baseSize;
    private int maxSize;
    private int indexShapeList;
    private (int x, int y) indexGraphicA;
    private (int x, int y) indexGraphicB;

    private Stopwatch inputTimer;
    private ConsoleKeyInfo prevInput;
    private CancellationTokenSource source;

    public DrawShapeProgram(){
         baseSize = 7;
         maxSize = Console.WindowWidth - 4;
         indexShapeList = 0;
         indexGraphicA = (16, 3);
         indexGraphicB = (2, 4);

         inputTimer = new Stopwatch();
         prevInput = new ConsoleKeyInfo();
         source = new CancellationTokenSource();
    }

    public void Run(){
        Console.Clear();
        Console.SetCursorPosition(0, 0);
        Console.CursorVisible = false;

        MainLoop();
    }

    private void MainLoop(){
        inputTimer.Start();        
       
        while(true){
            // reset... 
            Console.SetCursorPosition(0, 0);
            Console.ResetColor();
            
            ShowInformationBar();
            Console.SetCursorPosition(0, 3);
            ShowShapeList();
            ShowCharacterList();
            ShowInstructions();

#region Cleans DrawBoard
            string cleaner = string.Empty;
            for(int x = 0; x < Console.WindowWidth - (menu_width + 3); x++){
                cleaner += " ";
            }

            Console.SetCursorPosition(menu_width + 3, 3);
            for(int y = 0; y < Console.WindowHeight - 4; y++){
                Console.CursorLeft = menu_width + 3;
                Console.WriteLine(cleaner);
            }
#endregion
            // determine max size
            if(indexShapeList == 0 || indexShapeList == 1){
                maxSize = Console.WindowWidth - (menu_width + 4);
            }else if(indexShapeList >= 8 && indexShapeList <= 15){
                maxSize = Console.WindowHeight - 4;
            }else{
                maxSize = Console.WindowHeight - 4;
            }

            // clamp baseSize
            if(baseSize <= 3){
                baseSize = 3;
            }else if(baseSize >= maxSize){
                baseSize = maxSize;
            }

            // set shape settings...
            Shapes.graphicA = graphics[indexGraphicA.y, indexGraphicA.x];
            Shapes.graphicB = graphics[indexGraphicB.y, indexGraphicB.x];
            Shapes.enableColorChange = true;

            source = new CancellationTokenSource();
            
            // start drawing shape...
            Task draw = new Task(() => DrawSelectedShape(indexShapeList, baseSize, menu_width + 3, 3, source.Token));
            draw.Start(); 

/// <summary>
/// BUG: input_handling
///  Simultanious inputs cause input handling problems
///  This affects all processes dependant to input handling...
/// </summary>
#region Input Handling        
            ConsoleKeyInfo input = new ConsoleKeyInfo();
            while(true){
                if(Console.KeyAvailable){
                    input = Console.ReadKey(true);   

                    // exit... 
                    if(input.Key == ConsoleKey.Enter){
                        // move cursor to bottom of window...
                        Console.SetCursorPosition(0, Console.WindowHeight - 2);
                        Console.WriteLine("END");
                        return;
                    }

                    if((input == prevInput && inputTimer.ElapsedMilliseconds > 350) || input != prevInput){
                        prevInput = input;
                        inputTimer.Restart();
                        source.Cancel();

                        switch(input.Key){
                            case ConsoleKey.UpArrow: // move shape_list pointer up
                                indexShapeList--;
                                if(indexShapeList < 0){
                                    indexShapeList = 0; // set list boundaries
                                }
                                break;
                            case ConsoleKey.DownArrow: // move shape_list pointer down
                                indexShapeList++;
                                if(indexShapeList >= nameShapes.Length){
                                    indexShapeList = nameShapes.Length - 1; // set list boundaries
                                }
                                break;
                            case ConsoleKey.RightArrow: // increase shape size
                                baseSize++;                                
                                break;
                            case ConsoleKey.LeftArrow: // decrease shape size
                                baseSize--;
                                break;
                            case ConsoleKey.W: // move graphics-A_selector up
                                indexGraphicA.y--;
                                if(indexGraphicA.y < 0){
                                    indexGraphicA.y = 0;
                                }
                                break;
                            case ConsoleKey.S: // move graphics-A_selector down
                                indexGraphicA.y++;
                                if(indexGraphicA.y >= graphics.GetLength(0)){
                                    indexGraphicA.y = graphics.GetLength(0) - 1;
                                }
                                break;
                            case ConsoleKey.D: // move graphics-A_selector right
                                indexGraphicA.x++;
                                if(indexGraphicA.x >= graphics.GetLength(1)){
                                    indexGraphicA.x = graphics.GetLength(1) - 1;
                                }  
                                break;
                            case ConsoleKey.A: // move graphics-A_selector left
                                indexGraphicA.x--;
                                if(indexGraphicA.x < 0){
                                    indexGraphicA.x = 0;
                                }
                                break;
                            case ConsoleKey.I: // move graphics-B_selector up
                                indexGraphicB.y--;
                                if(indexGraphicB.y < 0){
                                    indexGraphicB.y = 0;
                                }
                                break;
                            case ConsoleKey.K: // move graphics-B_selector down
                                indexGraphicB.y++;
                                if(indexGraphicB.y >= graphics.GetLength(0)){
                                    indexGraphicB.y = graphics.GetLength(0) - 1;
                                }
                                break;
                            case ConsoleKey.L: // move graphics-B_selector right
                                indexGraphicB.x++;
                                if(indexGraphicB.x >= graphics.GetLength(1)){
                                    indexGraphicB.x = graphics.GetLength(1) - 1;
                                }  
                                break;
                            case ConsoleKey.J: // move graphics-B_selector left
                                indexGraphicB.x--;
                                if(indexGraphicB.x < 0){
                                    indexGraphicB.x = 0;
                                }
                                break;
                            case ConsoleKey.E: // increase draw delay thus slowing draw speed
                                Shapes.SetDrawDelay(Shapes.drawDelay + 5);
                                break;
                            case ConsoleKey.Q: // decrease draw delay thus speeding draw speed
                                Shapes.SetDrawDelay(Shapes.drawDelay - 5);
                                break;
                        }
     
                        // exit input loop...
                        break;
                    }
                }
            }
#endregion
        }
    }

#region UI
    private void ShowInformationBar(){
         // draw top border...
        Console.ForegroundColor = colorBorder;
        Console.WriteLine('\u250C' + Text.Limiter(string.Empty, Console.WindowWidth - 3, '\u2500') + '\u2510');
        Console.WriteLine('\u2502' + Text.Limiter(string.Empty, Console.WindowWidth - 3)+ '\u2502');
        Console.WriteLine('\u251C' + Text.Limiter(string.Empty, menu_width, '\u2500') + Text.Limiter("\u252C", (Console.WindowWidth - menu_width) - 3, '\u2500') + '\u2518');
        
        // put top info...
        Console.SetCursorPosition(1, 1);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" Draw [{nameShapes[indexShapeList]}] w/ size [{baseSize}] and draw delay [{Shapes.drawDelay}]");
    }

    private void ShowShapeList(){
        for(int i = 0; i < nameShapes.Length; i++){
            Console.ForegroundColor = colorBorder;
            Console.Write('\u2502');
            string line = " ";
            if(i == indexShapeList){
                Console.ForegroundColor = ConsoleColor.Gray; 
                line += "\u00BB ";
            } else{
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            Console.Write(Text.Limiter(line + nameShapes[i], menu_width));
        
            Console.ForegroundColor = colorBorder; 
            Console.WriteLine('\u2502' + Text.Limiter(string.Empty, Console.WindowWidth - (menu_width + 3)));
        }
    }

    private void ShowCharacterList(){
        // draw character list border...
        Console.WriteLine('\u251C' + Text.Limiter(string.Empty, menu_width, '\u2500') + '\u2524');
        int top = Console.CursorTop;
        for(int y = 0; y < graphics.GetLength(0); y++){
            Console.WriteLine('\u2502' + Text.Limiter(string.Empty, menu_width, ' ') + '\u2502');
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
    }

    private void ShowInstructions(){
        // show instructions...
        Console.ForegroundColor = colorBorder;
        Console.WriteLine('\u251C' + Text.Limiter(string.Empty, menu_width, '\u2500') + '\u2524');
        Console.WriteLine('\u2502' + Text.Limiter(" UP ARROW     - move pointer up", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" DOWN ARROW   - move pointer down", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" LEFT ARROW   - decrease shape size", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" RIGHT ARROW  - increase shape size", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" W A S D      - move graphicA selector", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" I J K L      - move graphicB selector", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" Q E          - change draw delay", menu_width) + '\u2502'); 
        Console.WriteLine('\u2502' + Text.Limiter(" ENTER        - exit", menu_width) + '\u2502'); 
        Console.WriteLine('\u2514' + Text.Limiter(string.Empty, menu_width, '\u2500') + '\u2518'); 
    }
#endregion

    /// <summary>
    /// Gets the current index in the lists then calls the right Shapes.Draw<Shape>() function.
    /// </summary>
    private void DrawSelectedShape(int index, int baseSize, int posX, int posY, CancellationToken token){
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
}
