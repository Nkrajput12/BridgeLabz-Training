using System;  //LeetCode Question no 9 
class Palindrome{
 public static void Main(string[]args){
	int n = Convert.ToInt32(Console.ReadLine()); //Taking input
	
	if(IsPalindrome(n)) Console.WriteLine("palindrome");
	else Console.WriteLine("Not a palindrome");
	
 }
 public static bool IsPalindrome(int n) {
    if(n<0) return false; //palindrome
    int temp = n;
    int rev = 0;
    while(temp>0){
        int rem = temp%10;
        rev *= 10;
        rev += rem;
        temp /= 10;
    }

    return rev == n;
        
    }
 

}