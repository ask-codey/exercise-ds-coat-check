# A hash table from scratch: names are the keys, coats are the values.
# Each hook (bucket) holds a chain: a short list of entries whose names
# land on that hook. hook_for, bucket_count and size are written for you.
# The comment inside each of the other methods says what it should do.
# Replace each one's body with your own code, and write its growth rate
# in its comment.


class Entry:
    def __init__(self, name, coat):
        self.name = name
        self.coat = coat


def new_hooks(size):
    return [[] for _ in range(size)]


class CoatCheck:
    def __init__(self):
        self.hooks = new_hooks(4)
        self.count = 0

    def bucket_count(self):
        """How many hooks the coat check has right now. It starts with 4."""
        return len(self.hooks)

    def size(self):
        """How many coats are hanging. Keep self.count up to date in put and remove."""
        return self.count

    def hook_for(self, name):
        """
        The times-31 recipe from the lesson "Hash Functions": multiply by 31,
        add the next letter's code, keep the remainder. It always gives a
        hook from 0 to bucket_count() - 1.
        """
        hash_value = 0
        for letter in name:
            hash_value = (hash_value * 31 + ord(letter)) % len(self.hooks)
        return hash_value

    def put(self, name, coat):
        """
        Hang a coat under a name. If the name is already on its hook, replace
        that coat (a name is never listed twice). Otherwise add a new entry to
        the hook's chain and add 1 to the count. Then, if the coat check is
        more than three-quarters full (size() > 0.75 * bucket_count()), call
        self._resize().

        put("Maya", "green raincoat"), then put("Maya", "red scarf") -> get("Maya") is "red scarf", size() is 1

        Growth rate: (write it here)
        """
        pass

    def get(self, name):
        """
        The coat hanging under this name, or None if nobody checked in under it.
        Go to the name's hook and walk its chain.

        put("Maya", "green raincoat") -> get("Maya") is "green raincoat", get("Leo") is None

        Growth rate: (write it here)
        """
        return None

    def remove(self, name):
        """
        Take the coat under this name off its hook. Return True if there was
        one, False if nobody checked in under that name. Keep size() right.

        put("Maya", "green raincoat") -> remove("Maya") is True, then remove("Maya") is False

        Growth rate: (write it here)
        """
        return False

    def load_factor(self):
        """
        How full the coat check is: coats divided by hooks.

        3 coats on 4 hooks -> 0.75
        """
        return 0

    def _resize(self):
        """
        Moving day: make twice as many hooks, and hang every coat again on
        its new hook (hook_for gives new answers once there are more hooks).
        put calls this; nothing else does.

        Growth rate: (write it here)
        """
        pass
