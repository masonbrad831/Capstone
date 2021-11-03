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

        Location location = new Location();
        Search search = new Search();
        VoiceAI ai = new VoiceAI();
        SpeechToText speech = new SpeechToText();

        string[] greeting = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\greetings.txt"));
        string[] goodbye = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\goodbye.txt"));
        string[] goodMorning = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\goodMorning.txt"));
        string[] goodnight = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\goodnight.txt"));
        string[] mood = (File.ReadAllLines(@"C:\Code\Github\Capstone\Capstone\Grammer\mood.txt"));

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
            search.stopListen();
        }       
        public void Search()
        {
            speech.stopListen();
            api.play("What would you like to search");
            search.listen();
        }

        public void Location(string location)
        {

        }       
        public void Location()
        {
            speech.stopListen();
            api.play("What location would you like to see");
            location.listen();
        }

        public void Date()
        {
            string date = DateTime.Now.ToString("MMMM d, yyyy");
            api.play(date);

        }

        public void Greeting()
        {
            api.play(GetResponse(greeting));
        }

        public void Goodbye()
        {
            api.play(GetResponse(goodbye));
        }

        public void Mood()
        {

        }

        public void Morning()
        {
            api.play(GetResponse(goodMorning));
        }

        public void Goodnight()
        {
            api.play(GetResponse(goodnight));
        }

    }
}
