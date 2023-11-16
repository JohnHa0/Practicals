using System;
using System.IO;
using System.Windows.Forms;
using OSGeo.OGR;
using System.Collections.Generic;
using OSGeo.GDAL;
using OSGeo.OSR;

namespace Draws
{
    public partial class MainForm : Form
    {
        ///private string logPath = "C:\\Users\\Hao\\Desktop\\error_log.txt";
        private string logPath = Path.Combine(Application.StartupPath, "error_log.txt");

        private string defaultOutputDirectory = "C:\\output";
        private string defaultLineColor = "#FF0000";

        enum GeometryType
        {
            Point,
            Line,
            Polygon
        }

        public MainForm()
        {
            InitializeComponent();
            GdalConfiguration.ConfigureGdal();
            GdalConfiguration.ConfigureOgr();
            Gdal.AllRegister();
            Ogr.RegisterAll();
        }

        private void textBoxCoords_TextChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "TXT files (*.txt)|*.txt|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxCoords.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void btn_savePath_Click(object sender, EventArgs e)
        {
            //�趨·��
            //using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            //{
            //    folderDialog.Description = "Select the folder to save the shapefile";
            //    folderDialog.ShowNewFolderButton = true;

            //    if (folderDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        // Set the selected folder path to the textbox
            //        textBox_savePath.Text = folderDialog.SelectedPath;
            //    }
            //}
        }


        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                InitialDirectory = defaultOutputDirectory,
                Filter = "Shapefile (*.shp)|*.shp"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string outputPath = saveFileDialog.FileName;
                    List<double[]> points = ParseCoordinates(textBoxCoords.Text);
                    if (points != null)
                    {
                        CreateShapefile(points, outputPath, defaultLineColor);
                        MessageBox.Show("Shapefile created successfully!");
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex.ToString());
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }
        }
        private void LogError(string error)
        {
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {error}");
            }
        }

        // Coords Example
        // 3459N、12337E,3409N、12337E,3309N、12321E,3309N、12253E


        private wkbGeometryType GetSelectedGeometryType()
        {
            if (radioButtonPoint.Checked)
                return wkbGeometryType.wkbPoint;
            else if (radioButtonLine.Checked)
                return wkbGeometryType.wkbLineString;
            else if (radioButtonPolygon.Checked)
                return wkbGeometryType.wkbPolygon;
            else
                return wkbGeometryType.wkbLineString; // 默认设置为折线图
        }


        private List<double[]> ParseCoordinates(string coordStr)
        {
            // 清理换行符和多余的空格
            string cleanedCoordStr = coordStr.Replace("\n", "").Replace("\r", "").Trim();
            var coordinates = cleanedCoordStr.Split(new[] { ',', '，' }, StringSplitOptions.RemoveEmptyEntries);// Split Data by "、"
            List<double[]> points = new List<double[]>();

            foreach (var coord in coordinates)
            {
                var parts = coord.Split('、'); //Replace potental Chinese coma in the data
                if (parts.Length != 2)
                {
                    MessageBox.Show($"Invalid coordinate format: {coord}. Please check the input.");
                    return null;
                }

                if (!parts[0].EndsWith("N") || !parts[1].EndsWith("E"))
                {
                    MessageBox.Show($"Invalid coordinate format: {coord}. Please check the input.");
                    return null;
                }

                try
                {
                    //double x = Convert.ToDouble(parts[1].TrimEnd('E'));
                    //double y = Convert.ToDouble(parts[0].TrimEnd('N'));
                    double x = ConvertToDecimalDegrees(parts[1].TrimEnd('E'), true); // 经度
                    double y = ConvertToDecimalDegrees(parts[0].TrimEnd('N'), false); // 纬度
                    points.Add(new double[] { x, y });
                }
                catch (FormatException)
                {
                    MessageBox.Show($"Invalid coordinate values in: {coord}. Please check the input.");
                    return null;
                }
            }

            return points;
        }
        private double ConvertToDecimalDegrees(string dms, bool isLongitude)
        {
            int degreeLength = isLongitude ? 3 : 2; // 经度为3位数，纬度为2位数
            double degrees = double.Parse(dms.Substring(0, degreeLength));
            double minutes = double.Parse(dms.Substring(degreeLength, 2));

            return degrees + (minutes / 60.0);
        }


        //private void CreateShapefile(List<double[]> points, string outputPath, string color = "#FF0000")
        //{
        //    var geometryType = GetSelectedGeometryType();///绘图类型

        //    var driver = Ogr.GetDriverByName("ESRI Shapefile");
        //    var ds = driver.CreateDataSource(outputPath, null);

        //    // 创建空间参考系统，使用WGS 84 / Pseudo-Mercator(3857)
        //    var srs = new SpatialReference("");
        //    srs.ImportFromEPSG(4326); // 例如，这里使用WGS84坐标系

        //    var layer = ds.CreateLayer("lineLayer", srs, wkbGeometryType.wkbLineString, null);

        //    FieldDefn colorField = new FieldDefn("Color", FieldType.OFTString);
        //    colorField.SetWidth(10);
        //    layer.CreateField(colorField, 1);

        //    FeatureDefn defn = layer.GetLayerDefn();
        //    var feature = new Feature(defn);

        //    var line = new Geometry(wkbGeometryType.wkbLineString);
        //    foreach (var point in points)
        //    {
        //        line.AddPoint(point[0], point[1], 0);  // 添加了0作为第三个参数
        //    }

        //    feature.SetGeometry(line);
        //    feature.SetField("Color", color);
        //    layer.CreateFeature(feature);

        //    feature.Dispose();
        //    ds.Dispose();
        //}



        private void CreateShapefile(List<double[]> points, string outputPath, string color = "#FF0000")
        {
            var geometryType = GetSelectedGeometryType(); // 绘图类型

            var driver = Ogr.GetDriverByName("ESRI Shapefile");
            var ds = driver.CreateDataSource(outputPath, null);

            // 创建空间参考系统，使用WGS 84
            var srs = new SpatialReference("");
            srs.ImportFromEPSG(4326); // 使用WGS84坐标系

            // 根据所选几何类型创建图层
            var layer = ds.CreateLayer("layer", srs, geometryType, null);

            FieldDefn colorField = new FieldDefn("Color", FieldType.OFTString);
            colorField.SetWidth(10);
            layer.CreateField(colorField, 1);

            FeatureDefn defn = layer.GetLayerDefn();
            var feature = new Feature(defn);

            var geom = new Geometry(geometryType);
            if (geometryType == wkbGeometryType.wkbPoint)
            {
                if (points.Count > 0)
                {
                    var point = points[0];
                    geom.AddPoint(point[0], point[1], 0);
                }
            }
            else if (geometryType == wkbGeometryType.wkbLineString)
            {
                foreach (var point in points)
                {
                    geom.AddPoint(point[0], point[1], 0);
                }
            }
            else if (geometryType == wkbGeometryType.wkbPolygon)
            {
                var ring = new Geometry(wkbGeometryType.wkbLinearRing);
                foreach (var point in points)
                {
                    ring.AddPoint(point[0], point[1], 0);
                }
                // 确保闭合多边形
                if (points.Count > 0)
                {
                    var firstPoint = points[0];
                    ring.AddPoint(firstPoint[0], firstPoint[1], 0);
                }
                geom.AddGeometryDirectly(ring);
            }

            feature.SetGeometry(geom);
            feature.SetField("Color", color);
            layer.CreateFeature(feature);

            feature.Dispose();
            geom.Dispose(); // 释放几何对象
            ds.Dispose();
        }


        private void label_filePath_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonPoint_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSettings_Click_Click(object sender, EventArgs e)
        {
            // 创建SettingsForm实例
            SettingsForm settingsForm = new SettingsForm();

            // 显示SettingsForm窗体
            settingsForm.ShowDialog(); // 使用ShowDialog来作为模态对话框打开
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
