class BFI
{
    public static void Main()
    {
        int[] arr = new int[30000];
        int index = 0;
        
        string code = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.";

        for (int i = 0; i < code.Length; i++)
        {
            switch (code[i])
            {
                case '<':
                    if (index > 0) index--;
                    else return;
                    break;
                case '>':
                    if (index < 30000) index++;
                    else return;
                    break;
                case '+':
                    arr[index]++;
                    break;
                case '-':
                    arr[index]--;
                    break;
                case '.':
                    Console.Write((char)arr[index]);
                    break;
                case ',':
                    arr[index] = Int32.Parse(Console.ReadLine());
                    break;
                case '[':
                    if (arr[index] != 0)
                        break;
                    i = LeftBracket(code, i);
                    if (i == -1) return;
                    break;
                case ']':
                    if (arr[index] == 0)
                        break;
                    i = RightBracket(code, i);
                    if (i == -1) return;
                    break;
            }
        }
    }

    private static int LeftBracket(string code, int i)
    {
        int counter = 1;
        for (int ind = i+1; ind < 30000; ind++)
        {
            if (code[ind] == '[')
                counter++;
            else if (code[ind] == ']')
                counter--;

            if (counter == 0)
                return i+1;
        }
        return -1;
    }

    private static int RightBracket(string code, int i)
    {
        int counter = 1;
        for (int ind = i-1; ind >= 0 ; ind--)
        {
            if (code[ind] == ']')
                counter++;
            else if (code[ind] == '[')
                counter--;
            
            if (counter == 0)
                return ind;
        }
        return -1;
    }
}