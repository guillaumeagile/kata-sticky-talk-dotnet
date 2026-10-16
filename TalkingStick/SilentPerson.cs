namespace TalkingStick;

public record SilentPerson(string Name)
{
    public bool CanTalk() => false;

}

public record VocalPerson(string Name)
{
    public bool CanTalk() => true;

}
