using Capstone.Voice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Speech.Recognition;
using System.Text;

namespace Capstone.Controllers
{
    class SpeechToText
    {

        string[] grammer = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt"));
        public SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();


        VoiceAI ai = new VoiceAI();
        TextToSpeechAPI TextToSpeech = new TextToSpeechAPI();

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
            initGrammer();
            SpeechRecognition.RecognizeAsync(RecognizeMode.Multiple);

        }

        public void stopListen()
        {
            SpeechRecognition.RecognizeAsyncCancel();
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string result = e.Result.Text;
            string request = ai.GetRequest(result);

            Trace.WriteLine("Input " + result);
            Trace.WriteLine("getRequest " + request);
        }
    }
}
