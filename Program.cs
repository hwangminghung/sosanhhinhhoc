using System;
using System.Collections;

// Interface IComparable
public interface IComparable
{
    int CompareTo(object obj);
}

// Lớp hình học
public abstract class Shape : IComparable
{
    public abstract double Area();

    // Triển khai phương thức CompareTo() từ interface IComparable
    public int CompareTo(object obj)
    {
        if (obj == null) return 1;

        Shape otherShape = obj as Shape;
        if (otherShape != null)
        {
            if (this.Area() < otherShape.Area())
                return -1;
            else if (this.Area() > otherShape.Area())
                return 1;
            else
                return 0;
        }
        else
        {
            throw new ArgumentException("Object is not a Shape");
        }
    }
}

// Lớp hình chữ nhật kế thừa từ lớp Shape
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double Area()
    {
        return Width * Height;
    }
}

// Lớp hình vuông kế thừa từ lớp Rectangle
public class Square : Rectangle
{
    public Square(double side) : base(side, side)
    {

    }
}

class Program
{
    static void Main(string[] args)
    {
        Shape[] shapes = new Shape[4];
        shapes[0] = new Rectangle(3, 4);
        shapes[1] = new Square(5);
        shapes[2] = new Rectangle(2, 6);
        shapes[3] = new Square(4);

        Console.WriteLine("Before sorting:");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }

        Array.Sort(shapes);

        Console.WriteLine("After sorting:");
        foreach (var shape in shapes)
        {
            Console.WriteLine(shape.Area());
        }
    }
}