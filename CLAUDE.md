# CLAUDE.md

## What this repo is

A TDD kata in C# on .NET 10: **Talking Stick**. The full list of behaviors is in
`README.en.md`, organized in phases (possession, transmission, circle, speaking requests,
speaking time, history). The kata is about the process, not the design: the design should
emerge from the tests.

## Stack and commands

- .NET 10 SDK, C# 14, nullable and implicit usings enabled.
- Tests: xUnit, with AwesomeAssertions for fluent assertions (`using AwesomeAssertions;`,
  then `value.Should()...`).
- Solution: `kata-sticky-talk-dotnet.slnx`. Test project: `Kata.Test/`.

```sh
dotnet test kata-sticky-talk-dotnet.slnx
```

## How we work: TDD by the book

Follow Kent Beck's cycle strictly:

1. **Red.** Write one failing test for the next behavior. Run it and check that it fails
   for the right reason (an assertion, not a compile error or a typo).
2. **Green.** Write the simplest code that makes it pass, even if it is ugly. Hardcoding
   a return value is fine ("fake it"). Only generalize when a second test forces it
   ("triangulate").
3. **Refactor.** Only when all tests are green. Remove duplication, improve names, and run
   the tests after each change. Never refactor while red.

Rules that go with the cycle:

- One behavior per test, and one failing test at a time.
- Write the test before the production code, every time. No production code without a
  failing test that demands it.
- Take the smallest step that moves the tests forward. If a step gets big, write a
  smaller test.
- Keep a short list of the next behaviors to test. Don't implement anything that is not
  on the list or the current test.
- Don't read ahead in `README.en.md`. Implement the behaviors in order, phase by phase,
  and let the next test decide the design.
- Don't edit a test just to make it pass. If a passing test has to change because the
  behavior changed (README step 19), make that change deliberately, in its own red-green
  cycle.

## Test rules

- Tests must be fast and deterministic. No real clocks, no sleeps, no randomness, no I/O.
- For speaking time (phase 5), inject time instead of reading the system clock. Prefer
  `System.TimeProvider`, and fake it in tests with `FakeTimeProvider` from
  `Microsoft.Extensions.TimeProvider.Testing`, adding the package when we first need it.
- Test names describe the behavior in plain language, for example
  `Taking_a_free_stick_makes_the_taker_its_holder`.
- Tests use the public API only. Don't expose internals just to test them.
- The test project is `Kata.Test/`. Production code goes in its own project (for example
  `TalkingStick/`), referenced from the test project. Create it with the first test that
  needs it, not before.

## Scope and changes

- Make small, reviewable changes that match the current red-green step.
- Don't add dependencies, packages, or features that no test asks for.
- Don't commit or push unless asked.
- Before reporting a step done, run `dotnet test kata-sticky-talk-dotnet.slnx` and report
  the actual result, including failures.
