import java.util.Scanner;
public class Powercal {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("enter number");
        int num = sc.nextInt();

        System.out.println("enter number power");
        long ans = 1;
        sc.close();
        for(int i = 0;i<num;i++){
             ans *= num;
        }

        System.out.println(ans);
    }
}
