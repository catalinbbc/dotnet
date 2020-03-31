using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace iClockEx
{
    public struct BusinessDate : IFormattable, IEquatable<BusinessDate>, IComparable<BusinessDate>, IXmlSerializable
    {

        private const string Iso8601DateFormat = "yyyy-MM-dd";
        private const string Iso8601DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.fffZ";

        private DateTime myDate;
        
        public DateTime MyDate { get => myDate; set => myDate = value; }
        public int Day { get => MyDate.Day; }
        public int Month { get => MyDate.Month; }
        public int Year { get => MyDate.Year; }
        //public IFormatProvider InvariantCulture { get; private set; }

        public BusinessDate(int day, int month, int year)
        {
            this.myDate = new DateTime(year, month, day, 0, 0, 0, DateTimeKind.Unspecified);
        }

        public BusinessDate(DateTime dateTime) : this()
        {
            this.myDate = dateTime;
        }

        public override string ToString()
        {
            string day = this.Day < 10 ? "0" + this.Day.ToString(): this.Day.ToString();
            string month = this.Month < 10 ? "0" + this.Month.ToString(): this.Month.ToString();

            return String.Join('-', day, month, this.Year);
        }

        public string ToString(string format)
        {
            return MyDate.ToString(format);
        }

       
        private object EscapeTimeFormatSpecifiers(string format)
        {
            return new BusinessDateFormatStringBuilder(format).EscapeFormatSpecifier("h")
               .EscapeFormatSpecifier("H")
               .EscapeFormatSpecifier("m")
               .EscapeFormatSpecifier("s")
               .EscapeFormatSpecifier("f")
               .EscapeFormatSpecifier("z")
               .EscapeFormatSpecifier("F")
               .EscapeFormatSpecifier("t")
               .EscapeFormatSpecifier("K")
               .ToString();
        }

        int IComparable<BusinessDate>.CompareTo(BusinessDate other)
        {
            string internalDateString = String.Join('-', this.Year, this.Month, this.Day);
            string compareToString    = String.Join('-', other.Year, other.Month, other.Day);
            return String.Compare(internalDateString, compareToString);
        }

        bool IEquatable<BusinessDate>.Equals(BusinessDate other)
        {
            if (this.Day == other.Day && this.Month == other.Month && this.Year == other.Year)
            {
                return true;
            }
                
            return false;
        }

        public int CompareTo([AllowNull] BusinessDate other)
        {
            string currentStr = String.Join('-', this.Year, this.Month, this.Day);
            string otherStr = String.Join('-', other.Year, other.Month, other.Day);
            return String.Compare(currentStr, otherStr);
        }

        public bool Equals([AllowNull] BusinessDate other)
        {
            if (this.Day == other.Day && this.Month == other.Month && this.Year == other.Year)
            {
                return true;
            }

            return false;
        }

        public static bool operator == (BusinessDate obj1, BusinessDate obj2)
        {

            return obj1.Equals(obj2);
        }

        public static bool operator != (BusinessDate obj1, BusinessDate obj2)
        {

            return !obj1.Equals(obj2);
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            var text = reader.ReadElementContentAsString();
            this = new BusinessDate(DateTime.ParseExact(text, Iso8601DateFormat, CultureInfo.InvariantCulture));
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            return myDate.ToString(format, formatProvider);
        }

        public static BusinessDate ParseFromIso8601String(string str)
        {
            DateTime  tempDate = DateTime.ParseExact(str, Iso8601DateFormat, CultureInfo.InvariantCulture);

            return new BusinessDate(tempDate.Day, tempDate.Month, tempDate.Year);
        }
    }


    public class BusinessDateFormatStringBuilder
    {
        private readonly StringBuilder builder;
        public BusinessDateFormatStringBuilder(string format)
        {
            builder = new StringBuilder(format);
        }
        public BusinessDateFormatStringBuilder EscapeFormatSpecifier(string formatSpecifier)
        {
            builder.Replace(formatSpecifier, "\\" + formatSpecifier);
            return this;
        }
        public override string ToString()
        {
            return builder.ToString();
        }
    }
}
