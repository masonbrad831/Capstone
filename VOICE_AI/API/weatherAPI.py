import requests
import json
from geopy.geocoders import Nominatim
import socket

from requests.api import get

key = '5cc27c4497e04bcc9cf151852212211'


def GetIp():
    hostname = socket.gethostname()
    ip_address = socket.gethostbyname(hostname)
    return ip_address



def getWeather(city):
    uri = 'http://api.weatherapi.com/v1/current.json?key={}&q={}&aqi=no'.format(key,city)

    response = requests.get(uri)
    data = response.json()

    locationJson = data["location"]
    cityName = locationJson["name"]
    state = locationJson["region"]

    weatherData = data["current"]
    condition = weatherData["condition"]

    weather = condition["text"]

    listData = [cityName, state, weather]
    return listData


