using Capstone.Controllers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Speech.Recognition;
using System.Text;

namespace Capstone.Voice
{
    class WakeWord
    {


        string[] grammer = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\WakeWord.txt"));
        public SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();

        SpeechToText speech = new SpeechToText();

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

            SpeechRecognition.RecognizeAsync(RecognizeMode.Multiple);

        }


        public void stopListen()
        {
            SpeechRecognition.RecognizeAsyncCancel();
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;

            if (result.Contains("Coeus"))
            {
                stopListen();
                speech.initGrammer();
            }
            Trace.WriteLine("Input " + result);
        }
    }
}
