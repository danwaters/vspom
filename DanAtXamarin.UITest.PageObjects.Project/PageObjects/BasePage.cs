using DanAtXamarin.UITest.PageObjects.Queries;
using Xamarin.UITest;

namespace $safeprojectname$
{
    public abstract class BasePage
    {
        protected IApp app { get; private set; }
        public Query Trait { get; protected set; }
        public string PageName { get; protected set; }

        /// <summary>
        /// Create a new instance of the page.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="pageName">The name of the page. This will be used in screenshots.</param>
        /// <param name="trait">A query representing a uniquely identifiable UI element that, when visible, means the page has loaded and the user is ready to begin interacting with it, such as a logo or username field.</param>
        public BasePage(IApp app, string pageName, Query trait = null)
        {
            this.app = app;
            this.PageName = pageName;

            if (trait != null)
            {
                this.Trait = trait;
                CheckForTrait();
            }
        }

        public void CheckForTrait()
        {
            app.WaitForElement(Trait.Func);
            app.Screenshot($"On the {PageName} page");
        }
    }
}
