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

        public SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();
        VoiceAI ai = new VoiceAI();


        public string input { get; set; }
        


        public void initGrammer()
        {
            try
            {
                SpeechRecognition.SetInputToDefaultAudioDevice();

                DictationGrammar defaultDictationGrammar = new DictationGrammar();
                defaultDictationGrammar.Name = "default dictation";
                defaultDictationGrammar.Enabled = true;

                DictationGrammar customDictationGrammar = new DictationGrammar("grammar:dictation");
                customDictationGrammar.Name = "question dictation";
                customDictationGrammar.Enabled = true;

                DictationGrammar spellingDictationGrammar = new DictationGrammar("grammar:dictation#spelling");
                spellingDictationGrammar.Name = "spelling dictation";
                spellingDictationGrammar.Enabled = true;

                SpeechRecognition.LoadGrammar(defaultDictationGrammar);
                SpeechRecognition.LoadGrammar(customDictationGrammar);
                SpeechRecognition.LoadGrammar(spellingDictationGrammar);
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
            input = e.Result.Text;
            Trace.WriteLine("Input " + input);
            stopListen();
            Commands commands = new Commands();
            commands.run(input);
            WakeWord wake = new WakeWord();
            wake.initGrammer();
        }
    }
}
