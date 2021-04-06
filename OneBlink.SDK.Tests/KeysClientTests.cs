using System;
using System.IO;
using System.Net;
using dotenv.net;
using OneBlink.SDK;
using OneBlink.SDK.Model;
using Xunit;

namespace OneBlink.SDK.Tests
{
  public class KeysClientTests
  {
    private string ACCESS_KEY;
    private string SECRET_KEY;
    private string apiOrigin;

    public TeamMembersClientTests()
    {
        bool raiseException = false;
        DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
        ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
        SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
    }

    [Fact]
    public void throws_error_if_keys_empty()
    {
      try
      {
        KeysClient teamMembersClient = new KeysClient("", "");
        Assert.NotNull(null);
      }
      catch (Exception ex)
      {
        Assert.NotNull(ex);
      }
    }

    [Fact]
    public void can_be_constructed()
    {
      KeysClient keysClient = new KeysClient(ACCESS_KEY, SECRET_KEY);
      Assert.NotNull(keysClient);
    }

    [Fact]
    public async void can_get_developer_key()
    {
      KeysClient keysClient = new KeysClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
      DeveloperKey developerKey = await keysClient.GetDeveloperKey(ACCESS_KEY);
      Assert.NotNull(developerKey);
    }

    [Fact]
    public async void get_developer_key_should_throw_oneblink_exception()
    {
      OneBlinkAPIException oneBlinkAPIException = await Assert.ThrowsAsync<OneBlinkAPIException>(() =>
      {
        KeysClient keysClient = new KeysClient("123", "aaaaaaaaaaaaaaabbbbbbbbbbbbbbbcccccccccccccccc", TenantName.ONEBLINK_TEST);
        return keysClient.GetDeveloperKey(ACCESS_KEY);
      });
      Assert.Equal(HttpStatusCode.Unauthorized, oneBlinkAPIException.StatusCode);
    }

    [Fact]
    public async void get_developer_key_return_null()
    {
      KeysClient keysClient = new KeysClient(ACCESS_KEY, SECRET_KEY, TenantName.ONEBLINK_TEST);
      DeveloperKey developerKey = await keysClient.GetDeveloperKey("fake-key-id");
      Assert.Null(developerKey);
    }

  }
}