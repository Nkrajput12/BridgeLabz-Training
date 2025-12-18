using System;
public class Powercal {
    public static void Main(String[] args) {
        int num = 4;
		int powvalue = 2;
		int ans = 1;
        for(int i = 0;i<powvalue;i++){
             ans *= num;
        }

        Console.WriteLine(ans);
    }
}
