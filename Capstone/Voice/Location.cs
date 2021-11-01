using Capstone.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Speech.Recognition;
using System.Text;

namespace Capstone.Voice
{
    class Location
    {
        string[] grammer = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\location.txt"));
        public SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();

        Commands commands = new Commands();

        public void initGrammer()
        {
            try
            {
                SpeechRecognition.SetInputToDefaultAudioDevice();
                SpeechRecognition.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(grammer))));
                SpeechRecognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(rec_SpeechRecognized);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void listen()
        {
            SpeechRecognition.RecognizeAsync(RecognizeMode.Multiple);

        }

        public void stopListen()
        {
            SpeechRecognition.RecognizeAsyncCancel();
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            commands.Location(result);
        }
    }
}
