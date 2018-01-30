using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using NUnit.Compatibility;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Remote;
using System.Threading;
using OpenQA.Selenium.Appium.MultiTouch;

namespace AndroidTests.Pages
{
    public class ViewsPage: MainPage
    {
        protected void GoToRotatingButton()
        {
            GoToViews();
            driver.Swipe(565, 594, 565, 473, 0);
            driver.Swipe(554, 858, 554, 745, 0);
            driver.FindElementByAccessibilityId("Rotating Button").Click();
        }
    }
}
