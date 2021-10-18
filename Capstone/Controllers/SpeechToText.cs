using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Diagnostics;
using Capstone.Controllers;

namespace Capstone
{
    class SpeechToText
    {
        TextToSpeechAPI textToSpeech = new TextToSpeechAPI();
        VoiceAI ai = new VoiceAI();

        // Grammer and Responses
        //string grammerFile = @"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt";
        //string[] grammer = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt"));

        Choices grammerList = new Choices();
        SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();
        String result;


        public string initGrammer()
        {
            //Grammar grammar = new Grammar(new GrammarBuilder(grammerList));

            try
            {
                SpeechRecognition.RequestRecognizerUpdate();
                SpeechRecognition.LoadGrammar(new DictationGrammar());
                SpeechRecognition.SpeechRecognized += rec_SpeechRecognized;
                SpeechRecognition.SetInputToDefaultAudioDevice();
                SpeechRecognition.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Trace.WriteLine(result + "INIT");
            return result;
        }


        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            result = e.Result.Text;

            //using (StreamWriter sw = File.AppendText(@"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt"))
            //{
            //    sw.WriteLine("\"" + result + "\",");
            //}

            //textToSpeech.SaveSound(result);
            //textToSpeech.PlaySound();
            //textToSpeech.DeleteSound("outputWAV.wav", @"C:\temp");
            //textToSpeech.DeleteSound("output.wav", @"C:\temp");

            //ai.GetRequest(result);
            Trace.WriteLine("Input " + result);
            Trace.WriteLine("getRequest " + ai.GetRequest(result));



        }

    }
}
