using System;
using Patterns.ChainOfResponsibilityClassic;

var quest = new EasyQuest();
var userData = new UserData()
{
    level = 1,
    intelect = 41,
    power = 12,
    mana = 32
};
Console.WriteLine(quest.MessageOnRequest(userData));