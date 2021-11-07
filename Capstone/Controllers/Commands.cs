using Capstone.Voice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;


namespace Capstone.Controllers
{
    class Commands
    {
        TextToSpeechAPI api = new TextToSpeechAPI();

        VoiceAI ai = new VoiceAI();
        SpeechToText speech = new SpeechToText();


        public string GetResponse(string[] input)
        {
            Random rand = new Random();
            int x = rand.Next(0, input.Length);

            return input[x];
        }
        public void Time()
        {
            speech.stopListen();
            string time = DateTime.Now.ToString("h:mm tt");
            api.play(time);
        }

        public void Search(string input)
        {
        }       
        public void Search()
        {
            speech.stopListen();
            api.play("What would you like to search");
        }

        public void Location(string location)
        {

        }       
        public void Location()
        {
            speech.stopListen();
            api.play("What location would you like to see");
        }

        public void Date()
        {
            string date = DateTime.Now.ToString("MMMM d, yyyy");
            api.play(date);

        }


    }
}
