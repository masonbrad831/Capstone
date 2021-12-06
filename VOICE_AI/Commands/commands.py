import speech_recognition
import pyttsx3 as tts
import mongodb
import os
from datetime import datetime
import webbrowser
import pyautogui

recognizer = speech_recognition.Recognizer()

speaker = tts.init()
speaker.setProperty('rate', 150)

def Copy():
    pyautogui.hotkey('ctrl', 'c')
    pyautogui.hotkey('ctrl', 'c')

def Paste():
    pyautogui.hotkey('ctrl', 'v')

def time():
    now = datetime.now()
    current_time = now.strftime( "%I:%M %p")
    speaker.say("it is currently " + current_time)
    speaker.runAndWait()


def date():
    now = datetime.now()
    date = now.today().strftime('%m-%d-%Y')
    speaker.say("it is currently " + date)
    speaker.runAndWait()

def show_todos():
    speaker.say("The items on your to-do list are")

    for item in mongodb.FindAllTodo():
        speaker.say(item)
    speaker.runAndWait()

def OpenChrome():
    try:
        os.startfile('chrome.exe')
    except Exception:
        print("falied")

def CloseChrome():
    try:
        os.system('TASKKILL /F /IM chrome.exe')
    except Exception:
        print("failed")

def OpenYoutube():
    webbrowser.open('https://www.youtube.com')

def OpenTwitch():
    webbrowser.open('https://www.twitch.com')

def OpenCanvas():
    webbrowser.open('https://lms.neumont.edu/')