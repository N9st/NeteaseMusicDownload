# NeteaseMusicDownload
网易云无损音乐下载，没有无损音质就默认下载最高音质。

## 序言
1.本项目仅供交流学习，尊重音乐版权，请勿私自搭建第三方接口供他人使用或用于非法盈利。

2.会员专属歌曲需要会员才能下载，所以别想着白嫖，抓紧给网易云音乐开会员！

## 测试环境
Win11 + Visual Studio 2022 + .Net Framework 4.8

## 所需库
Sunny UI、System.Text.Json、ZXing

## 功能
1.扫码登录：实时监控二维码状态，是否过期、是否扫码、是否完成登录；

2.搜索歌曲：默认返回符合搜索要求的前30首歌曲；

3.下载歌曲：默认下载无损音质或最高音质；

4.保存登录Cookie：将Cookie保存在本地，避免多次扫码登录，导致账号异常；

5.临时保存下载记录：在内存中临时保存本次下载记录，避免多次下载；

## 最后
1.接口有可能会失效，且行且珍惜，以后有机会随缘更新。

2.代码编写粗糙，可能存在一些未知bug，有缘人自行修复。

3.再会！

## License
[The MIT License (MIT)](https://github.com/N9st/NeteaseMusicDownload/blob/master/LICENSE.txt)