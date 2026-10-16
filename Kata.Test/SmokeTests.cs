using AwesomeAssertions;

namespace Kata.Test;

// Smoke test: proves that xUnit discovers and runs tests here, and that
// AwesomeAssertions' fluent `Should()` API is wired in. Delete once real tests exist.
public class SmokeTests
{
    [Fact]
    public void Fluent_assertions_and_xunit_work_together()
    {
        var greeting = string.Concat("Sticky", " ", "Talk");

        greeting.Should()
            .NotBeNullOrWhiteSpace()
            .And.StartWith("Sticky")
            .And.HaveLength(11);
    }
}
