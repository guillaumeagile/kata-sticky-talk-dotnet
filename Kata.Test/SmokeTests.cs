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
        var takenStick =  stick.GivenTo(alexandra);
        //ASSERT
        stick.IsBeingHeld.Should().BeFalse();
        takenStick.IsBeingHeld.Should().BeTrue();
    }

    [Fact]
    public void stick_posessor_can_talk()
    {
        //ARRANGE
        var stick = new Stick();
        var alexandra = new  SilentPerson ("Alexandra");
        alexandra.CanTalk().Should().BeFalse();
        //ACT
        var takenStick =  stick.GivenTo(alexandra);

        //ASSERT
        takenStick.Possessor.CanTalk().Should().BeTrue();

    }

    [Fact]
    public void a_silent_person_can_take_the_stick_from_vocal_person()
    {
        //ARRANGE
        var stick = new Stick();
        var alexandra = new  SilentPerson ("Alexandra");
        var harald = new SilentPerson("Harald");
        //ACT
        var takenStick =  stick.GivenTo(alexandra);
        var talkingAlexandra = takenStick.Possessor;

        var stickToHarald = takenStick.GivenTo(harald);

        stickToHarald.IsBeingHeld.Should().BeTrue();
        stickToHarald.Possessor.Name.Should().Be(harald.Name);

        stickToHarald.CanTalk()
    }
}
