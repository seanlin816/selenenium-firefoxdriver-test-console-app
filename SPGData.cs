using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace FirefoxDriverConsoleApp
{
    public class SPGData
    {
        public string GetDeactivationData(string esn)
        {
            using (var driver = new FirefoxDriver())
            {
                string baseURL = "https://www.boostmobilesales.com/";
                driver.Navigate().GoToUrl(baseURL + "/boost-sales-portal/faces/login.jsp");
                driver.FindElement(By.Id("loginform:username")).Clear();
                driver.FindElement(By.Id("loginform:username")).SendKeys("vha");
                driver.FindElement(By.Id("loginform:password")).Clear();
                driver.FindElement(By.Id("loginform:password")).SendKeys("1550Boost!");
                driver.FindElement(By.Id("loginform:Login")).Click();

                driver.Navigate().GoToUrl(baseURL + "boost-sales-portal/faces/_rlvid.jsp?_rap=pc_AccountPreferences.ESNLookup&_rvip=/accountPreferences.jsp");
                driver.FindElement(By.Id("meid")).Clear();
                driver.FindElement(By.Id("meid")).SendKeys("089446861501672553");
                driver.FindElement(By.Id("form1:Search")).Click();
                var result = driver.FindElement(By.XPath("//table[@id='dataTable']/tbody/tr[2]/td[4]")).Text;
                Console.WriteLine("Result title: " + result);

                driver.Quit();
                return result;
            }
        }
    }
}
