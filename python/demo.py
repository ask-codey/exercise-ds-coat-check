# Tries your coat check on five guests. Run it with: python demo.py
from coat_check import CoatCheck

room = CoatCheck()

print(f"Hooks at the start: {room.bucket_count()}")
print(f"Maya goes to hook {room.hook_for('Maya')}, and Zoe to hook {room.hook_for('Zoe')}")

room.put("Maya", "green raincoat")
room.put("Leo", "denim jacket")
room.put("Priya", "red scarf")
room.put("Zoe", "yellow umbrella")
room.put("Ben", "gray hoodie")

print(f"Zoe's coat: {room.get('Zoe') or 'none'}")
print(f"After 5 coats: {room.bucket_count()} hooks, load factor {room.load_factor()}")

room.remove("Leo")
print(f"After Leo leaves: {room.size()} coats, Leo's coat: {room.get('Leo') or 'none'}")
