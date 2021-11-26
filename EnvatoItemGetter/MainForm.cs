using EnvatoItemGetter.Models;
using ExcelDataReader;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EnvatoItemGetter
{
    public partial class MainForm : Form
    {
        List<KeyValue> errorIdList = new List<KeyValue>();
        List<EnvatoItem> envatoItems = new List<EnvatoItem>();
        bool isStop = false;
        bool isContinue = false;
        bool isFinish = false;

        int lastIndex = 0;
        string savePath = string.Empty;
        
        public string TruncateLongString(string str, int maxLength)
        {
            if (string.IsNullOrEmpty(str))
                return str;
            return str.Substring(0, Math.Min(str.Length, maxLength));
        }

        public MainForm()
        {
            InitializeComponent();
            IdListFileDialog.FileOk += IdListFileDialog_FileOk;
            EnvatoItemSaveDialog.FileOk += EnvatoItemSaveDialog_FileOk;

            BuErrorListExport.Enabled = false;
            BuStart.Enabled = false;
            BuStop.Enabled = false;
            BuExport.Enabled = false;
            TbToken.Enabled = false;

            columncheck.Items.Insert(0, "EnvatoItemId");
            columncheck.Items.Insert(1, "EnvatoItemName");
            columncheck.Items.Insert(2, "EnvatoItemNumberOfSales");
            columncheck.Items.Insert(3, "EnvatoItemAuthorUsername");
            columncheck.Items.Insert(4, "EnvatoItemAuthorUrl");
            columncheck.Items.Insert(4, "EnvatoItemUrl");
            columncheck.Items.Insert(4, "EnvatoItemUpdatedAt");
            columncheck.Items.Insert(4, "EnvatoItemDescription");
            columncheck.Items.Insert(4, "EnvatoItemSite");
            columncheck.Items.Insert(4, "EnvatoItemClassification");
            columncheck.Items.Insert(4, "EnvatoItemClassificationUrl");
            columncheck.Items.Insert(4, "EnvatoItemPriceCents");
            columncheck.Items.Insert(4, "EnvatoItemAuthorImage");
            columncheck.Items.Insert(4, "EnvatoItemSummary");
            columncheck.Items.Insert(4, "EnvatoItemRating");
            columncheck.Items.Insert(4, "EnvatoItemRatingCount");
            columncheck.Items.Insert(4, "EnvatoItemPublishedAt");
            columncheck.Items.Insert(4, "EnvatoItemTrending");
            columncheck.Items.Insert(4, "EnvatoItemTags");
            columncheck.Items.Insert(4, "Attributealphachannel");
            columncheck.Items.Insert(4, "Attributefilesize");
            columncheck.Items.Insert(4, "Attributefixedpreviewresolution");
            columncheck.Items.Insert(4, "Attributelengthvideo");
            columncheck.Items.Insert(4, "Attributeloopedvideo");
            columncheck.Items.Insert(4, "Attributeresolution");
            columncheck.Items.Insert(4, "Attributevideoencoding");
            columncheck.Items.Insert(4, "IconPreviewIconUrl");
            //buradan ekledik.

        }

        private void EnvatoItemSaveDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            savePath = EnvatoItemSaveDialog.FileName;

            ExportData();

            if (isFinish)
            {
                LbIds.Items.Clear();
                LbEnvatoItems.Items.Clear();
                PbItem.Value = 0;
            }
        }

        private void ExportData()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            List<string> selectedCheck = new List<string>();

            //secili olan listesinde seçili olanalrı ekle sadece kolon olarak
            

            for (int i = 0; i < columncheck.CheckedItems.Count; i++)
            {
                selectedCheck.Add(columncheck.CheckedItems[i].ToString()); 
                
            }

            foreach (var item in envatoItems)
            {
                try
                {
                    DataRow dr = dt.NewRow();

                    
                    var envateItemProperties = GetProperties(item);

                    //keyde başlık value değeri


                    for (int i = 0; i < envateItemProperties.Count; i++)
                    {
                        if (!dt.Columns.Contains(envateItemProperties[i].Key))
                        {
                            if (selectedCheck.Any(s=>s==envateItemProperties[i].Key))
                            {
                                dt.Columns.Add(envateItemProperties[i].Key);
                            }
                            //if mi ne olursa 
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
                catch (Exception ex)
                {

                }
            }


            StringBuilder sb = new StringBuilder();

            var columnNames = 
                dt.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", fields));
            }


            File.WriteAllText(savePath, sb.ToString(), Encoding.Default);

            MessageBox.Show("Çıktı Alındı.");
        }

        private void IdListFileDialog_FileOk(
            object sender,
            System.ComponentModel.CancelEventArgs e)
        {
            BuLoadId.Enabled = true;
            BuStart.Enabled = true;
            BuStop.Enabled = false;
            BuExport.Enabled = true;
            TbToken.Enabled = true;

            isStop = false;
            isContinue = false;

            using (
                var stream =
                File.Open(IdListFileDialog.FileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    do
                    {
                        while (reader.Read())
                        {
                            for (int column = 0; column < reader.FieldCount; column++)
                            {
                                LbIds.Items.Add(reader.GetValue(column));
                            }
                        }
                    } while (reader.NextResult());
                }
            }
        }

        private void BuLoadId_Click(object sender, EventArgs e)
        {
            IdListFileDialog.ShowDialog();
        }
        public int tokenIndex { get; set; } = 0;
        private async void BuStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbToken.Text))
            {
                MessageBox.Show("Api Key Boş Olamaz!");
                return;
            }

            BuLoadId.Enabled = false;
            BuStart.Enabled = false;
            BuStop.Enabled = true;
            BuExport.Enabled = false;
            TbToken.Enabled = false;


            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.
                    MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add(
                  "Authorization",
                  "Bearer " + TbToken.Text.Split(';')[0]);
                tokenIndex = 0;

                PbItem.Maximum = LbIds.Items.Count;
                PbItem.Value = 0;

                Application.DoEvents();

                for (int i = 0; i < LbIds.Items.Count; i++)
                {
                    if (isStop)
                    {
                        lastIndex = i;
                        isContinue = true;
                        break;
                    }

                    if (isContinue)
                    {
                        PbItem.Value = lastIndex;
                        i = lastIndex;
                        lastIndex = 0;
                        isContinue = false;
                    }

                    try
                    {
                        string url =
                            $"https://api.envato.com/v3/market/" +
                            $"catalog/item?id={LbIds.Items[i]}";

                        using (
                            HttpResponseMessage response =
                            await client.GetAsync(url))
                        {
                            response.EnsureSuccessStatusCode();
                            string responseBody =
                                await response.Content.ReadAsStringAsync();

                            var envatoItem = EnvatoItemExport.FromJson(responseBody);
                            envatoItems.Add(envatoItem);
                            LbEnvatoItems.Items.Add(
                                $"{envatoItem.Id} " +
                                $"- {envatoItem.Name} " +
                                $"- {envatoItem.Description}");
                        }
                        PbItem.Value++;
                        Application.DoEvents();
                    }
                    catch (Exception ex)
                    {
                        if (!ex.Message.Contains("404"))
                        {
                            if (tokenIndex == 0)
                            {
                                client.DefaultRequestHeaders
                                    .Authorization = new AuthenticationHeaderValue(
                                        "Bearer", TbToken.Text.Split(';')[1]);
                                tokenIndex = 1;
                            }
                            else
                            {
                                client.DefaultRequestHeaders
                                     .Authorization = new AuthenticationHeaderValue(
                                         "Bearer", TbToken.Text.Split(';')[0]);
                                tokenIndex = 0;
                            }
                            LbError.Text = "Çok fazla istek geldiği için bekleme moduna geçildi";
                            await Task.Delay(5000);
                            LbError.Text = "Bekleme modu sona erdi.";
                            i--;
                            //lastIndex = i;
                            //isContinue = true;

                            //MessageBox.Show(ex.Message);
                            //MessageBox.Show("Muhtemelen Max. Limite ulaşıldığı için durduruldu.");

                            //EnvatoItemSaveDialog.ShowDialog();

                            //MessageBox.Show("modeme reset atıp başlat tuşuna basarsanız devam edecektir.");

                            //BuLoadId.Enabled = true;
                            //BuStart.Enabled = true;
                            //BuStop.Enabled = false;
                            //BuExport.Enabled = true;
                            //TbToken.Enabled = true;
                            //isStop = false;
                            //break;

                        }
                        else
                        {
                            errorIdList.Add(new KeyValue { Key = LbIds.Items[i].ToString(), Value = ex.Message });
                        }
                    }
                }

                if (isStop)
                    MessageBox.Show("İşlem Durduruldu.");
                else
                {
                    MessageBox.Show("Veriler Excele Aktarmaya Hazır.");
                    isFinish = true;
                }

                BuLoadId.Enabled = true;
                BuStart.Enabled = true;
                BuStop.Enabled = false;
                BuExport.Enabled = true;
                TbToken.Enabled = true;
                isStop = false;

                if (errorIdList.Count > 0)
                {
                    BuErrorListExport.Enabled = true;
                }
            }
        }

        private void BuStop_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void BuExport_Click(object sender, EventArgs e)
        {
            EnvatoItemSaveDialog.ShowDialog();
        }

        private void BuErrorListExport_Click(object sender, EventArgs e)
        {
            File.WriteAllText("errorList.json", JsonConvert.SerializeObject(errorIdList));
            MessageBox.Show("Hata listesi uygulama dizinine çıkartıldı.");
        }

        public List<KeyValue> GetProperties(object item)
        {
            if (item is null)
            {
                return new List<KeyValue>();
            }

            List<KeyValue> keyValues = new List<KeyValue>();

            try
            {
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
                    else if (propertyName == "Description")
                    {
                        propertyValue = TruncateLongString(p.GetValue(item).ToString(),31000);
                    }
                    else
                    {
                        if (p is null)
                        {
                            propertyValue = "";
                        }
                        else
                        {
                            try
                            {
                                propertyValue = p.GetValue(item).ToString();
                            }
                            catch
                            {
                                propertyValue = "";
                            }
                        }
                    }

                    keyValues.Add(new KeyValue
                    {
                        Key = item.GetType().Name + propertyName.Replace("-", string.Empty),
                        Value = propertyValue
                    });
                }
            }
            catch (Exception)
            {

            }
            return keyValues;
        }
    }
}
