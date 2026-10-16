using AwesomeAssertions;
using TalkingStick;

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
        var alexandra = new  SilentPerson ("Alexandra");
        //ACT
        var takenStick =  stick.Take(alexandra);
        //ASSERT
        stick.IsBeingHeld.Should().BeFalse();
        takenStick.IsBeingHeld.Should().BeTrue();
    }

    [Fact]
    public void tick_is_being_taken_by_someone()
    {
        //ARRANGE
        var stick = new Stick();
        var alexandra = new  SilentPerson ("Alexandra");
        alexandra.CanTalk().Should().BeFalse();
        //ACT
        var takenStick =  stick.Take(alexandra);

        //ASSERT
        takenStick.Possessor.CanTalk().Should().BeTrue();
    }
}
