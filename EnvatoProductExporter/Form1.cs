using CsvHelper;
using ExcelDataReader;
using Newtonsoft.Json;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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

        private async void BuGetInfo_Click(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("authorization", "Bearer qWZ0kRYnYv54P6NrT45gS6tZV8rnDFQm");
                pBarInfo.Maximum = idListBox.Items.Count;
                pBarInfo.Value = 0;
                Application.DoEvents();

                for (int i = 0; i < idListBox.Items.Count; i++)
                {
                    string url = $"https://api.envato.com/v3/market/catalog/item?id={idListBox.Items[i].ToString()}";
                    using (HttpResponseMessage response = await client.GetAsync(url))
                    {
                        response.EnsureSuccessStatusCode();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        var envatoItem = EnvatoItem.FromJson(responseBody);
                        envatoItems.Add(envatoItem);
                    }
                    pBarInfo.Value++;
                    Application.DoEvents();
                }
            }

            for (int i = 0; i < envatoItems.Count; i++)
            {
                items.Items.Add($"{envatoItems[i].Id} - {envatoItems[i].Name} - {envatoItems[i].Description}");
            }
            MessageBox.Show("Bilgiler Getirildi.");

        }

        private void BuExportExcel_Click(object sender, EventArgs e)
        {
            WriteCSVFile($"Sonuc{DateTime.Now.ToShortDateString()}.csv", envatoItems);
            WriteJsonFile($"Sonuc{DateTime.Now.ToShortDateString()}.json", envatoItems);
            MessageBox.Show("Çıktı Alındı.");
        }
        public void WriteJsonFile(string path, List<EnvatoItem> student)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(student));
        }
        public void WriteCSVFile(string path, List<EnvatoItem> student)
        {
            using (StreamWriter sw = new StreamWriter(path, false, new UTF8Encoding(true)))
            using (CsvWriter cw = new CsvWriter(sw, CultureInfo.InvariantCulture))
            {
                cw.WriteHeader<EnvatoItem>();
                cw.NextRecord();
                foreach (EnvatoItem stu in student)
                {
                    cw.WriteRecord<EnvatoItem>(stu);
                    cw.NextRecord();
                }
            }
        }
    }
}
