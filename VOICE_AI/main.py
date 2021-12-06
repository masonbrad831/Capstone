from neuralintents import GenericAssistant
import speech_recognition
import Commands.commands as c
import Commands.InputCommands as ic
import Commands.TalkbackCommands as tc
import winsound


recognizer = speech_recognition.Recognizer()

mappings = {
    "greeting": tc.hello,
    "goodbye": tc.goodbye,
    "time" : c.time,
    "search" : ic.search,
    "mood" : tc.mood,
    "date" : c.date,
    "joke" : tc.joke,
    "insult": tc.insult,
    "location": ic.location,
    "create_note": ic.create_note,
    "add_todo": ic.addTodo,
    "show_todo": c.show_todos,
    "openChrome": c.OpenChrome,
    "exitChrome": c.CloseChrome,
    "calendar" : ic.AddCalendar,
    # "timer" : ic.getTimer,
    "name" : tc.name,
    "weather" : ic.Weather,
    "copy": c.Copy,
    "paste" : c.Paste,
    "youtube" : c.OpenYoutube,
    "twitch" : c.OpenTwitch,
    "canvas" : c.OpenCanvas,
    "exit": tc.quit
}
def makeSound():
    winsound.PlaySound("Assets\ding.wav", winsound.SND_FILENAME)


assistant = GenericAssistant('intents.json', intent_methods=mappings)
assistant.train_model()
print('Coeus is up and Running. Try saying ''hello''.')
while True:
    try:
        with speech_recognition.Microphone() as mic:

            recognizer.adjust_for_ambient_noise(mic, duration=0.2)
            audio = recognizer.listen(mic)

            message = recognizer.recognize_google(audio)
            message = message.lower()
            makeSound()
            assistant.request(message)
    except speech_recognition.UnknownValueError:
        recognizer = speech_recognition.Recognizer()
