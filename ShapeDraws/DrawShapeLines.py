import geopandas as gpd
from shapely.geometry import Point, LineString

# 定义坐标点字符串
coord_str = "1112341E，231200N、1123323E，123421N、1123323E，123421N"
coordinates = coord_str.split('、')

# 解析坐标点
points = []
for coord in coordinates:
    coord = coord.replace("，", ",")
    parts = coord.split(',')
    x = float(parts[0][:-1])
    y = float(parts[1][:-1])
    points.append(Point(x, y))

# 使用解析的点创建LineString对象
line = LineString(points)

# 创建GeoDataFrame并为线设置一个颜色
gdf = gpd.GeoDataFrame({'geometry': [line], 'color': ['#FF0000']})  # 使用红色作为颜色的例子

# 指定坐标参考系统（CRS）
gdf.crs = "EPSG:32633"

# 保存为shapefile
output_path = "path_to_save/line.shp"
gdf.to_file(output_path)

print(f"Shapefile with line created successfully at {output_path}")
