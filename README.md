# Tiled-Tutorial
学习使用，如何将Tiled集成到Unity

## 注意事项
Localpackages文件夹内是Super Tiled2Unity的压缩包，需要解压之后使用，具体参考视频对应位置

此外，图块层可以建多层来分离碰撞逻辑。比如有完全无法穿过的墙壁，在unity中我们通常将其分到Ground layer，但是也有可以从下方穿过的平台（参考泰拉瑞亚等横板游戏），他们应该被归类到Platform layer，因此，你应该在Tiled中就将他们分到不同的图块层，并在导入Unity后给与他们对应的layer。
