namespace DesignPatternsInCsharp.SOLIDPrinciples.LiskovSubstitution
{
    //Breaks the liskov principle
    class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle()
        {
        }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    //Problem solve
    class RectangleTwo
    {
        public virtual int Width { get; set; } //Just making the properties virtual
        public virtual int Height { get; set; }

        public RectangleTwo()
        {
        }

        public RectangleTwo(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }
}
