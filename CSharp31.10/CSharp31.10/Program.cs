using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSharp31._10
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new Book("qwe", 2400, "Vadim", 2000);
            Book book2 = new Book("asd", 11230, "Vamid", 1999);
            Book book3 = new Book("zxc", 15740, "Admin", 2001);
            Book book4 = new Book("123", 12200, "Adnim", 2010);
            BookCountTestClass book5 = new BookCountTestClass();
            book5.OneMethod();
            
            BinaryFormatter formatter = new BinaryFormatter();
            
            using (FileStream fs = new FileStream("Book.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book1);
                formatter.Serialize(fs, book2);
                formatter.Serialize(fs, book3);
                formatter.Serialize(fs, book4);
                Console.WriteLine("Объект сериализован");
            }
            
            using (FileStream fileStream = new FileStream("Book.dat", FileMode.OpenOrCreate))
            {
                Book book = (Book)formatter.Deserialize(fileStream);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine("Название: " + book.Name + " Цена: " + book.Cost + " Автор: " + book.Author + " Год издания: " + book.Year);
            }

            Console.ReadLine();

        }
    }
}
