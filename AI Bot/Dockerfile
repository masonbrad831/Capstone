# Dockerfile, Image, Container
FROM python:3.9.5


COPY requirements.txt . 




ADD app.py .


ADD intents.json classes.pkl words.pkl chatbotmodel.h5 training.py .

RUN pip install -r requirements.txt
RUN python -m nltk.downloader all

CMD ["python", "./app.py"]