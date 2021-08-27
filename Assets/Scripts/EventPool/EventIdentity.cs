using System;

namespace CFramework.EventUni
{
    public class EventIdentity : Attribute
    {
        public string Identifier { get; set; }
        public EventIdentity(string identifier)
        {
            Identifier = identifier;
        }

        public EventIdentity()
        {

        }
    }

    public class CompentID:Attribute
    {
        public string Identifier { get; set; }

        public CompentID(string identifier)
        {
            Identifier = identifier;
        }

        public CompentID()
        {

        }
    }

    public class EventID:Attribute
    {
        public string Identifier { get; set; }

        public EventID(string identifier)
        {
            Identifier = identifier;
        }

        public EventID()
        {

        }
    }

}


