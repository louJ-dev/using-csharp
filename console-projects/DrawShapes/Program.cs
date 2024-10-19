using DrawShapes;

public class Program{
    static void Main(){
        int baseSize = -1;
        do{
            Console.Clear();
            Console.WriteLine("[?] number >= +3 and isOdd");
            Console.Write("Enter a number: ");
            baseSize = int.Parse(Console.ReadLine() ?? "0");
        } while(!(baseSize >= 3 && baseSize % 2 != 0));

        int index = 0;
        string[] nameShapes = new string[]{
            "line", "line-striped", "square",
            "parallelogram", "triangle", "triangle-reverse",
            "isoceles-triangle", "isoceles-triangle-revese", "hourglass",
            "diamond", "zero", "arrow-up",
            "arrow-down", "X", "bow-tie"
        };
        while(true){
            Console.Clear();
            Console.WriteLine($"Draw {nameShapes[index]} w/ base size {baseSize}\n");
            for(int i = 0; i < nameShapes.Length; i++){
                if(i == index){
                    Console.WriteLine($"> {nameShapes[i]}");
                }else{
                    Console.WriteLine($"{nameShapes[i]}");
                }
            }
            Console.WriteLine("\nUP ARROW\t- move pointer up");
            Console.WriteLine("DOWN ARROW\t- move pointer down");
            Console.WriteLine("ENTER\t\t- select shape");
            
            ConsoleKeyInfo input = Console.ReadKey();
            
            // Move index
            if(input.Key == ConsoleKey.UpArrow){
                index--;
            }else if(input.Key == ConsoleKey.DownArrow){
                index++;
            }
            
            // Set list boundaries
            if(index >= nameShapes.Length){
                index = nameShapes.Length - 1;
            }else if(index < 0){
                index = 0;
            }

            // Draw selected
            if(input.Key == ConsoleKey.Enter){
                break;
            }
        }

        switch(index){
            case 0:
                Shapes.DrawLine(baseSize);
                break;
            case 1:
                Shapes.DrawStripedLine(baseSize);
                break;
            case 2:
                Shapes.DrawSquare(baseSize);
                break;
            case 3:
                Shapes.DrawParallelogram(baseSize);
                break;
            case 4:
                Shapes.DrawTriangle(baseSize);
                break;
            case 5:
                Shapes.DrawTriangleRev(baseSize);
                break;
            case 6:
                Shapes.DrawIsocelesTriangle(baseSize);
                break;
            case 7:
                Shapes.DrawIsocelesTriangleRev(baseSize);
                break;
            case 8:
                Shapes.DrawHourGlass(baseSize);
                break;
            case 9:
                Shapes.DrawDiamond(baseSize);
                break;
            case 10:
                Shapes.DrawZero(baseSize);
                break;
            case 11:
                Shapes.DrawArrowUp(baseSize);
                break;
            case 12:
                Shapes.DrawArrowDown(baseSize);
                break;
            case 13:
                Shapes.DrawX(baseSize);
                break;
            case 14:
                Shapes.DrawBowTie(baseSize);
                break;
        }

        Console.WriteLine("END");
        
        /* TEST
        Console.WriteLine("\nline...");
        Shapes.DrawLine(testVal);
        Console.WriteLine("\nstriped...");
        Shapes.DrawStripedLine(testVal);
        Console.WriteLine("\nsquare...");
        Shapes.DrawSquare(testVal);
        Console.WriteLine("\nparallelogram...");
        Shapes.DrawParallelogram(testVal);
        Console.WriteLine("\ntriangle...");
        Shapes.DrawTriangle(testVal);
        Console.WriteLine("\ntriangle.reverse...");
        Shapes.DrawTriangleRev(testVal);
        Console.WriteLine("\nisoceles.triangle...");
        Shapes.DrawIsocelesTriangle(testVal);
        Console.WriteLine("\nisoceles.traingle.reverse...");
        Shapes.DrawIsocelesTriangleRev(testVal);
        Console.WriteLine("\nhourglass...");
        Shapes.DrawHourGlass(testVal);
        Console.WriteLine("\ndiamond...");
        Shapes.DrawDiamond(testVal);
        Console.WriteLine("\nzero...");
        Shapes.DrawZero(testVal);
        Console.WriteLine("\narrow.up...");
        Shapes.DrawArrowUp(testVal);
        Console.WriteLine("\narrow.down...");
        Shapes.DrawArrowDown(testVal);
        Console.WriteLine("\nx...");
        Shapes.DrawX(testVal);
        Console.WriteLine("\nbow.tie...");
        Shapes.DrawBowTie(testVal);
        */
    }
}