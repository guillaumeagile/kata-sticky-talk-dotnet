namespace TalkingStick;

public  record Participant
{
    public bool CanTalk() => false;
}

public sealed record SilentPerson(string Name) : Participant
{

}

public sealed record VocalPerson(string Name) : Participant
{
    public bool CanTalk() => true;

}
