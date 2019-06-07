using System;
using Xunit;
using OneBlink.SDK;
using dotenv.net;
using System.IO;
namespace unit_tests
{
  public class FormsTest
  {
    private string ACCESS_KEY;
    private string SECRET_KEY;
    public FormsTest() {
      bool raiseException = false;
      DotEnv.Config(raiseException, Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "..")) + "/.env");
      ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
      SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");
    }
    
    [Fact]
    public void can_be_constructed()
    {
      Forms forms = new Forms(ACCESS_KEY, SECRET_KEY);
      Assert.NotNull(forms);
    }

    [Fact]
    public void throws_error_if_keys_empty()
    {
      try
      {
        Forms forms = new Forms(ACCESS_KEY, SECRET_KEY);
      }
      catch (Exception ex)
      {
        Assert.NotNull(ex);
      }
    }

    [Fact]
    public async void can_search_forms()
    {
      Forms forms = new Forms(ACCESS_KEY, SECRET_KEY);
      string response = await forms.search(null, null, null);
      Assert.NotNull(response);
    }

    [Fact]
    public async void can_search_forms_with_all_params()
    {
      Forms forms = new Forms(ACCESS_KEY, SECRET_KEY);
      string response = await forms.search(true, true, "Location test");
      Assert.NotNull(response);
    }
  }
}
