using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ПРОГРАММА \"Движение объекта по маршруту\"");
            Console.WriteLine();

            int speed = 0;
            int time = 0;
            Console.Write("Введите скорость движения м/с (целое число): ");
            string inputSpeed = Console.ReadLine();

            Console.Write("Введите время в секундах с момента начала движения объекта (целое число): ");
            string inputTime = Console.ReadLine();

            try
            {
                speed = Convert.ToInt32(inputSpeed);
                time = Convert.ToInt32(inputTime);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Ввод не корректный данных.");
                Console.WriteLine("Завершение работы программы.");
                Console.ReadKey();
                Environment.Exit(0);
            }
                           
            int[][] V = new int[5][];
            V[0] = new int[] { 1, 1 };
            V[1] = new int[] { 6, 2 };
            V[2] = new int[] { 3, 3 };
            V[3] = new int[] { 4, 4 };
            V[4] = new int[] { 5, 5 };

            double lengthRoute = speed * time;
            Console.WriteLine();
            Console.WriteLine("Длина всего маршрута {0:0.##} ", lengthRoute);
            Console.WriteLine();

            //int l1 = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));

            // массив для хранения длин отрезков
            double[] lineSegment = new double[V.Length - 1];
            // общая длина отрезков
            double totalLength = 0;
            // номер отрезка, где находится объект
            int numberLineSegment = -1;
            // длина перемещения объекта на конкретном отрезке
            double length__numberLineSegment = -1;
            // координата х искомой точки
            double x = 0;
            // координата y искомой точки
            double y = 0;

            for (int i = 0; i < V.Length - 1; i++)
            {
                //Console.WriteLine("V{0}[x={1},y={2}]", i, V[i][0], V[i][1]);

                lineSegment[i] = Math.Sqrt(Math.Pow((V[i + 1][0] - V[i][0]), 2) + Math.Pow((V[i + 1][1] - V[i][1]), 2));
                Console.WriteLine("Длина отрезка: {0} равна {1:0.##}", i, lineSegment[i]);

                totalLength += lineSegment[i];
            }

            if (lengthRoute > totalLength)
            {
                Console.WriteLine("Длина маршрута больше общей длины всех отрезков");
                Console.WriteLine("Завершение работы программы.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                for (int i = 0; i < V.Length - 1; i++)
                {
                    if (lengthRoute < lineSegment[i])
                    {
                        numberLineSegment = i;
                        length__numberLineSegment = lengthRoute;
                        x = V[0][0] + (V[1][0] - V[0][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        y = V[0][1] + (V[1][1] - V[0][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        break;
                    }
                    else if(lengthRoute < (lineSegment[i] + lineSegment[i + 1]))
                    {
                        numberLineSegment = i + 1;
                        length__numberLineSegment = lengthRoute - lineSegment[i];
                        x = V[1][0] + (V[2][0] - V[1][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        y = V[1][1] + (V[2][1] - V[1][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        break;
                    }
                    else if (lengthRoute < (lineSegment[i] + lineSegment[i + 1]) + lineSegment[i + 2])
                    {
                        numberLineSegment = i + 2;
                        length__numberLineSegment = lengthRoute - (lineSegment[i] + lineSegment[i + 1]);
                        x = V[2][0] + (V[3][0] - V[2][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        y = V[2][1] + (V[3][1] - V[2][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        break;
                    }
                    else
                    {
                        //length__numberLineSegment = lengthRoute - (lineSegment[i] + lineSegment[i + 1]) + lineSegment[i + 2];
                        length__numberLineSegment = totalLength - lengthRoute;
                        numberLineSegment = i + 3;
                        x = V[3][0] + (V[4][0] - V[3][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        y = V[3][1] + (V[4][1] - V[3][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                        break;
                    }
                }
            }



            Console.WriteLine();
            Console.WriteLine("Cкорость движения: {0} м/с", speed);
            Console.WriteLine("Время с момента начала движения объекта: {0} с", time);
            Console.WriteLine("Общая длина отрезков: {0:0.##} м", totalLength);
            Console.WriteLine("Номер отрезка, где находится объект: {0}", numberLineSegment);
            Console.WriteLine("Длина перемещения объекта на конкретном отрезке: {0:0.##}", length__numberLineSegment);


            //int x = Math.Round();

            Console.WriteLine();
            Console.WriteLine("Координаты искомой точки равны x = {0:0.##}, y = {1:0.##}", x, y);






                



            Console.ReadKey();

        }
    }
}
