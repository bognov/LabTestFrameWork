﻿using OpenQA.Selenium;

namespace GitHubAutomation.Steps
{
    public class Steps
    {
        IWebDriver driver;

        public void InitBrowser()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        public void CloseBrowser()
        {
            Driver.DriverInstance.CloseBrowser();
        }

        public void OpenPage()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.OpenPage();
        }

        public void SetTypeDates(string type = "round", bool bis = false)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            if(bis == true)
                mainPage.SetBusnes();
            mainPage.SetTripType(type);
            if (type == "oneway")
            {
                mainPage.SetDateOne();
            }
            else
                mainPage.SetDate();
        }

        public void SetCityes(string from, string to)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.SetFromTo(from, to);
        }

        public void SetAirline()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.SetAirline();
        }

        public void SetCityesMulti(string from1, string to1, string from2, string to2)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.SetFromTo(from1, to1);
            mainPage.SetFromTo2(from2, to2);
        }

        public void SetPass(int num, int type)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            for (int i = 0; i < num; i++)
            {
                mainPage.IncreacePass(type);
            }
        }

        public void DecreasePass()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
        }

        public void Submit()
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            mainPage.StartSearch();
        }

        public void SelSort(string sort)
        {
            Pages.ResultPage resultPage = new Pages.ResultPage(driver);
            resultPage.SelectSort(sort);
        }

        public void SelFirst()
        {
            Pages.ResultPage resultPage = new Pages.ResultPage(driver);
            resultPage.SelectFirst();
            resultPage.SubmitChoice();
        }

        public bool GetErrorCity0(string errorMessage)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetCity0Error(errorMessage);
        }

        public bool GetErrorCity1(string errorMessage)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetCity1Error(errorMessage);
        }

        public bool GetErrorAdult(string errorMessage)
        {
            Pages.MainPage mainPage = new Pages.MainPage(driver);
            return mainPage.GetAdultsError(errorMessage);
        }
    }
}
