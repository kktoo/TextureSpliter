﻿# TextureSpliter

白鹭图集软件TextureMerger的反向工具，从TextureMerger输出的png文件和json文件，反向解析出单个图片，方便二次修改。

支持运行于windows，需要.net framework 4.5.2及以上。不需安装，解压即可使用。

开发工具：VisualStudio 2015

# ChangeLog

## 1.0.4 / 2019-09-20

- 增加对读取文件错误，解析文件格式不对等异常情况的处理

## 1.0.3 / 2019-08-02

- 增加进度条显示解析进度的功能
- 增加展示版本号的功能
- 增加清空按钮
- 增加对json文件中frame数据没有扩展名的情况的处理
- 修改猜测文件路径的条件，方便重复使用

## 1.0.2 / 2019-07-26

- 简化json解析
- 解析中的时候禁用操作按钮，解析完毕激活操作按钮
- 优化数据文件和目标文件夹的猜测填充逻辑
- 解析前增加合法性判断
- 解析中如果有失败项，进行数量统计并显示在结果提示框中

## 1.0.1 / 2019-07-25

- 输入默认目录设置为我的文档
- 显示起始位置设置为屏幕中部
- 增加自定义icon

## 1.0.0 / 2019-07-24

- 基本功能实现

