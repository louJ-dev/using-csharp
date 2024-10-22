namespace DrawShapes;

public static class Shapes{

    public static char graphicA;
    public static char graphicB;

    static Shapes(){
        graphicA = '*';
        graphicB = '_';
    }

	public static void DrawLine(int b, int posX = 0, int posY = 0){
	    string line = string.Empty;
	    for (int i = 0; i < b; i++){
	        line += graphicA;
	    }
        
        // Moving the shape in x axis 
        Console.SetCursorPosition(posX, posY++);
	    
        Console.WriteLine(line);
	}

	public static void DrawStripedLine(int b, int posX = 0, int posY = 0){
	    string line = string.Empty;
	    for(int i = 1; i <= b; i++){
	        if((i % 2) == 0){
	            line += graphicB;
	        }else{
	            line += graphicA;
	        }
	    }
        
        // Moving the shape in x axis 
        Console.SetCursorPosition(posX, posY++);
	    
        Console.WriteLine(line);
	}

	public static void DrawSquare(int b, int posX = 0, int posY = 0){
	    // int drawPosX = Console.GetCursorPosition().Left + 1;
        for(int y = 1; y <= b; y++){
	        string line = string.Empty;
            for (int x = 0; x < b; x++){
	            line += graphicA + " "; 
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            
            Console.WriteLine(line);
	    } 
	}

	public static void DrawParallelogram(int b, int posX = 0, int posY = 0){
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
	        }
	    
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        right--;
	        left--;
	    }
	}

	public static void DrawTriangle(int b, int posX = 0, int posY = 0){
	    int pointer = b;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= pointer){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }
	        }
	   
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        pointer--;
	    }
	}

	public static void DrawTriangleRev(int b, int posX = 0, int posY = 0){
	    int pointer = 1;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= pointer){
	                line += graphicA;
	            }else{
	                line += graphicB;
	            }
	        }  

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);
            
            Console.WriteLine(line);
	        pointer++;
	    }
	}

	public static void DrawIsocelesTriangle(int b, int posX = 0, int posY = 0){
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
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        left--;
	        right++;
	    }
	}


	public static void DrawIsocelesTriangleRev(int b, int posX = 0, int posY = 0) {
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
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        left++;
	        right--;
	    }
	}

	public static void DrawHourGlass(int b, int posX = 0, int posY = 0) {
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
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        
	        if(y < ((b - 1) / 2 + 1)){
	            left++;
	            right--;
	        }else{
	            left--;
	            right++;
	        }
	    }
	}

	public static void DrawDiamond(int b, int posX = 0, int posY = 0) {
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
	        }

            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        if(y < (b - 1) / 2 + 1){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }
	    }
	}    

	public static void DrawZero(int b, int posX = 0, int posY = 0) {
	    
	    string line = string.Empty;
	    for(int x = 0; x < b; x++){
	        line += graphicA;
	    }
	    
        // Moving the shape in x axis 
        Console.SetCursorPosition(posX, posY++);

        Console.WriteLine(line);
	    for(int y = 2; y < b; y++){
	        line = string.Empty + graphicA;
	        for(int x = 2; x < b; x++){
	            line += graphicB;
	        }
	        line += graphicA;
	        
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	    }
	    
	    line = string.Empty;
	    for(int x = 0; x < b; x++){    
	        line += graphicA;
	    }

        // Moving the shape in x axis 
        Console.SetCursorPosition(posX, posY++);

        Console.WriteLine(line);
	}

	public static void DrawArrowUp(int b, int posX = 0, int posY = 0) {
	    int left = (b - 1) / 2 + 1;
	    int right = left;
	    int half = (b - 1) / 2 + 1;

        ConsoleColor[] colors = new ConsoleColor[5];
        colors[0] = ConsoleColor.Green;
        colors[1] = ConsoleColor.Cyan;
        colors[2] = ConsoleColor.Yellow;
        colors[3] = ConsoleColor.DarkMagenta;
        colors[4] = ConsoleColor.DarkGray;

        int c = 0;

	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += graphicA;
	            }else{
	                line += graphicB;
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
            c++;
            if(c == 5){
                c = 0;
            }
            Console.ForegroundColor = colors[c];
            Console.WriteLine(line);
	    }
	}

	public static void DrawArrowDown(int b, int posX = 0, int posY = 0) {
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
	        }
	  
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        if(y == half - 1){
	            left = 1;
	            right = b;
	        }

	        if(y > half - 1){
	            left++;
	            right--;
	        }
	    }
	}

	public static void DrawX(int b, int posX = 0, int posY = 0) {
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
	        }
	 
            // Moving the shape in x axis 
            Console.SetCursorPosition(posX, posY++);

            Console.WriteLine(line);
	        if(y >= (b - 1) / 2 + 1){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }
	    }
	}

	public static void DrawBowTie(int b, int posX = 0, int posY = 0) {
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

            Console.WriteLine(line);
	    }
	}
}
