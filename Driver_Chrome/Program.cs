using OpenQA.Selenium;
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
            IWebDriver driver = new ChromeDriver("C:\\Users\\klync\\Source\\Repos\\Driver_Chrome\\Driver_Chrome");

            //Navigate to Yahoo finanace page
            driver.Navigate().GoToUrl("https://login.yahoo.com/config/login?.src=fpctx&.intl=us&.lang=en-US&.done=https%3A%2F%2Fwww.yahoo.com");

            //Maximize the window
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);

            driver.FindElement(By.Id("login-username")).SendKeys("" + Keys.Enter);
            driver.FindElement(By.Id("login-passwd")).SendKeys("" + Keys.Enter);

            //Navigate to my portfolio page
            driver.Navigate().GoToUrl("https://finance.yahoo.com/portfolio/p_0/view/v1");

            // close pop-up alert
            var alert = driver.FindElement(By.XPath("//dialog[@id = '__dialog']/section/button"));
            alert.Click();

            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> symbol = driver.FindElements(By.ClassName("_1_2Qy"));
            
            for (int i = 0; i < symbol.Count; i++)
            {
                Console.WriteLine(symbol[i].Text);
            }

            // Close the browser
            driver.Close();
        }
    }
}