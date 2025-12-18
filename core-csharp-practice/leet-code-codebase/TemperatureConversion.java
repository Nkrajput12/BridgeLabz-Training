import java.util.Scanner;
public class TemperatureConversion {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        float t = sc.nextFloat();

        float f = (t*9/5) + 32;
        System.out.println(f);
    }
}