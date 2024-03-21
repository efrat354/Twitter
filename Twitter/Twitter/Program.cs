using System.ComponentModel.DataAnnotations;

namespace Twitter
{
    internal class Program
    {
        private static void rectangle()
        {
            int height, width;
            Console.WriteLine("Enter height and width of the tower");
            height = int.Parse(Console.ReadLine()!);
            width = int.Parse(Console.ReadLine()!);
            if (height == width || Math.Abs(height - width) > 5)
            {
                Console.WriteLine("The rectangle's area is: " + (height * width));
            }
            else
            {
                Console.WriteLine("The rectangle's perimeter is: " + (2 * height + 2 * width));
            }
        }
        private static void triangle()
        {
            int choice = 0, height, width;
            Console.WriteLine("Enter height and width of the tower");
            height = int.Parse(Console.ReadLine()!);
            width = int.Parse(Console.ReadLine()!);

            Console.WriteLine("Enter 1 to calculate the perimeter\n2 to print the tower");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                throw new Exception("Invalid input. Please enter a valid choice.");
            }
            switch (choice)
            {
                case 1:
                    Console.WriteLine("The triangle's perimeter: " + (width + 2 * Math.Sqrt(Math.Pow(height, 2) + Math.Pow(0.5 * width, 2))));
                    break;

                case 2:
                    if (width % 2 == 0 || width / 2 > height)
                    {
                        Console.WriteLine("Impossible to print the triangle");
                    }
                    else
                    {
                        bool flag = false;
                        //Amount of types= ((width - 2) / 2) 
                        //The number of times the type suppose to be print (height - 2) / ((width - 2) / 2).
                        int length = (height - 2) / ((width - 2) / 2);

                        Console.WriteLine("{0," + width / 2 + "}*", " ");//The first line
                        for (int i = 1; i < ((width - 2) / 2)+1; i++)
                        {
                            if (i==1&& (height - 2) % ((width - 2) / 2)!=0)//If the number of rows in the middle does not divide exactly
                            {
                                flag = true;
                                length += (height - 2) % ((width - 2) / 2);//Add to the first time the rest.
                            }
                            for (int j = 0; j < length; j++)
                            {
                                Console.Write("{0," + (width/2 - i) + "}", " ");
                                for (int k = 0; k < 2 * i + 1 && k < width; k++)
                                {
                                    Console.Write("*");

                                    //רוחב פחות 2 לחק לשתיים זה מספר הסוגים שצריך להיות
                                    //גובה פחות 2 לחק למספר הסוגים שצריך להיות אם נשאר אחוזים זה לא מתחלק נכון והשארית צריכה להיות מספר השורות הנוספות מהסוג הראשון
                                }
                                Console.WriteLine();
                            }
                            if (flag == true)
                            {
                                flag = false;
                                length -= (height - 2) % ((width - 2) / 2);
                            }
                        }
                        for (int j = 0; j < width; j++)
                        {
                            Console.Write("*");
                        }
                        Console.WriteLine();
                    }

                    break;
                default:
                    throw new Exception("your choice is invalid");
            }
        }
        static void Main(string[] args)
        {

            try
            {
                int choice = 0;
                Console.WriteLine("Enter 1 to rectangle tower\n2 to triangle tower\n 3 to exit ");
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    throw new Exception("Invalid input. Please enter a valid choice.");
                }

                while (choice != 0)
                {
                    switch (choice)
                    {
                        case 1:
                            rectangle();
                            break;

                        case 2:
                            try
                            {
                                triangle();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                            break;

                        case 3:
                            break;

                        default:
                            throw new Exception("your choice is invalid");
                    }
                    Console.WriteLine("Enter 1 to rectangle tower\n2 to triangle tower\n 3 to exit ");
                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        throw new Exception("Invalid input. Please enter a valid choice.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}