using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FirefoxDriverConsoleApp
{
    class Program
    {
        static void Main()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("https://www.google.fr");

                var waiter = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

                // Get google input text element by name
                var elementSelector = By.Name("q");

                // Wait until this element is visible
                waiter.Until(ExpectedConditions.ElementIsVisible(elementSelector));

                // Get element
                var element = driver.FindElement(elementSelector);

                // Fill in input text
                element.SendKeys("test");

                // Submit page form
                element.Submit();

                // Wait until result stats are visible to get page title
                var resultStatsElementSelector = By.Id("resultStats");
                waiter.Until(ExpectedConditions.ElementIsVisible(resultStatsElementSelector));

                // Get page title
                var pageTitle = driver.Title;

                Console.WriteLine("Page title: " + pageTitle);

                driver.Quit();
            }
        }
    }
}
