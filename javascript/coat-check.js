// A hash table from scratch: names are the keys, coats are the values.
// Each hook (bucket) holds a chain: a short list of entries ({ name, coat })
// whose names land on that hook. hookFor, bucketCount and size are written
// for you. The comment above each of the other methods says what it should
// do. Replace each one's body with your own code, and write its growth rate
// in its comment.

function newHooks(size) {
  return Array.from({ length: size }, () => []);
}

export class CoatCheck {
  hooks = newHooks(4);
  count = 0;

  // How many hooks the coat check has right now. It starts with 4.
  bucketCount() {
    return this.hooks.length;
  }

  // How many coats are hanging. Keep this.count up to date in put and remove.
  size() {
    return this.count;
  }

  // The times-31 recipe from the lesson "Hash Functions": multiply by 31,
  // add the next letter's code, keep the remainder. It always gives a
  // hook from 0 to bucketCount() - 1.
  hookFor(name) {
    let hash = 0;
    for (const letter of name) {
      hash = (hash * 31 + letter.charCodeAt(0)) % this.hooks.length;
    }
    return hash;
  }

  /*
   * Hang a coat under a name. If the name is already on its hook, replace
   * that coat (a name is never listed twice). Otherwise add a new entry to
   * the hook's chain and add 1 to the count. Then, if the coat check is
   * more than three-quarters full (size() > 0.75 * bucketCount()), call
   * this.resize().
   *
   * put("Maya", "green raincoat"), then put("Maya", "red scarf") -> get("Maya") is "red scarf", size() is 1
   *
   * Growth rate: (write it here)
   */
  put(name, coat) {
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
  get(name) {
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
  remove(name) {
    return false;
  }

  /*
   * How full the coat check is: coats divided by hooks.
   *
   * 3 coats on 4 hooks -> 0.75
   */
  loadFactor() {
    return 0;
  }

  /*
   * Moving day: make twice as many hooks, and hang every coat again on
   * its new hook (hookFor gives new answers once there are more hooks).
   * put calls this; nothing else does.
   *
   * Growth rate: (write it here)
   */
  resize() {
    // Your code here
  }
}
