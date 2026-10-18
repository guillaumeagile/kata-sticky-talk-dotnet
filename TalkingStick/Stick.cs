using OneOf;

namespace TalkingStick;

public record Stick
{
    public OneOf<Free, Held> State { get; init; } = new Free();

    public record Free;
    public record Held(Participant Holder);
    public bool IsBeingHeld { get; init; } = false;
    public VocalPerson Possessor { get; init; }

    public Stick GivenTo(SilentPerson someone)
    {
        return this with { IsBeingHeld = true, Possessor = new VocalPerson(someone.Name) };
    }

    public bool CanTalk(Participant someone) =>
        IsBeingHeld && Possessor.Name == someone.Name;



}
