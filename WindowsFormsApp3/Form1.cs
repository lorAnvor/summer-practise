using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        Chart _chart;

        public Form1()
        {
            InitializeComponent();
        }

        private double? CheckTextBox(TextBox textBox)
        {
            try
            {
                double value = double.Parse(textBox.Text.Replace(".", ","));
                return value;
            }
            catch(ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

        private void btn_Build_Click(object sender, EventArgs e)
        {
            if (!CheckOnNullUserParams())
            {            
                         
                _chart?.Dispose();
                _chart = null;
                BesselFunction besselFunction;
                try
                {
                    besselFunction = InitialFunction();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Series graph = new Series();              
                GenerateGraphics(graph, besselFunction);
                MakeChart(graph);
                DoButtonVisible();
                _chart.MouseWheel += new MouseEventHandler(chartData_MouseWheel);
                this.Controls.Add(_chart);
            }
        }

        private void btn_addGruphic_Click(object sender, EventArgs e)
        {
            if (!CheckOnNullUserParams())
            {
                BesselFunction besselFunction;
                try
                {
                    besselFunction = InitialFunction();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка ввода!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Series graph = new Series();
                GenerateGraphics(graph, besselFunction);
                MakeChart(graph);
            }
        }

        private BesselFunction InitialFunction()
        {
            var order = InitializationUserParams(out double leftX, out double rightX);
            BesselFunction besselFunction = new BesselFunction(order, new Tuple<double, double>(leftX, rightX));
            return besselFunction;
        }

        private double InitializationUserParams(out double leftX, out double rightX)
        {
            var order = (double)CheckTextBox(tb_order);
            leftX = (double)CheckTextBox(tb_leftX);
            rightX = (double)CheckTextBox(tb_rightX);
            return order;
        }

        private List<TextBox> GetListWithTextBox()
        {
            List<TextBox> list = new List<TextBox>();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i] is TextBox)
                {
                    list.Add((TextBox)this.Controls[i]);
                }
            }
            return list;
        }

        private bool CheckOnNullUserParams()
        {
            var list = GetListWithTextBox();
            return list.All(t => CheckTextBox(t) == null);
        }

        private void chartData_MouseWheel(object sender, MouseEventArgs e)
        {
            
            int del = 2;
            if (e.Delta < 0)
            {
                _chart.ChartAreas[0].AxisX.ScaleView.ZoomReset();
                _chart.ChartAreas[0].AxisY.ScaleView.ZoomReset();
            }
            if (e.Delta > 0)
            {
                double xMin = _chart.ChartAreas[0].AxisX.ScaleView.ViewMinimum;
                double xMax = _chart.ChartAreas[0].AxisX.ScaleView.ViewMaximum;
                double yMin = _chart.ChartAreas[0].AxisY.ScaleView.ViewMinimum;
                double yMax = _chart.ChartAreas[0].AxisY.ScaleView.ViewMaximum;

                double posXStart = _chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) - (xMax - xMin) / del;
                double posXFinish = _chart.ChartAreas[0].AxisX.PixelPositionToValue(e.Location.X) + (xMax - xMin) / del;
                double posYStart = _chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) - (yMax - yMin) / del;
                double posYFinish = _chart.ChartAreas[0].AxisY.PixelPositionToValue(e.Location.Y) + (yMax - yMin) / del;

                _chart.ChartAreas[0].AxisX.ScaleView.Zoom(posXStart, posXFinish);
                _chart.ChartAreas[0].AxisY.ScaleView.Zoom(posYStart, posYFinish);
            }
        }

        private void MakeChart(params Series[] graphs)
        {
            if (_chart == null)
            {
                _chart = new Chart();
                _chart.ChartAreas.Add(new ChartArea());
                _chart.Legends.Add(new Legend());
                byte hollow = 8;
                _chart.Size = new Size(tb_order.Location.X - hollow, 0);
                _chart.PaletteCustomColors = GetColorArray();
                SetGraphs();               
            }
            else
            {
                SetGraphs();
            }

            void SetGraphs()
            {
                if (graphs.Length <= 0) return;
                foreach (var t in graphs)
                {
                    _chart.Series.Add(t);                    
                    try
                    {
                        _chart.Series[_chart.Series.Count - 1].Name = t.ToolTip;
                    }
                    catch (ArgumentException)
                    {
                        _chart.Series.Remove(_chart.Series.FindByName(t.ToolTip));
                        _chart.Series[t.Name].Name = t.ToolTip;
                    }
                    t.ChartType = SeriesChartType.Spline;
                    _chart.Dock = DockStyle.Left;
                }
            }
        }  

        private void GenerateGraphics(Series series, IFunction value)
        {
            //на будущее
            if (value is BesselFunction graphicOfBessel)
            {
                for (int i = 0; i < graphicOfBessel.Sample.Length; i++)
                {
                    series.Points.Add(new DataPoint(graphicOfBessel.SampleX[i], graphicOfBessel.Sample[i]));
                }
                series.ToolTip = $"J({graphicOfBessel.Order})(x)";
            }
        }

        private static Color[] GetColorArray()
        {
            return new Color[]{
                Color.Red,
                Color.Blue,
                Color.Green,
                Color.Violet,
                Color.Chocolate,
                Color.HotPink,
                Color.Brown,
                Color.DarkRed,
                Color.Black,
                Color.DarkOrange,
                Color.DarkGoldenrod,
                Color.DarkGreen,
                Color.Magenta,
                Color.Peru,
                Color.Cyan,
                Color.Tomato
            };
        }

        private void tb_order_MouseClick(object sender, MouseEventArgs e)
        {
            tb_order.Clear();
        }      

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (_chart != null && this.WindowState != System.Windows.Forms.FormWindowState.Minimized)
            {
                byte hollow = 8;
                _chart.Size = new Size(tb_order.Location.X - hollow, 0);
            }
        }

        private void DoButtonVisible()
        {
            btn_addGruphic.Visible = true;
            btn_saveChart.Visible = true;
        }
        
        private void btn_saveChart_Click(object sender, EventArgs e)
        {
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter = "Image(*.jpg;*.jpeg)|*.jpg;*.jpeg";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _chart.SaveImage(savedialog.FileName, ChartImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void tb_leftX_MouseClick(object sender, MouseEventArgs e)
        {
            tb_leftX.Clear();
        }

        private void tb_rightX_MouseClick(object sender, MouseEventArgs e)
        {
            tb_rightX.Clear();
        }

    }
}
