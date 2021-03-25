using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    interface IFunction
    {

        //интервал по оси Оу
        Tuple<double, double> IntervalY { get;}

        //интервал по оси Ох
        Tuple<double, double> IntervalX { get; set; }

        //хранятся точки функции
        double[] Sample { get; set; }

        //точки, распределенные по интервалу Х
        double[] SampleX { get; set; }

        int CountPoints { get; set; }

        /// <summary>
        /// Задаёт значения функции
        /// </summary>
        void SetSample();

        /// <summary>
        /// Задает значения аргумента
        /// </summary>
        void SetArrayOfX();
    }
}
