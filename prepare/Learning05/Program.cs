using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("Red", 30));
        shapes.Add(new Rectangle("Green", 40, 30));

        foreach (Shape item in shapes)
        {
            double pay = item.GetArea();
            string color = item.GetColor();
            Console.WriteLine("Area: "+pay);
            Console.WriteLine("Color: " + color);
            Console.WriteLine();
        }
    }
}