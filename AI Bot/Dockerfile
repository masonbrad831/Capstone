# Dockerfile, Image, Container
FROM python:3.9.5


COPY requirements.txt . 




ADD app.py .


ADD Bot/intents.json Bot/classes.pkl Bot/words.pkl Bot/chatbotmodel.h5 Bot/training.py ./Bot/

RUN pip install -r requirements.txt
RUN python -m nltk.downloader punkt

CMD ["python", "./app.py"]