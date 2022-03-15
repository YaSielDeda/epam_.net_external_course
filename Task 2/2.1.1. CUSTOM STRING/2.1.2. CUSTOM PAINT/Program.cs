using _2._1._2._CUSTOM_PAINT.Entities;
using SelfMadeLibrary;
using System;
using System.Collections.Generic;

namespace _2._1._2._CUSTOM_PAINT
{
    class Program
    {
        public static List<Shape> listOfShapes = new();
        static void Main(string[] args)
        {
            bool exit = false;

            var user = Login();

            while (!exit)
            {
                ShowMainMenu(user.Name);
                int.TryParse(Console.ReadLine(), out int switcher);
                
                switch (switcher)
                {
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(new CustomString("Unknown option!"));
                        Console.ResetColor();
                        break;
                    // Exit
                    case 1:
                        exit = true;
                        break;
                    // Change username
                    case 2:
                        user = Login();
                        break;
                    // Add new shape
                    case 3:
                        ShowChoosingTypeOfShapeMenu(user.Name);
                        int.TryParse(Console.ReadLine(),out int switchShape);
                        CreateShape(switchShape);
                        break;
                    // Show all created shapes
                    case 4:
                        if(listOfShapes.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("None of shapes is not created yet!");
                            Console.ResetColor();

                            break;
                        }

                        foreach (var shape in listOfShapes)
                        {
                            Console.WriteLine($"-----------{Environment.NewLine}{shape} ");
                        }
                        Console.WriteLine("-----------");
                        break;
                    // Clear canvas
                    case 5:
                        if(listOfShapes.Count != 0)
                        {
                            listOfShapes.Clear();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Now canvas is empty.");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("None of shapes is not created yet!");
                            Console.ResetColor();
                        }
                            
                        break;
                }
            }
        }

