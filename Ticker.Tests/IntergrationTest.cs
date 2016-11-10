using System;
using System.Text;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Threading;
using System.Net;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;


using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;



namespace TickerTest
{
    [TestClass]
    [TestFixture]
    public class IntergrationTest : BaseIntegrationTest
    {
        //IWebDriver Driver = new FirefoxDriver();
        [TestInitialize()]
        public void TestSetup()
        {
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            Driver.SwitchTo().Window(Driver.CurrentWindowHandle);

            //Logon(Logins.UserOne);

            //randomly picks a user
            //Users[RandString.Next(Logins.Users.Length)]);
        }

        [TestMethod]
        public void PlaylistGroups()
        {
            Dictionary<string, string> outputParams = new Dictionary<string, string>();
            string step = "starting the playlist group/games test";
            Driver.Navigate().GoToUrl("http://devticker.foxneo.com");

            try
            {

                step = "Login page";
                Driver.Manage().Window.Maximize();
                ClickAndWait(By.XPath(".//*[@id='main']/p[2]/a"), "http://oauth.foxneo.com/Account/LogOn?ReturnUrl=%2fOpenId%2fAskUser");
                //Driver.FindElement(By.XPath(".//*[@id='main']/p[2]/a")).Click();
                Driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("GANEOSDT1");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("5432fox%A");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='main']/form/div/fieldset/p[4]/input")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='responseButtonsDiv']/input[1]")).Click();
                Pause(1);

                step = "Select the Client";
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(1);
                
                step = "Create new Playlist";
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/div/a")).Click();//add playlist
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Name']")).SendKeys("11111test11111");// enter name
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[1]/td[3]/a[2]")).Click();//cancel
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/div/a")).Click();//add playlist again
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Name']")).SendKeys("11111test11111"); ;//enter name again
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[1]/td[3]/a[1]")).Click();//update  
                Pause(1);


                step = "Add groups/notes to playlist";
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[1]/td[3]/a[3]")).Click();//details
                Pause(1);

                step = "Create a new group";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip']/ul/li[3]/a")).Click();
                Pause(1);

                step = "Enter text into Name and OnAirName";
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroup']")).SendKeys("0test1");
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroupOnAirName']")).SendKeys("0t1");
                Pause(2);

