using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace library
{
    class Program
    {
        static void Main(string[] args)
        {
            //reading words
            string[] texts = File.ReadAllLines("bd.txt", Encoding.Default);
            
            int count = 0;
            count = texts.Count() - 1;

            //working condition
            bool work = true;

            while (work)
            {
                int k = 6; //for menu

                bool bmenu = true; //for menu

                int buff; //buff

                //menu
                while (bmenu)
                {
                    if ((k == 1) || (k == 2) || (k == 3) || (k == 4))
                    {
                        bmenu = false;
                    }
                    else
                    {
                        if (k == 0)
                        {
                            bmenu = false;
                            work = false;
                        }
                        else
                        {
                            Console.WriteLine();

                            menu();

                            k = int.Parse(Console.ReadLine());

                            Console.WriteLine();
                        }

                    }



                }

                int k1;

                switch (k)
                {
                    case (1):
                        //increased the array
                        Array.Resize(ref texts, texts.Length + 5);
                        count = count + 5;

                        //filling in the array
                        Console.WriteLine("UDC number");
                        texts[count - 4] = Console.ReadLine();

                        Console.WriteLine("Surname and initials of the author");
                        texts[count - 3] = Console.ReadLine();

                        Console.WriteLine("name");
                        texts[count - 2] = Console.ReadLine();

                        Console.WriteLine("year of publication");
                        texts[count - 1] = Console.ReadLine();

                        //Console.WriteLine("number of copies in the library");
                        texts[count] = "1";
                        break;
                    case (2):
                        k1 = search(texts, count); //book search

                        //checking availability
                        if ((k1 + 1) % 5 == 3)
                        {
                            Console.WriteLine("there is no such book");
                        }
                        else
                        {
                            k1--;

                            buff = int.Parse(texts[k1 + 2]);
                            buff++;
                            texts[k1 + 2] = buff.ToString();
                        }

                        break;
                    case (3):
                        k1 = search(texts, count); //book search

                        //checking availability
                        if ((k1 + 1) % 5 == 3)
                        {
                            Console.WriteLine("there is no such book");
                        }
                        else
                        {
                            k1--;

                            buff = int.Parse(texts[k1 + 2]);
                            buff--;
                            texts[k1 + 2] = buff.ToString();
                        }

                        break;
                    case (4):
                        k1 = search(texts, count); //book search

                        //checking availability
                        if ((k1 + 1) % 5 == 3)
                        {
                            Console.WriteLine("there is no such book");
                        }
                        else
                        {
                            k1--;
                            Console.WriteLine();
                            Console.WriteLine("UDC number: " + texts[k1 - 2]);
                            Console.WriteLine("Surname and initials of the author: " + texts[k1 - 1]);
                            Console.WriteLine("name: " + texts[k1]);
                            Console.WriteLine("year of publication: " + texts[k1 + 1]);
                            Console.WriteLine("number of copies in the library: " + texts[k1 + 2]);
                        }
                        break;
                    case (5):
                        k1 = search(texts, count); //book search

                        //checking availability
                        if ((k1 + 1) % 5 == 3)
                        {
                            Console.WriteLine("there is no such book");
                        }
                        else
                        {
                            k1--;
                            //reduced the array
                            Array.Resize(ref texts, texts.Length - 5);
                            count = count - 5;
                        }
                        break;
                }
            }

            
            File.Delete("bd.txt");
            File.WriteAllLines("bd.txt", texts);
  
        }
        static void menu()
        {
            Console.WriteLine("1) add a book");
            Console.WriteLine("2) get the book");
            Console.WriteLine("3) take a book");
            Console.WriteLine("4) find out information about the book");
            Console.WriteLine("5) delete a book");
            Console.WriteLine("enter 0 to exit");
        }
        static int search(string[] texts, int count)
        {
            int k2 = 0;
            StreamReader reader = new StreamReader("bd.txt", Encoding.Default);
            
            int i = 2;
            Console.WriteLine("enter the name of the book");
            string name_s = Console.ReadLine();
            while ((i + 3 < count) && (!texts[i].Equals(name_s)))
            {
                Console.WriteLine(texts[i]);
                i = i + 5;
            }
            if (texts[i].Equals(name_s))
                k2++;
            if (k2 > 0)
                i++;
            reader.Close();
            return i;
        }
    }
}
