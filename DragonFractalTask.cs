using System.Drawing;
using  System;
namespace Fractals
{
	internal static class DragonFractalTask
	{
		/*
			Начните с точки (1, 0)
			Создайте генератор рандомных чисел с сидом seed
			
			На каждой итерации:

			1. Выберите случайно одно из следующих преобразований и примените его к текущей точке:

				Преобразование 1. (поворот на 45° и сжатие в sqrt(2) раз):
				x' = (x · cos(45°) - y · sin(45°)) / sqrt(2)
				y' = (x · sin(45°) + y · cos(45°)) / sqrt(2)

				Преобразование 2. (поворот на 135°, сжатие в sqrt(2) раз, сдвиг по X на единицу):
				x' = (x · cos(135°) - y · sin(135°)) / sqrt(2) + 1
				y' = (x · sin(135°) + y · cos(135°)) / sqrt(2)
		
			2. Нарисуйте текущую точку методом pixels.SetPixel(x, y)

			*/
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
