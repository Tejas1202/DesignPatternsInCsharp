namespace DesignPatternsInCsharp.SOLIDPrinciples.LiskovSubstitution
{
    class Square : Rectangle
    {
        public new int Width
        {
            set { base.Width = base.Height = value; }
        }

        public new int Height
        {
            set { base.Width = base.Height = value; }
        }
    }


    //Here we override instead of hide
    class SquareTwo : RectangleTwo
    {
        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }
    }
}
