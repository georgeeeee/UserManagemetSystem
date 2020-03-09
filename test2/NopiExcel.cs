using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2
{
    class NopiExcel
    {
        /// <summary>
        /// Excel导入成DataGrieView
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static void ExcelToTable(string file, DataGridView dgv)
        {
            //获取一个日志记录器
            log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");
            
            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                if (fileExt == ".xlsx")
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (fileExt == ".xls")
                {
                    workbook = new HSSFWorkbook(fs);
                }
                else
                {
                    workbook = null;
                }
                if (workbook == null)
                {
                    MessageBox.Show("没有可用的excel格式");
                    log.Info(new LogContent(FrmLogin.Uid, "导入excel", FrmLogin.UserType, "没有可用的excel格式"));
                    return;
                }
                ISheet sheet = workbook.GetSheetAt(0);
                DataTable dt = new DataTable();

                //表头
                IRow header = sheet.GetRow(sheet.FirstRowNum);
                List<int> columns = new List<int>();
                for(int i = 0; i < header.LastCellNum; i++)
                {
                    object obj = GetValueType(header.GetCell(i));
                    if(obj == null || obj.ToString() == string.Empty)
                    {
                        dt.Columns.Add(new DataColumn(i.ToString()));
                    } 
                    else
                    {
                        dt.Columns.Add(new DataColumn(obj.ToString()));
                    }
                    columns.Add(i);
                }

                //数据
                for(int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                {
                    DataRow dr = dt.NewRow();
                    bool hasValue = false;
                    foreach (int j in columns)
                    {
                        dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                        if (dr[j] != null && dr[j].ToString() != string.Empty)
                        {
                            hasValue = true;
                        }
                    }
                    if (hasValue)
                    {
                        dt.Rows.Add(dr);
                    }
                }

                //将datatable导入datagridview
                using(DataSet ds = new DataSet())
                {
                    ds.Tables.Add(dt);
                    dgv.DataSource = ds.Tables[0];
                }

                log.Info(new LogContent(FrmLogin.Uid, "导入excel", FrmLogin.UserType, "导入成功"));
            }
        }

        /// <summary>
        /// 将datagridview数据导出到指定excel文件
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="file"></param>
        public static void TableToExcel(DataGridView dgv, string file)
        {
            //获取一个日志记录器
            log4net.ILog log = log4net.LogManager.GetLogger("testApp.Logging");

            IWorkbook workbook;
            string fileExt = Path.GetExtension(file).ToLower();
            if (fileExt == ".xlsx")
            {
                workbook = new XSSFWorkbook();
            }
            else if (fileExt == ".xls")
            {
                workbook = new HSSFWorkbook();
            }
            else
            {
                workbook = null;
            }

            if (workbook == null)
            {
                return;
            }

            ISheet sheet = workbook.CreateSheet("test");

            try
            {
                //Excel列名
                IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dgv.ColumnCount; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(dgv.Columns[i].HeaderText.ToString());
                }

                //遍历excel所有行
                for (int i = 0; i < dgv.RowCount - 1; i++)
                {
                    IRow row1 = sheet.CreateRow(i + 1);
                    //遍历每一行的中的所有列 从而实现所有单元格的遍历
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        if(dgv[j, i].Value.ToString() == null)
                        {
                            cell.SetCellValue("");
                        }
                        else
                        {
                            cell.SetCellValue(dgv[j, i].Value.ToString());
                        }
                    }
                }

                //转为字节数组
                MemoryStream stream = new MemoryStream();
                workbook.Write(stream);
                var buf = stream.ToArray();

                //保存为Excel文件
                using (FileStream fs = new FileStream(file, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(buf, 0, buf.Length);
                    fs.Flush();
                }

                MessageBox.Show("导出成功");
                log.Info(new LogContent(FrmLogin.Uid, "导出到Excel", FrmLogin.UserType, "导出成功"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace);
                log.Error(new LogContent(FrmLogin.Uid, "导出到Excel", FrmLogin.UserType, ex.Message));
            }
        }

        /// <summary>
        /// 获取单元格类型
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank:   
                    return null;
                case CellType.Boolean:   
                    return cell.BooleanCellValue;
                case CellType.Numeric:
                    return cell.NumericCellValue;
                case CellType.String:  
                    return cell.StringCellValue;
                case CellType.Error: 
                    return cell.ErrorCellValue;
                case CellType.Formula: 
                default:
                    return "=" + cell.CellFormula;
            }
        }
    }
}

