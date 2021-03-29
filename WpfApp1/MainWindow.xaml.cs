using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Automation;
using Automation = System.Windows.Automation;
using System.ComponentModel;
using System.Threading;
using ScreanReader.finder.automation;

namespace ScreanReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string TextToShow { get; set; }
        private bool isStartedFlag = false;
        private AutomationElement RootElement { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            RootElement = AutomationElement.RootElement;
            ToScrollAsync();
        }

        public void RunApp(object sender, RoutedEventArgs e)
        {
            while (!isStartedFlag)
            {
                Logic app;
                if (!(RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Notepad")) == null))
                {
                    app = new Logic(new NotepadAutomationElementFinder(AutomationElement.RootElement), this.Resources["speaker"] as Speaker);
                    app.Run();
                    isStartedFlag = true;
                    MessageBox.Show("Экранный диктор включен!");
                }
            }
        }

        async void ToScrollAsync()
        {
            await Task.Run(() => ToScroll());
        }

        private void ToScroll()
        {
            scrollViewer.ScrollToBottom();
        }
    }
}
    