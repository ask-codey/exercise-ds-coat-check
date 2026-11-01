// Tries your coat check on five guests. Run it with: node demo.ts
import { CoatCheck } from "./coat-check.ts";

const room = new CoatCheck();

console.log(`Hooks at the start: ${room.bucketCount()}`);
console.log(`Maya goes to hook ${room.hookFor("Maya")}, and Zoe to hook ${room.hookFor("Zoe")}`);

room.put("Maya", "green raincoat");
room.put("Leo", "denim jacket");
room.put("Priya", "red scarf");
room.put("Zoe", "yellow umbrella");
room.put("Ben", "gray hoodie");

console.log(`Zoe's coat: ${room.get("Zoe") ?? "none"}`);
console.log(`After 5 coats: ${room.bucketCount()} hooks, load factor ${room.loadFactor()}`);

room.remove("Leo");
console.log(`After Leo leaves: ${room.size()} coats, Leo's coat: ${room.get("Leo") ?? "none"}`);
