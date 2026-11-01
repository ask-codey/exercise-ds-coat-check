namespace BuildACoatCheck;

// A hash table from scratch: names are the keys, coats are the values.
// Each hook (bucket) holds a chain: a short list of entries whose names
// land on that hook. HookFor, BucketCount and Count are written for you.
// The comment above each of the other methods says what it should do.
// Replace each one's body with your own code, and write its growth rate
// in its comment.
public class CoatCheck
{
    public class Entry
    {
        public string Name;
        public string Coat;

        public Entry(string name, string coat)
        {
            Name = name;
            Coat = coat;
        }
    }

    private List<List<Entry>> hooks = NewHooks(4);
    private int count = 0;

    // How many hooks the coat check has right now. It starts with 4.
    public int BucketCount => hooks.Count;

    // How many coats are hanging. Keep the count field up to date in Put and Remove.
    public int Count => count;

    // The times-31 recipe from the lesson "Hash Functions": multiply by 31,
    // add the next letter's code, keep the remainder. It always gives a
    // hook from 0 to BucketCount - 1.
    public int HookFor(string name)
    {
        int hash = 0;
        foreach (char letter in name)
        {
            hash = (hash * 31 + letter) % hooks.Count;
        }
        return hash;
    }

    private static List<List<Entry>> NewHooks(int size)
    {
        List<List<Entry>> fresh = new List<List<Entry>>();
        for (int i = 0; i < size; i++)
        {
            fresh.Add(new List<Entry>());
        }
        return fresh;
    }

    /*
     * Hang a coat under a name. If the name is already on its hook, replace
     * that coat (a name is never listed twice). Otherwise add a new entry to
     * the hook's chain and add 1 to the count. Then, if the coat check is
     * more than three-quarters full (Count > 0.75 * BucketCount), call Resize.
     *
     * Put("Maya", "green raincoat"), then Put("Maya", "red scarf") -> Get("Maya") is "red scarf", Count is 1
     *
     * Growth rate: (write it here)
     */
    public void Put(string name, string coat)
    {
        // Your code here
    }

    /*
     * The coat hanging under this name, or null if nobody checked in under it.
     * Go to the name's hook and walk its chain.
     *
     * Put("Maya", "green raincoat") -> Get("Maya") is "green raincoat", Get("Leo") is null
     *
     * Growth rate: (write it here)
     */
    public string? Get(string name)
    {
        return null;
    }

    /*
     * Take the coat under this name off its hook. Return true if there was
     * one, false if nobody checked in under that name. Keep Count right.
     *
     * Put("Maya", "green raincoat") -> Remove("Maya") is true, then Remove("Maya") is false
     *
     * Growth rate: (write it here)
     */
    public bool Remove(string name)
    {
        return false;
    }

    /*
     * How full the coat check is: coats divided by hooks.
     *
     * 3 coats on 4 hooks -> 0.75
     */
    public double LoadFactor()
    {
        return 0;
    }

    /*
     * Moving day: make twice as many hooks, and hang every coat again on
     * its new hook (HookFor gives new answers once there are more hooks).
     * Put calls this; nothing else does.
     *
     * Growth rate: (write it here)
     */
    private void Resize()
    {
        // Your code here
    }
}
