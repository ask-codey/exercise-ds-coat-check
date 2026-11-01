// The tests for your coat check. You don't need to change this file.
// Each message says what was expected, so a failing test tells you what to look at.
import assert from "node:assert/strict";
import { test } from "node:test";
import { CoatCheck } from "./coat-check.js";

test("get finds the coat put under a name", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  assert.equal(room.get("Maya"), "green raincoat", "Not yet: Maya's coat is the green raincoat.");
  assert.equal(room.get("Leo"), null, "Not yet: nobody checked in as Leo, so get gives null.");
});

test("putting the same name again replaces the coat", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  room.put("Maya", "red scarf");
  assert.equal(room.get("Maya"), "red scarf", "Not yet: Maya's second coat replaces her first.");
  assert.equal(room.size(), 1, "Not yet: Maya is one name, so size() is 1.");
});

test("size goes up with each new name", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  room.put("Leo", "denim jacket");
  room.put("Priya", "red scarf");
  assert.equal(room.size(), 3, "Not yet: three names are three coats.");
});

test("names that share a hook are both found", () => {
  const room = new CoatCheck();
  assert.equal(room.hookFor("Maya"), room.hookFor("Zoe"), "Maya and Zoe should share a hook: don't change hookFor.");
  room.put("Maya", "green raincoat");
  room.put("Zoe", "yellow umbrella");
  assert.equal(room.get("Maya"), "green raincoat", "Not yet: Maya and Zoe share hook 0, and Maya's coat is still the green raincoat.");
  assert.equal(room.get("Zoe"), "yellow umbrella", "Not yet: Maya and Zoe share hook 0, and Zoe's coat is the yellow umbrella.");
});

test("remove takes one coat off its hook", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  room.put("Zoe", "yellow umbrella");
  assert.equal(room.remove("Maya"), true, 'Not yet: Maya checked in, so remove("Maya") gives true.');
  assert.equal(room.get("Maya"), null, 'Not yet: after Maya leaves, get("Maya") gives null.');
  assert.equal(room.get("Zoe"), "yellow umbrella", "Not yet: removing Maya leaves Zoe's coat on the same hook.");
  assert.equal(room.size(), 1, "Not yet: after Maya leaves, one coat is left.");
  assert.equal(room.remove("Maya"), false, "Not yet: Maya has already left, so a second remove gives false.");
});

test("load factor is coats divided by hooks", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  room.put("Leo", "denim jacket");
  assert.ok(Math.abs(room.loadFactor() - 0.5) < 0.0001, "Not yet: 2 coats on 4 hooks is a load factor of 0.5.");
  room.put("Priya", "red scarf");
  assert.ok(Math.abs(room.loadFactor() - 0.75) < 0.0001, "Not yet: 3 coats on 4 hooks is a load factor of 0.75.");
});

test("grows when more than three-quarters full", () => {
  const room = new CoatCheck();
  room.put("Maya", "green raincoat");
  room.put("Leo", "denim jacket");
  room.put("Priya", "red scarf");
  assert.equal(room.bucketCount(), 4, "Not yet: 3 coats on 4 hooks is exactly three-quarters full, so no resize yet.");
  room.put("Zoe", "yellow umbrella");
  assert.equal(room.bucketCount(), 8, "Not yet: the 4th coat makes it more than three-quarters full, so the hooks double to 8.");
  assert.ok(Math.abs(room.loadFactor() - 0.5) < 0.0001, "Not yet: 4 coats on 8 hooks is a load factor of 0.5.");
});

test("every coat is found after many resizes", () => {
  const room = new CoatCheck();
  for (let i = 0; i < 1000; i++) {
    room.put(`Guest ${i}`, `Coat ${i}`);
  }
  assert.equal(room.size(), 1000, "Not yet: 1,000 guests left 1,000 coats.");
  assert.equal(room.bucketCount(), 2048, "Not yet: doubling from 4 hooks whenever it's more than three-quarters full ends at 2,048 hooks for 1,000 coats.");
  for (let i = 0; i < 1000; i++) {
    assert.equal(room.get(`Guest ${i}`), `Coat ${i}`, `Not yet: after resizing, every coat must be found again: Guest ${i} has Coat ${i}.`);
  }
});

test("a busy night stays fast", () => {
  const room = new CoatCheck();
  const started = performance.now();
  for (let i = 0; i < 50000; i++) {
    room.put(`Guest ${i}`, `Coat ${i}`);
  }
  for (let i = 0; i < 50000; i++) {
    assert.equal(room.get(`Guest ${i}`), `Coat ${i}`, `Not yet: on a busy night every coat must still be found: Guest ${i} has Coat ${i}.`);
  }
  const seconds = (performance.now() - started) / 1000;
  assert.ok(seconds < 2, `Not yet: 50,000 coats in and out took ${seconds.toFixed(1)} seconds. When put and get each work on one hook, it takes well under one.`);
});
