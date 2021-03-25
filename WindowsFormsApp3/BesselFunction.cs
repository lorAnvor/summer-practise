using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    public class BesselFunction : IFunction
    {
       
        public readonly int _factorialIterations = 85;

        public double Order { get; set; }

        public Tuple<double, double> IntervalX { get; set; }

        public Tuple<double, double> IntervalY {
            get
            {
                if (Sample?.Length != 0)
                {
                    return new Tuple<double, double>(Sample[0], Sample[Sample.Length - 1]);
                }
                else
                    throw new Exception();
            }
        }

        /// <summary>
        /// массив значений функции
        /// </summary>
        public double[] Sample { get; set; }

        /// <summary>
        /// количество точек функции
        /// </summary>
        public int CountPoints { get;  set; }

        /// <summary>
        /// массив значений по оси абсцисс
        /// </summary>
        public double[] SampleX { get; set; }

        public BesselFunction() { }

        public BesselFunction(double order, Tuple<double, double> intervalX, 
            int countPoints = 25)
        {
            if(countPoints <= 0)
                throw new ArgumentException("Количество точек должно быть положительным.");        

            if (intervalX.Item1 >= intervalX.Item2 && intervalX.Item2 > 0 && intervalX.Item1 >= 0)
                throw new ArgumentException("Введите корректное значение отрезка");

            Order = order;
            CountPoints = countPoints;
            IntervalX = intervalX;
            SetArrayOfX();
            SetSample();           
        }

        /// <summary>
        /// Заполнение массива значений функции Sample
        /// </summary>
        public void SetSample()
        {
            var chart = new Chart();
            Sample = new double[CountPoints];
            if (!DoubleIsInteger(Order) && Order < 0)
            {
                RealNegativeSample(chart);
            }
            else
            {
                UsualSample(chart);
            }
        }

        /// <summary>
        /// Заполняет SampleX значениями оси абсцисс
        /// </summary>
        public void SetArrayOfX()
        {
            SampleX = new double[CountPoints];
            for (int i = 0; i < CountPoints; i++)
            {
                SampleX[i] = IntervalX.Item1 + i * (IntervalX.Item2 - IntervalX.Item1) / CountPoints;
            }
        }

        /// <summary>
        /// Заполняет массив Sapmle, используя вещественные значения аргумента функции
        /// </summary>
        /// <param name="chart">для обращения к гамма-функции</param>
        private void RealNegativeSample(Chart chart)
        {
            double tempDegree = Math.Abs(Order);
            double[] arr1 = new double[CountPoints];
            double[] arr2 = new double[CountPoints];
            for (int i = 0; i < SampleX.Length; i++)
            {
                for (int k = 0; k <= tempDegree / 2; k++)
                {
                    arr1[i] += (Math.Pow(-1, k) * chart.DataManipulator.Statistics.GammaFunction(tempDegree + 2 * k + 1)) /
                        (chart.DataManipulator.Statistics.GammaFunction(2 * k + 1)
                        * chart.DataManipulator.Statistics.GammaFunction(1 + tempDegree - 2 * k)
                        * Math.Pow(2.0 * SampleX[i], 2.0 * k));
                }
                for (int k = 0; k <= (tempDegree - 1) / 2; k++)
                {
                    arr2[i] += (Math.Pow(-1, k) * chart.DataManipulator.Statistics.GammaFunction(tempDegree + 2 * k + 2)) /
                         (chart.DataManipulator.Statistics.GammaFunction(2 * k + 2)
                         * chart.DataManipulator.Statistics.GammaFunction(tempDegree - 2 * k) 
                         * Math.Pow(2.0 * SampleX[i], 2.0 * k + 1));
                }
                Sample[i] = Math.Sqrt(2 / (Math.PI * SampleX[i])) * (Math.Sin(SampleX[i] + ((2 * tempDegree + 2) * Math.PI) / 4) * arr1[i]
                                        + Math.Cos(SampleX[i] + ((2 * tempDegree + 2) * Math.PI) / 4) * arr2[i]);
            }
            //тут играться для вида
             //мб, придётся ставить FastLine в чарте
             if (double.IsNegativeInfinity(Sample[0]))
                 Sample[0] = Sample[1] + Math.Abs(Sample[2]) < -100 ? Sample[1] + Math.Abs(Sample[2]) : -100;
             else if (double.IsPositiveInfinity(Sample[0]))
                 Sample[0] = Sample[1] + Math.Abs(Sample[2]) < 100 ?  100 : Sample[1] + Math.Abs(Sample[2]);
             else
                 Sample[0] = Sample[1] + Sample[2];
        }

        /// <summary>
        /// Заполняет массив Sapmle, используя целочисленные значения аргумента функции
        /// </summary>
        /// <param name="chart">для обращения к гамма-функции</param>
        private void UsualSample(Chart chart)
        {
            bool flag = Order >= 0 ? false : true;
            double tempDegree = Math.Abs(Order);
            for (int i = 0; i < SampleX.Length; i++)
            {
                for (int k = 0; k <= _factorialIterations; k++)
                {
                    Sample[i] += (Math.Pow(-1, k) / (chart.DataManipulator.Statistics.GammaFunction(k + 1) *
                        chart.DataManipulator.Statistics.GammaFunction(k + tempDegree + 1))) *
                        Math.Pow((1.0 * SampleX[i]) / 2, 2 * k + tempDegree);
                }
                if (flag)
                {
                    Sample[i] = Sample[i] * Math.Pow(-1, tempDegree);
                }
            }
        }

        /// <summary>
        /// Определяет, можно ли параметр привести к целочисленному значению без потери информации
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private bool DoubleIsInteger(double n)
        {
            return (n == ((double)((int)n)));             
        }
    }
}

