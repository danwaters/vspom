using Xamarin.UITest;
using Xamarin.UITest.Queries;
using DanAtXamarin.UITest.PageObjects.Queries;

namespace DanAtXamarin.UITest.PageObjects.Helpers
{
    public static partial class AppExtensions
    {
        public static void Screenshot(this IApp app, string format, params object[] args)
        {
            app.Screenshot(string.Format(format, args));
        }

        public static AppResult[] Query(this IApp app, Query query)
        {
            return app.Query(query.Func);
        }

        public static void WaitAndTap(this IApp app, Query query)
        {
            app.WaitForElement(query.Func);
            app.Tap(query.Func);
        }

        public static void EnterText(this IApp app, Query query, string text)
        {
            app.EnterText(query.Func, text);
        }

        public static void Tap(this IApp app, Query query)
        {
            app.Tap(query.Func);
        }
    }
}
