# The tests for your coat check. You don't need to change this file.
# Each message says what was expected, so a failing test tells you what to look at.
import time

from coat_check import CoatCheck


def test_get_finds_the_coat_put_under_a_name():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    assert room.get("Maya") == "green raincoat", "Not yet: Maya's coat is the green raincoat."
    assert room.get("Leo") is None, "Not yet: nobody checked in as Leo, so get gives None."


def test_putting_the_same_name_again_replaces_the_coat():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    room.put("Maya", "red scarf")
    assert room.get("Maya") == "red scarf", "Not yet: Maya's second coat replaces her first."
    assert room.size() == 1, "Not yet: Maya is one name, so size() is 1."


def test_size_goes_up_with_each_new_name():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    room.put("Leo", "denim jacket")
    room.put("Priya", "red scarf")
    assert room.size() == 3, "Not yet: three names are three coats."


def test_names_that_share_a_hook_are_both_found():
    room = CoatCheck()
    assert room.hook_for("Maya") == room.hook_for("Zoe"), "Maya and Zoe should share a hook: don't change hook_for."
    room.put("Maya", "green raincoat")
    room.put("Zoe", "yellow umbrella")
    assert room.get("Maya") == "green raincoat", \
        "Not yet: Maya and Zoe share hook 0, and Maya's coat is still the green raincoat."
    assert room.get("Zoe") == "yellow umbrella", \
        "Not yet: Maya and Zoe share hook 0, and Zoe's coat is the yellow umbrella."


def test_remove_takes_one_coat_off_its_hook():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    room.put("Zoe", "yellow umbrella")
    assert room.remove("Maya") is True, 'Not yet: Maya checked in, so remove("Maya") gives True.'
    assert room.get("Maya") is None, 'Not yet: after Maya leaves, get("Maya") gives None.'
    assert room.get("Zoe") == "yellow umbrella", "Not yet: removing Maya leaves Zoe's coat on the same hook."
    assert room.size() == 1, "Not yet: after Maya leaves, one coat is left."
    assert room.remove("Maya") is False, "Not yet: Maya has already left, so a second remove gives False."


def test_load_factor_is_coats_divided_by_hooks():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    room.put("Leo", "denim jacket")
    assert abs(room.load_factor() - 0.5) < 0.0001, "Not yet: 2 coats on 4 hooks is a load factor of 0.5."
    room.put("Priya", "red scarf")
    assert abs(room.load_factor() - 0.75) < 0.0001, "Not yet: 3 coats on 4 hooks is a load factor of 0.75."


def test_grows_when_more_than_three_quarters_full():
    room = CoatCheck()
    room.put("Maya", "green raincoat")
    room.put("Leo", "denim jacket")
    room.put("Priya", "red scarf")
    assert room.bucket_count() == 4, "Not yet: 3 coats on 4 hooks is exactly three-quarters full, so no resize yet."
    room.put("Zoe", "yellow umbrella")
    assert room.bucket_count() == 8, \
        "Not yet: the 4th coat makes it more than three-quarters full, so the hooks double to 8."
    assert abs(room.load_factor() - 0.5) < 0.0001, "Not yet: 4 coats on 8 hooks is a load factor of 0.5."


def test_every_coat_is_found_after_many_resizes():
    room = CoatCheck()
    for i in range(1000):
        room.put(f"Guest {i}", f"Coat {i}")
    assert room.size() == 1000, "Not yet: 1,000 guests left 1,000 coats."
    assert room.bucket_count() == 2048, \
        "Not yet: doubling from 4 hooks whenever it's more than three-quarters full ends at 2,048 hooks for 1,000 coats."
    for i in range(1000):
        assert room.get(f"Guest {i}") == f"Coat {i}", \
            f"Not yet: after resizing, every coat must be found again: Guest {i} has Coat {i}."


def test_a_busy_night_stays_fast():
    room = CoatCheck()
    started = time.perf_counter()
    for i in range(50000):
        room.put(f"Guest {i}", f"Coat {i}")
    for i in range(50000):
        assert room.get(f"Guest {i}") == f"Coat {i}",             f"Not yet: on a busy night every coat must still be found: Guest {i} has Coat {i}."
    seconds = time.perf_counter() - started
    assert seconds < 2, f"Not yet: 50,000 coats in and out took {seconds:.1f} seconds. When put and get each work on one hook, it takes well under one."
