import java.util.ArrayList;
import java.util.List;

// A hash table from scratch: names are the keys, coats are the values.
// Each hook (bucket) holds a chain: a short list of entries whose names
// land on that hook. hookFor, bucketCount and size are written for you.
// The comment above each of the other methods says what it should do.
// Replace each one's body with your own code, and write its growth rate
// in its comment.
public class CoatCheck {
    static class Entry {
        String name;
        String coat;

        Entry(String name, String coat) {
            this.name = name;
            this.coat = coat;
        }
    }

    private List<List<Entry>> hooks = newHooks(4);
    private int count = 0;

    // How many hooks the coat check has right now. It starts with 4.
    public int bucketCount() {
        return hooks.size();
    }

    // How many coats are hanging. Keep the count field up to date in put and remove.
    public int size() {
        return count;
    }

    // The times-31 recipe from the lesson "Hash Functions": multiply by 31,
    // add the next letter's code, keep the remainder. It always gives a
    // hook from 0 to bucketCount() - 1.
    public int hookFor(String name) {
        int hash = 0;
        for (char letter : name.toCharArray()) {
            hash = (hash * 31 + letter) % hooks.size();
        }
        return hash;
    }

    private static List<List<Entry>> newHooks(int size) {
        List<List<Entry>> fresh = new ArrayList<>();
        for (int i = 0; i < size; i++) {
            fresh.add(new ArrayList<>());
        }
        return fresh;
    }

    /*
     * Hang a coat under a name. If the name is already on its hook, replace
     * that coat (a name is never listed twice). Otherwise add a new entry to
     * the hook's chain and add 1 to the count. Then, if the coat check is
     * more than three-quarters full (size() > 0.75 * bucketCount()), call resize.
     *
     * put("Maya", "green raincoat"), then put("Maya", "red scarf") -> get("Maya") is "red scarf", size() is 1
     *
     * Growth rate: (write it here)
     */
    public void put(String name, String coat) {
        // Your code here
    }

    /*
     * The coat hanging under this name, or null if nobody checked in under it.
     * Go to the name's hook and walk its chain.
     *
     * put("Maya", "green raincoat") -> get("Maya") is "green raincoat", get("Leo") is null
     *
     * Growth rate: (write it here)
     */
    public String get(String name) {
        return null;
    }

    /*
     * Take the coat under this name off its hook. Return true if there was
     * one, false if nobody checked in under that name. Keep size() right.
     *
     * put("Maya", "green raincoat") -> remove("Maya") is true, then remove("Maya") is false
     *
     * Growth rate: (write it here)
     */
    public boolean remove(String name) {
        return false;
    }

    /*
     * How full the coat check is: coats divided by hooks.
     *
     * 3 coats on 4 hooks -> 0.75
     */
    public double loadFactor() {
        return 0;
    }

    /*
     * Moving day: make twice as many hooks, and hang every coat again on
     * its new hook (hookFor gives new answers once there are more hooks).
     * put calls this; nothing else does.
     *
     * Growth rate: (write it here)
     */
    private void resize() {
        // Your code here
    }
}
