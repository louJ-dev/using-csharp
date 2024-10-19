namespace DrawShapes;

public static class Shapes{
	public static void DrawLine(int b){
	    string line = string.Empty;
	    for (int i = 0; i < b; i++){
	        line += "*";
	    }
	    Console.WriteLine(line);
	}

	public static void DrawStripedLine(int b){
	    string line = string.Empty;
	    for(int i = 1; i <= b; i++){
	        if((i % 2) == 0){
	            line += "_";
	        }else{
	            line += "*";
	        }
	    }
	    Console.WriteLine(line);
	}

	public static void DrawSquare(int b){
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 0; x < b; x++){
	            line += "*"; 
	        }
	        Console.WriteLine(line);
	    }
	}

	public static void DrawParallelogram(int b){
	    int left = b;
	    int right = b * 2;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b * 2; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
	        Console.WriteLine(line);
	        right--;
	        left--;
	    }
	}

	public static void DrawTriangle(int b){
	    int pointer = b;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= pointer){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
	        Console.WriteLine(line);
	        pointer--;
	    }
	}

	public static void DrawTriangleRev(int b){
	    int pointer = 1;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x <= pointer){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
	        Console.WriteLine(line);
	        pointer++;
	    }
	}

	public static void DrawIsocelesTriangle(int b){
	    int left = (b - 1) / 2 + 1; 
	    int right = (b - 1) / 2 + 1;
	    for(int y = 1; y <= (b - 1) / 2 + 1; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
	        Console.WriteLine(line);
	        left--;
	        right++;
	    }
	}


	public static void DrawIsocelesTriangleRev(int b) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= (b - 1) / 2 + 1; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*"; 
	            }else{
	                line += "_";
	            }
	        }
	        Console.WriteLine(line);
	        left++;
	        right--;
	    }
	}

	public static void DrawHourGlass(int b) {
	    int left = 1;
	    int right = b;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
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

	public static void DrawDiamond(int b) {
	    int left = (b - 1) / 2 + 1;
	    int right = left;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
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

	public static void DrawZero(int b) {
	    
	    string line = string.Empty;
	    for(int x = 0; x < b; x++){
	        line += "*";
	    }
	    Console.WriteLine(line);
	    for(int y = 2; y < b; y++){
	        line = "*";
	        for(int x = 2; x < b; x++){
	            line += "_";
	        }
	        line += "*";
	        Console.WriteLine(line);
	    }
	    
	    line = string.Empty;
	    for(int x = 0; x < b; x++){    
	        line += "*";
	    }
	    Console.WriteLine(line);
	}

	public static void DrawArrowUp(int b) {
	    int left = (b - 1) / 2 + 1;
	    int right = left;
	    int half = (b - 1) / 2 + 1;
	    for(int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for(int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
	        if(y < half){
	            left--;
	            right++;
	        }else{
	            left = half - ((half - 1) / 2);
	            right = half + ((half - 1) / 2);
	        }
	       Console.WriteLine(line);
	    }
	}

	public static void DrawArrowDown(int b) {
	    int half = (b - 1) / 2 + 1;
	    int left = half - (half - 1) / 2;
	    int right = half + (half - 1) / 2;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x >= left && x <= right){
	                line += "*";
	            }else{
	                line += "_";
	            }
	        }
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

	public static void DrawX(int b) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x == left || x == right){
	                line += "*";
	            }else{
	                line += "_"; 
	            }
	        }
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

	public static void DrawBowTie(int b) {
	    int left = 1;
	    int right = b;
	    for (int y = 1; y <= b; y++){
	        string line = string.Empty;
	        for (int x = 1; x <= b; x++){
	            if(x > left && x < right){
	                line += "_";
	            }else{
	                line += "*";
	            }
	        }
	        if(y > (b - 1) / 2){
	            left--;
	            right++;
	        }else{
	            left++;
	            right--;
	        }
	        Console.WriteLine(line);
	    }
	}
}
