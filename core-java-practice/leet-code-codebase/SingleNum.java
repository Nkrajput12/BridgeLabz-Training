// leetcode problem single number problem no 136

import java.util.*;

public class SingleNum {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int n = sc.nextInt();

        int[] arr = new int[n];

        for(int i = 0;i<n;i++){
            arr[i] = sc.nextInt();
        }

        System.out.println(singleNumber(arr));
    }

     public static int singleNumber(int[] nums) {
       
     int xor=0;
        for(int i=0;i<nums.length;i++)
        {
            xor=xor^nums[i];
        }
        return xor;
    }
}
