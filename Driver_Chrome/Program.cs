using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support;

namespace Driver_Chrome
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new ChromeOptions();
            options.AddArgument("--headless");
            options.AddArguments("--disable-gpu");
            options.AddArguments("disable-popup-blocking");

            var chromeDriver = new ChromeDriver("C:\\Users\\klync\\Source\\Repos\\Driver_Chrome\\Driver_Chrome", options);

            chromeDriver.Navigate().GoToUrl("https://login.yahoo.com/");
            chromeDriver.Manage().Window.Maximize();

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);
           
            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            chromeDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            chromeDriver.Url = ("https://finance.yahoo.com/portfolio/p_0/view/v1");

            var closePopup = chromeDriver.FindElementByXPath("//dialog[@id = '__dialog']/section/button");
            closePopup.Click();

            IWebElement list = chromeDriver.FindElement(By.TagName("tbody"));
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> stocks = list.FindElements(By.TagName("tr"));
            
            Console.WriteLine("Info on stocks in Katelynn's Portfolio: " + stocks.Count);

            for (int i = 1; i < stocks.Count; i++)
            {
                var symbol = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[1]/span/a")).Text;
                //var lastPrice = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[2]/span")).Text;
                var change = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[3]/span")).Text;
                //var pChange = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[4]/span")).Text;
                //var currency = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[5]")).Text;
                //var volume = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[7]/span")).Text;
                //var avgVolume = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[9]")).Text;
                //var marketCap = chromeDriver.FindElement(By.XPath("//*[@id=\"main\"]/section/section[2]/div[2]/table/tbody/tr[" + i + "]/td[13]/span")).Text;

                Console.WriteLine(symbol + " " + change); //+ lastPrice " " + change); + " " + pChange + " " + currency + " " + volume + " " + avgVolume + " " + marketCap//);
            }
            Console.WriteLine("\n");

            chromeDriver.Close();
        }
    }
}