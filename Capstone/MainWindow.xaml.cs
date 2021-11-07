using Capstone.Controllers;
using Capstone.Voice;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Capstone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        WakeWord wakeWord = new WakeWord();

        public MainWindow()
        {
            InitializeComponent();
            wakeWord.initGrammer();
            wakeWord.listen();
        }

    }
}

