using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using Ticker;


using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;


//using OpenQA.Selenium.IE;
//using OpenQA.Selenium.Chrome;

namespace TickerTest
{
    public class BaseIntegrationTest
    {
        //public const string BaseUrl = "http://localhost/VideoOnDemand";
        //public const string remoteAddressURL = "http://127.0.0.1:4444/wd/hub";
        //public const string BaseUrl = "http://fn101devz01/VideoOnDemand";
        //public const string remoteAddressURL = "http://fn101devz01:4444/wd/hub";

        /// <summary>
        /// Specify if our web-app uses a virtual path 
        /// </summary>
        private const string VirtualPath = "";
        /// <summary>
        /// Connect Timeout
        /// </summary>
        private const int TimeOut = 30;
        /// <summary>
        /// DOM-read Timeout (implicit wait time)
        /// </summary>
        private const int GetElementTimeout = 5;
        private const int WaitForElementTimeout = GetElementTimeout;
        /// <summary>
        /// Tells Selenium to wait a certain time in milliseconds before trying to interact with a modal dialog message box. 
        /// This gives the web browser enough time to draw the message box first.
        /// </summary>
        private const int ModalDialogWaitTime = 750;

        protected List<string> VerificationErrors;

        protected IWebDriver Driver = new FirefoxDriver();
        /* public string BaseUrl()
         {
            
          string DevURL = "devticker.foxneo.com";
           return DevURL;
         }*/

        /*
        public string BaseUrl
        {
            get
            {

                switch (ConfigurationManager.AppSettings["SeleniumServer"])
                {
                    case "DevServer":
                        return ConfigurationManager.AppSettings["DevServerBaseUrl"];
                    case "QAServer":
                        return ConfigurationManager.AppSettings["QAServerBaseUrl"];
                    case "LocalServer":
                        return ConfigurationManager.AppSettings["LocalServerBaseUrl"];
                }
                return null;
            }
        }*/

        //RemoteWebDriver RemoteDriver = new RemoteWebDriver(DesiredCapabilities.Firefox());
        //private int _testClassesRunning;
        //private IWebDriver StaticDriver;
        private static Login _currentlyLoggedInAs;
        /*
        public IWebDriver Driver
        {
            get { return StaticDriver; }
            set { StaticDriver = value; }
        }*/
        public IWebDriver CreateDriverInstance(string baseUrl)// = BaseUrl)
        {
            DesiredCapabilities desiredCapabilities = DesiredCapabilities.Firefox(); // Firefox();
            //desiredCapabilities.SetCapability("chrome.binary",@"C:\Users\areich\AppData\Local\Google\Chrome\Application\chrome.exe");
            //var remoteAddress = new Uri("http://127.0.0.1:4444/wd/hub");

            //IWebDriver driver = new ScreenShotRemoteWebDriver(remoteAddress, desiredCapabilities);


            //this.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            //driver.Manage().Window.Size = new System.Drawing.Size(1024, 768);
            //driver.Manage().Window.Size = new System.Drawing.Size(640, 480);
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(GetElementTimeout)); // implicitly wait for elements in the DOM

            return Driver;
        }
        public void ClassInitialize(Login login = null)
        {
            //_testClassesRunning++;
            //if (login == null)
            //{
            //    Logoff();
            //}
            //else if (!IsCurrentlyLoggedInAs(login))
            //{

            //Logon(login);
            //}
            Driver.Manage().Window.Maximize();
        }

        public void Open(string url)
        {
            //Driver.Navigate().GoToUrl(BaseUrl + VirtualPath + url.Trim('~'));
            Driver.Navigate().GoToUrl(url);
        }
        /* public void ClassCleanup()
         {
             try
             {
                 _testClassesRunning--;
                 if (_testClassesRunning == 0)
                 {
                     StaticDriver.Quit();
                 }

                 //System.Diagnostics.Process.Start("TASKKILL /F /IM Firefox.exe");
                 //System.Diagnostics.Process.Start("TASKKILL /F /IM iexplore.exe");
             }
             catch (Exception ex)
             {
                 // Ignore errors if unable to close the browser
             }
         }*/




        /// <summary>
        /// Navigate to a webpage URL
        /// </summary>
        /// <param name="url">Webpage to navigate to</param>
        /*public void Open(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }*/
        ///// <summary>
        ///// Navigate to a webpage, and then wait until a particular element is loaded/found before continuing. Then returns (bool) success.
        ///// </summary>
        ///// <param name="url">The webpage to navigate to</param>
        ///// <param name="waitOnThisElement">Wait until this element is loaded/found before continuing.</param>
        ///// <returns>Returns true if the [waitOnThisElement] element was loaded/found</returns>
        //public bool OpenAndWait(string url, By waitOnThisElement)
        //{
        //    bool success = false;
        //    try
        //    {
        //        Driver.Navigate().GoToUrl(BaseUrl + VirtualPath + url.Trim('~'));
        //        WebDriverWait _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
        //        _wait.Until(d => d.FindElement(waitOnThisElement));
        //        success = true;
        //    }
        //    catch (Exception err)
        //    {
        //        throw err;
        //    }
        //    return success;
        //}
        /// <summary>
        /// Navigate to a webpage, and then wait until a particular element is loaded/found before continuing.
        /// </summary>
        /// <param name="url">The webpage to navigate to</param>
        /// <param name="waitOnThisElement">Wait until this element is loaded/found before continuing.</param>


