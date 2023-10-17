// 一个TextBox（命名为textBoxCoords）用于用户手动输入坐标。
// 一个Button（命名为btnLoadFromFile）用于从文件中加载坐标。
// 一个Button（命名为btnSave）用于保存Shapefile。
// 一个SaveFileDialog（命名为saveFileDialog）用于选择保存路径。


using System;
using System.IO;
using System.Windows.Forms;
using OSGeo.OGR;
using System.Collections.Generic;


namespace ShapefileCreationExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Ogr.RegisterAll();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "Shapefile (*.shp)|*.shp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveFileDialog.FileName;
                CreateShapefile(textBoxCoords.Text, outputPath);
                MessageBox.Show("Shapefile created successfully!");
            }
        }

        private void CreateShapefile(string coordStr, string outputPath)
        {
            var coordinates = coordStr.Split('、');
            List<double[]> points = new List<double[]>();
            
            foreach (var coord in coordinates)
            {
                var parts = coord.Replace("，", ",").Split(',');
                double x = Convert.ToDouble(parts[0].TrimEnd('E'));
                double y = Convert.ToDouble(parts[1].TrimEnd('N'));
                points.Add(new double[] { x, y });
            }

            var driver = Ogr.GetDriverByName("ESRI Shapefile");
            var ds = driver.CreateDataSource(outputPath, null);
            var layer = ds.CreateLayer("lineLayer", null, wkbGeometryType.wkbLineString, null);

            FieldDefn colorField = new FieldDefn("Color", FieldType.OFTString);
            colorField.SetWidth(10);
            layer.CreateField(colorField, 1);

            FeatureDefn defn = layer.GetLayerDefn();
            var feature = new Feature(defn);

            var line = new Geometry(wkbGeometryType.wkbLineString);
            foreach (var point in points)
            {
                line.AddPoint(point[0], point[1]);
            }

            feature.SetGeometry(line);
            feature.SetField("Color", "#FF0000");
            layer.CreateFeature(feature);

            feature.Dispose();
            ds.Dispose();
        }
    }
}
