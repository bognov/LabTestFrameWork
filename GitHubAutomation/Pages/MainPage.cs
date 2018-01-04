using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;

namespace GitHubAutomation.Pages
{
    public class MainPage
    {
        private const string BASE_URL = "https://aviago.by/";

        [FindsBy(How = How.Id, Using = "cty0")]
        private IWebElement TextFrom1;

        [FindsBy(How = How.Id, Using = "cty1")]
        private IWebElement TextTo1;

        [FindsBy(How = How.Id, Using = "cty2")]
        private IWebElement TextFrom2;

        [FindsBy(How = How.Id, Using = "cty3")]
        private IWebElement TextTo2;

        [FindsBy(How = How.Id, Using = "journey-roundTrip")]
        private IWebElement TypeRound;

        [FindsBy(How = How.Id, Using = "journey-oneway")]
        private IWebElement TypeOneway;

        [FindsBy(How = How.Id, Using = "journey-multi")]
        private IWebElement TypeMulti;

        [FindsBy(How = How.Id, Using = "outDate")]
        private IWebElement DateOut1;

        [FindsBy(How = How.Id, Using = "retDate")]
        private IWebElement DateRet1;

        [FindsBy(How = How.Id, Using = "cabin2")]
        private IWebElement BisnesOnly;

        [FindsBy(How = How.Id, Using = "airlineLink")]
        private IWebElement AirlineChoose;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"pax\"]/div[1]/div[2]/span/a[1]")]
        private IWebElement AdultsNum;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"pax\"]/div[1]/div[2]/span/a[2]")]
        private IWebElement AdultsDec;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"pax\"]/div[2]/div[2]/span/a[1]")]
        private IWebElement ChildrenNum;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sf\"]/div[3]/div[2]/div")]
        private IWebElement Submit;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"airlines\"]/option[214]")]
        private IWebElement TurAirline;

        private IWebDriver driver;

        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(BASE_URL);
        }

        public void EnterPath(string Path1, string Path2)
        {
            TextFrom1.SendKeys(Path1);
            TextTo1.SendKeys(Path2);
        }

        public void IncreacePass(int pass)
        {
            switch (pass)
            {
                case 1: AdultsNum.Click(); break;
                case 2: ChildrenNum.Click(); break;
            }
        }

        public void DecreacePass(int pass)
        {
            AdultsDec.Click();
        }

        public void SetTripType(string TypeTrip)
        {
            switch (TypeTrip)
            {
                case "round": TypeRound.Click(); break;
                case "oneway": TypeOneway.Click(); break;
                case "multi": TypeMulti.Click(); break;
            }
        }

        public void SetDateOne(string date)
        {
            DateOut1.SendKeys(date);
        }

        public void SetDate(string date1, string date2)
        {
            DateOut1.SendKeys(date1);
            DateRet1.SendKeys(date2);
        }

        public void StartSearch()
        {
            Submit.Click();
        }

        public void SetAirline()
        {
            AirlineChoose.Click();
            TurAirline.Click();
        }

        public void SetBusnes()
        {
            BisnesOnly.Click();
        }

        public void SetFromTo(string from, string to)
        {
            TextFrom1.SendKeys(from);
            TextTo1.SendKeys(to);
        }

        public void SetFromTo2(string from, string to)
        {
            TextFrom2.SendKeys(from);
            TextTo2.SendKeys(to);
        }

        public bool GetCity0Error(string error)
        {
            try
            {
                var errorCity0 = driver.FindElement(By.XPath("//*[@id=\"cty0-error\"]"));
                return errorCity0.Text == error;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool GetCity1Error(string error)
        {
            try
            {
                var errorCity1 = driver.FindElement(By.XPath("//*[@id=\"cty1-error\"]"));
                return errorCity1.Text == error;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool GetAdultsError(string error)
        {
            try
            {
                var errorPass = driver.FindElement(By.XPath("//*[@id=\"adults - error\"]"));
                return errorPass.Text == error;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
