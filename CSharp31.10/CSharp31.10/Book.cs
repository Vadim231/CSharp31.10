using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CSharp31._10
{
    public enum Count
    {
        one=1,
        two,
        three
    }

    [Serializable]
    [AttributeUsage(AttributeTargets.Class)]
    public class Book : Attribute
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book(string name, int cost, string author, int year)
        {
            Name = name;
            Cost = cost;
            Author = author;
            Year = year;
        }
    }
  

    internal class BookCountAttribute : Attribute
    {
        protected Count count;
        public Count Count
        {
            get { return count; }
            set { count = value; }
        }
        public BookCountAttribute(Count count)
        {
            this.count = count;
        }
    }

    class BookCountTestClass
    {
        [BookCount(Count.one)]
        public void OneMethod() { Console.WriteLine("Одна книга"); }

        [BookCount(Count.two)]
        public void TwoMethod() { Console.WriteLine("Две книги"); }

        [BookCount(Count.three)]
        public void ThreeMethod() { Console.WriteLine("Три книги"); }
    }
}
