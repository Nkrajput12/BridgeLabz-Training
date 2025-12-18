import java.util.Scanner;
public class VolumeofCylinder {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);

        System.out.println("enter radius");
        double radius = sc.nextDouble();

        System.out.println("enter height");
        double height = sc.nextDouble();

        sc.close();

        double vol = 3.14*radius*radius*height;

        System.out.println("volume of cylinder = "+vol);
    }
}
