# TDD Kata: Talking Stick

![.NET](https://img.shields.io/badge/.NET-10-512BD4?logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-14-239120?logo=csharp&logoColor=white)
![xUnit](https://img.shields.io/badge/tests-xUnit-5C2D91)
![TDD](https://img.shields.io/badge/made%20with-TDD-ff69b4)
![Talking Stick](https://img.shields.io/badge/🥢-who's%20got%20the%20stick%3F-brightgreen)

**The principle:** only the person holding the stick may speak. The stick is passed around among the participants, and those who want to speak can line up.

Each step is an expected behavior. This version of the kata is in C# on .NET 10. Students are free to choose their model and their names.

## Getting Started

The solution is `kata-sticky-talk-dotnet.slnx`. Tests use xUnit, with AwesomeAssertions for fluent assertions.

```sh
dotnet restore kata-sticky-talk-dotnet.slnx
dotnet test kata-sticky-talk-dotnet.slnx
```

Tests live in `Kata.Test/`. Delete `Kata.Test/SmokeTests.cs` once real tests exist.

## Phase 1: Possession

1. At the start, nobody holds the stick.
2. The first person in the list can take the free stick (they now hold it).
3. The person holding the stick may speak. The others may not.
4. When the holder releases the stick, another person must pick it up.

## Phase 2: Transmission

6. The person holding the stick can give it to someone else, who then holds it.
7. A person who does not hold the stick cannot give it.
8. Giving the stick to oneself makes no sense.
9. The stick can only be given to one person (at a time).
10. The stick cannot be given to no one (empty / nobody).

## Phase 3: The Circle

11. The stick belongs to a circle of participants defined in advance. A person outside the circle cannot take it.
13. The person holding the stick can pass it to their neighbor, following the order of the circle.
14. The last person in the circle passes the stick to the first.
15. A circle cannot be empty, and the same person cannot appear in it twice.

## Phase 4: Speaking Requests

16. A participant can request to speak. The request is then recorded.
17. Requesting to speak twice counts as once.
18. The person holding the stick cannot request to speak.
19. When the stick is passed on, it goes to the person who requested to speak first.
20. When the stick is passed on and nobody has requested to speak, nobody holds it anymore.
21. A participant can withdraw their speaking request.
22. As long as speaking requests are pending, nobody can take the stick without waiting their turn.

## Phase 5: Speaking Time

23. It is possible to know how long the person holding the stick has been speaking.
24. A maximum speaking time can be set. It is then possible to know whether the person holding the stick has exceeded it.
25. If the time is exceeded and someone has requested to speak, the stick automatically passes to that person.
26. If the time is exceeded and nobody has requested to speak, the person holding the stick keeps speaking.

## Phase 6: History (bonus)

27. It is possible to retrieve, in order, who has held the stick.
28. It is possible to know the total speaking time of each participant.
29. It is possible to know which participant has spoken the least.

## Notes for the Facilitator

- **Format:** pair ping-pong. A writes the test, B makes it pass and writes the next one. Roles switch every 5 to 7 minutes.
- **Duration:** phases 1 to 3 take about 1h30. Allow 2 to 3 hours to get through phase 5. Phase 6 is reserved for fast pairs.
- **Rule of the game:** do not read the next steps in advance. The design should emerge from the tests, not from anticipation.
- **The only imposed constraint:** tests must be fast and deterministic, including in phase 5.
- **Debrief points:**
    - Step 5: how did each pair express a refusal?
    - Step 11: what impact did the arrival of the circle have on the existing tests?
    - Step 19: a behavior that was already tested changes. What did you do with the affected test?
    - Step 23: how did you make time testable?
    - End of session: compare the pairs' designs. What makes them so different when they start from the same behaviors?

## DevPod Setup

This project runs in a dev container (image `mcr.microsoft.com/devcontainers/dotnet:10.0`, with the C# Dev Kit and C# extensions). The configuration is in `.devcontainer/devcontainer.json`. Its post-create step restores and tests the solution.
