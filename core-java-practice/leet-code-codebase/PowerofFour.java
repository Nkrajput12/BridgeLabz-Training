// Power of four Leetcode problem number 342
import java.util.Scanner;
public class PowerofFour {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        int number = sc.nextInt();

        System.out.println(isPowerOfFour(number));
    }


    public static boolean isPowerOfFour(int n) {
        if(n<=0) return false;
        while(n!=0 && n>1){
            int rem = n%4;
            if(rem !=0) return false;
            n = n/4;
        }
        return true;        
        
    }
}
