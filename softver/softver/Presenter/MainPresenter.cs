using OpenQA.Selenium;
using softver.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace softver.Models.Presenter
{
    public class MainPresenter
    {

        private MainModel model;
        private MainView view;

        public MainPresenter(MainModel model, MainView view)
        {
            this.model = model;
            this.view = view;

            view.Presenter = this;
        }

        public WhatsappModel Whatsapp(IWebDriver driver, String Group_name, String number_of_Medias)
        {
            return model.Whatsapp(driver, Group_name, Convert.ToInt32(number_of_Medias));
        }

        public WhatsappModel WhatsappWeb()
        {
            return model.WhatsappWeb();
        }

        
    }
}
