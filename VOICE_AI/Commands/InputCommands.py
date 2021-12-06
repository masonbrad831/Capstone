import speech_recognition
import pyttsx3 as tts
import mongodb
import webbrowser
import API.weatherAPI as weather

recognizer = speech_recognition.Recognizer()

speaker = tts.init()
speaker.setProperty('rate', 150)

def create_note():
    global recognizer

    speaker.say("What do you want to write onto your note")
    speaker.runAndWait()

    done = False

    while not done:
        try:

            with speech_recognition.Microphone() as mic:

                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                note = recognizer.recognize_google(audio)
                note = note.lower()

                speaker.say("Choose a note name!")
                speaker.runAndWait()

                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                filename = recognizer.recognize_google(audio)
                filename = filename.lower()

                mongodb.InsertNotes({"noteName": filename, "note" : note})

                done = True
                speaker.say(f"I wrote your note " + filename)
                speaker.runAndWait()

        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()


def addTodo():
    global recognizer

    speaker.say('What to-do do you want to add?')
    speaker.runAndWait()

    done = False
    while not done:
        try:

            with speech_recognition.Microphone() as mic:
                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                item = recognizer.recognize_google(audio)
                item = item.lower()

                mongodb.InsertTodo({"todo": item})
                done = True

                speaker.say("I added {item} to the to-do list")
                speaker.runAndWait()
        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()


# def timer(t):
#     while t:
#         mins, secs = divmod(t, 60)
#         timer = '{:02d}:{:02d}'.format(mins, secs)
#         print(timer, end="\r")
#         timer.sleep(1)
#         t -= 1


# def getTimer(): 
#     global recognizer
#     speaker.say("how many seconds would you like the timer to go for?")
#     speaker.runAndWait()

#     done = False
#     while not done:
#         try:

#             with speech_recognition.Microphone() as mic:
#                 recognizer.adjust_for_ambient_noise(mic, duration=0.2)
#                 audio = recognizer.listen(mic)

#                 timeStr = recognizer.recognize_google(audio)
#                 time = ''.join(filter(str.isdigit, timeStr))

#                 print(time)
#                 done = True
#                 speaker.say("Timer set for " + time + " seconds")
#                 speaker.runAndWait()
#         except speech_recognition.UnknownValueError:
#             recognizer = speech_recognition.Recognizer()
#             speaker.say("Im sorry I didnt understant, please say that again")
#             speaker.runAndWait()
#     timer(int(time))


def search():
    global recognizer
    speaker.say("What do you want to search?")
    speaker.runAndWait()
    done = False
    while not done:
        try:

            with speech_recognition.Microphone() as mic:
                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                search = recognizer.recognize_google(audio)
                search = search.lower()

                done = True

                
                webbrowser.open('https://www.google.com/search?q='+search)
                speaker.say("searching for " + search)
                speaker.runAndWait()
        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()


def location():
    global recognizer
    speaker.say("What location do you want to search for?")
    speaker.runAndWait()
    done = False
    while not done:
        try:

            with speech_recognition.Microphone() as mic:
                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                search = recognizer.recognize_google(audio)
                search = search.lower()

                done = True

                
                webbrowser.open('https://www.google.com/maps/place/'+search)
                speaker.say("looking for " + search)
                speaker.runAndWait()
        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()
def AddCalendar():
    global recognizer
    speaker.say('what would you like to add to your calendar')
    speaker.runAndWait()

    done = False
    while not done:
        try:

            with speech_recognition.Microphone() as mic:

                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                info = recognizer.recognize_google(audio)
                info = info.lower()

                speaker.say("when do you want this to be? please use format month, day, year")
                speaker.runAndWait()

                recognizer.adjust_for_ambient_noise(mic,duration=0.2)
                audio = recognizer.listen(mic)

                date = recognizer.recognize_google(audio)
                date = date.lower()

                splitDate = date.split()

                month = splitDate[0]
                day = splitDate[1]
                year = splitDate[2]

                done = True
                
                speaker.say("Succesfully added " + info + " On " + date)

                speaker.runAndWait()

        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()

def Weather():
    global recognizer
    speaker.say('What city or zipcode do you want weather from?')
    speaker.runAndWait()

    done = False
    while not done:
        try:
            with speech_recognition.Microphone() as mic:
                recognizer.adjust_for_ambient_noise(mic, duration=0.2)
                audio = recognizer.listen(mic)

                city = recognizer.recognize_google(audio)
                city = city.lower()

                city = weather.getWeather(city)[0]
                state = weather.getWeather(city)[1]
                txt = weather.getWeather(city)[2]

                done = True

                speaker.say('The weather in {}, {} is {} today'.format(city, state, txt))

        except speech_recognition.UnknownValueError:
            recognizer = speech_recognition.Recognizer()
            speaker.say("Im sorry I didnt understant, please say that again")
            speaker.runAndWait()