using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softver.Models.Models
{
    public class MainModel
    {

        public WhatsappModel Whatsapp(IWebDriver driver, String Group_name, int number_of_Medias)
        {
            WhatsappModel wm = new WhatsappModel(driver ,Group_name, number_of_Medias);
            return wm;//.Start();
        }

        public WhatsappModel WhatsappWeb()
        {
            WhatsappModel wm = new WhatsappModel();
            return wm;//.Start();
        }
    }
}
