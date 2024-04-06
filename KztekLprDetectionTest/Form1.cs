using iParkingv5.LprDetecter.LprDetecters;
using iParkingv5.Objects;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace KztekLprDetectionTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            txtInputPath.Text = Properties.Settings.Default.inputPath;
            txtOutputPath.Text = Properties.Settings.Default.outputPath;
            this.Load += Form1_Load;
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
            StaticPool.LprDetect = LprFactory.CreateLprDetecter(StaticPool.lprConfig, null);
            StaticPool.LprDetect?.CreateLpr(StaticPool.lprConfig);
            //StaticPool.LprDetect2 = LprFactory.CreateLprDetecter(StaticPool.lprConfig, null);
            //StaticPool.LprDetect2?.CreateLpr(StaticPool.lprConfig);
            //StaticPool.LprDetect3 = LprFactory.CreateLprDetecter(StaticPool.lprConfig, null);
            //StaticPool.LprDetect3?.CreateLpr(StaticPool.lprConfig);
            //StaticPool.LprDetect4 = LprFactory.CreateLprDetecter(StaticPool.lprConfig, null);
            //StaticPool.LprDetect4?.CreateLpr(StaticPool.lprConfig);
            dgvData.SelectionChanged += DgvData_SelectionChanged;
        }

        private void DgvData_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvData.CurrentRow == null)
            {
                return;
            }

            string inputPath = dgvData.CurrentRow.Cells[1].Value?.ToString();
            string outputPath = dgvData.CurrentRow.Cells[2].Value?.ToString();

            try
            {
                if (!string.IsNullOrEmpty(inputPath) && File.Exists(inputPath))
                {
                    using (Image input = Image.FromFile(inputPath))
                    {
                        picInput.Image = (Image)input.Clone();
                    }
                }
                else
                {
                    picInput.Image = null;
                }

                if (!string.IsNullOrEmpty(outputPath) && File.Exists(outputPath))
                {
                    using (Image output = Image.FromFile(outputPath))
                    {
                        picOutput.Image = (Image)output.Clone();
                    }
                }
                else
                {
                    picOutput.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading images: {ex.Message}");
            }
        }

        private void btnCreateLPR_Click(object sender, EventArgs e)
        {

        }

        List<string> files = new List<string>();
        int lastIndex = 1;
        private async void btnDetect_Click(object sender, EventArgs e)
        {
            //dgvData.SelectionChanged -= DgvData_SelectionChanged;
            string rootPath = txtInputPath.Text;
            string resultPath = txtOutputPath.Text;
            if (!isStop)
            {
                Properties.Settings.Default.inputPath = rootPath;
                Properties.Settings.Default.outputPath = resultPath;
                Properties.Settings.Default.Save();
                if (!Directory.Exists(rootPath))
                {
                    MessageBox.Show("Đường dẫn vào không tồn tại");
                    return;
                }

                if (!Directory.Exists(resultPath))
                {
                    MessageBox.Show("Đường dẫn ra không tồn tại");
                    return;
                }
                try
                {
                    Directory.Delete(resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\LPR");
                    Directory.Delete(resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\ERROR");
                }
                catch (Exception)
                {
                }
            }
            dgvData.Rows.Clear();
            Directory.CreateDirectory(resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\LPR");
            Directory.CreateDirectory(resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\ERROR");
            files = Directory.GetFiles(rootPath).OrderBy(t => t).OrderBy(t => t.Length).ToList();
            var sw = Stopwatch.StartNew();
            isStop = false;

            //Task.Run(() =>
            //{
            //    for (int i = lastIndex; i < files.Count; i += 1)
            //    {
            //        //1;5;7;9;11;13
            //        if (i % 2 == 0 || i % 3 == 0)
            //        {
            //            continue;
            //        }
            //        string? file = files[i];
            //        if (!isStop)
            //        {
            //            try
            //            {
            //                using (Image img = Image.FromFile(file))
            //                {
            //                    var sw = Stopwatch.StartNew();
            //                    string plate = StaticPool.LprDetect.GetPlateNumber(img, chbIsCar.Checked, null, out Image resultImg);
            //                    var detectTime = sw.ElapsedMilliseconds;
            //                    string savePath = string.Empty;

            //                    //Task.Run(() =>
            //                    //{
            //                    if (string.IsNullOrEmpty(plate))
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "ERROR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        img?.Save(savePath, ImageFormat.Jpeg);
            //                    }
            //                    else
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "LPR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        resultImg?.Save(savePath, ImageFormat.Jpeg);
            //                        resultImg?.Dispose();
            //                    }
            //                    //});


            //                    this.Invoke(new Action(() =>
            //                    {
            //                        dgvData.Rows.Add(dgvData.Rows.Count + 1, file, savePath, Path.GetFileNameWithoutExtension(file), plate, sw.ElapsedMilliseconds + " ms");
            //                        dgvData.CurrentCell = dgvData.Rows[dgvData.RowCount - 1].Cells[0];
            //                        Application.DoEvents();
            //                    }));
            //                    //GC.Collect();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                // Handle exceptions
            //                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            //            }
            //        }
            //        else
            //        {
            //            lastIndex = i;
            //            break;
            //        }
            //    }
            //});
            //Task.Run(() =>
            //{
            //    for (int i = lastIndex; i < files.Count; i += 1)
            //    {
            //        //0;2;4;6;8;10
            //        if (i % 2 != 0)
            //        {
            //            continue;
            //        }
            //        string? file = files[i];
            //        if (!isStop)
            //        {
            //            try
            //            {
            //                using (Image img = Image.FromFile(file))
            //                {
            //                    var sw = Stopwatch.StartNew();
            //                    string plate = StaticPool.LprDetect2.GetPlateNumber(img, chbIsCar.Checked, null, out Image resultImg);
            //                    var detectTime = sw.ElapsedMilliseconds;
            //                    string savePath = string.Empty;

            //                    //Task.Run(() =>
            //                    //{
            //                    if (string.IsNullOrEmpty(plate))
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "ERROR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        img?.Save(savePath, ImageFormat.Jpeg);
            //                    }
            //                    else
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "LPR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        resultImg?.Save(savePath, ImageFormat.Jpeg);
            //                        resultImg?.Dispose();
            //                    }
            //                    //});


            //                    this.Invoke(new Action(() =>
            //                    {
            //                        dgvData.Rows.Add(dgvData.Rows.Count + 1, file, savePath, Path.GetFileNameWithoutExtension(file), plate, sw.ElapsedMilliseconds + " ms");
            //                        dgvData.CurrentCell = dgvData.Rows[dgvData.RowCount - 1].Cells[0];
            //                        Application.DoEvents();
            //                    }));
            //                    //GC.Collect();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                // Handle exceptions
            //                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            //            }
            //        }
            //        else
            //        {
            //            lastIndex = i;
            //            break;
            //        }
            //    }
            //});
            //Task.Run(() =>
            //{
            //    for (int i = lastIndex; i < files.Count; i += 1)
            //    {
            //        //1;3;9
            //        if (i % 2 == 0 || i % 3 != 0)
            //        {
            //            continue;
            //        }
            //        string? file = files[i];
            //        if (!isStop)
            //        {
            //            try
            //            {
            //                using (Image img = Image.FromFile(file))
            //                {
            //                    var sw = Stopwatch.StartNew();
            //                    string plate = StaticPool.LprDetect3.GetPlateNumber(img, chbIsCar.Checked, null, out Image resultImg);
            //                    var detectTime = sw.ElapsedMilliseconds;
            //                    string savePath = string.Empty;

            //                    //Task.Run(() =>
            //                    //{
            //                    if (string.IsNullOrEmpty(plate))
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "ERROR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        img?.Save(savePath, ImageFormat.Jpeg);
            //                    }
            //                    else
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "LPR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        resultImg?.Save(savePath, ImageFormat.Jpeg);
            //                        resultImg?.Dispose();
            //                        Application.DoEvents();
            //                    }
            //                    //});


            //                    this.Invoke(new Action(() =>
            //                    {
            //                        dgvData.Rows.Add(dgvData.Rows.Count + 1, file, savePath, Path.GetFileNameWithoutExtension(file), plate, sw.ElapsedMilliseconds + " ms");
            //                        dgvData.CurrentCell = dgvData.Rows[dgvData.RowCount - 1].Cells[0];
            //                        Application.DoEvents();
            //                    }));
            //                    //GC.Collect();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                // Handle exceptions
            //                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            //            }
            //        }
            //        else
            //        {
            //            lastIndex = i;
            //            break;
            //        }

            //    }
            //});
            //Task.Run(() =>
            //{
            //    for (int i = lastIndex; i < files.Count; i += 1)
            //    {
            //        //0;6;12;18
            //        if (i % 2 != 0 || i % 3 != 0)
            //        {
            //            continue;
            //        }
            //        string? file = files[i];
            //        if (!isStop)
            //        {
            //            try
            //            {
            //                using (Image img = Image.FromFile(file))
            //                {
            //                    var sw = Stopwatch.StartNew();
            //                    string plate = StaticPool.LprDetect4.GetPlateNumber(img, chbIsCar.Checked, null, out Image resultImg);
            //                    var detectTime = sw.ElapsedMilliseconds;
            //                    string savePath = string.Empty;

            //                    if (string.IsNullOrEmpty(plate))
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "ERROR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        img?.Save(savePath, ImageFormat.Jpeg);
            //                    }
            //                    else
            //                    {
            //                        savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "LPR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
            //                        resultImg?.Save(savePath, ImageFormat.Jpeg);
            //                        resultImg?.Dispose();
            //                    }

            //                    this.Invoke(new Action(() =>
            //                    {
            //                        dgvData.Rows.Add(dgvData.Rows.Count + 1, file, savePath, Path.GetFileNameWithoutExtension(file), plate, sw.ElapsedMilliseconds + " ms");
            //                        dgvData.CurrentCell = dgvData.Rows[dgvData.RowCount - 1].Cells[0];
            //                        Application.DoEvents();
            //                    }));
            //                    //GC.Collect();
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                // Handle exceptions
            //                Console.WriteLine($"Error processing file {file}: {ex.Message}");
            //            }
            //        }
            //        else
            //        {
            //            lastIndex = i;
            //            break;
            //        }

            //    }
            //});
            for (int i = lastIndex; i < files.Count; i += 1)
            {
                //1;5;7;9;11;13
                //if (i % 2 == 0 || i % 3 == 0)
                //{
                //    continue;
                //}
                string? file = files[i];
                if (!isStop)
                {
                    try
                    {
                        using (Image img = Image.FromFile(file))
                        {
                            sw = Stopwatch.StartNew();
                            string plate = StaticPool.LprDetect.GetPlateNumber(img, chbIsCar.Checked, null, out Image resultImg);
                            var detectTime = sw.ElapsedMilliseconds;
                            string savePath = string.Empty;

                            //Task.Run(() =>
                            //{
                            if (string.IsNullOrEmpty(plate))
                            {
                                savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "ERROR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
                                img?.Save(savePath, ImageFormat.Jpeg);
                            }
                            else
                            {
                                savePath = Path.Combine(resultPath, DateTime.Now.ToString("yyyy_MM_dd"), "LPR", $"{Path.GetFileNameWithoutExtension(file)}_{plate.Replace("-", "").Replace(" ", "")}.jpg");
                                resultImg?.Save(savePath, ImageFormat.Jpeg);
                                resultImg?.Dispose();
                            }
                            //});


                            this.Invoke(new Action(() =>
                            {
                                dgvData.Rows.Add(dgvData.Rows.Count + 1, file, savePath, Path.GetFileNameWithoutExtension(file), plate, sw.ElapsedMilliseconds + " ms");
                                dgvData.CurrentCell = dgvData.Rows[dgvData.RowCount - 1].Cells[0];
                                Application.DoEvents();
                            }));
                            //GC.Collect();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        Console.WriteLine($"Error processing file {file}: {ex.Message}");
                    }
                }
                else
                {
                    lastIndex = i;
                    break;
                }
            }
        }

        private void btnSaveErrorPic_Click(object sender, EventArgs e)
        {
            string resultPath = txtOutputPath.Text;
            Directory.CreateDirectory(resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\FALSE");
            string detectPlate = dgvData.CurrentRow.Cells[4].Value?.ToString();
            if (!string.IsNullOrEmpty(detectPlate))
            {
                string savePath = resultPath + "\\" + DateTime.Now.ToString("yyyy_MM_dd") + "\\FALSE\\" + detectPlate + ".jpg";
                picInput.Image.Save(savePath, ImageFormat.Jpeg);
            }
        }

        bool isStop = false;
        private void btnStop_Click(object sender, EventArgs e)
        {
            isStop = true;
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            dgvData.SelectionChanged += DgvData_SelectionChanged;
        }
    }
}
