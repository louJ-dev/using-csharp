namespace DrawShapes;

public static class Text{
    public static string Limiter(string text, int lineWidth, char empty=' '){
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
