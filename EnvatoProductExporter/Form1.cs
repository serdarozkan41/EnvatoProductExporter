using ChoETL;
using CsvHelper;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace EnvatoProductExporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BuIdUpload_Click(object sender, EventArgs e)
        {
            ofdIds.ShowDialog();
        }

        private void ofdIds_FileOk(object sender, CancelEventArgs e)
        {
            string selectedFileName = ofdIds.FileName;
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = File.Open(selectedFileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read()) //Each ROW
                        {
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                //Console.WriteLine(reader.GetString(column));//Will blow up if the value is decimal etc. 
                                idListBox.Items.Add(reader.GetValue(column));
                                Debug.WriteLine(reader.GetValue(column));
                                //Get Value returns object
                            }
                        }
                    } while (reader.NextResult()); //Move to NEXT SHEET
                }
            }

            MessageBox.Show("Idler Getirildi.");
        }

        List<EnvatoItem> envatoItems = new List<EnvatoItem>();
        public bool isStop { get; set; } = false;
        public bool isContinue { get; set; } = false;
        public int Count { get; set; } = 0;
        private async void BuGetInfo_Click(object sender, EventArgs e)
        {
            BuGetInfo.Enabled = false;
            BuExportExcel.Enabled = false;
            BuIdUpload.Enabled = false;

            using (HttpClient client = new HttpClient())
            {
                client
                    .DefaultRequestHeaders
                    .Add(
                    "authorization",
                    "Bearer 4na26UjXS6eKdPblbDZoHIgRDjlm78FV");
                pBarInfo.Maximum = idListBox.Items.Count;
                pBarInfo.Value = 0;
                Application.DoEvents();

                for (int i = 0; i < idListBox.Items.Count; i++)
                {
                    try
                    {
                        string url = $"https://api.envato.com/v3/market/catalog/item?id={idListBox.Items[i].ToString()}";
                        using (HttpResponseMessage response = await client.GetAsync(url))
                        {
                            response.EnsureSuccessStatusCode();
                            string responseBody = await response.Content.ReadAsStringAsync();
                            var envatoItem = EnvatoItem.FromJson(responseBody);
                            envatoItems.Add(envatoItem);
                            items.Items.Add($"{envatoItem.Id} - {envatoItem.Name} - {envatoItem.Description}");
                        }
                        pBarInfo.Value++;
                        Application.DoEvents();
                        if (isStop)
                        {
                            Count = i;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        items.Items.Add($"{ex.Message}");
                    }
                }
                BuGetInfo.Enabled = true;
                BuExportExcel.Enabled = true;
                BuIdUpload.Enabled = true;
                isStop = false;
            }

            //for (int i = 0; i < envatoItems.Count; i++)
            //{
            //    items.Items.Add($"{envatoItems[i].Id} - {envatoItems[i].Name} - {envatoItems[i].Description}");
            //}
            MessageBox.Show("Bilgiler Getirildi.");

        }

        private void BuExportExcel_Click(object sender, EventArgs e)
        {
            Dictionary<string, string?> Ogrenci = new Dictionary<string, string?>();
            DataTable dt = new DataTable();
            dt.Clear();

            //EnvatoItem modelimin standart özelliklerini içeri aktarmak için


            foreach (var item in envatoItems)
            {
                DataRow dr = dt.NewRow();

                var envateItemProperties = GetProperties(item);
                for (int i = 0; i < envateItemProperties.Count; i++)
                {
                    if (!dt.Columns.Contains(envateItemProperties[i].Key))
                    {
                        dt.Columns.Add(envateItemProperties[i].Key);
                    }

                    var column = dt.Columns[envateItemProperties[i].Key];
                    dr[column] = envateItemProperties[i].Value;
                }

                foreach (var attr in item.Attributes)
                {
                    var att2 = "Attribute" + attr.Name.Replace("-", string.Empty);

                    if (!dt.Columns.Contains(att2))
                    {
                        dt.Columns.Add(att2);
                    }

                    var column = dt.Columns[att2];
                    string val = "";

                    if (attr.Value?.String != null)
                    {
                        val = attr.Value?.String;
                    }
                    else if (attr.Value?.StringArray != null)
                    {
                        val = string.Join(",", attr.Value?.StringArray);
                    }
                    else
                    {
                        val = string.Empty;
                    }

                    dr[column] = val;
                }

                if (item.WordpressThemeMetadata != null)
                {
                    foreach (var wmeta in GetProperties(item.WordpressThemeMetadata))
                    {
                        if (!dt.Columns.Contains(wmeta.Key))
                        {
                            dt.Columns.Add(wmeta.Key);
                        }

                        var column = dt.Columns[wmeta.Key];
                        dr[column] = wmeta.Value;
                    }
                }

                if (item.Previews != null)
                {
                    //foreach (var wmeta in GetProperties(item.Previews))
                    //{
                    //    if (!dt.Columns.Contains(wmeta.Key))
                    //    {
                    //        dt.Columns.Add(wmeta.Key);
                    //    }

                    //    var column = dt.Columns[wmeta.Key];
                    //    dr[column] = wmeta.Value;
                    //}

                    foreach (var wmeta in GetProperties(item.Previews.IconPreview))
                    {
                        if (!dt.Columns.Contains(wmeta.Key))
                        {
                            dt.Columns.Add(wmeta.Key);
                        }

                        var column = dt.Columns[wmeta.Key];
                        dr[column] = wmeta.Value;
                    }

                    foreach (var wmeta in GetProperties(item.Previews.IconWithLandscapePreview))
                    {
                        if (!dt.Columns.Contains(wmeta.Key))
                        {
                            dt.Columns.Add(wmeta.Key);
                        }

                        var column = dt.Columns[wmeta.Key];
                        dr[column] = wmeta.Value;
                    }

                    foreach (var wmeta in GetProperties(item.Previews.LandscapePreview))
                    {
                        if (!dt.Columns.Contains(wmeta.Key))
                        {
                            dt.Columns.Add(wmeta.Key);
                        }

                        var column = dt.Columns[wmeta.Key];
                        dr[column] = wmeta.Value;
                    }

                    foreach (var wmeta in GetProperties(item.Previews.LiveSite))
                    {
                        if (!dt.Columns.Contains(wmeta.Key))
                        {
                            dt.Columns.Add(wmeta.Key);
                        }

                        var column = dt.Columns[wmeta.Key];
                        dr[column] = wmeta.Value;
                    }
                }

                dt.Rows.Add(dr);
            }

            StringBuilder sb = new StringBuilder();

            var columnNames = dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText($"{Guid.NewGuid()}_{DateTime.Now.ToShortDateString()}.csv", sb.ToString(), Encoding.Default);
     
            MessageBox.Show("Çıktı Alındı.");
        }



        public List<KeyValue> GetProperties(object item)
        {
            List<KeyValue> keyValues = new List<KeyValue>();
            foreach (PropertyInfo p in item.GetType().GetProperties())
            {
                string propertyName = p.Name;
                if (propertyName == "Type"
                    || propertyName == "Attributes"
                    || propertyName == "WordpressThemeMetadata"
                    || propertyName == "Previews")
                {
                    continue;
                }

                string propertyValue = "";

                if (propertyName == "Tags")
                {
                    object ls = p.GetValue(item);
                    propertyValue = string.Join(",", (List<string>)ls);
                }
                else
                {
                    propertyValue = p.GetValue(item).ToString();
                }

                keyValues.Add(new KeyValue
                {
                    Key = item.GetType().Name + propertyName.Replace("-", string.Empty),
                    Value = propertyValue
                });
            }

            return keyValues;
        }

        public void WriteJsonFile(string path, List<EnvatoItem> student)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(student));
        }

        public void WriteCSVFile(string path, List<EnvatoItem> student)
        {
            using (var parser = new ChoCSVWriter<EnvatoItem>(path))
            {
                parser.Write(student);
            }
        }

        private void BuStop_Click(object sender, EventArgs e)
        {
            if (isStop)
            {
                isStop = false;
            }
            else
            {
                isStop = true;
            }
        }
    }

    public class KeyValue
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
