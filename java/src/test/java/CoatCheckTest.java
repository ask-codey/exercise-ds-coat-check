import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertNull;
import static org.junit.jupiter.api.Assertions.assertTrue;

import org.junit.jupiter.api.Test;

// The tests for your coat check. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
class CoatCheckTest {
    @Test
    void getFindsTheCoatPutUnderAName() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        assertEquals("green raincoat", room.get("Maya"), "Not yet: Maya's coat is the green raincoat.");
        assertNull(room.get("Leo"), "Not yet: nobody checked in as Leo, so get gives null.");
    }

    @Test
    void puttingTheSameNameAgainReplacesTheCoat() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        room.put("Maya", "red scarf");
        assertEquals("red scarf", room.get("Maya"), "Not yet: Maya's second coat replaces her first.");
        assertEquals(1, room.size(), "Not yet: Maya is one name, so size() is 1.");
    }

    @Test
    void sizeGoesUpWithEachNewName() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        room.put("Leo", "denim jacket");
        room.put("Priya", "red scarf");
        assertEquals(3, room.size(), "Not yet: three names are three coats.");
    }

    @Test
    void namesThatShareAHookAreBothFound() {
        CoatCheck room = new CoatCheck();
        assertEquals(room.hookFor("Maya"), room.hookFor("Zoe"), "Maya and Zoe should share a hook: don't change hookFor.");
        room.put("Maya", "green raincoat");
        room.put("Zoe", "yellow umbrella");
        assertEquals("green raincoat", room.get("Maya"), "Not yet: Maya and Zoe share hook 0, and Maya's coat is still the green raincoat.");
        assertEquals("yellow umbrella", room.get("Zoe"), "Not yet: Maya and Zoe share hook 0, and Zoe's coat is the yellow umbrella.");
    }

    @Test
    void removeTakesOneCoatOffItsHook() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        room.put("Zoe", "yellow umbrella");
        assertTrue(room.remove("Maya"), "Not yet: Maya checked in, so remove(\"Maya\") gives true.");
        assertNull(room.get("Maya"), "Not yet: after Maya leaves, get(\"Maya\") gives null.");
        assertEquals("yellow umbrella", room.get("Zoe"), "Not yet: removing Maya leaves Zoe's coat on the same hook.");
        assertEquals(1, room.size(), "Not yet: after Maya leaves, one coat is left.");
        assertFalse(room.remove("Maya"), "Not yet: Maya has already left, so a second remove gives false.");
    }

    @Test
    void loadFactorIsCoatsDividedByHooks() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        room.put("Leo", "denim jacket");
        assertEquals(0.5, room.loadFactor(), 0.0001, "Not yet: 2 coats on 4 hooks is a load factor of 0.5.");
        room.put("Priya", "red scarf");
        assertEquals(0.75, room.loadFactor(), 0.0001, "Not yet: 3 coats on 4 hooks is a load factor of 0.75.");
    }

    @Test
    void growsWhenMoreThanThreeQuartersFull() {
        CoatCheck room = new CoatCheck();
        room.put("Maya", "green raincoat");
        room.put("Leo", "denim jacket");
        room.put("Priya", "red scarf");
        assertEquals(4, room.bucketCount(), "Not yet: 3 coats on 4 hooks is exactly three-quarters full, so no resize yet.");
        room.put("Zoe", "yellow umbrella");
        assertEquals(8, room.bucketCount(), "Not yet: the 4th coat makes it more than three-quarters full, so the hooks double to 8.");
        assertEquals(0.5, room.loadFactor(), 0.0001, "Not yet: 4 coats on 8 hooks is a load factor of 0.5.");
    }

    @Test
    void everyCoatIsFoundAfterManyResizes() {
        CoatCheck room = new CoatCheck();
        for (int i = 0; i < 1000; i++) {
            room.put("Guest " + i, "Coat " + i);
        }
        assertEquals(1000, room.size(), "Not yet: 1,000 guests left 1,000 coats.");
        assertEquals(2048, room.bucketCount(), "Not yet: doubling from 4 hooks whenever it's more than three-quarters full ends at 2,048 hooks for 1,000 coats.");
        for (int i = 0; i < 1000; i++) {
            assertEquals("Coat " + i, room.get("Guest " + i), "Not yet: after resizing, every coat must be found again: Guest " + i + " has Coat " + i + ".");
        }
    }

    @Test
    void aBusyNightStaysFast() {
        CoatCheck room = new CoatCheck();
        long started = System.nanoTime();
        for (int i = 0; i < 50000; i++) {
            room.put("Guest " + i, "Coat " + i);
        }
        for (int i = 0; i < 50000; i++) {
            assertEquals("Coat " + i, room.get("Guest " + i), "Not yet: on a busy night every coat must still be found: Guest " + i + " has Coat " + i + ".");
        }
        double seconds = (System.nanoTime() - started) / 1e9;
        assertTrue(seconds < 2, "Not yet: 50,000 coats in and out took %.1f seconds. When put and get each work on one hook, it takes well under one.".formatted(seconds));
    }
}
