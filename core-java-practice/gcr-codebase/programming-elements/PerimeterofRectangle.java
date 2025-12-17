import java.util.Scanner;
public class perimeterofRectangle {

    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int Length = sc.nextInt();
        int width = sc.nextInt();

        int perimeter = 2*(Length+width);

        System.out.println(perimeter);
    }
}