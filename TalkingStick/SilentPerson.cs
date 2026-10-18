namespace TalkingStick;

public record Participant(string Name)
{
    public bool CanTalk() => false;
}

public sealed record SilentPerson(string Name) : Participant(Name);

public sealed record VocalPerson(string Name) : Participant(Name)
{
    public bool CanTalk() => true;
}
