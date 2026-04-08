using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.Wrapper;

[TestFixture]
public class DelegateTokenProviderTests
{
    [Test]
    public void Constructor_NullFactory_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() =>
            new DelegateTokenProvider(null!));
    }

    [Test]
    public async Task GetTokenAsync_ReturnsTokenFromDelegate()
    {
        var provider = new DelegateTokenProvider(_ => Task.FromResult("my-token"));

        var token = await provider.GetTokenAsync();

        Assert.That(token, Is.EqualTo("my-token"));
    }

    [Test]
    public async Task GetTokenAsync_InvokesDelegateOnEveryCall()
    {
        var callCount = 0;
        var provider = new DelegateTokenProvider(_ =>
        {
            callCount++;
            return Task.FromResult($"token-{callCount}");
        });

        var first = await provider.GetTokenAsync();
        var second = await provider.GetTokenAsync();

        Assert.That(callCount, Is.EqualTo(2));
        Assert.That(first, Is.EqualTo("token-1"));
        Assert.That(second, Is.EqualTo("token-2"));
    }

    [Test]
    public void GetTokenAsync_NullReturnFromDelegate_ThrowsInvalidOperationException()
    {
        var provider = new DelegateTokenProvider(_ => Task.FromResult<string>(null!));

        Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
    }

    [Test]
    public void GetTokenAsync_DelegateThrows_PropagatesException()
    {
        var provider = new DelegateTokenProvider(_ =>
            throw new InvalidOperationException("vault unavailable"));

        Assert.ThrowsAsync<InvalidOperationException>(() => provider.GetTokenAsync());
    }

    [Test]
    public async Task GetTokenAsync_PassesCancellationTokenToDelegate()
    {
        using var cts = new CancellationTokenSource();
        CancellationToken capturedCt = default;

        var provider = new DelegateTokenProvider(ct =>
        {
            capturedCt = ct;
            return Task.FromResult("token");
        });

        await provider.GetTokenAsync(cts.Token);

        Assert.That(capturedCt, Is.EqualTo(cts.Token));
    }

    [Test]
    public async Task GetTokenAsync_CancelledToken_ThrowsOperationCanceledException()
    {
        using var cts = new CancellationTokenSource();
        cts.Cancel();

        var provider = new DelegateTokenProvider(async ct =>
        {
            await Task.Delay(10000, ct);
            return "token";
        });

        // TaskCanceledException is a subclass of OperationCanceledException.
        try
        {
            await provider.GetTokenAsync(cts.Token);
            Assert.Fail("Expected OperationCanceledException to be thrown.");
        }
        catch (OperationCanceledException)
        {
            // Expected — pass
        }
    }
}
