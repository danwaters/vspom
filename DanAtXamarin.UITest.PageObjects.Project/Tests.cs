using NUnit.Framework;
using Xamarin.UITest;

namespace $safeprojectname$
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests : BaseTest
    {
        public Tests(Platform platform) 
            : base(platform)
        {

        }

        [Test]
        [Category("smoke-tests")]
        public void AppLaunches()
        {
            app.WaitForElement(e => e.All());
            app.Screenshot("On the first page of the app.");
            
        }

        [Test]
        [Ignore]
        public void PageObjectExample()
        {
            new LoginPage(app)
                .LogIn("testuser@example.com", "pa55w0rd");
        }
    }
}

