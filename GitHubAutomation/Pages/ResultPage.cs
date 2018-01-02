using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace GitHubAutomation.Pages
{
    public class ResultPage
    {
        [FindsBy(How = How.Id, Using = "fromCheapest")]
        private IWebElement FromCheapest;

        [FindsBy(How = How.Id, Using = "fromOptimal")]
        private IWebElement FromOptimal;

        [FindsBy(How = How.Id, Using = "fromFastest")]
        private IWebElement FromFastest;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sortedOffers\"]/div[1]/div/table/tbody/tr[4]/td/div/div[2]/div")]
        private IWebElement buttonSelect;

        [FindsBy(How = How.XPath, Using = "/html/body/div[79]/div/div/div/div[2]/div")]
        private IWebElement buttonSubmit;

        private IWebDriver driver;

        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void SelectSort(string sort)
        {
            switch (sort)
            {
                case "cheap": FromCheapest.Click(); break;
                case "opt": FromOptimal.Click(); break;
                case "fast": FromFastest.Click(); break;
            }
        }

        public void SelectFirst()
        {
            buttonSelect.Click();
        }

        public void SubmitChoice()
        {
            buttonSubmit.Click();
        }
    }
}
