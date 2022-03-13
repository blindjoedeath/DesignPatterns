using System;
using System.Linq;
using System.Collections.Generic;	

namespace Patterns.ChainOfResponsibilityClassic
{
    public struct UserData 
    {
        public double level;
        public double intelect;
        public double power;
        public double mana;
    }

    public abstract class QuestComponentChecker
    {
        public QuestComponentChecker NextChecker;

        public abstract string ErrorMessage { get; }

        public abstract bool IsComplete(UserData data);

        public string CheckIfError(UserData data)
        {
            if (this.IsComplete(data))
            {
                if (this.NextChecker != null)
                {
                    return this.NextChecker.CheckIfError(data);
                } 
                else
                {
                    return "This quest is for you!";
                } 
            }
            return this.ErrorMessage;
        }
    }

    public class StartLevelChecker: QuestComponentChecker
    {
        public override bool IsComplete(UserData data) 
        {
            return data.level > 1;
        }

        public override string ErrorMessage
        {
            get 
            {
                return "You have to level up!";
            }
        }
    }

    public class WarriorChecker: QuestComponentChecker
    {
        public override bool IsComplete(UserData data) 
        {
            return data.level > 10 && data.power > 15;
        }

        public override string ErrorMessage
        {
            get 
            {
                return "You have to be stronger warrior!";
            }
        }
    }

    public class WizzardChecker: QuestComponentChecker
    {
        public override bool IsComplete(UserData data) 
        {
            return data.mana > 12 && data.intelect > 20;
        }

        public override string ErrorMessage
        {
            get 
            {
                return "You have to be more wizzard!";
            }
        }
    }

    public class EasyQuest 
    {
        public string MessageOnRequest(UserData data) 
        {
            var levelChecker = new StartLevelChecker();
            return levelChecker.CheckIfError(data);
        }
    }

    public class HardQuest 
    {
        public string MessageOnRequest(UserData data) 
        {
            var warriorChecker = new WarriorChecker();
            var wizzardChecker = new WizzardChecker();

            warriorChecker.NextChecker = wizzardChecker;

            return warriorChecker.CheckIfError(data);
        }
    }
}