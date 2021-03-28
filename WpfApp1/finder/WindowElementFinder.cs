using System.Collections.Generic;
using System.Windows.Automation;
using WpfApp1.finder;

namespace WpfApp1
{
    interface WindowElementFinder
    {
        IEnumerable<WindowElement> FindAllElements(WindowElement src);

        IEnumerable<WindowElement> FindFloatingMenuElements(WindowElement src);

    }
}
