from ibm_watson import TextToSpeechV1
from ibm_cloud_sdk_core.authenticators import IAMAuthenticator
import json

from ibm_watson.text_to_speech_v1 import Voice




def SaveSound(output):
    authenticator = IAMAuthenticator('n5vCzRzoQOW7bhBosz7D3E58-Dl7nuFgMEzk9-m-J1Dc')
    text_to_speech = TextToSpeechV1(
    authenticator=authenticator
    )

    text_to_speech.set_service_url('https://api.au-syd.text-to-speech.watson.cloud.ibm.com/instances/73384042-ca73-44fc-b98e-733432a043b2')

    voice = text_to_speech.get_voice('en-US_AllisonV3Voice').get_result()   

    with open('output.wav', 'wb') as audio_file:
        audio_file.write(
            text_to_speech.synthesize(
                output,
                voice='en-US_AllisonV3Voice',
                accept='audio/wav'        
            ).get_result().content)

