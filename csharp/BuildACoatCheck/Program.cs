using BuildACoatCheck;

// Tries your coat check on five guests. Run it with: dotnet run --project BuildACoatCheck
CoatCheck room = new CoatCheck();

Console.WriteLine("Hooks at the start: " + room.BucketCount);
Console.WriteLine("Maya goes to hook " + room.HookFor("Maya") + ", and Zoe to hook " + room.HookFor("Zoe"));

room.Put("Maya", "green raincoat");
room.Put("Leo", "denim jacket");
room.Put("Priya", "red scarf");
room.Put("Zoe", "yellow umbrella");
room.Put("Ben", "gray hoodie");

Console.WriteLine("Zoe's coat: " + (room.Get("Zoe") ?? "none"));
Console.WriteLine("After 5 coats: " + room.BucketCount + " hooks, load factor " + room.LoadFactor());

room.Remove("Leo");
Console.WriteLine("After Leo leaves: " + room.Count + " coats, Leo's coat: " + (room.Get("Leo") ?? "none"));
