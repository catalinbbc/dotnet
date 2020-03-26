using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iClockEx
{
     public class SystemClock : IClock
    {
        DateTime IClock.Now => throw new NotImplementedException();

        DateTime IClock.UtcNow => throw new NotImplementedException();

        BusinessDate IClock.Today => throw new NotImplementedException();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {
        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }

        int IComparable<BusinessDate>.CompareTo(BusinessDate other)
        {
            throw new NotImplementedException();
        }

        bool IEquatable<BusinessDate>.Equals(BusinessDate other)
        {
            throw new NotImplementedException();
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }

   
}
