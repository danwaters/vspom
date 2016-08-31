using System;
using Xamarin.UITest.Queries;

namespace DanAtXamarin.UITest.PageObjects.Queries
{
    public class Query
    {
        public Func<AppQuery, AppQuery> Func { get; private set; }

        public Query(Func<AppQuery, AppQuery> query)
        {
            Func = query;
        }

        /// <summary>
        /// Creates a new "Marked" query, which matches id/text on Android and iOS, 
        /// accessibilityLabel on iOS and contentDescription on Android. 
        /// This method works well with AutomationId in Xamarin.Forms.
        /// </summary>
        /// <param name="marked"></param>
        public Query(string marked)
        {
            Func = e => e.Id(marked);
        }
    }
}
