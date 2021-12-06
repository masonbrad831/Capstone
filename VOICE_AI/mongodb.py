from pymongo import MongoClient

cluster = MongoClient("mongodb+srv://Masonbrad831:hoohm099@cluster0.88jsu.mongodb.net/myFirstDatabase?retryWrites=true&w=majority")
db = cluster["Capstone"]
todo = db["Todo"]
notes = db["Notes"]
calendar = db["Calendar"]


def InsertTodo(post):
    todo.insert_one(post)


def FindAllTodo():
    results = todo.find({})
    todoList = []
    for x in results:
        todoList.append(x["todo"])
    return todoList


def DeleteFromTodo(input):
    results = todo.delete_one({"todo":input})

def InsertNotes(post):
    notes.insert_one(post)

def FindAllNotes():
    results = notes.find({})
    noteList = []
    for x in results:
        noteList.append(x["note"])
    return noteList

def DeleteFromNotes(input):
    results = notes.delete_one({"note" : input})

def InsertCalendar(post):
    calendar.insert_one(post)