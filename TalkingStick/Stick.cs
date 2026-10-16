namespace TalkingStick;

public record Stick
{
    public bool IsBeingHeld { get; init; } = false;
    public VocalPerson Possessor { get; init; }

    public Stick Take(SilentPerson someone)
    {
        return this with { IsBeingHeld = true, Possessor = new VocalPerson(someone.Name) };
    }

}
