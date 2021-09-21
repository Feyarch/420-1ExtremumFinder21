using System;

namespace GoldenRatio
{
    abstract class FunctionX
    {
        public virtual float GetY(float x)
        {
            return 0;
        }
    }
    abstract class ExtremumFinder
    {
        protected FunctionX function;
        public ExtremumFinder()
        {

        }
        public ExtremumFinder(FunctionX function) 
        {
            this.function = function;
        }
        public virtual float Solver(float a, float b, float c)
        {
            return function.GetY(a * b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new GoldenFinder(new MyRandomFucntion()).Solver(-1f, 10f, 0.00001f));
        }
    }
    
    class MyRandomFucntion : FunctionX
    {
        public override float GetY(float x)
        {
            return MathF.Pow(x, 3) - 2 * x + MathF.Abs(x / 2);
        }
    }
    class GoldenFinder : ExtremumFinder
    {
        private const float fi = 1.618f;

        public GoldenFinder(FunctionX function)
        {
            this.function = function;
        }
        public override float Solver(float a, float b, float eps)
        {
            while (MathF.Abs(b - a) > eps)
            {
                float x1 = b - ((b - a) / fi);
                float x2 = a + ((b - a) / fi);
                if(function.GetY(x1) > function.GetY(x2)) 
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }
            }
            return (a + b) / 2;
        }
    }
}
