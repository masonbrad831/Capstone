import speech_recognition
import pyttsx3 as tts
import sys
from numpy import random

recognizer = speech_recognition.Recognizer()

speaker = tts.init()
speaker.setProperty('rate', 150)

insults = ["If I had a face like yours, I'd sue my parents",
            "I guess you prove that even god makes mistakes sometimes",
            "You must have been born on a highway because that's where most accidents happen",
            "You're so ugly, you scared the crap out of the toilet",
            "If laughter is the best medicine, your face must be curing the world",
            "Brains aren't everything. In your case they're nothing",
            "Some babies were dropped on their heads but you were clearly thrown at a wall",
            "They say opposites attract. I hope you meet someone who is good-looking, intelligent, and cultured",
            "You are not as bad as people say, you are much, much worse",
            "The last time I saw something like you, I flushed it",
            "If ugly were a crime, you'd get a life sentence",
            "I may not be real, but you’ll always be ugly",
            "I don't know what your problem is, but I'll bet it's hard to pronounce"]

jokes = ["What do you call a blonde who dyes her hair brown? Artificial intelligence",
            "I went to buy some camo pants but could not find any",
            "I want to die peacefully in my sleep, like my grandfather Not screaming and yelling like the passengers in his car",
            "I told him to be himself that was pretty mean, I guess",
            "The easiest time to add insult to injury is when you’re signing someones cast"]

names = ["My name is Coeus",
            "My name is Coeus, Just like the greek god of intelligence",
            "Just like the greek god of intelligence, my name is Coeus"]

greetings = ["Hello!", 
          "Good to see you again!",
           "Hi there, how can I help?"]

goodbyes = ["Sad to see you go", 
          "Talk to you later", 
          "Goodbye!"]
moods = ["Im doing good, how about you",
        "Im doing really well",
        "Im doing good considering im not real"]

def getRandomResponse(list):
    length = len(list)
    x = random.randint(length)

    return list[x]


def hello():
    speaker.say(getRandomResponse(greetings))
    speaker.runAndWait()

def goodbye():
    speaker.say(getRandomResponse(goodbyes))
    speaker.runAndWait()

def mood():
    speaker.say(getRandomResponse(moods))
    speaker.runAndWait()

def quit():
    speaker.say("Goodbye, see you around")
    speaker.runAndWait()
    sys.exit(0)

def joke():
    speaker.say(getRandomResponse(jokes))
    speaker.runAndWait()

def insult():
    speaker.say(getRandomResponse(insults))
    speaker.runAndWait()

def name():
    speaker.say(getRandomResponse(names))
    speaker.runAndWait()
