using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.TextToSpeech.v1;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
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

  
    class API
    {
        private static string key = "n5vCzRzoQOW7bhBosz7D3E58-Dl7nuFgMEzk9-m-J1Dc";
        private static string uRL = "https://api.au-syd.text-to-speech.watson.cloud.ibm.com/instances/73384042-ca73-44fc-b98e-733432a043b2";
        public void SaveSound(TextBox input, ComboBox dropdown)
        {
            IamAuthenticator authenticator = new IamAuthenticator(apikey: key);

            TextToSpeechService textToSpeech = new TextToSpeechService(authenticator);
            textToSpeech.SetServiceUrl(uRL);

            var result = textToSpeech.Synthesize
                (
                   text: input.Text,
                   accept: "audio/mp3",
                   voice: dropdown.Text
                );

            using FileStream fs = File.Create(@"C:\temp\output.wav");
            result.Result.WriteTo(fs);
            fs.Close();
            result.Result.Close();


        }
        private static void ConvertMp3ToWav(string _inPath_, string _outPath_)
        {
            using (Mp3FileReader mp3 = new Mp3FileReader(_inPath_))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(_outPath_, pcm);
                }
            }
        }
        public void PlaySound()
        {
            ConvertMp3ToWav(@"C:\temp\output.wav", @"C:\temp\outputWAV.wav");

            SoundPlayer simpleSound = new SoundPlayer(@"C:\temp\outputWAV.wav");
            simpleSound.PlaySync();
        }
        public void DeleteSound(string delete, string path)
        {

            try
            {
                // Check if file exists with its full path    
                if (File.Exists(System.IO.Path.Combine(path, delete)))
                {
                    // If file found, delete it    
                    File.Delete(System.IO.Path.Combine(path, delete));
                    Console.WriteLine("File deleted.");
                }
                else Console.WriteLine("File not found");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
        }
        public void createVoices(ComboBox dropbox)
        {
            try
            {
                IamAuthenticator authenticator = new IamAuthenticator(apikey: key);

                TextToSpeechService textToSpeech = new TextToSpeechService(authenticator);
                textToSpeech.SetServiceUrl(uRL);

                var result = textToSpeech.ListVoices();

                foreach (var voice in result.Result._Voices)
                {
                    //dropdown.Items.Add(voice.Name);
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Voice");
            }

            dropbox.Text = "-- Select --";
        }

    }
}
