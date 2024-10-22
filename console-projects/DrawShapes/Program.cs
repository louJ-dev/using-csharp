using DrawShapes;

public class Program{
    static void Main(){
        const int menu_width = 38;

        string[] nameShapes = new string[]{
            "line", "line-striped", "square",
            "parallelogram", "triangle", "triangle-reverse",
            "isoceles-triangle", "isoceles-triangle-revese", "hourglass",
            "diamond", "zero", "arrow-up",
            "arrow-down", "X", "bow-tie"
        };

        // usable graphics for shapes...
        char[,] graphics = new char[,]{
            {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o'},
            {'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D'},
            {'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'O', 'P', 'Q', 'R', 'S', 'T', 'U'},
            {'V', 'W', 'X', 'Y', 'Z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'},
            {'!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '_', '-', '+', '=', '{'},
            {'}', '[', ']', '|', '\\', ':', ';', '\"', '\'', '<', '>', ',', '.', '?', '/'},
            {'~', '`', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '}
        };      

        Console.Title = "Draw Shapes: ";

        int baseSize = 7;
        (int x, int y) indexGraphicA = (7, 4);
        (int x, int y) indexGraphicB = (10, 4);
        
        // Create Menu
        int index = 0; 
        while(true){
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine($"Draw [{nameShapes[index]}] w/ size [{baseSize}]");
            Console.WriteLine(TextLimiter(string.Empty, menu_width, '-') + TextLimiter("+", menu_width, '-'));
            Console.ForegroundColor = ConsoleColor.Cyan;
            for(int i = 0; i < nameShapes.Length; i++){
                string line = string.Empty;
                
                int lineWidth = menu_width;
                if(i == index){
                    line += "> ";
                    lineWidth -= 2;
                }

                line += TextLimiter(nameShapes[i], lineWidth);
                Console.WriteLine(line + "|");
            }
           
            // show instructions...
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(TextLimiter(string.Empty, menu_width, '_') + "|");
            Console.WriteLine(TextLimiter("UP ARROW     - move pointer up", menu_width) + "|");
            Console.WriteLine(TextLimiter("DOWN ARROW   - move pointer down", menu_width) + "|");
            Console.WriteLine(TextLimiter("LEFT ARROW   - decrease shape size", menu_width) + "|");
            Console.WriteLine(TextLimiter("RIGHT ARROW  - increase shape size", menu_width) + "|");
            Console.WriteLine(TextLimiter("WASD         - move graphicA selector", menu_width) + "|");
            Console.WriteLine(TextLimiter("IJKL         - move graphicB selector", menu_width) + "|");
            Console.WriteLine(TextLimiter("ENTER        - select shape", menu_width) + "|");
            Console.WriteLine(TextLimiter(string.Empty, menu_width, '-') + "+");

            for(int y = 0; y < graphics.GetLength(0); y++){
                for (int x = 0; x < graphics.GetLength(1); x++){
                    if(x == indexGraphicA.x && y == indexGraphicA.y || x == indexGraphicB.x && y == indexGraphicB.y){
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"[{graphics[y, x]}] ");
                    }else{
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(graphics[y, x] + " ");
                    }
                }
                Console.Write('\n');
            }
                 
            Shapes.graphicA = graphics[indexGraphicA.y, indexGraphicA.x];
            Shapes.graphicB = graphics[indexGraphicB.y, indexGraphicB.x];

            // show live shape view...
            DrawSelectedShape(index, baseSize, menu_width + 2, 2);

            // Process Inputs
            ConsoleKeyInfo input = Console.ReadKey();

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

                if(baseSize > 49){
                    baseSize = 49;
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
            
            // Draw selected
            if(input.Key == ConsoleKey.Enter){
                break;
            }
        }
        
        // move cursor to bottom of window...
        Console.SetCursorPosition(0, Console.BufferHeight - 2);
        Console.WriteLine("END");  
    }

    static void DrawSelectedShape(int index, int baseSize, int posX, int posY){
        switch(index){
            case 0:
                Shapes.DrawLine(baseSize, posX, posY);
                break;
            case 1:
                Shapes.DrawStripedLine(baseSize, posX, posY);
                break;
            case 2:
                Shapes.DrawSquare(baseSize, posX, posY);
                break;
            case 3:
                Shapes.DrawParallelogram(baseSize, posX, posY);
                break;
            case 4:
                Shapes.DrawTriangle(baseSize, posX, posY);
                break;
            case 5:
                Shapes.DrawTriangleRev(baseSize, posX, posY);
                break;
            case 6:
                Shapes.DrawIsocelesTriangle(baseSize, posX, posY);
                break;
            case 7:
                Shapes.DrawIsocelesTriangleRev(baseSize, posX, posY);
                break;
            case 8:
                Shapes.DrawHourGlass(baseSize, posX, posY);
                break;
            case 9:
                Shapes.DrawDiamond(baseSize, posX, posY);
                break;
            case 10:
                Shapes.DrawZero(baseSize, posX, posY);
                break;
            case 11:
                Shapes.DrawArrowUp(baseSize, posX, posY);
                break;
            case 12:
                Shapes.DrawArrowDown(baseSize, posX, posY);
                break;
            case 13:
                Shapes.DrawX(baseSize, posX, posY);
                break;
            case 14:
                Shapes.DrawBowTie(baseSize, posX, posY);
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
