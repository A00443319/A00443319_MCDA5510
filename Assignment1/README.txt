This is a README file for Assignment 1, a CSV Parser program in C#


Class description:

DirWalker.cs
Traverses the directories and sub directories looking for csv files

CsvParser.cs
The parsing logic of the program resides in CsvParser.cs, which reads the Sample of csv files and determines whether the csv record is good or bad based on the custom conditions that has been defined; See below,

Conditions that determine a bad csv record:
- First and Last name being empty
- Phone number being non-numeric
- Email not containing '@' symbol

Good record gets stored in /Output folder.
Bad record gets put in /Logs folder.


Fields.cs
A class with csv header names. 

Logger.cs
A custom logger that prints out the date, time of the log and the log message.

Utils.cs
Contains reusable variables like current, output csv and log directory paths.
If current directory needs to changed, update currentDir. 