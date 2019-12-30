using DesignPatternsInCsharp.SOLIDPrinciples.OpenClose;
using DesignPatternsInCsharp.SOLIDPrinciples.SingleResponsibility;
using DesignPatternsInCsharp.SOLIDPrinciples.LiskovSubstitution;
using DesignPatternsInCsharp.SOLIDPrinciples.InterfaceSegregation;
using System;
using System.Diagnostics;
using DesignPatternsInCsharp.SOLIDPrinciples.DependencyInversion;

namespace DesignPatternsInCsharp.SOLIDPrinciples
{
    class Caller
    {
        public void SolidPrinciplesCall()
        {  
            SingleResposibility();

            OpenClosed();

            LiskovSubstitution();

            InterfaceSegregation();

            DependencyInversion();
        }

        private void SingleResposibility()
        {
            var journal = new Journal();
            journal.AddEntry("I cried today");
            journal.AddEntry("I ate a bug");

            //Default implementations of the Object.ToString method return the fully qualified name of the object's type. Hence we overrided it
            Console.WriteLine(journal);

            var p = new Persistance();
            var filename = @"E:\Computer Science\C#\TempFilesUsedForExercises\journal.txt";
            p.SaveToFile(journal, filename, true);
            Process.Start(filename);
        }

        private void OpenClosed()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);

            Product[] products = { apple, tree, house };

            var productFilter = new ProductFilter();
            Console.WriteLine("Green products (old):");
            foreach(var item in productFilter.FilterByColor(products, Color.Green))
            {
                Console.WriteLine($"{item.Name} is green");
            }

            var betterFilter = new BetterFilter();
            Console.WriteLine("Green products (new):");
            foreach (var item in betterFilter.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($"{item.Name} is green");
            }

            Console.WriteLine("Large blue items");
            foreach (var item in betterFilter.Filter(
                products,
                new AndSpecification<Product>(
                    new ColorSpecification(Color.Blue),
                    new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($"{item.Name} is large and blue");
            }
        }

        static private int Area(Rectangle rectangle) => rectangle.Width * rectangle.Height;
        static private int Area(RectangleTwo rectangleTwo) => rectangleTwo.Width * rectangleTwo.Height;

        private void LiskovSubstitution()
        {
            Rectangle rectangle = new Rectangle(4,5);
            Console.WriteLine($"{rectangle} has area {Area(rectangle)}");

            Square square = new Square { Width = 4 };
            Console.WriteLine($"{square} has area {Area(square)}");

            Rectangle rc = new Square();
            rc.Width = 4;//Now here, when we're setting the Width, we're not setting the height unlike above
            /*Hence we get the wrong output, which violates the Liskov principle(means it should've still behaved as a Square 
            even if we upcasted it to Rectangle)*/
            Console.WriteLine($"{rc} has area {Area(rc)}");

            //Now here what happens is, eventhough we're holding a rectange reference to a square, when you go and access the width
            //what really happens is it walks over the Rectangle class and looks at Width and looks at the setter. But as the setter is virtual
            //it goes to the Square class and then finds the appropriate setter as we've overrided it
            RectangleTwo rcTwo = new SquareTwo();
            rcTwo.Width = 4;
            Console.WriteLine($"{rcTwo} has area {Area(rcTwo)}");
        }

        private void InterfaceSegregation()
        {
            var multiFunctionMachine = new MultiFunctionMachine(new PhotoCopier(), new PhotoCopier());
            multiFunctionMachine.Print(new Document());
            multiFunctionMachine.Scan(new Document());
        }

        private void DependencyInversion()
        {
            //we're just doing kind of setup by adding relationships, but after that we want to perform the research
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Chris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships(); //so we want to take this low level module and we want to access it in a high level module(i.e. Research)
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);

            new Research(browser: relationships);
        }
    }
}
