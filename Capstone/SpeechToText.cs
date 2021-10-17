using System;
using System.Collections.Generic;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;


namespace Capstone
{
    class SpeechToText
    {
        //private static string key = "mpE5NH8lrqwYJz6JogLQ9inVlSn0vuEktbVwkf-h8_Mu";
        //private static string uRL = "https://api.au-syd.speech-to-text.watson.cloud.ibm.com/instances/becdeaf6-01a2-439d-9843-3c76696873b6";

        TextToSpeechAPI textToSpeech = new TextToSpeechAPI();

        // Grammer and Responses
        string grammerFile = @"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt";
        string[] grammer = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\grammer.txt"));

        //Speach Synth
        //SpeechSynthesizer speechSynth = new SpeechSynthesizer();

        //Speech Recognition
        Choices grammerList = new Choices();
        SpeechRecognitionEngine SpeechRecognition = new SpeechRecognitionEngine();


        public void initGrammer()
        {
            grammerList.Add(grammer);
            Grammar grammar = new Grammar(new GrammarBuilder(grammerList));

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

            //speechSynth.SelectVoiceByHints(VoiceGender.Female);
        }

        //public void say(string text)
        //{
        //    speechSynth.SpeakAsync(text);
        //}

        private void rec_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            String result = e.Result.Text;


            //foreach (string s in grammer)
            //{
            //    if (result == s && s != "")
            //    {
            //        textToSpeech.SaveSound("How are you");
            //        textToSpeech.PlaySound();
            //        textToSpeech.DeleteSound("outputWAV.wav", @"C:\temp");
            //        textToSpeech.DeleteSound("output.wav", @"C:\temp");
            //    }
            //}


            textToSpeech.SaveSound(result);
            textToSpeech.PlaySound();
            textToSpeech.DeleteSound("outputWAV.wav", @"C:\temp");
            textToSpeech.DeleteSound("output.wav", @"C:\temp");


            Console.WriteLine(result);

            //using (StreamWriter sw = File.AppendText(grammerFile))
            //{
            //    sw.WriteLine(result);
            //}
        }
    }
}
