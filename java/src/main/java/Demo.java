// Tries your coat check on five guests. Run it with: java src/main/java/Demo.java
public class Demo {
    public static void main(String[] args) {
        CoatCheck room = new CoatCheck();

        System.out.println("Hooks at the start: " + room.bucketCount());
        System.out.println("Maya goes to hook " + room.hookFor("Maya") + ", and Zoe to hook " + room.hookFor("Zoe"));

        room.put("Maya", "green raincoat");
        room.put("Leo", "denim jacket");
        room.put("Priya", "red scarf");
        room.put("Zoe", "yellow umbrella");
        room.put("Ben", "gray hoodie");

        String zoesCoat = room.get("Zoe");
        System.out.println("Zoe's coat: " + (zoesCoat == null ? "none" : zoesCoat));
        System.out.println("After 5 coats: " + room.bucketCount() + " hooks, load factor " + room.loadFactor());

        room.remove("Leo");
        String leosCoat = room.get("Leo");
        System.out.println("After Leo leaves: " + room.size() + " coats, Leo's coat: " + (leosCoat == null ? "none" : leosCoat));
    }
}
