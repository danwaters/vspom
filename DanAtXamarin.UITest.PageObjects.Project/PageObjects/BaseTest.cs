using NUnit.Framework;
using Xamarin.UITest;

namespace $safeprojectname$
{
    [TestFixture]
    public class BaseTest
    {
        protected IApp app;
        protected Platform platform;

        public BaseTest(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void SetUpApp()
        {
            app = AppInitializer.StartApp(platform);
        }
    }
}
