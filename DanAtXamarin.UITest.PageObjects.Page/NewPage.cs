using DanAtXamarin.UITest.PageObjects.Helpers;
using DanAtXamarin.UITest.PageObjects.Queries;
using Xamarin.UITest;

namespace $rootnamespace$
{
    public class $safeitemname$ : BasePage
    {
        public $safeitemname$(IApp app)
            : base(app, "$safeitemname$", new Query(e => e.Id("id_of_trait")))
        {

        }

        public void TapAButton()
        {
            /*
             * If this action does not result in a page change, just return.
             * If this action results in a page transition, return an instance of that new page:
            
            app.Tap("sign_in");
             
            return new HomePage(app);

            */
        }
    }
}
