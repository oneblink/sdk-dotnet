using System;
using Xunit;
using OneBlink.SDK;
using System.Net.Http;
namespace unit_tests
{
  public class PdfTests
  {
    private string ACCESS_KEY = Environment.GetEnvironmentVariable("ACCESS_KEY");
    private string SECRET_KEY = Environment.GetEnvironmentVariable("SECRET_KEY");

    [Fact]
    public void can_be_constructed()
    {
      Pdf pdf = new Pdf(ACCESS_KEY, SECRET_KEY);
      Assert.NotNull(pdf);
    }

    [Fact]
    public async void can_generate_pdf()
    {
      Pdf pdf = new Pdf(ACCESS_KEY, SECRET_KEY);

      string response = await pdf.generate(1477, "be89c14d-e61b-4ecb-9a39-258cde05e2f5");
      Console.WriteLine("response!!!!!!!" + response);

      //Assert.NotNull(response);
    }

  }
}
