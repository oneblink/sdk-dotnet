using System;
using Xunit;
using oneblink_sdk_dotnet;

namespace unit_tests
{
    public class FormsTest
    {
        [Fact]
        public void can_be_constructed()
        {
            Forms forms = new Forms("a", "b");
        }

        [Fact]
        public void can_search_forms() {
            Forms forms = new Forms("", ""); // TODO Get creds from config
            string response = forms.search(null, null, string.Empty);
            Assert.True(response != null);
            // Console.WriteLine("Response: " + response);
        }

        [Fact]
        public void can_search_forms_with_all_params() {
            Forms forms = new Forms("", ""); // TODO Get creds from config
            string response = forms.search(true, true, "Location test");
            Assert.True(response != null);
            Console.WriteLine("Response: " + response);
        }
    }
}
