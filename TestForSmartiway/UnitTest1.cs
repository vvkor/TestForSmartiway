using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TestForSmartiway.Pages;

namespace TestForSmartiway
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        protected TranslatePage translatePage;
        protected Actions actions;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));

            translatePage = new Pages.TranslatePage(driver);
            actions = new Actions(driver);
        }

        [Test]
        public void EngToUkr()
        {
            translatePage.goToTranslatePage();
            translatePage.selectLanguageEngToUkr();
            translatePage.typeTextInTranslator("This text is in English");
            translatePage.checkTranslatedText("Цей текст англійською мовою");
            translatePage.swapLangs();
            translatePage.checkTranslatedText("This text is in English");
            translatePage.clearField();
        }

        [Test]
        public void UkrToEng()
        {
            translatePage.goToTranslatePage();
            translatePage.selectLanguageUkrToEng();
            translatePage.typeTextInTranslator("Цей текст англійською мовою");
            translatePage.checkTranslatedText("This text is in English");
            translatePage.swapLangs();
            translatePage.checkTranslatedText("Цей текст англійською мовою");
            translatePage.clearField();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}