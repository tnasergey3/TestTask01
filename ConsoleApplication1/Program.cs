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
            Console.WriteLine("Нажмите Esc для выхода из программы");
            Console.WriteLine();

            int[][] V = new int[5][];
            V[0] = new int[] { 0, 0, 1 };
            V[1] = new int[] { 0, 1, 2 };
            V[2] = new int[] { 0, 2, 1 };
            V[3] = new int[] { 0, 3, 1 };
            V[4] = new int[] { 0, 4, 1 };

            // массив для хранения времени прохождения каждого отрезка
            double[] arrTime = new double[V.Length - 1];
            // массив для хранения длин отрезков
            double[] lineSegment = new double[V.Length - 1];
            // общая длина отрезков
            double totalLength = 0;
            // общее время прохождение всех отрезков
            double totalTime = 0;
            // Определение временого интервала на текущем отрезке
            double timeCurrentLine = 0;
            // номер отрезка, где находится объект
            int numberLineSegment = -1;
            // длина перемещения объекта на конкретном отрезке
            double length__numberLineSegment = -1;
            // координата х искомой точки
            double x = 0;
            // координата y искомой точки
            double y = 0;

            // Вычисление длины каждого отрезка
            for (int i = 0; i < V.Length - 1; i++)
            {
                //int l1 = Math.Round(Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2)));
                lineSegment[i] = Math.Sqrt(Math.Pow((V[i + 1][0] - V[i][0]), 2) + Math.Pow((V[i + 1][1] - V[i][1]), 2));
                Console.WriteLine("l{0} = {1:0.##}", i, lineSegment[i]);

                // Вычисление времени прохождения каждого отрезка
                arrTime[i] = lineSegment[i] / V[i][2];

                // Вычисление общей длины всех отрезков
                totalLength += lineSegment[i];

                // Вычисление общего времени прохождения всех отрезков
                totalTime += arrTime[i];

                Console.WriteLine("t{0} = {1:0.##}", i, arrTime[i]);
            }
            Console.WriteLine("Общая длина отрезков: {0:0.##} м", totalLength);
            Console.WriteLine("Время прохождения всего маршрута {0:0.##} с", totalTime);

            do
            {
                Console.WriteLine();

                double time = 0;
                Console.Write("Введите время в секундах с момента начала движения объекта: ");
                string inputTime = Console.ReadLine();

                try
                {
                    time = Convert.ToDouble(inputTime);
                }
                catch (Exception e)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ввод не корректный данных.");
                    continue;
                }                        
                
                Console.WriteLine();                

                if (time >= totalTime)
                {
                    Console.WriteLine();
                    Console.WriteLine("Заданое время больше или равно времени прохождения всего маршрута.");
                    Console.WriteLine("Попробуйте еще раз.");
                    continue;
                }
                else
                {
                    ////////////////////////////////////////
                    // Первое решение
                    ////////////////////////////////////////

                    //int i = 0;
                    //if (lengthRoute < lineSegment[i])
                    //{
                    //    numberLineSegment = i;
                    //    length__numberLineSegment = lengthRoute;
                    //    x = V[0][0] + (V[1][0] - V[0][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //    y = V[0][1] + (V[1][1] - V[0][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //}
                    //else if (lengthRoute < (lineSegment[i] + lineSegment[i + 1]))
                    //{
                    //    numberLineSegment = i + 1;
                    //    length__numberLineSegment = lengthRoute - lineSegment[i];
                    //    x = V[1][0] + (V[2][0] - V[1][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //    y = V[1][1] + (V[2][1] - V[1][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //}
                    //else if (lengthRoute < (lineSegment[i] + lineSegment[i + 1] + lineSegment[i + 2]))
                    //{
                    //    numberLineSegment = i + 2;
                    //    length__numberLineSegment = lengthRoute - (lineSegment[i] + lineSegment[i + 1]);
                    //    x = V[2][0] + (V[3][0] - V[2][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //    y = V[2][1] + (V[3][1] - V[2][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //}
                    //else
                    //{
                    //    length__numberLineSegment = lengthRoute - (lineSegment[i] + lineSegment[i + 1] + lineSegment[i + 2]);
                    //    numberLineSegment = i + 3;
                    //    x = V[3][0] + (V[4][0] - V[3][0]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //    y = V[3][1] + (V[4][1] - V[3][1]) * length__numberLineSegment / lineSegment[numberLineSegment];
                    //}
                    ////////////////////////////////////////
                    // Второе решение
                    ////////////////////////////////////////

                    //double sumTemp = 0;
                    //double sumLineSegments = 0;
                    //for (int i = 0; i < V.Length - 1; i++)
                    //{
                    //    sumLineSegments += lineSegment[i];

                    //    if (lengthRoute < sumLineSegments)
                    //    {
                    //        length__numberLineSegment = lengthRoute - sumTemp;

                    //        x = V[i][0] + (V[i + 1][0] - V[i][0]) * length__numberLineSegment / lineSegment[i];
                    //        y = V[i][1] + (V[i + 1][1] - V[i][1]) * length__numberLineSegment / lineSegment[i];
                    //        numberLineSegment = i;
                    //        break;
                    //    }
                    //    sumTemp += lineSegment[i];
                    //}

                    // Сумма временных интервалов прохождения отрезков до текущего отрезка маршрута 
                    //double sumTime = 0;

                    double sumTimeSegments = 0;

                    // Определение на каком отрезке нужно вычислить координаты объекта
                    // в зависимости от введеного времени - time
                    for (int i = 0; i < arrTime.Length - 1; i++)
                    {                         
                        timeCurrentLine = time - sumTimeSegments;

                        if (timeCurrentLine < arrTime[i])
                        {                            
                            // Вычисление пройденого растояния на конкретном отрезке по формуле S = V * t
                            length__numberLineSegment = V[i][2] * arrTime[i];

                            x = V[i][0] + (V[i + 1][0] - V[i][0]) * length__numberLineSegment / lineSegment[i];
                            y = V[i][1] + (V[i + 1][1] - V[i][1]) * length__numberLineSegment / lineSegment[i];
                            numberLineSegment = i;
                            break;                           
                        }
                        sumTimeSegments += arrTime[i];
                    }
                }

                Console.WriteLine();
                //Console.WriteLine("Длина всего маршрута {0:0.##} ", lengthRoute);
                Console.WriteLine("Номер отрезка, где находится объект: {0}", numberLineSegment);
                Console.WriteLine("Длина перемещения объекта на конкретном отрезке: {0:0.##}", length__numberLineSegment);
                Console.WriteLine("Временой интервал перемещения объекта на конкретном отрезке: {0:0.##}", timeCurrentLine);
                Console.WriteLine("Координаты конечной точки маршрута x = {0:0.##}, y = {1:0.##}", x, y);
                Console.WriteLine("-------------------------------------------------------------");
                Console.ReadKey();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