        /// <summary>
        /// Click an element specified by what its name contains (implicitly waits for element)
        /// </summary>
        /// <param name="elementNameContains">The element to click whose name contains this string</param>
        public void Click(string elementNameContains)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GetElementTimeout));
            IWebElement elem = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.XPath("//*[contains( @name , '" + elementNameContains + "')] "));
            });
            try
            {
                elem.Click();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.ToLower().Contains("modal dialog"))
                {
                    System.Threading.Thread.Sleep(ModalDialogWaitTime);
                    elem.Click();
                }
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Click an element specified by [By]
        /// </summary>
        /// <param name="locator">Specify an element by its class name, CSS selector, link text, name, partial link text, tag name, or XPath.</param>
        public void Click(By locator)
        {
            try
            {
                Driver.FindElement(locator).Click();
            }
            catch (InvalidOperationException err)
            {
                if (err.Message.ToLower().Contains("modal dialog"))
                {
                    System.Threading.Thread.Sleep(ModalDialogWaitTime);
                    Driver.FindElement(locator).Click();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Click an element specified by its full ID string, and then wait until the current webpage URL [contains] the string newUrl.
        /// </summary>
        /// <param name="id">Full ID string</param>
        /// <param name="newUrl"></param>
        public void ClickAndWait(string id, string newUrl)
        {
            ClickAndWait(By.Id(id), newUrl);
        }
        /// <summary>
        /// Click an element specified by its full ID string, and then wait until the current webpage URL [contains] the string newUrl.
        /// Use when you are navigating via a hyper-link and need for the page to fully load before moving further.  
        /// </summary>
        public void ClickAndWait(By locator, string newUrl)
        {
            Driver.FindElement(locator).Click();
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
            wait.Until(d => d.Url.Contains(newUrl.Trim('~')));
        }
        /// <summary>
        /// Click an element specified by [By] and wait [delay] milliseconds before continuing
        /// </summary>
        /// <param name="locator">Specify an element by its class name, CSS selector, link text, name, partial link text, tag name, or XPath.</param>
        public void ClickAndDelay(By locator, int delay = 50)
        {
            try
            {
                Driver.FindElement(locator).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (InvalidOperationException err)
            {
                if (err.Message.ToLower().Contains("modal dialog"))
                {
                    System.Threading.Thread.Sleep(ModalDialogWaitTime);
                    Driver.FindElement(locator).Click();
                    System.Threading.Thread.Sleep(delay);
                }
            }
            catch (StaleElementReferenceException err)
            {
                // try again; happens when the page changes
                Driver.FindElement(locator).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Click an element whose name [contains] string and wait [delay] milliseconds before continuing
        /// </summary>
        /// <param name="locator">Specify an element by its class name, CSS selector, link text, name, partial link text, tag name, or XPath.</param>
        public void ClickAndDelay(string nameContains, int delay = 50)
        {
            try
            {
                Driver.FindElement(By.XPath("//*[contains( @name , '" + nameContains + "')] ")).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (InvalidOperationException err)
            {
                if (err.Message.ToLower().Contains("modal dialog"))
                {
                    System.Threading.Thread.Sleep(ModalDialogWaitTime);
                    Driver.FindElement(By.XPath("//*[contains( @name , '" + nameContains + "')] ")).Click();
                    System.Threading.Thread.Sleep(delay);
                }
            }
            catch (StaleElementReferenceException err)
            {
                // try again; happens when the page changes
                Driver.FindElement(By.XPath("//*[contains( @name , '" + nameContains + "')] ")).Click();
                System.Threading.Thread.Sleep(delay);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ClickAndWaitForElement(By elementToClick, By elementToWaitFor)
        {
            try
            {
                GetElement(elementToClick).Click();
                WebDriverWait _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitForElementTimeout));
                _wait.Until(d => d.FindElement(elementToWaitFor));
            }
            catch (NoSuchElementException err)
            {
                throw err;
            }
        }

        public void Pause(int Seconds)
        {
            System.Threading.Thread.Sleep(Seconds * 1000);
        }
        /// <summary>
        /// Finds an element by [By], clears its value, and then sends keys to it.
        /// </summary>
        /// <param name="by">Specify an element by its class name, CSS selector, link text, name, partial link text, tag name, or XPath.</param>
        /// <param name="text">The [keys] to send to the element.</param>
        public void Type(By by, string text)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GetElementTimeout));
                IWebElement element = wait.Until<IWebElement>((d) =>
                {
                    //return d.FindElement(By.XPath("//*[contains( @name , '" + id + "')] "));
                    return d.FindElement(by);
                });

                //element.Clear();
                if (ClearValue(by))
                    element.SendKeys(text);
            }
            catch (StaleElementReferenceException ex)
            {
                // try again
                IWebElement elem = Driver.FindElement(by);
                elem.SendKeys(text);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Finds an element whose name [contains] nameContains, clears it, and then sends textToSend to the element.
        /// </summary>
        /// <param name="nameContains">The full or partial name of the element</param>
        /// <param name="textToSend">The keys to send to the element</param>
        public void Type(string nameContains, string textToSend)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GetElementTimeout));
                IWebElement element = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath("//*[contains( @name , '" + nameContains + "')] "));
                });

                element.Clear();
                element.SendKeys(textToSend);
            }
            catch (StaleElementReferenceException ex)
            {
                IWebElement elem = Driver.FindElement(By.XPath("//*[contains( @name , '" + nameContains + "')] "));
                elem.Clear();
                elem.SendKeys(textToSend);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Finds an elements whose full ID is fullID, clears it, and then sends textToSend to the element.
        /// </summary>
        /// <param name="fullID"></param>
        /// <param name="textToSend"></param>
        public void TypeExact(string fullID, string textToSend)
        {
            IWebElement element;

            element = Driver.FindElement(By.Id(fullID));
            element.Clear();
            element.SendKeys(textToSend);
        }



        /// <summary>
        /// Waits for an alert to be drawn in the web browser, and then accepts the alert.
        /// </summary>
        /// <returns>Returns TRUE if successfully accepts the alert and switches back to the default content.</returns>
        public void AcceptAlert()
        {
            //try
            //{
            System.Threading.Thread.Sleep(ModalDialogWaitTime);
            Driver.SwitchTo().Alert().Accept();
            Driver.SwitchTo().DefaultContent();
            //  return true;
            //}
            //catch (Exception ex)
            //{
            //   throw ex;
            //}
        }
        /// <summary>
        /// Waits for an alert to be drawn in the web browser, and the dismisses the alert.
        /// </summary>
        public void CancelAlert()
        {
            System.Threading.Thread.Sleep(ModalDialogWaitTime);
            Driver.SwitchTo().Alert().Dismiss();
            Driver.SwitchTo().DefaultContent();
        }
        /// <summary>
        /// Get the actual string text of the current alert
        /// </summary>
        /// <returns>Returns the alert text</returns>
        public string GetAlertText()
        {
            System.Threading.Thread.Sleep(ModalDialogWaitTime);
            string txt = Driver.SwitchTo().Alert().Text;
            //Driver.SwitchTo().DefaultContent();
            return txt;
        }


        /// <summary>
        /// Sends keys to an alert message, and then tries to switch back to the default content.
        /// </summary>
        /// <param name="keys">The keys to send to the alert box.</param>
        public void SendKeysToAlert(string keys)
        {
            try
            {
                System.Threading.Thread.Sleep(ModalDialogWaitTime);
                Driver.SwitchTo().Alert().SendKeys(keys);
                Driver.SwitchTo().DefaultContent();
            }
            catch (Exception err)
            {
                throw err;
            }
        }


        public void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }



        /// <summary>
        /// Finds an element, and then returns TRUE if the element was found
        /// </summary>
        /// <param name="by">Specifies which element to search for</param>
        /// <returns>Returns TRUE if the element was found. FALSE otherwise.</returns>
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public bool IsElementDisplayed(By locator)
        {
            return GetElement(locator).Displayed;
        }
        public bool IsElementSelected(By locator)
        {
            return GetElement(locator).Selected;
        }
        public bool IsElementEnabled(By locator)
        {
            return GetElement(locator).Enabled;
        }
        /// <summary>
        /// Pause code execution until a particular element has been loaded/found.
        /// </summary>
        /// <param name="by">Specifies which element to search for</param>
        public void WaitForElement(By by)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(WaitForElementTimeout));
            IWebElement options = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(by);
            });
        }
        /// <summary>
        /// Pauses code execution until a particular element has been loaded/found, and then it returns that element.
        /// </summary>
        /// <param name="locator">Specifies which element to search for</param>
        /// <returns>Returns the found element</returns>
        public IWebElement GetElement(By locator)
        {
            //return Driver.FindElement(By.Id(id));

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GetElementTimeout));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(locator);
            });
            return element;
        }
        /// <summary>
        /// Pauses code execution until a particular element has been loaded/found, and then it returns that element.
        /// </summary>
        /// <param name="fullID">The full ID of the element to be found</param>
        /// <returns>Returns [IWebElement] found with the ID of fullID</returns>
        public IWebElement GetElement(string fullID)
        {
            //return Driver.FindElement(By.Id(fullID));

            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(GetElementTimeout));
            IWebElement element = wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id(fullID));
            });
            return element;
        }
        /// <summary>
        /// If this current element is a form, or an element within a form, then this will be submitted to the web server. If this causes the current page to change, then this method will block until the new page is loaded.
        /// </summary>
        /// <param name="locator">Specifies which element to submit</param>
        public void SubmitElement(By locator)
        {
            try
            {
                GetElement(locator).Submit();
            }
            catch (StaleElementReferenceException ex)
            {
                // try again
                GetElement(locator).Submit();
            }
            catch (Exception err)
            {
                throw err;
            }
        }



        /// <summary>
        /// Finds an element via [By] and returns the element's 'value' attribute value.
        /// </summary>
        /// <param name="locator">Specifies which element</param>
        /// <returns>Returns the value of the element's 'value' attribute</returns>
        public string GetValue(By locator)
        {
            try
            {
                return Driver.FindElement(locator).GetAttribute("value");
            }
            catch (NoSuchElementException err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Gets the innerText of an element, without any leading or trailing whitespace, and with other whitespace collapsed.
        /// </summary>
        /// <param name="locator">Specifies which element to search for</param>
        /// <returns>Returns the innerText of an element, without any leading or trailing whitespace, and with other whitespace collapsed.</returns>
        public string GetText(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Text;
            }
            catch (StaleElementReferenceException ex)
            {
                // try again
                return Driver.FindElement(locator).Text;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// Clears the content of an element found via [By]
        /// </summary>
        /// <param name="by">Specifies which element to search for</param>
        /// <returns>Returns TRUE if successful</returns>
        public bool ClearValue(By by)
        {
            bool success = false;
            try
            {
                IWebElement elem = GetElement(by);
                elem.Clear();
                success = true;
            }
            catch (StaleElementReferenceException ex)
            {
                // try again
                IWebElement elem = GetElement(by);
                elem.Clear();
                success = true;
            }
            catch (Exception err)
            {
                throw err;
            }
            return success;
        }



        /// <summary>
        /// Finds an element whose ID exactly matches fullID, and then clicks the element if it is already selected.
        /// </summary>
        /// <param name="fullID">The full ID of the element to uncheck</param>
        public void Uncheck(string fullID)
        {
            Uncheck(By.Id(fullID));
        }
        /// <summary>
        /// Finds an element whose ID exactly matches fullID, and then clicks the element if it is already selected.
        /// </summary>
        /// <param name="locator">Specifies which element to uncheck</param>
        public void Uncheck(By locator)
        {
            var element = Driver.FindElement(locator);
            if (element.Selected)
                element.Click();
        }
        /// <summary>
        /// Finds an element via [By], and then returns TRUE if the element contains the attribute 'checked'.
        /// </summary>
        /// <param name="locator">Specifies which element to search for</param>
        /// <returns>Returns TRUE if the element contains the attribute 'checked'</returns>
        public bool IsChecked(By locator)
        {
            try
            {
                return Convert.ToBoolean(Driver.FindElement(locator).GetAttribute("checked"));
            }
            catch (StaleElementReferenceException err)
            {
                // try again
                return Convert.ToBoolean(Driver.FindElement(locator).GetAttribute("checked"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// Select an option within a dropdown.
        /// </summary>
        /// <param name="id">The ID of the dropdown [contains!] this string</param>
        /// <param name="optionToBeSelected">The [TEXT] of the option to be selected</param>
        public void Select(string id, string optionToBeSelected)
        {
            var options = Driver.FindElement(By.XPath("//*[contains( @id , '" + id + "')] ")).FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (optionToBeSelected == option.Text)
                {
                    option.Click();
                    break;
                }
            }
        }

        public int GetXpathCount(By locator)
        {
            return Driver.FindElements(locator).Count;
        }
        /// <summary>
        /// Select an option within a dropdown
        /// </summary>
        /// <param name="by">How to find the dropdown</param>
        /// <param name="optionToBeSelected">The [index OR text OR value] of the option to be selected</param>
        /// <param name="selectBy">How to find the option</param>
        public void Select(By by, string optionToBeSelected, SelectDropdownValueBy selectBy)
        {
            SelectElement select = new SelectElement(GetElement(by));
            select.DeselectAll();
            if (selectBy == SelectDropdownValueBy.Index)
            {
                select.SelectByIndex(Convert.ToInt32(optionToBeSelected));
            }
            else if (selectBy == SelectDropdownValueBy.Text)
            {
                select.SelectByText(optionToBeSelected);
            }
            else if (selectBy == SelectDropdownValueBy.Value)
            {
                select.SelectByValue(optionToBeSelected);
            }
        }
        /// <summary>
        /// Select an option within a dropdown, and then wait until Selenium is responsive before continuing.
        /// </summary>
        /// <param name="by">How to find the dropdown</param>
        /// <param name="optionToBeSelected">The [index OR text OR value] of the option to be selected</param>
        /// <param name="selectBy">How to find the option</param>
        public void SelectAndWait(By by, string optionToBeSelected, SelectDropdownValueBy selectBy)
        {
            SelectElement select = new SelectElement(GetElement(by));
            //select.DeselectAll();
            if (selectBy == SelectDropdownValueBy.Index)
            {
                select.SelectByIndex(Convert.ToInt32(optionToBeSelected));
            }
            else if (selectBy == SelectDropdownValueBy.Text)
            {
                select.SelectByText(optionToBeSelected);
            }
            else if (selectBy == SelectDropdownValueBy.Value)
            {
                select.SelectByValue(optionToBeSelected);
            }

            WebDriverWait _wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
            _wait.Until(d => d.FindElement(by)); // works?
        }
        /// <summary>
        /// Select an option within a dropdown by sending a 'Click'
        /// </summary>
        /// <param name="id">The full ID string of the dropdown</param>
        /// <param name="optionToBeSelected">The full TEXT of the option to be selected</param>
        public void SelectExact(string id, string optionToBeSelected)
        {
            var options = Driver.FindElement(By.Id(id)).FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (optionToBeSelected == option.Text)
                {
                    option.Click();
                    break;
                }
            }
        }
        /// <summary>
        /// Will click each element in the list if the element is enabled and not already selected.
        /// </summary>
        /// <param name="elems">List of elements to be selected</param>
        public void SelectElements(List<IWebElement> elems)
        {
            foreach (IWebElement el in elems)
            {
                try
                {
                    if (!el.Selected && el.Enabled) el.Click();
                }
                catch (StaleElementReferenceException ex)
                {
                    // try again
                    if (!el.Selected && el.Enabled) el.Click();
                }
                catch (ElementNotVisibleException err)
                {
                    throw err;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        /// <summary>
        /// Returns an [IList] of [IWebElement]s of the checkbox elements found within a given element.
        /// </summary>
        /// <param name="fromParent">This element contains the checkboxes. It can be a parent, grandparent, great-grandparent, etc.</param>
        /// <param name="maxItems">If supplied, then will return only [maxItems] # of checkbox elements (Randomly selected)</param>
        /// <returns></returns>
        public IList<IWebElement> GetCheckboxCollection(By fromParent, int maxItems = 0)
        {
            IList<IWebElement> elems = (IList<IWebElement>)Driver.FindElement(fromParent).FindElements(By.XPath("//input[@type='checkbox']")); // (List<IWebElement>)

            if (maxItems > 0)
            {
                ShuffleGenericList<IWebElement>(elems);
                int count = elems.Count - maxItems;
                while (count > 0)
                {
                    elems.RemoveAt(count);
                    count--;
                }
            }

            return (IList<IWebElement>)elems;
        }
        /// <summary>
        /// Returns an [IList] of [IWebElement]s of the option elements (dropdown choices) found within a given element.
        /// </summary>
        /// <param name="fromParent">This element contains the options. It can be a parent, grandparent, great-grandparent, etc.</param>
        /// <param name="maxItems">If supplied, then will return only [maxItems] # of option elements (Randomly selected)</param>
        /// <returns></returns>
        public IList<IWebElement> GetOptionCollection(By fromParent, int maxItems = 0)
        {
            IList<IWebElement> elems = (IList<IWebElement>)Driver.FindElement(fromParent).FindElements(By.XPath("//option")); // (((List<IWebElement>)((IList<IWebElement>))))

            if (maxItems > 0)
            {
                ShuffleGenericList<IWebElement>(elems);
                int count = elems.Count - maxItems;
                while (count > 0)
                {
                    elems.RemoveAt(count);
                    count--;
                }
            }

            return elems; // (IList<IWebElement>)
        }
        /// <summary>
        /// Returns an [IList] of [IWebElement]s of the radio elements found within a given element.
        /// </summary>
        /// <param name="fromParent">This element contains the radio buttons. It can be a parent, grandparent, great-grandparent, etc.</param>
        /// <param name="maxItems">If supplied, then will return only [maxItems] # of radio elements (Randomly selected)</param>
        /// <returns></returns>
        public IList<IWebElement> GetRadioCollection(By fromParent, int maxItems = 0)
        {
            IList<IWebElement> elems = (IList<IWebElement>)Driver.FindElement(fromParent).FindElements(By.XPath("//input[@type='radio']")); // (List<IWebElement>)

            if (maxItems > 0)
            {
                ShuffleGenericList<IWebElement>(elems);
                int count = elems.Count - maxItems;
                while (count > 0)
                {
                    elems.RemoveAt(count);
                    count--;
                }
            }

            return (IList<IWebElement>)elems;
        }
        /// <summary>
        /// Returns an [IList] of [IWebElement]s of the button elements found within a given element.
        /// </summary>
        /// <param name="fromParent">This element contains the buttons. It can be a parent, grandparent, great-grandparent, etc.</param>
        /// <param name="maxItems">If supplied, then will return only [maxItems] # of button elements (Randomly selected)</param>
        /// <returns></returns>
        public IList<IWebElement> GetButtonCollection(By fromParent, int maxItems = 0)
        {
            IList<IWebElement> elems = (IList<IWebElement>)Driver.FindElement(fromParent).FindElements(By.XPath("//input[@type='button']")); // (List<IWebElement>)

            if (maxItems > 0)
            {
                ShuffleGenericList<IWebElement>(elems);
                int count = elems.Count - maxItems;
                while (count > 0)
                {
                    elems.RemoveAt(count);
                    count--;
                }
            }

            return elems; // (IList<IWebElement>)
        }



        /// <summary>
        /// Clicks to select a random set of elements out of the collection given
        /// </summary>
        /// <param name="elements">The full element collection to be randomized</param>
        public void RandomlySelect(IList<IWebElement> elements)
        {
            Random rand = new Random();
            double randomDouble = rand.NextDouble();
            int selectCount = Convert.ToInt32(elements.Count * randomDouble);
            int nextIndex, iter = 0;
            while (iter < selectCount)
            {
                nextIndex = Convert.ToInt32(rand.NextDouble() * elements.Count);
                if (elements[nextIndex].Enabled)// && !elements[nextIndex].Selected)
                    elements[nextIndex].Click();
                iter++;
            }
        }
        /// <summary>
        /// Returns a list of all possible sets of combinations of every size from a collection of elements
        /// </summary>
        /// <typeparam name="IWebElement"></typeparam>
        /// <param name="list">Collection of elements</param>
        /// <returns>Returns a list of every possible ordered combination.</returns>
        public IEnumerable<IEnumerable<IWebElement>> GetAllCombinations<IWebElement>(IList<IWebElement> list)
        {
            return GetPowerSet<IWebElement>(list);
        }
        private IEnumerable<IEnumerable<T>> GetPowerSet<T>(IList<T> list)
        {
            return from m in Enumerable.Range(0, 1 << list.Count)
                   select
                       from i in Enumerable.Range(0, list.Count)
                       where (m & (1 << i)) != 0
                       select list[i];
        }
        /// <summary>
        /// Generates random sentences
        /// </summary>
        /// <param name="charCount">How long should the return string be?</param>
        /// <returns>Returns random sentence(s)</returns>
        public string GenerateRandomWords(int charCount)
        {
            Random rnd = new Random();
            string summary = "";
            string[] start = { "When", "In a world where", "Sometimes", "Nowadays", "When" };
            string[] adjs = { "a bunch of the", "some", "a few", "none of the", "all of the" };
            string[] nouns = { "guys", "drunks", "gals", "young kids", "college students", "boys", "hopefuls", "cops", "scientists", "contestants" };
            string[] verbs = { "discover", "forget", "dance on", "sing about", "pretend with", "destroy", "build", "allow", "deny", "question", "consider" };
            string[] nouns2 = { "a dead car", "an alien", "more peanuts", "a time machine", "a atomic clock", "a video game", "a nuclear war", "spring break", "the ability to stop time", "a cash machine", "immortality" };
            while (summary.Length < charCount)
            {
                summary += start[rnd.Next(start.Length)];
                summary += " " + adjs[rnd.Next(adjs.Length)];
                summary += " " + nouns[rnd.Next(nouns.Length)];
                summary += " " + verbs[rnd.Next(verbs.Length)];
                summary += " " + nouns2[rnd.Next(nouns2.Length)];
                summary += ".";
            }
            return summary.Substring(0, charCount);
        }
        /// <summary>
        /// Generates a random set of characters
        /// </summary>
        /// <param name="charCount">The number of characters you want returned</param>
        /// <param name="allowSpecialChar">Set to 'true' if you want Special Characters to be part of the generation</param>
        /// <returns>Returns string of randomly generated characters/punctuation.</returns>
        public string GenerateRandomChars(int charCount, Boolean allowSpecialChar = false)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            string allowedNonAlphaNum = "!@#$%^&*()_-+=[{]};:<>|./?'";
            Random rd = new Random();

            if (charCount <= 0)
            {
                charCount = 0;
            }

            if (allowSpecialChar)
            {
                allowedChars += allowedNonAlphaNum;
            }
            char[] allowedArray = allowedChars.ToCharArray();
            char[] result = new char[charCount];

            for (int i = 0; i < charCount; i++)
            {
                result[i] = allowedArray[rd.Next(allowedArray.Length)];
            }

            return new String(result);
        }



        public void AssertTextContains(string id, string text)
        {
            AssertTextContains(By.Id(id), text);
        }
        public void AssertTextContains(By locator, string text)
        {
            Assert.IsTrue(Driver.FindElement(locator).Text.Contains(text));
        }
        public void AssertTextEquals(string id, string text)
        {
            AssertTextEquals(By.Id(id), text);
        }
        public void AssertTextEquals(By locator, string text)
        {
            Assert.AreEqual(text, Driver.FindElement(locator).Text);
        }
        public void AssertValueContains(string id, string text)
        {
            AssertValueContains(By.Id(id), text);
        }
        public void AssertValueContains(By locator, string text)
        {
            Assert.IsTrue(GetValue(locator).Contains(text));
        }
        public void AssertValueEquals(string id, string text)
        {
            AssertValueEquals(By.Id(id), text);
        }
        public void AssertValueEquals(By locator, string text)
        {
            Assert.AreEqual(text, GetValue(locator));
        }



        /// <summary>
        /// Is a particular [Login] currently logged in?
        /// </summary>
        /// <param name="login">The [Login] to check</param>
        /// <returns>Returns true if that particular [Login] is currently logged in</returns>
        private static bool IsCurrentlyLoggedInAs(Login login)
        {
            return _currentlyLoggedInAs != null &&
                   _currentlyLoggedInAs.Equals(login);
        }
        /// <summary>
        /// Login using a particular [Login]
        /// </summary>
        /// <param name="login">The [Login] credentials to use</param>
        /*public void Logon(Login login)
        {
            StaticDriver.Navigate().GoToUrl(BaseUrl + VirtualPath + "/Login.aspx");

            StaticDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_UserNameTextBox")).SendKeys(login.Username);
            StaticDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_PasswordTextBox")).SendKeys(login.Password);
            StaticDriver.FindElement(By.Id("ctl00_ContentPlaceHolder1_LoginButton")).Click();

            _currentlyLoggedInAs = login;
        }*/
        /// <summary>
        /// Logoff the currently logged in user
        /// </summary>
        private static void Logoff()
        {
            //StaticDriver.Navigate().GoToUrl(
            //    VirtualPath + RedirectLinks.SignOff.Trim('~'));
            _currentlyLoggedInAs = null;
        }



        /// <summary>
        /// Defines whether to select a dropdown option by the option's text, value, or index.
        /// </summary>
        public enum SelectDropdownValueBy
        {
            Text,
            Value,
            Index
        }

        /// <summary>
        /// method for shuffling a generic list of type T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">the list we wish to shuffle</param>
        private static void ShuffleGenericList<T>(IList<T> list)
        {
            //generate a Random instance
            Random rnd = new Random();
            //get the count of items in the list
            int i = list.Count();
            //do we have a reference type or a value type
            T val = default(T);

            //we will loop through the list backwards
            while (i >= 1)
            {
                //decrement our counter
                i--;
                //grab the next random item from the list
                var nextIndex = rnd.Next(i, list.Count());
                val = list[nextIndex];
                //start swapping values
                list[nextIndex] = list[i];
                list[i] = val;
            }
        }

        public void Logic(string first, string middle, string last, string date1, string date2)
        {
            Driver.FindElement(By.XPath("html/body/div[1]/section/div/div[4]/table/thead/tr/th[2]/a[1]/span")).Click();
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[1]/span/span[2]/span")).Click();
            Pause(3);
            Driver.FindElement(By.XPath(first)).Click();//1st logic setting
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/input")).Clear();
            Pause(3);

            if (date1 != null)
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/span/span")).Click();
                Driver.FindElement(By.XPath(date1)).Click();//needs to be changed later

            }
            else
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/input")).SendKeys("9/18/2013");
            }

            Pause(3);

            if ((middle.Equals("Or")) == true)
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[2]")).Click();
                Pause(3);
            }

            else
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[2]")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[1]")).Click();
                Pause(3);
            }

            Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[4]/span/span[2]/span")).Click();
            Pause(3);
            Driver.FindElement(By.XPath(last)).Click();//last logic setting
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[5]/span/input")).Clear();
            Pause(3);

            if (date2 != null)
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[5]/span/span/span")).Click();
                Driver.FindElement(By.XPath(date2)).Click();//needs to be changed later

            }
            else
            {
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[5]/span/input")).SendKeys("9/21/2013");
            }

            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[1]")).Click();
            Pause(20);
        }

        public void Logic2(string first, string middle, string last, string column, string column_click)
        {

            Driver.FindElement(By.XPath("html/body/div[1]/section/div/div[4]/table/thead/tr/th[" + column_click + "]/a[1]/span")).Click();
            Pause(3);//html/body/div[4]/form/div[1]/span[1]/span/span[2]/span
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/input[1]")).Clear();
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/input[1]")).SendKeys("111");
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/span[1]/span/span[2]/span")).Click();
            Pause(3);
            Driver.FindElement(By.XPath(first)).Click();
            Pause(3);

            if ((middle.Equals("Or")) == true)
            {
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/span[2]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[3]/div/ul/li[2]")).Click();
                Pause(3);
            }
            else
            {
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/span[2]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[3]/div/ul/li[2]")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/span[2]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[3]/div/ul/li[1]")).Click();
                Pause(3);
            }
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/span[3]/span/span[2]/span")).Click();
            Pause(3);
            Driver.FindElement(By.XPath(last)).Click();
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/input[2]")).Clear();
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/input[2]")).SendKeys("222");
            Pause(3);
            Driver.FindElement(By.XPath("html/body/div[" + column + "]/form/div[1]/div[2]/button[1]")).Click();
            Pause(20);
        }

        public void edit_group(bool gameOruser, string header, string n_header, short updateOrcancel)//unfinished
        {
            string step = "edit group";
            Actions builder = new Actions(Driver);
            if (gameOruser == true)
            {
                switch (updateOrcancel)
                {
                    case 1:
                        step = "Choose a TeamID first";
                        Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[2]/td[1]/div[2]/div[1]/span/span/span[2]/span")).Click();
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='ddlGroupSports_listbox']/li[18]")).Click();//MLB
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[2]/td[1]/div[2]/div[2]/span/span/span[2]/span")).Click();
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='ddlGroupTeam_listbox']/li[16]")).Click();//LAD
                        Pause(1);

                        step = "Enter a header";
                        Driver.FindElement(By.XPath(".//*[@id='Header']")).SendKeys(header);
                        Pause(1);

                        step = "Add a note";
                        Driver.FindElement(By.XPath(".//*[@id='Notes']/div/a")).Click();
                        Pause(1);

                        step = "choose team Id stuff";
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")).Click();
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='ddlEditorSports_listbox']/li[18]")).Click();//MLB
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[2]/span[1]/span/span[2]/span")).Click();
                        Pause(1);
                        Driver.FindElement(By.XPath(".//*[@id='ddlEditorTeam_listbox']/li[16]")).Click();//LAD
                        Pause(1);

                        step = "enter something for header";
                        Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr/td[3]/input")).SendKeys("1st");
                        Pause(1);

                        step = "enter some text";
                        IWebElement iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));

                        add_note(updateOrcancel);
                        Pause(4);
                        step = "add notes after a cancel";
                        add_note(2);
                        add_note(3);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    default:
                        break;
                }
            }
                

            else//for games
            {

            }
        }

        public void add_note(short type)
        {
            IWebElement iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
            Driver.SwitchTo().Frame(iframe);
            string step = "start adding note";
            Actions builder = new Actions(Driver);
            switch (type)
            {
                case 1:
                    IWebElement body = Driver.FindElement(By.TagName("body")); // then you find the body
                    body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                    body.SendKeys("Ticker is GREAT");

                    Driver.SwitchTo().DefaultContent();
                    Pause(1);
                    // alternative way to send keys to body
                    // IJavaScriptExecutor jsExecutor = driver as IJavaScriptExecutor;
                    // jsExecutor.ExecuteScript("var body = document.getElementsByTagName('body')[0]; body.innerHTML = 'Some text';");

                    step = "click on cancel";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[6]/a[2]")).Click();
                    Pause(4);
                    break;
                case 2:
                    step = "click on add note again and start process again";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/div/a")).Click();
                    Pause(1);

                    step = "choose team Id stuff";
                    Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")).Click();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='ddlEditorSports_listbox']/li[18]")).Click();//MLB
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[2]/span[1]/span/span[2]/span")).Click();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='ddlEditorTeam_listbox']/li[16]")).Click();//LAD

                    step = "enter something for header";
                    Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr/td[3]/input")).SendKeys("1st");
                    Pause(1);

                    step = "enter some text";
                    Driver.SwitchTo().Frame(iframe);

                    body = Driver.FindElement(By.TagName("body")); // then you find the body
                    body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                    body.SendKeys("Ticker is GREAT");

                    step = "highlight the Text";
                    body.SendKeys(Keys.Control + "a");

                    Driver.SwitchTo().DefaultContent();
                    Pause(2);

                    step = "choose red from the color text box for now";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")).Click();
                    Pause(3);

                    IAction pressDownR = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")))
                        .SendKeys(Keys.Down)
                        .SendKeys(Keys.Down)
                        .SendKeys(Keys.Down).Build();
                    pressDownR.Perform();
                    Pause(1);

                    step = "click on update";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[6]/a[1]")).Click();
                    Pause(4);
                    break;
                case 3:
                    step = "choose team Id stuff";
                    Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")).Click();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='ddlEditorSports_listbox']/li[5]")).Click();//CFB
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[2]/span[1]/span/span[2]/span")).Click();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='ddlEditorTeam_listbox']/li[8]")).Click();//ALBANY UA
                    Pause(1);

                    step = "enter something for header";
                    Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr/td[3]/input")).SendKeys("2nd");
                    Pause(2);

                    step = "enter some text";
                    Driver.SwitchTo().Frame(iframe);

                    body = Driver.FindElement(By.TagName("body")); // then you find the body
                    body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                    body.SendKeys("GREAT is Ticker");

                    step = "highlight the Text";
                    body.SendKeys(Keys.Control + "a");

                    Driver.SwitchTo().DefaultContent();
                    Pause(2);

                    step = "choose blue from the color text box for now";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")).Click();
                    Pause(1);

                    IAction pressDownB = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")))
                        .SendKeys(Keys.Down)
                        .SendKeys(Keys.Down)
                        .SendKeys(Keys.Down)
                        .SendKeys(Keys.Down).Build();
                    pressDownB.Perform();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[text()='Blue']")).Click();
                    Pause(1);

                    step = "click on update";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[6]/a[1]")).Click();
                    Pause(2);

                    step = "move the order of the notes";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[2]/td[5]/a[1]")).Click();
                    Pause(1);
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[5]/a[2]")).Click();
                    Pause(2);
                    break;
                case 4:
                    break;
                default:
                    break;

            }
        }

    }


    public class Login
    {
        public Login(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public override bool Equals(object obj)
        {
            Login compareTo = obj as Login;
            if (compareTo == null)
                return false;

            return compareTo.Username == Username &&
                   compareTo.Password == Password;
        }
    }
    public class Position
    {
        public Position(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public int x { get; private set; }
        public int y { get; private set; }
        public override bool Equals(object obj)
        {
            Position compareTo = obj as Position;
            if (compareTo == null)
                return false;

            return compareTo.x == y &&
                   compareTo.y == y;
        }
    }
    public class Positions
    {
        public static Position PositionOne
        {
            get
            {
                return new Position(0, 0);
            }
        }

        public static Position PositionTwo
        {
            get
            {
                return new Position(640, 0);
            }
        }
        public static Position PositionThree
        {
            get
            {
                return new Position(0, 480);
            }
        }
        public static Position PositionFour
        {
            get
            {
                return new Position(640, 480);
            }
        }
    }
    public class Logins
    {
        public static Login[] Users = { UserOne, UserTwo, UserThree, UserFour, UserFive };
        public static Login UserOne
        {
            get
            {
                return new Login("GANEOSDT1", "5432fox%A");
            }
        }
        public static Login UserTwo
        {
            get
            {
                return new Login("GANEOSDT2", "5432fox%A");
            }
        }
        public static Login UserThree
        {
            get
            {
                return new Login("GANEOSDT3", "5432fox%A");
            }
        }
        public static Login UserFour
        {
            get
            {
                return new Login("GANEOSDT4", "5432fox%A");
            }
        }
        public static Login UserFive
        {
            get
            {
                return new Login("GANEOSDT5", "5432fox%A");
            }
        }
    }
    public class ScreenShotRemoteWebDriver : RemoteWebDriver, ITakesScreenshot
    {
        public ScreenShotRemoteWebDriver(Uri RemoteAdress, ICapabilities capabilities)
            : base(RemoteAdress, capabilities)
        {
        }

        /// <summary>
        /// Gets a <see cref="Screenshot"/> object representing the image of the page on the screen.
        /// </summary>
        /// <returns>A <see cref="Screenshot"/> object containing the image.</returns>
        public Screenshot GetScreenshot()
        {
            // Get the screenshot as base64.
            Response screenshotResponse = this.Execute(DriverCommand.Screenshot, null);
            string base64 = screenshotResponse.Value.ToString();

            // ... and convert it.
            return new Screenshot(base64);
        }
    }
}

