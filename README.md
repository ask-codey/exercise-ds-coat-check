# Exercise: Build a Coat Check

Exercise code for the lesson **Exercise: Build a Coat Check** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

## The ticket

> **From:** the manager, Riverside Hall
>
> Saturday's concert sold 3,000 tickets, and the coat check's paper tickets run out on every big night. So from now on there are no tickets: guests say their name when they hand over a coat, and say it again to get it back.
>
> 1. **Every handout takes a moment,** whether 30 coats are hanging or 50,000. At 11 p.m. everyone wants their coat at once.
> 2. **No coat is ever lost or handed to the wrong person,** even when two names end up on the same hook. A guest who checks a second coat under the same name swaps it for the first.
> 3. **The rack grows.** We start with 4 hooks. When there are more coats than three-quarters of the hooks, we move to a room with twice as many hooks and hang every coat again.
> 4. **A guest who leaves early** can take their coat back off the rack.

The code that's there has the coat check's class, its 4 hooks, and the recipe that turns a name into a hook number: `hookFor`, the times-31 recipe from the lesson *Why Is Everyone on Hook 3? Hash Functions*. Five methods are yours to finish:

- `put` (`Put` in C#): hang a coat under a name, swapping the coat if the name is already there, and move to a bigger room when the rack is more than three-quarters full
- `get` (`Get`): the coat under a name, or nothing if nobody checked in under it
- `remove` (`Remove`): take a coat off its hook, and say whether there was one
- `loadFactor` (`LoadFactor`, `load_factor` in Python): how crowded the rack is, coats divided by hooks
- `resize` (`Resize`, `_resize`): moving day, twice the hooks, every coat hung again

Nine tests check it, ending with a busy night: 50,000 coats in and out, in under 2 seconds.

## Pick your language

The same exercise is here in five languages. Work in the folder for the language you set up; you only need one.

| Folder | Your code | The tests |
|---|---|---|
| `csharp/` | `BuildACoatCheck/CoatCheck.cs` | `BuildACoatCheck.Tests/CoatCheckTests.cs` |
| `java/` | `src/main/java/CoatCheck.java` | `src/test/java/CoatCheckTest.java` |
| `python/` | `coat_check.py` | `test_coat_check.py` |
| `javascript/` | `coat-check.js` | `coat-check.test.js` |
| `typescript/` | `coat-check.ts` | `coat-check.test.ts` |

Each method you finish does nothing, or returns an empty answer, for now. The comment above it says what it should do, with an example. Replace its body with your own code, and write its growth rate on its **Growth rate:** line.

Every folder also has a small demo program that tries your coat check on five guests. You don't need to change the tests or the demo.

## Run it and check your work

Open your language's folder in VS Code (**File > Open Folder**), then open its terminal (**Terminal > New Terminal**) and run these commands there.

**C#**

```bash
dotnet run --project BuildACoatCheck
dotnet test
```

**Java** (the Maven Wrapper downloads Maven the first time, so the first run takes a minute)

```bash
java src/main/java/Demo.java
./mvnw test
```

On Windows in PowerShell, write `.\mvnw test` instead of `./mvnw test`.

**Python** (once: make a virtual environment and install pytest into it)

```bash
python -m venv .venv
```

Then turn it on: `.venv\Scripts\Activate.ps1` in PowerShell on Windows, or `source .venv/bin/activate` on macOS (where the command is `python3`, not `python`). Then:

```bash
pip install -r requirements.txt
python demo.py
python -m pytest
```

**JavaScript**

```bash
node demo.js
npm test
```

**TypeScript** (once: `npm install`, which installs TypeScript)

```bash
node demo.ts
npm test
```

At first every test fails: that is expected. Each method you finish turns its tests green. A failing test's message starts with **Not yet:** and says what it expected.

<details>
<summary>Stuck?</summary>

- **Where to look:** the ticket asks for what the lesson *Finding Maya's Coat Without a Ticket: Hash Tables* builds, a **hash table**. `hookFor` turns a name into the one hook worth looking at, so `get`, `put` and `remove` never search the other hooks.
- **Two names on one hook:** each hook holds a list (a **chain**) of name-and-coat entries. Walk that one list and compare names, as in *Collisions: Two Coats, One Hook*.
- **Start with `get`.** Find the name's hook with `hookFor`, then walk along that hook's chain until an entry's name matches.
- **`put` checks the chain first.** If the name is already there, change that entry's coat and stop. Only a new name adds an entry and adds 1 to the count.
- **Resize after adding, not before.** "More than three-quarters full" is `count > 0.75 * bucketCount`, which you can write without decimals as `count * 4 > bucketCount * 3`.
- **In `resize`, make the new hooks first, then hang each coat again.** `hookFor` uses the current number of hooks, so once the new, bigger list of hooks is in place, it gives each name its new hook.

</details>

<details>
<summary>Why Should I Choose This?</summary>

Open this once your tests are green. The busy night is 50,000 coats hung and 50,000 handed back.

- **Coats in the order they arrive, checked one by one:** hanging is instant, but each handout reads name tags from the first hook, about 25,000 on average. That's O(n) per handout, over a billion name tags for the night, and the 2 seconds run out long before.
- **A rack kept in A to Z order:** a handout takes about 16 looks, halving the rack each time (O(log n)). But every arriving coat slides the coats after it along to make room, O(n) per coat: about 600 million moves to hang 50,000.
- **A hash table:** the name gives the hook (O(1)), the chain on it holds a coat or two, and moving day is rare: 15 moves on the way from 4 hooks to 131,072, each one twice as far from the last. So put and get are O(1) on average, and the busy night takes a fraction of a second.
- **What it gives up:** the hooks follow the recipe, not the alphabet. If the coat check also had to list every guest from A to Z, or everyone from Kai to Maya, a structure that keeps its keys in order would earn its place: a binary search tree, in Module 6.

</details>

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
