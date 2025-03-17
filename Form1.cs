/* Задание №4 Интерполирование функций Часть 1. Алексеенко Юрий. Вариант №1  st054497@student.spbu.ru
InterpolationApp Приложение для нахождения полиномов Лагранжа и Ньютона, нахождения максимального отклонения и построения графиков
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Legends;
using OxyPlot.Series;
using OxyPlot.WindowsForms;

namespace InterpolationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnCalculate.Click += new EventHandler(btnCalculate_Click);
            FillDataGrid();
            UpdatePlots();
        }
        // количество узлов
        private int[] nValues = { 3, 10, 25, 50 };

        // Функция Вариант 1 х-sin(x)-0,25
        private static double Func(double x) => x - Math.Sin(x) - 0.25;
        // Строим полином Лагранжа 
        private static Func<double, double> LagrangePolynomial(List<double> xValues, List<double> yValues)
        {
            return x =>
            {
                double result = 0;
                int n = xValues.Count;
                for (int i = 0; i < n; i++)
                {
                    double term = yValues[i];
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            term *= (x - xValues[j]) / (xValues[i] - xValues[j]);
                        }
                    }
                    result += term;
                }
                return result;
            };
        }

        //Кнопка для обновления графиков 
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            FillDataGrid();
            UpdatePlots();
        }
        // Строим полином Ньютона
        private static Func<double, double> NewtonPolynomial(List<double> xValues, List<double> yValues)
        {
            int n = xValues.Count;
            double[] divDiff = new double[n];
            yValues.CopyTo(divDiff);

            for (int i = 1; i < n; i++)
            {
                for (int j = n - 1; j >= i; j--)
                {
                    divDiff[j] = (divDiff[j] - divDiff[j - 1]) / (xValues[j] - xValues[j - i]);
                }
            }

            return x =>
            {
                double result = divDiff[n - 1];
                for (int i = n - 2; i >= 0; i--)
                {
                    result = result * (x - xValues[i]) + divDiff[i];
                }
                return result;
            };
        }

        // Строим таблицу с необходимыми данными и вносим их 
        private void FillDataGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("n", "Количество узлов (n)");
            dataGridView1.Columns.Add("m", "Количество проверочных точек (m)");
            dataGridView1.Columns.Add("lagrangeEq", "Макс. отклонение Лагранжа (равноотстоящие)");
            dataGridView1.Columns.Add("lagrangeCh", "Макс. отклонение Лагранжа (Чебышев)");
            dataGridView1.Columns.Add("newtonEq", "Макс. отклонение Ньютона (равноотстоящие)");
            dataGridView1.Columns.Add("newtonCh", "Макс. отклонение Ньютона (Чебышев)");

            double a = 0, b = 2 * Math.PI;
            int m = 1000;

            foreach (var n in nValues)
            {   // Разбиения
                var eqNodes = GenerateEquidistantNodes(n, a, b);
                var chNodes = GenerateChebyshevNodes(n, a, b);

                var eqValues = eqNodes.Select(Func).ToList();
                var chValues = chNodes.Select(Func).ToList();
                // Полиномы
                var lagrangeEq = LagrangePolynomial(eqNodes, eqValues);
                var lagrangeCh = LagrangePolynomial(chNodes, chValues);
                var newtonEq = NewtonPolynomial(eqNodes, eqValues);
                var newtonCh = NewtonPolynomial(chNodes, chValues);
                // Нахождение отклонения
                double maxDevLagrangeEq = MaxDeviation(lagrangeEq, a, b, m);
                double maxDevLagrangeCh = MaxDeviation(lagrangeCh, a, b, m);
                double maxDevNewtonEq = MaxDeviation(newtonEq, a, b, m);
                double maxDevNewtonCh = MaxDeviation(newtonCh, a, b, m);

                dataGridView1.Rows.Add(n, m, maxDevLagrangeEq, maxDevLagrangeCh, maxDevNewtonEq, maxDevNewtonCh);
            }
        }

        // Построение графиков через OxyPlot
        private void UpdatePlots()
        {
            double a = 0, b = 2 * Math.PI;
            int points = 500;

            // График 1: Лагранж равноотстоящие узлы
            var modelLagrangeEq = new PlotModel { Title = "Интерполяция Лагранжа равноотстоящие узлы" };
            var functionSeriesEq = new LineSeries { Title = "f(x)", Color = OxyColors.Black };

            for (int i = 0; i < points; i++)
            {
                double x = a + i * (b - a) / (points - 1);
                functionSeriesEq.Points.Add(new DataPoint(x, Func(x)));
            }
            modelLagrangeEq.Series.Add(functionSeriesEq);
            // График 2: Лагранжа узлы Чебышева
            var modelLagrangeCh = new PlotModel { Title = "Интерполяция Лагранжа узлы Чебышева" };
            var functionSeriesCh = new LineSeries { Title = "f(x)", Color = OxyColors.Black };

            for (int i = 0; i < points; i++)
            {
                double x = a + i * (b - a) / (points - 1);
                functionSeriesCh.Points.Add(new DataPoint(x, Func(x)));
            }
            modelLagrangeCh.Series.Add(functionSeriesCh);

            // График 3: Ньютон равноотстоящие узлы
            var modelNewtonEq = new PlotModel { Title = "Интерполяция Ньютона равноотстоящие узлы" };
            var functionSeriesNewtonEq = new LineSeries { Title = "f(x)", Color = OxyColors.Black };

            for (int i = 0; i < points; i++)
            {
                double x = a + i * (b - a) / (points - 1);
                functionSeriesNewtonEq.Points.Add(new DataPoint(x, Func(x)));
            }
            modelNewtonEq.Series.Add(functionSeriesNewtonEq);

            // График 4: Ньютон узлы Чебышева
            var modelNewtonCh = new PlotModel { Title = "Интерполяция Ньютона узлы Чебышева" };
            var functionSeriesNewtonCh = new LineSeries { Title = "f(x)", Color = OxyColors.Black };

            for (int i = 0; i < points; i++)
            {
                double x = a + i * (b - a) / (points - 1);
                functionSeriesNewtonCh.Points.Add(new DataPoint(x, Func(x)));
            }
            modelNewtonCh.Series.Add(functionSeriesNewtonCh);
            //Массив цветов для различия графиков (не помогает)
            OxyColor[] colors = { OxyColors.Blue, OxyColors.Red, OxyColors.Green, OxyColors.Orange }; 
            //Массив стилей линий, для визуализации график (тоже не помогает)
            LineStyle[] lineStyles = { LineStyle.Solid, LineStyle.Dash, LineStyle.Dot, LineStyle.DashDot };
            int colorIndex = 0;
            int lineStylesIndex = 0;
            

            foreach (var n in nValues)
            {
                // Разбиения
                var eqNodes = GenerateEquidistantNodes(n, a, b);
                var chNodes = GenerateChebyshevNodes(n, a, b);
                var eqValues = eqNodes.Select(Func).ToList();
                var chValues = chNodes.Select(Func).ToList();
                // Полиномы
                var lagrangeEq = LagrangePolynomial(eqNodes, eqValues);
                var newtonEq = NewtonPolynomial(eqNodes, eqValues);
                var lagrangeCh = LagrangePolynomial(chNodes, chValues);
                var newtonCh = NewtonPolynomial(chNodes, chValues);

                //Выбираем цвет и линию
                var seriesLagrangeEq = new LineSeries { Title = $"L{n}(x)", Color = colors[colorIndex], LineStyle = lineStyles[lineStylesIndex] };
                var seriesNewtonEq = new LineSeries { Title = $"N{n}(x)", Color = colors[colorIndex], LineStyle = lineStyles[lineStylesIndex] };
                var seriesLagrangeCh = new LineSeries { Title = $"Lop{n}(x)", Color = colors[colorIndex], LineStyle = lineStyles[lineStylesIndex] };
                var seriesNewtonCh = new LineSeries { Title = $"Nop{n}(x)", Color = colors[colorIndex], LineStyle = lineStyles[lineStylesIndex] };

                //Добавляем точки
                for (int i = 0; i < points; i++)
                {
                    double x = a + i * (b - a) / (points - 1);
                    seriesLagrangeEq.Points.Add(new DataPoint(x, lagrangeEq(x)));
                    seriesLagrangeCh.Points.Add(new DataPoint(x, lagrangeCh(x)));
                    seriesNewtonEq.Points.Add(new DataPoint(x, newtonEq(x)));
                    seriesNewtonCh.Points.Add(new DataPoint(x, newtonCh(x)));
                }
                //Добавляем графики в нужный бокс
                modelLagrangeEq.Series.Add(seriesLagrangeEq);
                modelLagrangeCh.Series.Add(seriesLagrangeCh);
                modelNewtonEq.Series.Add(seriesNewtonEq);
                modelNewtonCh.Series.Add(seriesNewtonCh);
                //Переходим к следующему индексу
                colorIndex = (colorIndex + 1) % colors.Length;
                lineStylesIndex = (lineStylesIndex + 1) % lineStyles.Length;
            }

            // Присваиваем новые графики и строим их
            plotViewLagrange.Model = modelLagrangeEq;
            plotViewNewton.Model = modelNewtonCh;
            plotViewLagrangeCh.Model = modelLagrangeCh;
            plotViewNewtonEq.Model = modelNewtonEq;
            plotViewLagrange.InvalidatePlot(true);
            plotViewLagrangeCh.InvalidatePlot(true);
            plotViewNewton.InvalidatePlot(true);
            plotViewNewtonEq.InvalidatePlot(true);
            //Задаем легенды
            plotViewLagrange.Model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendTitle = "Функции",
                LegendPosition = OxyPlot.Legends.LegendPosition.LeftTop,
            });
            plotViewLagrangeCh.Model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendTitle = "Функции",
                LegendPosition = OxyPlot.Legends.LegendPosition.LeftTop,
            });
            plotViewNewtonEq.Model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendTitle = "Функции",
                LegendPosition = OxyPlot.Legends.LegendPosition.LeftTop,
            });
            plotViewNewton.Model.Legends.Add(new OxyPlot.Legends.Legend()
            {
                LegendTitle = "Функции",
                LegendPosition = OxyPlot.Legends.LegendPosition.LeftTop,
            });
        }

        // Генерация точек равноудаленных
        private static List<double> GenerateEquidistantNodes(int n, double a, double b)
        {
            return Enumerable.Range(0, n).Select(i => a + i * (b - a) / (n - 1)).ToList();
        }
        // Генерация точек "оптимальных" (Чебышева)
        private static List<double> GenerateChebyshevNodes(int n, double a, double b)
        {
            return Enumerable.Range(0, n).Select(i => 0.5 * ((b - a) * Math.Cos((2 * i + 1) * Math.PI / (2 * n)) + (b + a))).ToList();
        }
        // Вычисление максимального отклонения заданного полинома
        private static double MaxDeviation(Func<double, double> polynomial, double a, double b, int m)
        {
            return Enumerable.Range(0, m).Select(i => a + i * (b - a) / (m - 1)).Max(x => Math.Abs(Func(x) - polynomial(x)));
        }
    }
}
