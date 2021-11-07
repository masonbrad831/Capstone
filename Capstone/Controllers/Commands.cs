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







        public void run(string input)
        {

            Trace.WriteLine("INPUT  " + input);
            string tag = ai.GetTag(input);
           

            switch (tag)
            {
                case "Greeting":
                    api.play(ai.GetRequest(input));
                    break;
                case "Goodbye":
                    api.play(ai.GetRequest(input));
                    break;
                case "Good Morning":
                    api.play(ai.GetRequest(input));
                    break;
                case "Goodnight":
                    api.play(ai.GetRequest(input));
                    break;
                case "Mood":
                    api.play(ai.GetRequest(input));
                    break;
                case "Time":
                    Time();
                    break;
                case "Date":
                    Date();
                    break;
                default:
                    Trace.WriteLine("SHITT  " + input + "   " + tag);
                    break;
            }
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
            api.play("What would you like to search");
        }

        public void Location(string location)
        {

        }       
        public void Location()
        {
            api.play("What location would you like to see");
        }

        public void Date()
        {
            string date = DateTime.Now.ToString("MMMM d, yyyy");
            api.play(date);

        }


    }
}
