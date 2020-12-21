using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestForSmartiway
{
    public class Actions
    {
        IWebDriver driver;
        WebDriverWait wait;
        public Actions(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
        }

        public void waitToBeClickable(IWebElement element)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(element));
        }

        public void waitToBeVisible(IWebElement element)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible((By)element));
            }
            catch (Exception e)
            {
                Assert.Fail("Can`t find element " + element + "! Exception: " + e);
            }

        }

        public void click(IWebElement element)
        {
            try
            {
                waitToBeClickable(element);
                element.Click();
            }
            catch (Exception e)
            {
                Assert.Fail("Can`t click on element " + element + "! Exception: " + e);
            }
        }

        public void insertText(IWebElement element, String text)
        {
            try
            {
                waitToBeClickable(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception e)
            {
                Assert.Fail("Can`t insert text in field " + e);
            }
        }
    }
}
