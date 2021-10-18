using Capstone.Controllers;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.TextToSpeech.v1;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Capstone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SpeechToText speechToText = new SpeechToText();
        TextToSpeechAPI textToSpeech = new TextToSpeechAPI();
        VoiceAI voiceAI = new VoiceAI();
        

        public MainWindow()
        {
            InitializeComponent();
            speechToText.initGrammer();
        }


        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_browser.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_browser.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        // MENU BUTTONS CLICKED
        private void Home_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }



        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{

        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    API api = new API();
        //    //api.SaveSound(input, dropdown);
        //    api.PlaySound();
        //    api.DeleteSound("outputWAV.wav", @"C:\temp");
        //    api.DeleteSound("output.wav", @"C:\temp");
        //    //webBrowser1.Source = new Uri("https://www.google.com/maps/place/" + input.Text);
        //}

        //private void dropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListViewItem_Selected_1(object sender, RoutedEventArgs e)
        {

        }


    }
}

