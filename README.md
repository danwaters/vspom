# Xamarin.UITest Templates for Page Object Model
Quickly create cross-platform tests that are scalable and maintainable by using the [Page Object Model design pattern](https://danatxamarin.com/2015/05/12/building-a-scalable-test-suite-with-xamarin-uitest-and-page-objects/) with Xamarin.UITest. 

**Download and install these templates as a [VSIX installer for Visual Studio 2017]
(https://github.com/danwaters/vspom/blob/master/DanAtXamarin.UITest.PageObjects.VS2017.vsix)**
**Download and install these templates as a [VSIX installer for Visual Studio 2015](https://github.com/danwaters/vspom/raw/master/DanAtXamarin.UITest.PageObjects.vsix)**

## Features

* Works with Xamarin.Forms projects
* Supports IDE integration in Xamarin Studio and Visual Studio
* Works with standalone projects (apk/ipa)
* Works with the Visual Studio test runner
* Install via [vsix for VS2015](https://github.com/danwaters/vspom/raw/master/DanAtXamarin.UITest.PageObjects.vsix) | [vsix for VS2017](https://github.com/danwaters/vspom/blob/master/DanAtXamarin.UITest.PageObjects.VS2017.vsix)

## Getting Started
### Basics of the Pattern - Managing Page Transitions
This template comes with a starting point (Tests.cs) which you may delete if you wish, but it shows how to structure a basic test.

Each Page Object derives from BasePage.cs and can have an optional `Query` attached to it called a *trait*. The trait of a page is a unique query that, when executed against the page, returns a result indicating that you are firmly on the page. For example, you might use the Log In button as the trait for the login page, because it likely doesn't exist in other places in the app, and when the login button is visible, you are on the login page. This helps keep the page objects "on track" with the actual flow of your application.

Each operation in the page object can return whatever it wants to, but for the pattern to work, you should either `return this;` if the operation does not cause a page transition, or `return new OtherPage(app);`, passing in `app`, if the operation results in a page transition to `OtherPage`. 

This enables you to create fluent style scripts, such as:
```
new LoginPage().LogIn("me", "password").ViewOrders().SelectFirstOrder();
```
In this way, the pattern helps limit the trouble a tester can get into, while providing page functionality that is reusable across tests.

In the example above, the `LogIn` method might return a new hypothetical `MainPage`, which has a method called `ViewOrders()`, which would go to an `OrderPage`. After selecting an order, the user might be on the `OrderDetailPage`. Each of these page objects would contain your automation logic, wrapped in a descriptive method name. 

### Using These Templates
After installing the templates, simply add a new *Xamarin.UITest Project with Page Objects* project to your solution. 

The solution comes with a few things out of the box:
1.  an example smoke test and an example test that uses page objects (Tests.cs)
2.  an example page object (LoginPage.cs)
3.  several useful app extensions
4.  a wrapper for a Query - just pass your lambda as usual into the constructor (does not support `WebQuery` yet)

## How do I?

### Test a Xamarin or Xamarin.Forms application
By default, your project will support testing your Xamarin.Forms, Xamarin.iOS and Xamarin.Android applications. All you need to do is add a .NET project reference to your iOS or Droid project from the UITest project, and you're done! See more about preparing your apps for testing [here](https://developer.xamarin.com/guides/testcloud/uitest/). 

### Test an app built with non Xamarin tools (XCode, Android Studio, Cordova, etc)
Open up PageObjects/BaseTest.cs and find this line:
`app = AppInitializer.StartApp(platform);`

Change it to use `ConfigureApp` and point to the application binary, for example,
```
var path = @"path/to/my.apk";
app = ConfigureApp.Android.ApkFile(path).StartApp();
```
Learn about [the ways to start tests on iOS and Android](https://developer.xamarin.com/guides/testcloud/uitest/intro-to-uitest/). 

### Add a new page object
Right-click the `Pages` folder in your project and choose **Add | New Item**. Choose "Xamarin.UITest Page Object" from the list. Here are some best practices for new page objects.
* Find out what the queries are for each important UI element and store this query in the page object itself:
```
private readonly Query usernameField = new Query("username");
private readonly Query passwordField = new Query("password");
private readonly Query submitButton = new Query("submit");
```
* Create methods at are action-oriented and parameterized if necessary. Think about what the user is doing, not what you are doing in the script, when you name things:
```
public MainPage LogIn(string username, string password)
{
    app.EnterText(usernameField, username);
    app.Screenshot("Username entered");

    app.EnterText(passwordField, password);
    app.Screenshot("Password entered");

    app.Tap(submitButton);
}
```
Make sure the return type of the method is where the app will actually end up after this operation.
* Use traits to tell the page object what to wait for when you instantiate it. When you instantiate a page object, it will automatically look for its own trait (if you've set one) before it takes a screenshot. You can override this behavior in any page object.
* Use a friendly display name for your page object. Your test will automatically take a screenshot with this name when it is first displayed, if a trait is set. This is done automatically in the base page. To set the friendly page name and the trait, specify these properties in the page object's constructor, in the call to `base(...)`.
```
public LoginPage(IApp app)
    : base(app, "Login", submitButton)
{

}
```
