using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Speech.Synthesis;
using System.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using WpfApp1.finder;
using WpfApp1.finder.automation;

namespace WpfApp1
{
    class Logic
    {
        private WindowElementFinder finder;
        private Speaker speaker;
        public Logic(NotepadAutomationElementFinder finder, Speaker speaker)
        {
            this.finder = finder;
            this.speaker = speaker;
        }

        public void Run()
        {
            FocusHandler focusHandler = new FocusHandler(finder, speaker);
            focusHandler.SubscribeToFocusChange();
        }      
    }
}
