using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Minder.Forms.Skins.Skin1;
using Core.Forms;

namespace Minder.Forms.Skins
{
    class WpfSkinPreparer : IFormPreparer
    {
        //IWpfSkin m_form = null;
        WpfSkin1 m_form = null;

        public WpfSkinPreparer()
        {
            m_form = new WpfSkin1();
        }

        public System.Windows.Forms.Form Form
        {
            get { throw new NotImplementedException(); }
        }
        
        public WpfSkin1 WpfForm
        {
        	get { return m_form; }
        }

        public void PrepareForm()
        {
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(m_form); 
//            m_form.MDateLabel.ContentStringFormat = "Ignas";
//            m_form.MTextBox.Text = "Ignas";
            m_form.ShowInTaskbar = false;
            m_form.MTextBox.Focus();
//            m_form.Hide();
        }

        public void SetEvents()
        {
           
        }
    }
}
