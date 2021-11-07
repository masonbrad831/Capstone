using Capstone.Controllers;
using Capstone.Voice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capstone.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        SpeechToText speechToText = new SpeechToText();

        public HomeView()
        {
            InitializeComponent();
        }



        private void listen_btn_Click(object sender, RoutedEventArgs e)
        {
            speechToText.listen();

            
            Image image = VoiceWave;
            if (image.Visibility == Visibility.Visible)
            {
                image.Visibility = Visibility.Hidden;
            }
            else
            {
                image.Visibility = Visibility.Visible;
            }
        }
    }
}
