using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>() {
            new Square("Red", 10),
            new Rectangle("Blue", 10, 5),
            new Circle("Green", 30)
        };

        foreach (Shape s in shapes)
        {
            Type shapeType = s.GetType();
            Console.WriteLine($"The color of the {shapeType} is {s.GetColor()}, and the area is {s.GetArea()}");
        }
    }
}