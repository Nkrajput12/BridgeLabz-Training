import java.util.Scanner;
public class ConvertKmtom {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        
        int KM = sc.nextInt();
        sc.close();
        int meter = KM*1000;
        System.out.println(meter+"m");
    }
}