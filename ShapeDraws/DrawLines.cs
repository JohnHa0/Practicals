// <!-- C#中实现这一功能，通常使用GDAL/OGR库，它是一个开源的地理空间数据处理库，能够创建和读取大多数GIS数据格式，包括Shapefile。

// 首先，你需要为你的C#项目安装GDAL库。你可以使用NuGet包管理器为你的项目安装GDAL。

// 以下是使用C#和GDAL/OGR库创建Shapefile的代码：  -->


using OSGeo.OGR;
using System;
using System.Collections.Generic;

namespace ShapefileCreationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Ogr.RegisterAll();

            string coordStr = "1112341E，231200N、1123323E，123421N、1123323E，123421N";
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
            if (driver == null)
            {
                Console.WriteLine("Driver not available");
                return;
            }

            var ds = driver.CreateDataSource("path_to_save/line.shp", null);
            var layer = ds.CreateLayer("lineLayer", null, wkbGeometryType.wkbLineString, null);

            FeatureDefn defn = layer.GetLayerDefn();
            var feature = new Feature(defn);

            var line = new Geometry(wkbGeometryType.wkbLineString);
            foreach (var point in points)
            {
                line.AddPoint(point[0], point[1]);
            }

            feature.SetGeometry(line);
            layer.CreateFeature(feature);

            feature.Dispose();
            ds.Dispose();

            Console.WriteLine("Shapefile created successfully!");
        }
    }
}
