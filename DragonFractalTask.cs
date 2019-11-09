using System.Drawing;
using  System;
namespace Fractals
{
	internal static class DragonFractalTask
	{
		public static void DrawDragonFractal(Pixels pixels, int iterationsCount, int seed)
		{
            var x = 1.0;
            var y = 0.0;
            var newX = x;
            var newY = y;
            var pi = System.Math.PI;
            var random = new Random(seed);
            for (var i = 0; i < iterationsCount ; i++)
            {
                var nextNumber = random.Next(10);
                if (nextNumber == 0)
                {
                    newX = (x * System.Math.Cos(pi / 4) - y * System.Math.Sin(pi / 4)) / System.Math.Sqrt(2);
                    newY = (x * System.Math.Sin(pi / 4) + y * System.Math.Cos(pi / 4)) / System.Math.Sqrt(2);
                }
                if (nextNumber > 0 )
                {
                    newX = (x * System.Math.Cos(5*pi/4) - y * System.Math.Sin(5*pi/4)) / System.Math.Sqrt(2) + 1;
                    newY = (x * System.Math.Sin(5*pi/4) + y * System.Math.Cos(5*pi/4)) / System.Math.Sqrt(2);
                }
                x = newX;
                y = newY;
				pixels.SetPixel(newX, newY);
			}
		}
	}
}
