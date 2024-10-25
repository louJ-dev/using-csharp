namespace DrawShapes;

public static class Shapes{

    public static char graphicA;
    public static char graphicB;
    public static bool enableColorChange;
    public static int drawDelay { get; private set; }

    public static int indexColor { get; private set; }

    private static ConsoleColor[] colors;

    static Shapes(){
        graphicA = '*';
        graphicB = '_';
        enableColorChange = false;
        drawDelay = 50;

        indexColor = 0;

        colors = new ConsoleColor[5];
        colors[0] = ConsoleColor.Green;
        colors[1] = ConsoleColor.Cyan;
        colors[2] = ConsoleColor.Yellow;
        colors[3] = ConsoleColor.DarkMagenta;
        colors[4] = ConsoleColor.DarkGray;
    }   

    public static void SetColorIndex(int index){
        if(index >= colors.Length){
            indexColor = 0;
        }else if(index < 0){
            indexColor = colors.Length - 1;
        }else{
            indexColor = index;
        }
    }

    public static void SetDrawDelay(int delay){
        drawDelay = delay;

        if(drawDelay < 0){
            drawDelay = 0;
        }else if(drawDelay > 1000){
            drawDelay = 1000;
        }
    }

    public static string[] GetAvailableColors(){
        string[] names = new string[colors.Length];
        for (int i = 0; i < colors.Length; i++){
            names[i] = colors[i].ToString();
        }

        return names;
    }

	public static async void DrawLine(int b, CancellationToken cToken, int posX = 0, int posY = 0){
	    string line = string.Empty;
        Console.SetCursorPosition(posX, posY);
	    for (int i = 0; i < b; i++){
            Console.ForegroundColor = colors[indexColor];
            if(cToken.IsCancellationRequested){
                return;
            }
	        
            Console.Write(graphicA);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    } 
	}

	public static async void DrawStripedLine(int b, CancellationToken cToken, int posX = 0, int posY = 0){
        Console.SetCursorPosition(posX, posY); 
        for(int i = 1; i <= b; i++){
            Console.ForegroundColor = colors[indexColor];
            if(cToken.IsCancellationRequested){
                return;
            }
	       
            if((i % 2) == 0){
	            Console.Write(graphicB);
	        }else{
	            Console.Write(graphicA);
	        }

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    } 
    }

	public static async void DrawSquare(int b, CancellationToken cToken, int posX = 0, int posY = 0){
        // make proportion to others...
        b /= 2;
        
        for(int y = 1; y <= b; y++){
	        string line = string.Empty;
            for (int x = 0; x < b; x++){
	            line += graphicA + " "; // this space cause the improportion, but it makes it more square-looking...
                if(cToken.IsCancellationRequested){
                    return;
                }
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    } 
	}

	public static async void DrawParallelogram(int b, CancellationToken cToken, int posX = 0, int posY = 0){
	    // make shape proportion to others... 
        b /= 2;
       
        int left = b;
	    int right = b * 2;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b * 2; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            right--;
            left--;
	    
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor];
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

    public static async void DrawTriangle(int b, CancellationToken cToken, int posX = 0, int posY = 0){
	    int right = b;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }
               
                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            right--;
	   
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);  
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line); 

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawTriangleRev(int b, CancellationToken cToken, int posX = 0, int posY = 0){
	    int right = 1;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            right++;

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor];            
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawIsocelesTriangle(int b, CancellationToken cToken, int posX = 0, int posY = 0){
	    int left = (b - 1) / 2 + 1; 
	    int right = (b - 1) / 2 + 1;
	    for(int y = 1; y <= (b - 1) / 2 + 1; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            left--;
            right++;;

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
        }
	}


	public static async void DrawIsocelesTriangleRev(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= (b - 1) / 2 + 1; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA; 
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            right--;
            left++;

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor];            
            Console.WriteLine(line); 

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawHourGlass(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = 1;
	    int right = b;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
	        if(y < ((b - 1) / 2 + 1)){
	            left++;
	            right--;
	        }else{
	            left--;
	            right++;
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor];
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
        }
	}

	public static async void DrawDiamond(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = (b - 1) / 2 + 1;
	    int right = left;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }

            if(y < (b - 1) / 2 + 1){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line); 

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            } 
	    }
	}    

	public static async void DrawZero(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	   for (int y = 1; y <= b; y++){
            string line = string.Empty;
            for (int x = 1; x <= b; x++){
                if(y == 1 || y == b || x == 1 || x == b){
                    line += graphicA;
                }else{
                    line += graphicB;
                }

                if(cToken.IsCancellationRequested){
                    return;
                }
            }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor];
            Console.WriteLine(line);
            
            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
        }
    }

	public static async void DrawArrowUp(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = (b - 1) / 2 + 1;
	    int right = left;
	    int half = (b - 1) / 2 + 1;

        for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            if(y < half){
	            left--;
	            right++;
	        }else{
	            left = half - ((half - 1) / 2);
	            right = half + ((half - 1) / 2);
	        }
	   
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);
            
            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawArrowDown(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int half = (b - 1) / 2 + 1;
	    int left = half - (half - 1) / 2;
	    int right = half + (half - 1) / 2;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            if(y == half - 1){
	            left = 1;
	            right = b;
	        }
	        if(y > half - 1){
	            left++;
	            right--;
	        }
	  
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawX(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x == left || x == right){
	                line += graphicA;
	            }else{
	                line += graphicB; 
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
            if(y >= (b - 1) / 2 + 1){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);
             
            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}

	public static async void DrawBowTie(int b, CancellationToken cToken, int posX = 0, int posY = 0) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x > left && x < right){
	                line += graphicB;
	            }else{
	                line += graphicA;
	            }

                if(cToken.IsCancellationRequested){
                    return;
                }
	        }
	        if(y > (b - 1) / 2){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }
	
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            Console.ForegroundColor = colors[indexColor]; 
            Console.WriteLine(line);

            await Task.Delay(drawDelay);

            if(enableColorChange){
                SetColorIndex(++indexColor);
            }
	    }
	}
}
