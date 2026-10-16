using AwesomeAssertions;

namespace Kata.Test;

// Smoke test: proves that xUnit discovers and runs tests here, and that
// AwesomeAssertions' fluent `Should()` API is wired in. Delete once real tests exist.
public class SmokeTests
{
    [Fact]
    public void new_stick_is_not_being_held()
    {
        //ARRANGE
        var stick = new Stick();
        //ASSERT
        stick.IsBeingHeld.Should().BeFalse();
    }

    [Fact]
    public void tick_is_not_being_held()
    {
        //ARRANGE
        var stick = new Stick();
        //ACT
        var takenStick =  stick.Take();

        //ASSERT
        stick.IsBeingHeld.Should().BeFalse();
        takenStick.IsBeingHeld.Should().BeTrue();
    }
}

public record Stick
{
    public bool IsBeingHeld { get; init; } = false;

    public Stick Take()
    {
       return this with { IsBeingHeld = true };
    }
}
