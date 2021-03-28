using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace ScreanReader.finder.automation
{
    class AutomationElementToWindowElementMapper
    {
        public WindowElement Map(AutomationElement element)
        {
            return new WindowElement(element.Current.AutomationId, element.Current.Name);
        }
    }
}
