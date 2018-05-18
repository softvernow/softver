using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using softver.View;
using System;
using System.Collections.Generic;
using System.Linq;

namespace softver.Models
{
    public class WhatsappModel
    {
        private String GROUP_NAME;
        private int NUMBER_OF_MEDIAS;
        public IWebDriver driver;


        public WhatsappModel()
        {
            
        }


        public WhatsappModel(IWebDriver driver, String GROUP_NAME, int NUMBER_OF_MEDIAS)
        {
            this.GROUP_NAME = GROUP_NAME;
            this.NUMBER_OF_MEDIAS = NUMBER_OF_MEDIAS;
            this.driver = driver;
        }


        /// <summary>
        /// Close media section
        /// </summary>
        public void Close_Media_Selection_Page()
        {
            try
            {
                IWebElement query3 = driver.FindElement(By.ClassName("_1aTxu"));
                query3.Click();
            }
            catch
            {
                Console.Write("");
            }

             
        }

        /// <summary>
        /// Close each media. 
        /// </summary>
        public void Close_Media()
        {

            IList<IWebElement> clicks = driver.FindElements(By.CssSelector("[title^='Close']"));
            //IWebElement web = null;

            // int count = 0;
            foreach (IWebElement element in clicks)
            {
                try
                {
                    element.Click();
                }
                catch
                {
                    //return web;
                }


            }

            //return web;
        }





        /// <summary>
        /// Open whatsapp web. 
        /// </summary>
        /// <param name="Save_Path"></param>
        public void Open_Page(String Save_Path)
        {

            if (Save_Path != null)
            {
                var chromeOptions = new ChromeOptions();
                var downloadDirectory = Save_Path;

                chromeOptions.AddUserProfilePreference("download.default_directory", downloadDirectory);
                chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
                chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");


                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(driverService, chromeOptions);
            }
            else
            {

                var driverService = ChromeDriverService.CreateDefaultService();
                driverService.HideCommandPromptWindow = true;
                driver = new ChromeDriver(driverService);
            }

      

            try
            {
                driver.Navigate().GoToUrl("https://web.whatsapp.com/");

            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// Get group information from whatsapp web. 
        /// </summary>
        /// <returns></returns>
        public List<String> Get_Groups()
        {
            List<String> result = new List<String>();

             IList<IWebElement> all = driver.FindElements(By.ClassName("_25Ooe"));

            foreach (IWebElement element in all)
            {
                if(element.Text.Length != 0)
                    result.Add(element.Text);
            }

            result = result.OrderBy(x => x).ToList();

            return result;

        }


        /// <summary>
        /// Select desired group. 
        /// </summary>
        /// <param name="group_name"></param>
        public void Select_Group(String group_name)
        {

            try
            {
                IList<IWebElement> all = driver.FindElements(By.ClassName("_25Ooe"));
                foreach (IWebElement element in all)
                {
                    if (element.Text.ToLower().Contains(group_name.ToLower()))
                    {
                        try
                        {
                            IWebElement query = element;
                            query.Click();
                        }
                        catch
                        {

                        }
                    }
                }


                Waiting(0);

                IWebElement query2 = driver.FindElement(By.ClassName("_1WBXd"));
                query2.Click();
            }
            catch
            {
                throw new System.ArgumentException("Try this group again, Could not open media section");
            }

        }



        public void Select_Group()
        {

            IList<IWebElement> all = driver.FindElements(By.ClassName("_1wjpf"));
            foreach (IWebElement element in all)
            {
                if (element.Text.ToLower().Contains(GROUP_NAME))
                {
                    IWebElement query = element;
                    query.Click();
                }
            }


            Waiting(0);

            IWebElement query2 = driver.FindElement(By.ClassName("_1WBXd"));
            query2.Click();


        }


        /// <summary>
        /// Open all media section. 
        /// </summary>
        public void Open_All_Media()
        {
            IList<IWebElement> all123 = driver.FindElements(By.ClassName("_1sYdX"));
            foreach (IWebElement element in all123)
            {
                try
                {

                    if (element.Text.ToLower().Contains("media"))
                    {
                        IWebElement query = element;
                        query.Click();
                    }
                }
                catch
                {

                }

            }
        }



        /// <summary>
        /// Retrieves number of media. 
        /// </summary>
        /// <returns></returns>
        public int Number_Of_Medias()
        {
            IList<IWebElement> all123 = driver.FindElements(By.ClassName("_2Ry6_"));
            int count = 0;
            foreach (IWebElement element in all123)
            {
                count++;
            }

            return count;
        }


        /// <summary>
        /// Opens and saves each media individually.
        /// </summary>
        /// <param name="number_of_medias"></param>
        public void Open_And_Save_Each_Media(int number_of_medias)
        {

            var element12 = driver.FindElement(By.ClassName("_2Ry6_"));

            element12.Click();

            IWebElement e = Get_Previous_Click(driver);
            IWebElement e_download = Get_Download_Click(driver);

            for (int j = 0; j < number_of_medias; j++)
            {

                if (e != null)
                {
                    try
                    {

                        if (Is_Waiting())
                        {
                            e.Click();
                        }

                        e_download.Click();
                        Boolean cancel = Waiting(j+1);

                        if (!cancel)
                            break;

                        e.Click();

                    }
                    catch
                    {

                    }


                }

            }
        }


        /// <summary>
        /// Checks if media still loading. 
        /// </summary>
        /// <returns></returns>
        public Boolean Is_Waiting()
        {
            IList<IWebElement> all123 = driver.FindElements(By.ClassName("_1l3ap"));
            foreach (IWebElement element in all123)
            {
                return true;

            }

            return false;
        }



        /// <summary>
        /// Opens downloading screen. 
        /// </summary>
        /// <param name="j"></param>
        /// <returns></returns>
        private Boolean Waiting(int j)
        {
            FlipPageView flipPageView = new FlipPageView(j.ToString(), 3);
            flipPageView.ShowDialog();

            Boolean RESULT = flipPageView.RESULT;
            flipPageView.Close();

            return RESULT;
        }

     

        /// <summary>
        /// cleans up driver. 
        /// </summary>
        public void Close()
        {
            if (driver != null)
            {
                //driver.Close();
                driver.Quit();
                driver = null;
            }
                
        }



        /// <summary>
        /// Get download button. 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        private IWebElement Get_Download_Click(IWebDriver driver)
        {

            IList<IWebElement> clicks = driver.FindElements(By.CssSelector("[title^='Download']"));
            IWebElement web = null;

            foreach (IWebElement element in clicks)
            {
                try
                {
                    web = element;
                }
                catch
                {
                    return web;
                }


            }

            return web;
        }


        /// <summary>
        /// Gets Previous button. 
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        private IWebElement Get_Previous_Click(IWebDriver driver)
        {

            IList<IWebElement> clicks = driver.FindElements(By.CssSelector("[title^='Previous']"));
            IWebElement web = null;

            foreach (IWebElement element in clicks)
            {
                try
                {
                    web = element;
                }
                catch
                {
                    return web;
                }

               
            }

            return web;
        }
    }
}
