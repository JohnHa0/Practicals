# Dependencies
# pip install geopandas shapely
# 
import geopandas as gpd
from shapely.geometry import Point
import geopandas as gpd
from shapely.geometry import Point

## 结构化与规范数据
# 定义坐标点列表
coordinates = ["1102300E，223400N", "1102500E,223500N"]  # 注意，第一个坐标使用了中文逗号

# 解析坐标点
points = []
for coord in coordinates:
    coord = coord.replace("，", ",")  # 将中文逗号替换为英文逗号
    parts = coord.split(',')
    x = float(parts[0][:-1])  # 从字符串中去除"E"，并转为浮点数
    y = float(parts[1][:-1])  # 从字符串中去除"N"，并转为浮点数
    points.append(Point(x, y))

# 创建GeoDataFrame
gdf = gpd.GeoDataFrame({'geometry': points})

# 指定坐标参考系统（CRS）
gdf.crs = "EPSG:32633"  # 例如，这是UTM 33N的EPSG代码。根据需要进行更改

# 保存为shapefile
output_path = "path_to_save/points.shp"  # 修改保存路径
gdf.to_file(output_path)

print(f"Shapefile created successfully at {output_path}")

## 如果从剪切板复制，可能会存在非结构化数据，对此可以批量处理
import geopandas as gpd
from shapely.geometry import Point

# 定义坐标点字符串
coord_str = "1112341E，231200N、1123323E，123421N、1123323E，123421N"

# 使用中文顿号将字符串分割为坐标点列表
coordinates = coord_str.split('、')

# 解析坐标点
points = []
for coord in coordinates:
    coord = coord.replace("，", ",")  # 将中文逗号替换为英文逗号
    parts = coord.split(',')
    x = float(parts[0][:-1])  # 从字符串中去除"E"，并转为浮点数
    y = float(parts[1][:-1])  # 从字符串中去除"N"，并转为浮点数
    points.append(Point(x, y))

# 创建GeoDataFrame
gdf = gpd.GeoDataFrame({'geometry': points})

# 指定坐标参考系统（CRS）
gdf.crs = "EPSG:32633"  # 例如，这是UTM 33N的EPSG代码。根据需要进行更改

# 保存为shapefile
output_path = "path_to_save/points.shp"  # 修改保存路径
gdf.to_file(output_path)

print(f"Shapefile created successfully at {output_path}")

