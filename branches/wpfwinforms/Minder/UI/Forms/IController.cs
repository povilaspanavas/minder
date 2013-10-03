using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Minder.UI.Forms
{
    public interface IController
    {
        Window Window { get; }

        void PrepareWindow();
    }
}
