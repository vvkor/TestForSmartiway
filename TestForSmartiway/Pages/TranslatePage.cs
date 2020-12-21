using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TestForSmartiway.Pages
{
    public class TranslatePage : ParentPage
    {
        Actions actions;
        WebDriverWait wait;
        IWebDriver driver;
        public TranslatePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            actions = new Actions(driver);
        }
        
        IWebElement btnOpenFirstLangDropdown => driver.FindElement(By.CssSelector("[jsdata='deferred-i7'] .akczyd:nth-of-type(2) .NMm5M"));
        IWebElement btnOpenSecondLangDropdown => driver.FindElement(By.CssSelector("[jsdata='deferred-i7'] .akczyd:nth-of-type(5) .NMm5M"));
        IWebElement btnUkrLangFirst => driver.FindElement(By.XPath("//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']/div[@class='hRFt4b']/c-wiz/div[@class='OoYv6d']/div[@class='UU714 X4hZJc']/div[3]/div[@class='SL5JTc']/div[3]/div[@data-language-code = 'uk']/div[@class='PxXj2d']"));
        IWebElement btnUkrLangSecond => driver.FindElement(By.XPath("//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']/div[@class='hRFt4b']/c-wiz/div[@class='ykTHSe']/div[@class='UU714 X4hZJc']//div[@class='rT1Yue']/div[@data-language-code = 'uk']/div[@class='PxXj2d']"));
        IWebElement btnEngLangFirst => driver.FindElement(By.XPath("//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']/div[@class='hRFt4b']/c-wiz/div[@class='OoYv6d']/div[@class='UU714 X4hZJc']/div[3]/div[@class='SL5JTc']/div[3]/div[@data-language-code = 'en']/div[@class='PxXj2d']"));
        IWebElement btnEngLangSecond => driver.FindElement(By.XPath("//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']/div[@class='hRFt4b']/c-wiz/div[@class='ykTHSe']/div[@class='UU714 X4hZJc']//div[@class='rT1Yue']/div[@data-language-code = 'en']/div[@class='PxXj2d']"));
        IWebElement inputOriginalText => driver.FindElement(By.CssSelector(".er8xn"));
        IWebElement translateResult => driver.FindElement(By.CssSelector(".ChMk0b.JLqJ4b > span"));
        IWebElement btnClearField => driver.FindElement(By.XPath("/html//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']//div[@class='OPPzxe']/c-wiz[1]/div[@class='DVHrxd']/div//button/i[.='clear']"));
        IWebElement btnSwapLangs => driver.FindElement(By.XPath("//body[@id='yDmH0d']/c-wiz//div[@class='WFnNle']/c-wiz/div[@class='OlSOob']/c-wiz[@role='main']//c-wiz[@class='EO28P']/div[3]//button/i[.='swap_horiz']"));


        public void goToTranslatePage()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            driver.Navigate().GoToUrl("https://translate.google.com.ua/");
        }

        public void selectLanguageEngToUkr()
        {
            actions.click(btnOpenFirstLangDropdown);
            actions.click(btnEngLangFirst);
            actions.click(btnOpenFirstLangDropdown);
            // Тут пришлось вставить слип потому, что явное ожидание не помогало. На более элегантное решение, к сожалению, не было времени.
            Thread.Sleep(500);
            actions.click(btnOpenSecondLangDropdown);
            actions.click(btnUkrLangSecond);
            Thread.Sleep(500);
            actions.click(btnOpenSecondLangDropdown);
        }

        public void selectLanguageUkrToEng()
        {
            actions.click(btnOpenFirstLangDropdown);
            actions.click(btnUkrLangFirst);
            actions.click(btnOpenFirstLangDropdown);
            Thread.Sleep(500);
            actions.click(btnOpenSecondLangDropdown);
            actions.click(btnEngLangSecond);
            Thread.Sleep(500);
            actions.click(btnOpenSecondLangDropdown);
        }

        public void typeTextInTranslator(String text)
        {
            actions.insertText(inputOriginalText, text);
        }

        public void checkTranslatedText(String expectedText)
        {
            String actualText = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".ChMk0b.JLqJ4b > span"))).Text;

            Assert.AreEqual(expectedText, actualText);
        }

        public void clearField()
        {
            actions.click(btnClearField);
        }

        public void swapLangs()
        {
            actions.click(btnSwapLangs);
            Thread.Sleep(500);
        }

    }
}