                step = "Click on the Save button";
                Driver.FindElement(By.XPath(".//*[@id='GroupOfGames']")).Click();
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='onNewGroup']")).Click();
                Pause(2);
                //ClickAndWaitForElement(By.XPath(".//*[@id='onNewGroup']"), By.XPath(".//*[@id='tabStrip-1']/span/span/span[2]/span"));

                step = "close the group editor after it is created";
                Driver.FindElement(By.XPath("html/body/div[4]/div[1]/div/a/span")).Click();
                //ClickAndWaitForElement(By.XPath("html/body/div[4]/div[1]/div/a/span"), By.XPath(".//*[text()='0test1 -         0']"));

                step = "select the newly created group from the groups list";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip-1']/span/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupType_listbox']/li[1]")).Click();
                Pause(3);
                //ClickAndWaitForElement(By.XPath(".//*[@id='ddlGroupType_listbox']/li[1]"), By.XPath("html/body/div[4]/div[1]/div/a/span"));

                Pause(5);

                step = "find the group and double click it";
                Actions builder = new Actions(Driver);
                IAction doubleClick = builder.DoubleClick(Driver.FindElement(By.XPath(".//*[text()='0test1 -         0']"))).Build();
                doubleClick.Perform();
                Pause(3);

                step = "close the game group editor";
                //Driver.FindElement(By.XPath("html/body/div[4]/div[1]/div/a/span")).Click();
                ClickAndWaitForElement(By.XPath("html/body/div[4]/div[1]/div/a/span"), By.XPath(".//*[@id='tabStrip']/ul/li[3]/a"));

                step = "create a new group";
                //Driver.FindElement(By.XPath(".//*[@id='tabStrip']/ul/li[3]/a")).Click();
                ClickAndWaitForElement(By.XPath(".//*[@id='tabStrip']/ul/li[3]/a"), By.XPath(".//*[@id='txtNewGroup']"));

                step = "Enter a name and onairname and then save";
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroup']")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroup']")).SendKeys("101test");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroupOnAirName']")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroupOnAirName']")).SendKeys("101test");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='GroupOfGames']")).Click();
                Pause(1);
                //Driver.FindElement(By.XPath(".//*[@id='onNewGroup']")).Click();
                ClickAndWaitForElement(By.XPath(".//*[@id='onNewGroup']"), By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[2]/td[1]/div[2]/div[1]/span/span/span[2]/span"));

                
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
                Driver.FindElement(By.XPath(".//*[@id='Header']")).SendKeys("101t");
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
                Driver.SwitchTo().Frame(iframe);

                IWebElement body = Driver.FindElement(By.TagName("body")); // then you find the body
                body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                body.SendKeys("Ticker is GREAT");

                //Driver.Quit();
                Driver.SwitchTo().DefaultContent();
                Pause(1);
                // alternative way to send keys to body
                // IJavaScriptExecutor jsExecutor = driver as IJavaScriptExecutor;
                // jsExecutor.ExecuteScript("var body = document.getElementsByTagName('body')[0]; body.innerHTML = 'Some text';");

                step = "click on cancel";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[6]/a[2]")).Click();
                Pause(2);
                
                //edit_group(true, "101t", "1st", 1);

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
                iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
                Driver.SwitchTo().Frame(iframe);

                body = Driver.FindElement(By.TagName("body")); // then you find the body
                body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                body.SendKeys("Ticker is GREAT");

                //step = "highlight the Text";
                //body.SendKeys(Keys.Control + "a");

                //Actions builder3 = new Actions(Driver);
                IAction highLight = builder.MoveToElement(Driver.FindElement(By.XPath("//*[text()='Ticker is GREAT']")))
                   .ClickAndHold()
                   .MoveByOffset(18, 0)
                   .Release().Build();

                highLight.Perform();

                Driver.SwitchTo().DefaultContent();
                Pause(2);

                step = "choose red from the color text box for now";
                //Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")).Click();
                ClickAndWaitForElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span"), By.XPath(".//*[@id='templateTool_listbox']/li[4]"));
           
                
                IAction pressDownR = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")))
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down).Build();
                pressDownR.Perform();
                Pause(1);
                
                //Driver.FindElement(By.XPath(".//*[@id='templateTool_listbox']/li[4]")).Click();
                //Driver.FindElement(By.XPath(".//*[text()='Red']")).Click();
                //Pause(1);

                step = "click on update";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[6]/a[1]")).Click();
                Pause(4);

                step = "click on add note again and start process again";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/div/a")).Click();
                Pause(1);

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
                Pause(1);

                step = "enter some text";
                Pause(2);
                iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
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

                step = "click on save";
                Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[1]/td[3]/input")).Click();
                Pause(1);

                step = "click on user created groups";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip-1']/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupType_listbox']/li[2]")).Click();
                Pause(2);

                step = "drag and drop a group into the playlist";
                IAction dragANDdropG = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[text()='101test -         2']")))
                    .DragAndDrop(Driver.FindElement(By.XPath(".//*[text()='101test -         2']")), Driver.FindElement(By.XPath(".//*[@id='tvPlaylistDetails']/ul/li/div/span/span"))).Build();
                dragANDdropG.Perform();
                Pause(3);

                step = "double click the playlist and then edit";
                IAction doubCplay = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[text()='101test']")))
                    .DoubleClick().Build();
                doubCplay.Perform();
                Pause(3);

                step = "edit the group";
                Driver.FindElement(By.XPath(".//*[@id='Name']")).Clear();//name
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Name']")).SendKeys("101test1");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='OnAirName']")).Clear();//onairname
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='OnAirName']")).SendKeys("101test2");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Header']")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Header']")).SendKeys("101t3");//header
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[2]/td[1]/div[2]/div[1]/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupSports_listbox']/li[5]")).Click();//CFB
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[2]/td[1]/div[2]/div[2]/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupTeam_listbox']/li[8]")).Click();//APAC
                Pause(1);

                step = "edit the notes";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[6]/a[1]/span")).Click();
                Pause(1);

                step = "choose team Id stuff";
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlEditorSports_listbox']/li[5]")).Click();//CFB
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[2]/span[1]/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlEditorTeam_listbox']/li[13]")).Click();//ARK
                Pause(1);

                step = "enter something for header";
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[1]/td[3]/input")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[1]/td[3]/input")).SendKeys("3rd");
                Pause(1);

                step = "enter some text";
                iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
                Driver.SwitchTo().Frame(iframe);

                body = Driver.FindElement(By.TagName("body")); // then you find the body
                body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                body.SendKeys("Ticker is ");

                Driver.SwitchTo().DefaultContent();
                Pause(1);

                step = "click on cancel";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[6]/a[2]")).Click();
                Pause(1);

                step = "re-edit the 1st note";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[6]/a[1]/span")).Click();
                Pause(1);

                step = "choose team Id stuff";
                Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")).Click();
                Pause(2);
                IAction clickDown = builder.SendKeys(Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")), Keys.Down).Build();
                clickDown.Perform();
                //Driver.FindElement(By.XPath("html/body/div[12]/div/ul/li[6]")).Click();//CFB
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")).Click();
                Pause(2);
                IAction clickDown2 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")), Keys.Down)
                    .SendKeys(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")), Keys.Up).Build();
                clickDown2.Perform();
                //Driver.FindElement(By.XPath("html/body/div[13]/div/ul/li[13]")).Click();//ARK
                Pause(1);

                step = "enter something for header";
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[1]/td[3]/input")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[1]/td[3]/input")).SendKeys("3rd");
                Pause(2);

                step = "enter some text";
                iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
                Driver.SwitchTo().Frame(iframe);

                body = Driver.FindElement(By.TagName("body")); // then you find the body
                body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                body.SendKeys("FOX IS GREAT ");

                step = "re-highlight the text";
                body.SendKeys(Keys.Control + "a");

                Driver.SwitchTo().DefaultContent();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")).Click();
                Pause(1);

                IAction pressDownY = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")))
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down).Build();
                pressDownY.Perform();
                Driver.FindElement(By.XPath(".//*[text()='Yellow']")).Click();
                Pause(1);

                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[6]/a[1]")).Click();//update
                Pause(2);

                step = "re-edit the 2nd note";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[2]/td[6]/a[1]")).Click();
                Pause(1);
                //Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[2]/td[2]/div/span/span/span[2]/span"));

                IAction clickDown3 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[@id='divEditorSports']/span/span/span[2]/span")), Keys.Down)
                    .SendKeys(Keys.Up).Build();
                clickDown3.Perform();
                //Driver.FindElement(By.XPath("html/body/div[15]/div/ul/li[18]")).Click();//MLB
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[2]/td[2]/span[1]/span/span[2]/span")).Click();
                Pause(2);
                IAction clickDown4 = builder.SendKeys(Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[2]/td[2]/span[1]/span/span[2]/span")), Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down).Build();
                clickDown4.Perform();
                //Driver.FindElement(By.XPath("html/body/div[16]/div/ul/li[26]")).Click();//SD
                Pause(1);

                step = "enter something for header";
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[2]/td[3]/input")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/table/tbody/tr[2]/td[3]/input")).SendKeys("4th");
                Pause(2);

                step = "enter some text";
                iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
                Driver.SwitchTo().Frame(iframe);

                body = Driver.FindElement(By.TagName("body")); // then you find the body
                body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                body.SendKeys("GREAT IS FOX");

                step = "re-highlight the text";
                body.SendKeys(Keys.Control + "a");

                Driver.SwitchTo().DefaultContent();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")).Click();
                IAction pressDownG = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[4]/table/tbody/tr[1]/td/ul/li/span/span/span[2]/span")))
                   .SendKeys(Keys.Down)
                   .SendKeys(Keys.Down)
                   .SendKeys(Keys.Down)
                   .SendKeys(Keys.Down)
                   .SendKeys(Keys.Down).Build();
                pressDownG.Perform();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[text()='Green']")).Click();
                Pause(1);

                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[2]/td[6]/a[1]")).Click();//update
                Pause(1);

                step = "move the order of the notes";
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[2]/td[5]/a[1]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr[1]/td[5]/a[2]")).Click();
                Pause(2);

                step = "click save";
                Driver.FindElement(By.XPath(".//*[@id='winEditor']/form/fieldset/table/tbody/tr[1]/td[3]/input")).Click();
                Pause(2);

                step = "edit game group from left side panel for rips";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip-1']/span/span/span[2]/span")).Click();
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupType_listbox']/li[1]")).Click();
                Pause(2);

                step = "drag the game group into the playlist";
                IAction dragANDdropGG = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[text()='0test1 -         0']")))
                    .DragAndDrop(Driver.FindElement(By.XPath(".//*[text()='0test1 -         0']")), Driver.FindElement(By.XPath(".//*[@id='tvPlaylistDetails']/ul/li/div/span[2]/span"))).Build();
                dragANDdropGG.Perform();
                Pause(2);

                step = "double click the playlist and then edit";
                IAction doubCplayGG = builder.MoveToElement(Driver.FindElement(By.XPath(".//*[text()='0test1']")))
                    .DoubleClick().Build();
                doubCplayGG.Perform();
                Pause(2);

                step = "the actual editing of the game group";
                Driver.FindElement(By.XPath(".//*[@id='Rips']/td[1]/div[2]/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlRipGameStatusType_listbox']/li[2]")).Click();//rip type
                Pause(1);

                Driver.FindElement(By.XPath(".//*[@id='Rips']/td[2]/div[2]/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlRipCount_listbox']/li[2]")).Click();//rip count
                Pause(1);

                step = "edit the names of the text boxes";
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/form/fieldset/table/tbody/tr[1]/td[1]/div[2]/input")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/form/fieldset/table/tbody/tr[1]/td[1]/div[2]/input")).SendKeys("0test12");
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/form/fieldset/table/tbody/tr[1]/td[2]/div[2]/input")).Clear();
                Pause(1);
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/form/fieldset/table/tbody/tr[1]/td[2]/div[2]/input")).SendKeys("0t12");
                Pause(1);

                step = "click on save";
                Driver.FindElement(By.XPath("html/body/div[4]/div[2]/div/form/fieldset/table/tbody/tr[2]/td[3]/input")).Click();
                Pause(3);
                
                step = "delete previously created game group with delete key";
                IAction pressDelete = builder.SendKeys(Driver.FindElement(By.XPath(".//*[text()='0test12 -         0']")), Keys.Delete).Build();
                pressDelete.Perform();
                Pause(2);

                step = "reject the alert and try to delete again";
                Driver.SwitchTo().Alert().Dismiss();
                Pause(2);

                step = "accept the alert this time";
                IAction pressDelete2 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[text()='0test12 -         0']")), Keys.Delete).Build();
                pressDelete2.Perform();
                Pause(1);
                Driver.SwitchTo().Alert().Accept();
                Pause(1);

                step = "delete group created earlier";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip-1']/span/span/span[2]/span")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlGroupType_listbox']/li[2]")).Click();
                Pause(1);

                step = "delete previously created group with delete key";
                IAction pressDelete3 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[text()='101test1 -         2']")), Keys.Delete).Build();
                pressDelete3.Perform();
                Pause(2);

                step = "reject the alert and try to delete again";
                Driver.SwitchTo().Alert().Dismiss();
                Pause(1);

                step = "accept the alert this time";
                IAction pressDelete4 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[text()='101test1 -         2']")), Keys.Delete).Build();
                pressDelete4.Perform();
                Pause(1);
                Driver.SwitchTo().Alert().Accept();
                Pause(1);

                step = "try refresh on Groups and Games tab";
                Driver.FindElement(By.XPath(".//*[@id='onGroupRefresh']")).Click();
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='tabStrip']/ul/li[2]/a")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='onDHGamesRefresh']")).Click();
                Pause(2);


                step = "test the Stage button and delete the playlist";
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[1]/a")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[2]/a")).Click();
                Pause(3);

                int total = Driver.FindElements(By.XPath(".//*[@id='Playlists']/table/tbody/tr")).Count;
                string index = null;
                bool playlist_delete = false;

                for (int i = 1; i <= total; i++)
                {
                    string pos = i.ToString();
                    string play_name = Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[" + pos + "]/td[2]")).Text;
                    index = pos;
                    playlist_delete = play_name.Equals("11111test11111");

                    if (playlist_delete == true)
                    {
                        break;
                    }
                }

                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[4]/button")).Click();//staged button
                Pause(2);
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[4]/button")).Click();
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[" + index + " ]/td[3]/a[2]/span")).Click();
                Pause(2);

                step = "reject the alert and try to delete again";
                Driver.SwitchTo().Alert().Dismiss();
                Pause(2);

                step = "accept the alert this time";
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[" + index + " ]/td[3]/a[2]/span")).Click();
                Pause(2);
                Driver.SwitchTo().Alert().Accept();

            }

            catch (Exception ex)
            {
                string errorFileName = "c:\\share\\Playlist_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }

        }

        [TestMethod]
        public void Add100notes()
        {
           Dictionary<string, string> outputParams = new Dictionary<string, string>();
            string step = "starting the playlist group/games test";
            Driver.Navigate().GoToUrl("http://devticker.foxneo.com");

            try
            {

                step = "Login page";
                Driver.Manage().Window.Maximize();
                ClickAndWait(By.XPath(".//*[@id='main']/p[2]/a"), "http://oauth.foxneo.com/Account/LogOn?ReturnUrl=%2fOpenId%2fAskUser");
                //Driver.FindElement(By.XPath(".//*[@id='main']/p[2]/a")).Click();
                Driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("GANEOSDT1");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("5432fox%A");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='main']/form/div/fieldset/p[4]/input")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='responseButtonsDiv']/input[1]")).Click();
                Pause(1);

                step = "Select the Client";
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(1);

                int total = Driver.FindElements(By.XPath(".//*[@id='Playlists']/table/tbody/tr")).Count;
                string index = null;
                bool playlist_delete = false;

                for (int i = 1; i <= total; i++)
                {
                    string pos = i.ToString();
                    string play_name = Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[" + pos + "]/td[2]")).Text;
                    index = pos;
                    playlist_delete = play_name.Equals("0000");

                    if (playlist_delete == true)
                    {
                        break;
                    }
                }
                                      //     html/body/div[1]/section/div[2]/div/table/tbody/tr[2]/td[3]/a[3]
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[3]/a[3]")).Click();
                Pause(2);

                step = "Create a new group";
                Driver.FindElement(By.XPath(".//*[@id='tabStrip']/ul/li[3]/a")).Click();
                Pause(1);

                step = "Enter text into Name and OnAirName";
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroup']")).SendKeys("0test1");
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='txtNewGroupOnAirName']")).SendKeys("0t1");
                Pause(2);

                step = "Click on the Save button";
                Driver.FindElement(By.XPath(".//*[@id='onNewGroup']")).Click();
                Pause(2);

                /*
                step = "find the group and double click it";
                Actions builder = new Actions(Driver);
                IAction doubleClick = builder.DoubleClick(Driver.FindElement(By.XPath(".//*[text()='101test -         0']"))).Build();
                doubleClick.Perform();
                Pause(3);
                */

                step = "Add 100 notes";

                for (int i = 0; i < 100; i++)
                {
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/div/a")).Click();
                    Pause(2);

                    step = "enter some text";
                    IWebElement iframe = Driver.FindElement(By.XPath("//iframe[@src='javascript:\"\"']"));
                    Driver.SwitchTo().Frame(iframe);

                    IWebElement body = Driver.FindElement(By.TagName("body")); // then you find the body
                    body.SendKeys(Keys.Control + "a"); // send 'ctrl+a' to select all
                    body.SendKeys("Ticker is GREAT");
                    body.SendKeys(" " + DateTime.Now.ToLongTimeString());

                    Driver.SwitchTo().DefaultContent();
                    Pause(2);

                    step = "click on update";
                    Driver.FindElement(By.XPath(".//*[@id='Notes']/table/tbody/tr/td[6]/a[1]")).Click();
                    Pause(2);
                }
            }

            catch (Exception ex)
            {
                string errorFileName = "c:\\share\\100notes_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }
        }

        [TestMethod]
        public void PlaylistNewGroup()
        {
            string step = "start test";
            Dictionary<string, string> outputParams = new Dictionary<string, string>();
            try
            {            
                Driver.Navigate().GoToUrl("http://docstoc.com");
                Driver.Manage().Window.Maximize();
                int size = Driver.FindElements(By.XPath("html/body/form/div[2]/div[3]/div/div[2]/div[1]/div[2]/ul[1]/li")).Count();
                string index = null;
                bool found = false;

                for (int i = 1; i < size; i++)
                {
                    index = i.ToString();
                    string compare = Driver.FindElement(By.XPath("html/body/form/div[2]/div[3]/div/div[2]/div[1]/div[2]/ul[1]/li[" + index + "]/a")).Text;
                    found = compare.Equals("Tax");
                    if (found == true)
                    {
                        break;
                    }
                }

                Driver.FindElement(By.XPath("html/body/form/div[2]/div[3]/div/div[2]/div[1]/div[2]/ul[1]/li[" + index + "]/a")).Click();

            }
            catch(Exception ex)
            {

                string errorFileName = "c:\\share\\test_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }
        }

        [TestMethod]
        public void Users()
        {
            Dictionary<string, string> outputParams = new Dictionary<string, string>();
            string step = "starting the Users test";
            Driver.Navigate().GoToUrl("http://devticker.foxneo.com");

            try
            {

                step = "Login page";
                Driver.Manage().Window.Maximize();
                Driver.FindElement(By.XPath(".//*[@id='main']/p[2]/a")).Click();
                Driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("GANEOSDT1");
                Driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("5432fox%A");
                Driver.FindElement(By.XPath(".//*[@id='main']/form/div/fieldset/p[4]/input")).Click();
                Driver.FindElement(By.XPath(".//*[@id='responseButtonsDiv']/input[1]")).Click();

                step = "Select the Client";
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(3);

                step = "click on Users tab";
                //Driver.FindElement(By.XPath("html/body/div[1]/header/div[2]/ul/li[1]/a")).Click();
                //Pause(5);
                Driver.FindElement(By.XPath("html/body/div[1]/header/div[2]/ul/li[3]/a")).Click();
                Pause(5);

                Actions builder = new Actions(Driver);
                /*
                step = "add a new user";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/div/a")).Click();
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[2]/input")).SendKeys("111");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[3]/input")).SendKeys("222");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[4]/input")).SendKeys("333");

                step = "set the drop down text box";
                IAction chooseTrue = builder.MoveToElement(Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[6]/select")))
                    .SendKeys(Keys.Down).Build();
                    chooseTrue.Perform();

                step = "click on cancel";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[5]/a[2]")).Click();

                step = "restart the process";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/div/a")).Click();
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[2]/input")).SendKeys("111");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[3]/input")).SendKeys("222");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[4]/input")).SendKeys("333");

                step = "set the drop down text box";
                IAction chooseNS = builder.MoveToElement(Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[6]/select")))
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Up).Build();
                chooseNS.Perform();

                step = "click on update";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[5]/a[1]")).Click();

                step = "enable admin mode";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[1]/td[7]/button")).Click();
                Pause(3);
                */
                step = "edit the newly created user";
                int size = Driver.FindElements(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr")).Count();
                string compare = null;
                string index = null;
                bool found = false;
                for (int i = 1; i < size; i++)
                {
                    index = i.ToString();
                    compare = Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[2]")).Text;
                    found = compare.Equals("0111");
                    if (found == true)
                    {
                        break;
                    }
                }

                step = "click on edit";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[5]/a")).Click();

                step = "edit the text with a 0 in the front";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[2]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[2]/input")).SendKeys("10111");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[3]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[3]/input")).SendKeys("10222");
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[4]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[4]/input")).SendKeys("10333");

                step = "set to false";
                IAction chooseFalse = builder.MoveToElement(Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[6]/select")))
                    .SendKeys(Keys.Down)
                    .SendKeys(Keys.Down).Build();
                chooseFalse.Perform();

                step = "change admin rights";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[7]/button")).Click();
                Pause(3);

                step = "deactivate/activate the user";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div[2]/div/table/tbody/tr[" + index + "]/td[6]/button")).Click();
            }
            catch (Exception ex)
            {
                string errorFileName = "c:\\share\\Users_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }
        }

        [TestMethod]
        public void Alerts()
        {
            Dictionary<string, string> outputParams = new Dictionary<string, string>();
            string step = "Start alerts test";
            Driver.Navigate().GoToUrl("http://devticker.foxneo.com");
            try
            {
                step = "Login page";
                Driver.Manage().Window.Maximize();
                Driver.FindElement(By.XPath(".//*[@id='main']/p[2]/a")).Click();
                Driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("GANEOSDT1");
                Driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("5432fox%A");
                Driver.FindElement(By.XPath(".//*[@id='main']/form/div/fieldset/p[4]/input")).Click();
                Driver.FindElement(By.XPath(".//*[@id='responseButtonsDiv']/input[1]")).Click();

                step = "Select the Client";
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(3);

                step = "click on Alerts tab";
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[4]/span")).Click();

                step = "create a new alert";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/div/a")).Click();

                step = "set type";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")).Click();
                Driver.FindElement(By.XPath(".//*[@id='BreakingNewsTypeID_listbox']/li[2]")).Click();

                step = "enter a name for the note; On Air Name; Header; Subject";
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[3]/input")).SendKeys("0testalert");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[4]/input")).SendKeys("0test");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[5]/input")).SendKeys("0tes");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[6]/input")).SendKeys("alert");

                step = "enter all the required fields and then cancel";
                IWebElement body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);
                body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);

                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]")).SendKeys("5");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]")).SendKeys("77");

                step = "click on cancel";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[9]/a[2]")).Click();
                Pause(2);
                //Actions builder = new Actions(Driver);
                //IAction pressDelete4 = builder.SendKeys(Driver.FindElement(By.XPath(".//*[text()='101test1 -         2']")), Keys.Delete).Build();
                //pressDelete4.Perform();

                step = "restart the process of adding a alert";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/div/a")).Click();

                step = "set type";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")).Click();
                Driver.FindElement(By.XPath(".//*[@id='BreakingNewsTypeID_listbox']/li[2]")).Click();

                step = "enter a name for the note; On Air Name; Header; Subject";
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[3]/input")).SendKeys("0testalert");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[4]/input")).SendKeys("0test");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[5]/input")).SendKeys("0tes");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[6]/input")).SendKeys("alert");

                step = "edit Repeat and Graphics Between";
                body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);
                body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);

                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]")).SendKeys("5");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]")).SendKeys("77");

                step = "click on update";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[9]/a[1]")).Click();

                step = "click on edit and edit the alert";
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[9]/a[1]")).Click();

                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[2]/span[1]/span/span[2]/span")).Click();
                Driver.FindElement(By.XPath(".//*[@id='BreakingNewsTypeID_listbox']/li[3]")).Click();

                step = "enter a name for the note; On Air Name; Header; Subject";
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[3]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[3]/input")).SendKeys("1testalert2");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[4]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[4]/input")).SendKeys("1test2");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[5]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[5]/input")).SendKeys("1tes");
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[6]/input")).Clear();
                Driver.FindElement(By.XPath("html/body/div[1]/div/div/table/tbody/tr[1]/td[6]/input")).SendKeys("alert2");

                step = "edit Repeat and Graphics Between";
                body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);
                body = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]"));
                body.SendKeys(Keys.Control + "a" + Keys.Delete);

                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[7]/span[1]/span/input[1]")).SendKeys("8");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[8]/span[1]/span/input[1]")).SendKeys("88");

                step = "click on update";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[9]/a[1]")).Click();

                step = "click on Enable";
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[10]/a")).Click();
                Driver.SwitchTo().Alert().Dismiss();
                Pause(2);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[1]/td[10]/a")).Click();
                Pause(2);
                Driver.SwitchTo().Alert().Accept();

                step = "find the alert again to delete it";
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[2]/a")).Click();
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();//select client again
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(3);
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[4]/span")).Click();//click alert 
                Pause(3);

                step = "delete the alert";
                int count = Driver.FindElements(By.XPath(".//*[@id='Alerts']/table/tbody/tr")).Count();
                string index = null;
                bool alert_delete = false;
                for (int i = 1; i <= count; i++)
                {
                    index = i.ToString();
                    string alert_name = Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[" + index + "]/td[3]")).Text;
                    alert_delete = alert_name.Equals("1testalert2");

                    if (alert_delete == true)
                    {
                        break;
                    }
                }

                step = "cancel then accept the alert";
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[" + index + "]/td[9]/a[2]")).Click();
                Pause(2);
                Driver.SwitchTo().Alert().Dismiss();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Alerts']/table/tbody/tr[" + index + "]/td[9]/a[2]")).Click();
                Pause(2);
                Driver.SwitchTo().Alert().Accept();


            }

            catch (Exception ex)
            {
                string errorFileName = "c:\\share\\Alerts_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }


        }

        [TestMethod]
        public void Logs()
        {
            Dictionary<string, string> outputParams = new Dictionary<string, string>();
            string step = "start Logs test";
            //Open("http://devticker.foxneo.com");
            Driver.Navigate().GoToUrl("http://devticker.foxneo.com");
            try
            {
                step = "Login page";
                Driver.Manage().Window.Maximize();
                Driver.FindElement(By.XPath(".//*[@id='main']/p[2]/a")).Click();
                Driver.FindElement(By.XPath(".//*[@id='username']")).SendKeys("GANEOSDT1");
                Driver.FindElement(By.XPath(".//*[@id='password']")).SendKeys("5432fox%A");
                Driver.FindElement(By.XPath(".//*[@id='main']/form/div/fieldset/p[4]/input")).Click();
                Driver.FindElement(By.XPath(".//*[@id='responseButtonsDiv']/input[1]")).Click();

                step = "Select the Client";
                Driver.FindElement(By.XPath(".//*[@id='divClient']/h2/span/span/span[2]")).Click();
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='ddlClients_listbox']/li[2]")).Click();
                Pause(3);

                step = "have to choose a playlist's details button first to be able to select the Logs tag";
                Driver.FindElement(By.XPath(".//*[@id='Playlists']/table/tbody/tr[1]/td[3]/a[3]")).Click();

                step = "click on the logs tab";
                Driver.FindElement(By.XPath(".//*[@id='menu']/li[5]/a")).Click();
                Pause(20);
                //ClickAndWaitForElement(By.XPath(".//*[@id='menu']/li[5]/a"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[2]"));
                /*
                step = "click on the Time, Username, Details and Object_Id to sort them";
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[2]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[2]"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[3]/a[2]"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[3]/a[2]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[3]/a[2]"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[4]/a[2]"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[4]/a[2]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[4]/a[2]"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[5]/a[2]"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[5]/a[2]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[5]/a[2]"), By.XPath(".//*[@id='Logs']/div/ul/li[2]/a"));

                step = "test the sorting of the pages";

                //Actions builder = new Actions(Driver);
                //IAction pressEnter = builder.SendKeys(Driver.FindElement(By.XPath(".//*[@id='Logs']/div/span[1]/input")), Keys.Enter).Build();
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/ul/li[2]/a")).Click();//click on 2
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/ul/li[2]/a"), By.XPath(".//*[@id='Logs']/div/a[3]/span"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/a[3]/span")).Click();//click on the next page
                Pause(20);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/a[3]/span"), By.XPath(".//*[@id='Logs']/div/span[1]/input"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/span[1]/input")).SendKeys(Keys.Control + "a" + Keys.Delete);//enter a manual number into text box
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/span[1]/input")).SendKeys("10");
                Pause(1);
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/span[1]/input")).SendKeys(Keys.Return);
                //pressEnter.Perform();
                Pause(20);
                //IWebElement body = Driver.FindElement(By.XPath(".//*[@id='Logs']/div/span[1]/input"));
                //body.SendKeys(Keys.Control + "a" + Keys.Delete);
                //body.SendKeys("10");
                //body.SendKeys(Keys.Return);
                //Pause(20);
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/a[2]/span")).Click();//click the previous page
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/a[2]/span"), By.XPath(".//*[@id='Logs']/div/ul/li[7]/a"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/ul/li[7]/a")).Click();//click on ... forward
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/ul/li[7]/a"), By.XPath(".//*[@id='Logs']/div/ul/li[1]/a"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/ul/li[1]/a")).Click();//click on ... backward
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/ul/li[1]/a"), By.XPath(".//*[@id='Logs']/div/a[1]/span"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/a[1]/span")).Click();//click on first page
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/a[1]/span"), By.XPath(".//*[@id='Logs']/div/a[4]/span"));
                Driver.FindElement(By.XPath(".//*[@id='Logs']/div/a[4]/span")).Click();//click on last page
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='Logs']/div/a[4]/span"), By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span"));

                step = "test the different actions";
                Driver.FindElement(By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span")).Click();//addition
                Driver.FindElement(By.XPath(".//*[@id='flags_listbox']/li[2]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='flags_listbox']/li[2]"), By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span"));

                step = "action change";
                Driver.FindElement(By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span")).Click();//change
                Driver.FindElement(By.XPath(".//*[@id='flags_listbox']/li[3]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='flags_listbox']/li[3]"), By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span"));

                step = "action deletion";
                Driver.FindElement(By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span")).Click();//deletion
                Driver.FindElement(By.XPath(".//*[@id='flags_listbox']/li[4]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='flags_listbox']/li[4]"), By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span"));

                step = "back to all";
                Driver.FindElement(By.XPath(".//*[@id='main']/div/div[1]/h2/span/span/span[2]/span")).Click();//deletion
                Driver.FindElement(By.XPath(".//*[@id='flags_listbox']/li[1]")).Click();
                Pause(15);
                //ClickAndWaitForElement(By.XPath(".//*[@id='flags_listbox']/li[1]"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[1]/span"));
                
                step = "test the logic for time";
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[1]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/input")).SendKeys("9/18/2013");
            
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();//change And to Or
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[2]")).Click();

                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[4]/span/span[2]/span")).Click();//change Is equal to...to is not equal to
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[5]/div/ul/li[2]")).Click();//is not equal to
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[5]/span/input")).SendKeys("9/20/2013");//the second date entered

                step = "click on Clear";
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[1]")).Click();
                Pause(20);
                //ClickAndWaitForElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[1]"), By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[1]/span"));

                step = "restart the logic for time";
                Driver.FindElement(By.XPath(".//*[@id='Logs']/table/thead/tr/th[2]/a[1]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/span/span")).Click();//calender button
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[3]/div/div/div[1]/a[1]/span")).Click();//previous month click
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[3]/div/div/div[1]/a[3]/span")).Click();//next month button
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[3]/div/div/table/tbody/tr[4]/td[5]/a")).Click();//click on the 9/19/2013

                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();//change And to Or
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[2]")).Click();

                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[4]/span/span[2]/span")).Click();//change Is equal to...to is not equal to
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[5]/div/ul/li[2]")).Click();//is not equal to
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[5]/span/input")).SendKeys("9/20/2013");//the second date entered

                step = "click on Filter";
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[1]")).Click();
                Pause(20);
                //ClickAndWaitForElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[1]"), By.XPath("html/body/div[4]/form/div[2]/div/ul/li[1]"));

                step = "set 2nd to is not equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[1]", "And", "html/body/div[4]/form/div[5]/div/ul/li[2]", null, null);

                step = "set 2nd to is after or equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[1]", "Or", "html/body/div[4]/form/div[5]/div/ul/li[3]", null, null);

                step = "set 2nd to is after";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[1]", "And", "html/body/div[4]/form/div[5]/div/ul/li[4]", null, null);

                step = "set 2nd to is before or equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[1]", "Or", "html/body/div[4]/form/div[5]/div/ul/li[5]", null, null);

                step = "set 2nd to is before ";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[1]", "And", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);

                step = "change the logic of the first input sections to is not equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[2]", "Or", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);

                step = "set logic to is after or equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[3]", "And", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);
                
                step = "set to is after";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[4]", "Or", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);

                step = "set to is before or equal to";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[5]", "And", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);
                
                step = "set to is before";
                Logic("html/body/div[4]/form/div[2]/div/ul/li[6]", "Or", "html/body/div[4]/form/div[5]/div/ul/li[6]", null, null);
                step = "test the  3 other logic columns";
                
                step = "test the logic for username cancel first";
                Driver.FindElement(By.XPath("html/body/div[1]/section/div/div[4]/table/thead/tr/th[3]/a[1]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[1]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[2]/div/ul/li[2]")).Click();//is not equal to
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/input[1]")).SendKeys("111");
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[2]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[3]/div/ul/li[2]")).Click();//or
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/span[3]/span/span[2]/span")).Click();
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[4]/div/ul/li[2]")).Click();//is not equal to
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/input[2]")).SendKeys("222");
                Pause(3);
                Driver.FindElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[2]")).Click();
                Pause(20);
                //ClickAndWaitForElement(By.XPath("html/body/div[4]/form/div[1]/div[2]/button[2]"), By.XPath("html/body/div[4]/form/div[2]/div/ul/li[1]"));
                */
                step = "test the logic for Username, Details, Object_Id";
                for (int i = 4; i < 7; i++)
                {
                    string column_click = null;
                    string column = i.ToString();

                    if (i == 4)
                    {
                        column_click = "5";
                    }
                    if (i == 5)
                    {
                        column_click = "4";
                    }
                    if (i == 6)
                    {
                        column_click = "3";
                    }

                    if ((i == 4) || (i == 5) || (i == 6))
                    {
                        Pause(5);
                        //test logic for username and choose Filter changing the second logic setting
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[1]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "Or", "html/body/div[" + column + "]/form/div[4]/div/ul/li[2]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[3]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "Or", "html/body/div[" + column + "]/form/div[4]/div/ul/li[4]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[5]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[1]", "Or", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);

                        //test logic for username and choose Filter changing the first logic setting
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[2]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[3]", "Or", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[4]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[5]", "Or", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);
                        Logic2("html/body/div[" + column + "]/form/div[2]/div/ul/li[6]", "And", "html/body/div[" + column + "]/form/div[4]/div/ul/li[6]", column, column_click);
                    }
                }

            }

            catch (Exception ex)
            {
                string errorFileName = "c:\\share\\Logs_" + step + "_" + DateTime.Now.ToString("dd_MMM_h_mmtt") + ".png";
                outputParams.Add("errorFileName", errorFileName);
                Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile(errorFileName, System.Drawing.Imaging.ImageFormat.Png);
                VerificationErrors.Add("Error on step: " + step + ": " + ex.Message);
                NUnit.Framework.Assert.Fail();
            }
        }


    }
}

