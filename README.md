# README #

This approach to capturing tab reselection uses Xamarin.Forms 3.6, although it has been used with some older versions (at least back to 2.3), and the code it relies on in Xamarin.Forms does not appear to have changed since.

The codebase has branches demonstrating different uses of the code:

|Branch|Features|
|------|--------|
|master|Pretty barebones implementation, with each tab having a single ContentPage, pops up an alert when reselecting a tab.|
|NavigationPage|Each tab has a NavigationPage which can accumulate a stack of ContentPages. Reselecting a tab pops the navigation stack for that tab.|

See http://www.criticalhittech.com/2017/09/14/tab-reselection-in-xamarin-forms-part-1/ for walkthrough of how the basics of how this works.  The followup post https://criticalhittech.com/2019/03/20/tab-retap-in-xamarin-forms-revisited/ discusses the updates for tab icons.

**TL;DR**

This is a fully buildable Xamarin.Forms app which is largely still the template-generated code, and hence a lot of boring stuff.

The most interesting bits are:
- TabReselectDemo\TabReselectDemo\MainPage.xaml.cs
- TabReselectDemo\TabReselectDemo.Android\MainTabPageRenderer.cs
- TabReselectDemo\TabReselectDemo.iOS\MainTabPageRenderer.cs
- TabReselectDemo\TabReselectDemo.UWP\MainTabPageRenderer.cs

Everything else is there to make a functional demo.

**Platform Support**

- Xamarin.iOS
- Xamarin.Android (AppCompat)
- Xamarin.UWP