        private static User Login()
        {
            Console.Write("Enter your name: ");
            return new User(Console.ReadLine());
        }
        private static void ShowMainMenu(string name)
        {
            Console.WriteLine($"{name}, choose the option: {Environment.NewLine}" +
                              $"1. Exit {Environment.NewLine}" +
                              $"2. Switch user {Environment.NewLine}" +
                              $"3. Add Shape {Environment.NewLine}" +
                              $"4. Show all created shapes {Environment.NewLine}" +
                              $"5. Clear canvas (Erase all existed shapes)");
        }
        private static void ShowChoosingTypeOfShapeMenu(string name)
        {
            Console.WriteLine($"{name}, choose the type of shape to create: {Environment.NewLine}" +
                              $"1. To main menu {Environment.NewLine}" +
                              $"2. Round {Environment.NewLine}" +
                              $"3. Ring {Environment.NewLine}" +
                              $"4. Square {Environment.NewLine}" +
                              $"5. Rectangle {Environment.NewLine}" +
                              $"6. Line");
        }
        private static void CreateShape(int switcher)
        {
            bool back = false;

            while (!back)
            {
                switch (switcher)
                {
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Unknown option!");
                        Console.ResetColor();

                        break;
                    // To menu
                    case 1:
                        back = true;
                        break;
                    // Create round
                    case 2:
                        Console.WriteLine("Creating center point");
                        var RoundCenterPoint = CreatePoint();

                        try
                        {
                            Console.Write("Enter radius length: ");
                            double.TryParse(Console.ReadLine(), out double radius);

                            Console.WriteLine($"Create new round with next parameters: {Environment.NewLine}" +
                                $"Center point: {RoundCenterPoint} {Environment.NewLine}" +
                                $"Radius: {radius}? [y/n]");

                            if (Confirm())
                            {
                                listOfShapes.Add(new Round(RoundCenterPoint, radius));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New round is successfully created!");
                                Console.ResetColor();
                            }

                            back = true;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();

                            back = true;
                        }
                        break;
                    // Create ring
                    case 3:
                        Console.WriteLine("Creating center point");
                        var RingCenterPoint = CreatePoint();

                        try
                        {
                            Console.Write("Enter inner radius length: ");
                            double.TryParse(Console.ReadLine(), out double innerRadius);

                            Console.Write("Enter outer radius length: ");
                            double.TryParse(Console.ReadLine(), out double outerRadius);

                            Console.WriteLine($"Create new ring whith next parameters: {Environment.NewLine}" +
                                $"Center point: {RingCenterPoint} {Environment.NewLine}" +
                                $"Inner radius: {innerRadius} {Environment.NewLine}" +
                                $"Outer radius: {outerRadius}? [y/n]");

                            if (Confirm())
                            {
                                listOfShapes.Add(new Ring(RingCenterPoint, innerRadius, outerRadius));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New ring is successfully created!");
                                Console.ResetColor();
                            }

                            back = true;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();

                            back = true;
                        }
                        break;
                    // Create square
                    case 4:
                        Console.WriteLine("Creating center point");
                        var SquareCenterPoint = CreatePoint();

                        try
                        {
                            Console.Write("Enter width: ");
                            double.TryParse(Console.ReadLine(), out double squareWidth);

                            Console.WriteLine($"Create new square whith next parameters: {Environment.NewLine}" +
                                $"Center point: {SquareCenterPoint} {Environment.NewLine}" +
                                $"Width: {squareWidth} [y/n]");

                            if (Confirm())
                            {
                                listOfShapes.Add(new Square(SquareCenterPoint, squareWidth));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New square is successfully created!");
                                Console.ResetColor();
                            }

                            back = true;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();

                            back = true;
                        }

                        break;
                    // Create rectangle
                    case 5:
                        Console.WriteLine("Creating center point");
                        var RectangleCenterPoint = CreatePoint();

                        try
                        {
                            Console.Write("Enter width: ");
                            double.TryParse(Console.ReadLine(), out double rectangleWidth);

                            Console.Write("Enter height: ");
                            double.TryParse(Console.ReadLine(), out double rectangleHeight);

                            Console.WriteLine($"Create new rectangle whith next parameters: {Environment.NewLine}" +
                                $"Center point: {RectangleCenterPoint} {Environment.NewLine}" +
                                $"Width: {rectangleWidth} {Environment.NewLine}" +
                                $"Height {rectangleHeight} [y/n]");

                            if (Confirm())
                            {
                                listOfShapes.Add(new Rectangle(RectangleCenterPoint, rectangleWidth, rectangleHeight));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New rectangle is successfully created!");
                                Console.ResetColor();
                            }

                            back = true;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();

                            back = true;
                        }

                        break;
                    //Create line
                    case 6:
                        Console.WriteLine("Creating start point");
                        var LineStartPoint = CreatePoint();

                        Console.WriteLine("Creating end point");
                        var LineEndPoint = CreatePoint();

                        try
                        {
                            Console.Write("Enter length: ");
                            double.TryParse(Console.ReadLine(), out double lineLength);

                            Console.WriteLine($"Create new line whith next parameters: {Environment.NewLine}" +
                                $"Start point: {LineStartPoint} {Environment.NewLine}" +
                                $"End point: {LineEndPoint} {Environment.NewLine}" +
                                $"Length {lineLength} [y/n]");

                            if (Confirm())
                            {
                                listOfShapes.Add(new Line(LineStartPoint, LineEndPoint, lineLength));

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("New line is successfully created!");
                                Console.ResetColor();
                            }

                            back = true;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(e.Message);
                            Console.ResetColor();

                            back = true;
                        }

                        break;
                }
            }
        }
        private static Point CreatePoint() 
        {
            bool cycle = false;

            Point point = null;

            while (!cycle)
            {
                Console.Write("X = ");
                int.TryParse(Console.ReadLine(), out int x);
                Console.Write("Y = ");
                int.TryParse(Console.ReadLine(), out int y);

                Console.WriteLine($"Create new point with coords X = {x}, Y = {y}? [y/n]");

                if (Confirm())
                {
                    point = new Point(x, y);
                    break;
                }
                    
            }
            return point;
        }
        private static bool Confirm() => Console.ReadLine().ToLower() == "y" ? true : false;
    }
}
