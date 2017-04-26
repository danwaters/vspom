using Xamarin.UITest;

namespace $safeprojectname$
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    // To use a specific APK, uncomment the line below and provide the path
                    //.ApkFile(@"C:\path\to\my.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

