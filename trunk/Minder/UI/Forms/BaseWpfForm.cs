﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Minder.UI.Forms
{
    public class BaseWpfForm : Window
    {
        public BaseWpfForm() : base()
        {
            this.KeyUp += delegate(object sender, KeyEventArgs e)
            {
                if (e.Key == Key.Escape)
                {
                    this.Close();
                }
            };
        }
    }
}
