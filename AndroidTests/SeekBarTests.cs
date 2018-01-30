using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using AndroidTests.Pages;

namespace AndroidTests
{
    [TestFixture]
    public class SeekBarTests:ViewsPage
    {
        private static readonly object[] TestData =
        {
            new object[] { "io.appium.android.apis:id/scaleX",0.8}
        };


        [Test, TestCaseSource(nameof(TestData))]
        //[Test, TestCaseSource(nameof(TestData))]
        public void SearchAndMoveSeekBar(string seekBarId, double percentToMove)
        {
            GoToRotatingButton();
            if (percentToMove > 1)
            {
                throw new Exception("percentToMove variable can be set only in [0,1] range");
            }
            IWebElement seekBar = driver.FindElementById(seekBarId);
            driver.FindElementById(seekBarId).Tap(1, 100);
            //Get start point of seekbar.
            double startX = seekBar.Location.X;
            double yPos = seekBar.Location.Y;
            double bound = seekBar.Size.Width;
            double moveByX = startX + bound * percentToMove;
            //Moving seekbar using TouchAction class.
            TouchAction act = new TouchAction(driver);
            act.LongPress(startX, yPos).MoveTo(startX - bound / 2, yPos).Release().Perform();
            startX = seekBar.Location.X;
            act.LongPress(startX, yPos).MoveTo(moveByX, yPos).Release().Perform();
        }
    }
}