using DanAtXamarin.UITest.PageObjects.Helpers;
using DanAtXamarin.UITest.PageObjects.Queries;
using Xamarin.UITest;

namespace $safeprojectname$
{
    public class LoginPage : BasePage
    {
        private readonly Query usernameField = new Query("username");
        private readonly Query passwordField = new Query("password");
        private readonly Query submitButton = new Query("submit");

        public LoginPage(IApp app)
            : base(app, "Login", submitButton)
        {

        }

        public void LogIn(string username, string password)
        {
            app.EnterText(usernameField, username);
            app.Screenshot("Username entered");

            app.EnterText(passwordField, password);
            app.Screenshot("Password entered");

            app.Tap(submitButton);

            /*
             * If this action does not result in a page change, just return.
             * If this action results in a page transition, return an instance of that new page:
             
            return new HomePage(app);

            */
        }
    }
}
