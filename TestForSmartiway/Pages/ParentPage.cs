using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TestForSmartiway.Pages;

namespace TestForSmartiway
{
    public class ParentPage
    {

        IWebDriver driver;
        WebDriverWait wait;
        Actions actions;


        // public IWebDriver driver { get; set; }


        public ParentPage(IWebDriver driver)
        {
            this.driver = driver;
            actions = new Actions(driver);
            wait = wait;
            //        WebDriverWait wait  = new WebDriverWait(webDriver, 60);
            //allNewsPage = new AllNewsPage(webDriver);
            //PageFactory.initElements(driver, this);
        }
    }
}
