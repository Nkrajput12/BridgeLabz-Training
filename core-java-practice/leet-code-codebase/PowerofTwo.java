// Power of two Leetcode problem number 231

import java.util.Scanner;

public class PowerofTwo {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int number = sc.nextInt();

        System.out.println(isPowerOfTwo(number));
    }
    public static boolean isPowerOfTwo(int n) {
        if(n==1) return true;
        while(n>3){
            if(n%2!=0) return false;
            n/=2;
        }
        return n==2;
    }
}
