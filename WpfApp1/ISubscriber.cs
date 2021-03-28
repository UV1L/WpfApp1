using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using Automation = System.Windows.Automation;

namespace WpfApp1
{
    interface ISubscriber
    {
        void SubscribeToFocusChange();

        void OnFocusChange(object src, AutomationFocusChangedEventArgs e);

        void UnsubscribeFocusChange();
    }
}
