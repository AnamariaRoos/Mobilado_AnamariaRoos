﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mobilado_AnamariaRoos
{
    public class BasePage
    {

        public IWebDriver driver;
        

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        
    }
}
