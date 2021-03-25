using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApp3;
using OfficeOpenXml;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class ErrorTest
    {

        [TestMethod]
        public void CommonTest()
        {
            var order = 0;
            int countOfTest = 7;
            for(int i = 0; i < countOfTest; i++)
            {
                double[] sampleExpected = Excel.GetArray(order);
                BesselFunction functionActual = new BesselFunction(order, new Tuple<double, double>(0, 25));
                for (int j = 0; j < functionActual.Sample.Length; j++)
                {
                    Assert.AreEqual(sampleExpected[j], functionActual.Sample[j], 1e-5);
                }
                order++;
            }
        }
    }

    internal static class Excel
    {
        /// <summary>
        /// Получить выборку из экселя. 
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static double[] GetArray(int order)
        {
            //Порядок функции + 1 = столбец соответсвующих значений
            return TwoDimensionToOne(ReadExcel(++order));
        }

        private static double[,] ReadExcel(int order)
        {
            double[,] arr;
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            //корневая папка будет UnitTestProject1
            using (ExcelPackage excelFile = new ExcelPackage(new FileInfo("test.xlsx")))
            {
                ExcelWorksheet worksheet = excelFile.Workbook.Worksheets[0];
                int totalRows = worksheet.Dimension.End.Row;
                int totalColumns = 1;
                arr = new double[totalRows, totalColumns];
                for (int rowIndex = 1; rowIndex <= totalRows; rowIndex++)
                {
                    IEnumerable<string> row =
                        worksheet.Cells[rowIndex, order, rowIndex, order].Select(c => c.Value == null ? string.Empty : c.Value.ToString());
                    List<string> list = row.ToList<string>();
                    for (int i = 0; i < list.Count; i++)
                    {
                        arr[rowIndex - 1, i] = Convert.ToDouble(list[i].Replace('.', ','));
                    }
                }
                return arr;
            }
        }

        private static T[] TwoDimensionToOne<T>(T[,] arr)
        {
            T[] resArr = new T[arr.GetLength(0) * arr.GetLength(1)];
            int k = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    resArr[k] = arr[i, j];
                    k++;
                }
            }
            return resArr;
        }
    }
}
