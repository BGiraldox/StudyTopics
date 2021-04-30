using ExtensionMethods;
using System;

namespace Study
{
    //AN EVENT CAN BE INVOKED BY WHO HAS IT, AT LEAST YOU INHERIT IT.
    internal class Program
    {
        public delegate void SendMessage(string message);

        public static event SendMessage SendMessageEvt;

        //Delegates
        // Params
        public Func<string> test = () => "";

        // Void
        public Action testVoid = () => Console.WriteLine("Hey");

        // Bool
        public static Predicate<int> IsAnAdult = age => age > 18;

        private static void Main(string[] args)
        {
            //Delegate&Events
            //InitDelegateEventsInherit();
            //InitDelegateEventsNoInherit();

            //TestingAnonymousFunc();

            //var isAdult = IsAnAdult(11);

            //var wordCapitalizedTest = "a".Capitalice();

            LinqStudy.Sample_ToLookup_Lambda();
        }

        public static void InitDelegateEventsInherit()
        {
            new SubscriberOne();
            new SubscriberTwo();
        }

        public static void InitDelegateEventsNoInherit()
        {
            new SubscriberThree();
            new SubscriberFour();
            SendMessageEvt("Test");
        }

        //Anonymous methods
        public static void TestingAnonymousFunc()
        {
            SendMessage anonymousFunc = name => Console.WriteLine("This is the msj here : " + name);
            anonymousFunc("Anonymous");
        }
    }

    #region Delegate&Events No Ihnerit

    public class SubscriberThree
    {
        public SubscriberThree()
        {
            Program.SendMessageEvt += new Program.SendMessage(this.SusbscriberMessage);
        }

        private void SusbscriberMessage(string message)
        {
            Console.WriteLine($"Message is : I'm three");
        }
    }

    public class SubscriberFour
    {
        public SubscriberFour()
        {
            Program.SendMessageEvt += new Program.SendMessage(this.SusbscriberMessage);
        }

        private void SusbscriberMessage(string message)
        {
            Console.WriteLine($"Message is : I'm four");
        }
    }

    #endregion Delegate&Events No Ihnerit

    #region Delegate&Events Inherit

    public class Publisher
    {
        public delegate void GetAnswer(object sender, string name);

        public event GetAnswer GetAnswerEvent;

        protected virtual void CallMeEvent(string name)
        {
            GetAnswer delegado = CallMeBaby;
            GetAnswerEvent += delegado;

            GetAnswerEvent?.Invoke(this, name);
        }

        public void CallMeBaby(object subscriber, string val)
        {
            Console.WriteLine($"the subscriber is a {subscriber.GetType()} and the value is {val}");
        }
    }

    public class SubscriberOne : Publisher
    {
        public SubscriberOne()
        {
            Init();
        }

        private void Init()
        {
            CallMeEvent("Subscriber One");
        }
    }

    public class SubscriberTwo : Publisher
    {
        public SubscriberTwo()
        {
            Init();
        }

        private void Init()
        {
            CallMeEvent("Subscriber Two");
        }
    }

    #endregion Delegate&Events Inherit
}