using DrawShapes;

public class Program{
    static void Main(){
        int testVal = -1;
        do{
            Console.Clear();
            Console.WriteLine("? Num should be odd  +3 to +infinity");
            Console.Write("Enter a number: ");
            testVal = int.Parse(Console.ReadLine());
        } while(!(testVal >= 3 && testVal % 2 != 0));

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
    }
}