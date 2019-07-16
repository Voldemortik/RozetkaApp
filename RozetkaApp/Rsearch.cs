using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace RozetkaApp
{
    class Rsearch
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver(@"C:\Program Files (x86)\Google\Chrome\Application\");
        }

        [Test]
        public void test()
        {
            string path = Path.GetTempFileName();
            FileInfo resultFile = new FileInfo(path);
            driver.Url = " https://rozetka.com.ua";
            
            IWait<IWebDriver> wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10000));
            
            IWebElement startEl = driver.FindElement(By.XPath("/html/body/app-root/div/div[1]/app-rz-main-page/div/aside/main-page-sidebar/sidebar-fat-menu/div/ul/li[2]/a"));

            Actions actions = new Actions(driver);
            actions.MoveToElement(startEl).Build().Perform();

            IWebElement smartPhonesElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("body > app-root > div > div:nth-child(2) > div.app-rz-header > header > div > div.header-bottomline > div.menu-outer.js-rz-fat-menu > fat-menu > div > ul > li:nth-child(2) > div > div.menu__main-cats > div.menu__main-cats-inner > div:nth-child(1) > ul:nth-child(1) > li > ul > li:nth-child(1) > a")));
            smartPhonesElement.Click();
            
            IWebElement appleElement = driver.FindElement(By.XPath("//*[@id='filter_producer_69']/label/a"));
            appleElement.Click();
            System.Threading.Thread.Sleep(6000);

            IWebElement samsungElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='filter_producer_12']/label/a")));
            samsungElement.Click();
            System.Threading.Thread.Sleep(6000);

            IWebElement memoryElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='filter_41404_842250']/label/a")));
            memoryElement.Click();
            System.Threading.Thread.Sleep(6000);

            IWebElement maxPriceElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='price[max]']")));
            maxPriceElement.SendKeys("20000");
          
            IWebElement btnPriceElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='submitprice']")));
            btnPriceElement.Click();
            System.Threading.Thread.Sleep(5000);

            IWebElement sortElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='sort_view']/a")));
            sortElement.Click();
         
            IWebElement expensiveSortElement = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(" //*[@id='filter_sortexpensive']/a")));
            expensiveSortElement.Click();
            System.Threading.Thread.Sleep(5000);
            
            IWebElement phonesList = driver.FindElement(By.XPath(" //*[@id='catalog_goods_block']"));
            
                if (resultFile.Exists)
                {
                    
                    using (StreamWriter sw = resultFile.CreateText())
                    {

                        sw.WriteLine(phonesList.Text);

                    }

                }
            

        }
        
        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
        
    }
}
