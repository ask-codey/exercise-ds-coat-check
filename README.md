# Exercise: Build a Coat Check

Exercise code for the lesson **Exercise: Build a Coat Check** in the course *Data Structures and Big-O, Demystified* on [ask-codey.com](https://www.ask-codey.com).

A concert's coat check has no tickets: your name is the ticket. You'll build it as a hash table from scratch, with chaining for names that share a hook and resizing when it gets too full. The hash function, `hookFor`, is already written (the times-31 recipe from the lesson *Hash Functions*). There are five methods to finish:

- `put` (`Put` in C#): hang a coat under a name, replacing the coat if the name is already there, and resize when the coat check is more than three-quarters full
- `get` (`Get`): the coat under a name, or nothing if nobody checked in under it
- `remove` (`Remove`): take a coat off its hook, and say whether there was one
- `loadFactor` (`LoadFactor`, `load_factor` in Python): how full the coat check is, coats divided by hooks
- `resize` (`Resize`, `_resize`): moving day, twice the hooks, every coat hung again

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

## Tips

- **Start with `get`.** Find the name's hook with `hookFor`, then walk along that hook's chain until an entry's name matches.
- **`put` checks the chain first.** If the name is already there, change that entry's coat and stop. Only a new name adds an entry and adds 1 to the count.
- **Resize after adding, not before.** "More than three-quarters full" is `count > 0.75 * bucketCount`, which you can write without decimals as `count * 4 > bucketCount * 3`.
- **In `resize`, make the new hooks first, then hang each coat again.** `hookFor` uses the current number of hooks, so once the new, bigger list of hooks is in place, it gives each name its new hook.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
