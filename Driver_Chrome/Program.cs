﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driver_Chrome
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a driver instance for chromedriver
            IWebDriver driver = new ChromeDriver(@"C:\Users\klync\Downloads\chromedriver_win32");

            //Navigate to google page
            driver.Navigate().GoToUrl("https://login.yahoo.com/?.src=finance&.intl=us&authMechanism=primary&done=https%3A%2F%2Ffinance.yahoo.com%2Fscreener%2Fpredefined&eid=100&add=1");

            //Maximize the window
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            driver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);
            driver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            driver.FindElement(By.XPath("//a[contains(text(), 'My Portfolio')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(), 'Katelynns Portfolio')]")).Click();

            //Find the Search text box using xpath
            IList<IWebElement> stockNames = driver.FindElements(By.ClassName("_61PYt"));

            for (int i = 0; i < stockNames.Count; i++)
            {
                Console.WriteLine(stockNames[i].Text);
            }

            //Close the browser
            driver.Close();
        }
    }
}
