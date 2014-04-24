using Microsoft.International.Converters.PinYinConverter;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Groupage_client_coder
{
    public class CustomerBLL
    {
        public List<CustomerInfo> CurrentData { get; private set; }

        public void Readdata(string excelFileName)
        {
            List<CustomerInfo> result = new List<CustomerInfo>();

            //開檔
            FileStream fs = new FileStream(excelFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            //載入Excel檔案
            ExcelPackage ep = new ExcelPackage(fs);
            ExcelWorksheet sheet = ep.Workbook.Worksheets["Sheet1"];//取得Sheet1
            int startRowNumber = sheet.Dimension.Start.Row;//起始列編號，從1算起
            int endRowNumber = sheet.Dimension.End.Row;//結束列編號，從1算起
            bool isHeader = true;
            if (isHeader)//有包含標題
            {
                startRowNumber += 1;
            }

            //寫入標題文字
            //sheet.Cells[1, 11].Value = "緯度";
            //sheet.Cells[1, 12].Value = "經度";
            for (int i = startRowNumber; i <= endRowNumber; i++)
            {
                //讀值
                string cellValue1 = sheet.Cells[i, 1].Value.ToString();
                string cellValue2 = sheet.Cells[i, 2].Value.ToString();

                result.Add(new CustomerInfo() 
                        { 
                            Customer_Code = cellValue1
                            , Customer_Name=cellValue2
                        }
                    );
                //寫值
                //sheet.Cells[i, 1].Value = cellValue + "test";
            }

            fs.Close();
            ////建立檔案
            //fs = new FileStream(@"D:\目標檔案.xlsx", FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            //ep.SaveAs(fs);//存檔
            //fs.Close();
            //關閉資源
            ep.Dispose();
            ep = null;

            this.CurrentData = result;

            return ;
        }

        /// <summary>
        /// Export data to Excel
        /// </summary>
        /// <param name="excelFileName"></param>
        public void Export(string excelFileName)
        {
            //FileStream fs = new FileStream(excelFileName, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);

            //載入Excel檔案
            ExcelPackage ep = new ExcelPackage();
            ExcelWorksheet sheet = ep.Workbook.Worksheets.Add("Sheet1");//取得Sheet1

            int startRowNumber = 1;
            sheet.Cells[startRowNumber, 1].Value = "Customer_Code";
            sheet.Cells[startRowNumber, 2].Value = "Customer_Name";
            sheet.Cells[startRowNumber, 3].Value = "New_Code";

            //寫入標題文字
            //sheet.Cells[1, 11].Value = "緯度";
            //sheet.Cells[1, 12].Value = "經度";
            foreach (CustomerInfo item in this.CurrentData)
            {
                startRowNumber += 1;
                //寫值
                sheet.Cells[startRowNumber, 1].Value = item.Customer_Code;
                sheet.Cells[startRowNumber, 2].Value = item.Customer_Name;
                sheet.Cells[startRowNumber, 3].Value = item.New_Code;
            }

            //fs.Close();
            //建立檔案
            FileStream fs = new FileStream(excelFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            ep.SaveAs(fs);//存檔
            fs.Close();
            //關閉資源
            ep.Dispose();
            ep = null;

            return;
        }

        public void CalcNewCode()
        {
            foreach (CustomerInfo info in this.CurrentData)
            {
                info.Prefix = this.GetPrefix(info.Customer_Name);
            }

            foreach(var group in this.CurrentData.GroupBy(r=>r.Prefix))
            {
                int c = group.Count();
                int idx = 0;
                foreach(var item in group)
                {
                    idx++;

                    item.New_Code = item.Prefix + idx.ToString("000");
                }

            }

            this.CurrentData = this.CurrentData.OrderBy(r => r.New_Code).ToList();

            //foreach (CustomerInfo info in this.CurrentData.OrderBy(r => r.Prefix).ThenBy(r => r.Customer_Name))
            //{
            //    info.Prefix = this.GetPinyin(info.Customer_Name);
            //}
        }

        private string GetPrefix(string source)
        {
            source=source.Trim().Replace("'", "").ToUpper();
            source = ClearString(source);

            source = (source.Length >= 3 ? source.Substring(0, 3) : source);
            string prefix = GetFirstPinyin(source);
            return (prefix.Length == 3 ? prefix : (prefix + "000").Substring(0, 3));
        }

        /// <summary> 
        /// 汉字转化为拼音首字母
        /// </summary> 
        /// <param name="str">汉字</param> 
        /// <returns>首字母</returns> 
        public string GetFirstPinyin(string str)
        {
            string r = string.Empty;
            foreach (char obj in str)
            {
                try
                {
                    ChineseChar chineseChar = new ChineseChar(obj);
                    string t = chineseChar.Pinyins[0].ToString();
                    r += t.Substring(0, 1);
                }
                catch
                {
                    r += obj.ToString();
                }
            }
            return r;
        }

        /// <summary>
        /// 置換特殊字元
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public string ClearString(string source)
        {
            string pattern = @"\W";
            string result = Regex.Replace(source, pattern, "");
            return result;
        }
    }

    public class CustomerInfo
    {
        public string Customer_Code { get; set; }

        public string Customer_Name { get; set; }

        public string Prefix { get; set; }

        public string New_Code { get; set; }

    }
}
