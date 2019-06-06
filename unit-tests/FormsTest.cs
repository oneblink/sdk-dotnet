using System;
using Xunit;
using OneBlink.SDK;

namespace unit_tests
{
  public class FormsTest
  {
    private string ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
    private string SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");

    [Fact]
    public void can_be_constructed()
    {
      Forms forms = new Forms("a", "b");
    }

    [Fact]
    public void can_search_forms()
    {
      Forms forms = new Forms(ACCESS_KEY, SECRET_KEY); // TODO Get creds from config
      string response = forms.search(null, null, string.Empty);
      Assert.True(response != null);
      // Console.WriteLine("Response: " + response);
    }

    [Fact]
    public void can_search_forms_with_all_params()
    {
      Forms forms = new Forms(ACCESS_KEY, SECRET_KEY); // TODO Get creds from config
      string response = forms.search(true, true, "Location test");
      Assert.True(response != null);
      Console.WriteLine("Response: " + response);
    }
  }
}
