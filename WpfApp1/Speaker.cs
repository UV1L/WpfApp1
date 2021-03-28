using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;
using Automation = System.Windows.Automation;
using System.Linq;
using System.Speech.Synthesis;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ScreanReader
{
    class Speaker : INotifyPropertyChanged
    {

        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        public event PropertyChangedEventHandler PropertyChanged;

        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public void Speak(string text)
        {
            synthesizer.SpeakAsyncCancelAll();
            synthesizer.SpeakAsync(text);
            Text += "\n" + text;
        }

        public void Cancel() 
        {
            synthesizer.SpeakAsyncCancelAll();
        } 
    }
}
