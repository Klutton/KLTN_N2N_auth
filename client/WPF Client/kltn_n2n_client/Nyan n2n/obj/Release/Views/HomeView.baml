   M S B A M L   `   `   `  ???? C  ?Nyan n2n, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Nyan_n2n.ViewsNyan_n2n.Views      Nyan_n2n.Views.HomeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  (localclr-namespace:Nyan_n2n.Views  .??? $
??10,0q?.+??? -     ??Name$  Viewer??$
??Auto=?$
??Left=?.????  ?? Orientation$ Vertical=?.+??? $ Vertical=?.+??? ?? -   .?作者博客?? $??3q??? ?? -   .?CnGame使用手册9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??通知??.???? $
??Wrap=?   	MiLanFont#??[  ????  ?? ElementName$ Viewer.Width?? 以后将在此处更新通知?? mkCVLAN的开发已经开始，将摒弃n2n内核，重新开发一套组网应用，更侧重于游戏联机?? ??我相信这将为玩家们对于稳定联机游戏的渴望有所贡献，该项目将遵循gnu协议开放源代码，任何人都可以在经过简单学习后部署属于自己的CVLAN服务器，如果对此项目感兴趣，可以移步到作者博客获取更详细的信息?? ??如果觉得此项目有价值且愿意帮助开发者，您可以访问我的博客赞助页面来赞助开发者（关于新应用的展望、Nyan n2n项目的重构也会在博客详细标注）?? ??如果链接显示404或无法进入该网页，请下次想起来的时候再来，因为Nyan n2n的发布与网页的维护不是同步的?? ?? -   .?点击赞助赞助?? ?? 
???  ??.?wu赞助开发者不代表赞助免费搭建联机服务器的CnGame维基，他们免费维护了n2n服务器的运行?? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??更新??.???? $
??12,0q?$
??Wrap=?#??[  ???? $ Viewer.Width??1.4.0.1 --- 2023/2/25?? 1 修改了免费节点?? ?? 1.4.0.0 --- 2023/2/24?? %#1 增加了连接状态消息提示?? a_2 增加了缓存连接信息的功能（下次打开时不用重新输入服务器地址等等?? ?? 1.3.0.1 --- 2023/2/7?? a_1 修改了主页，增设“更新”栏填写更新日志，今后更新日志在此处显示?? .,2 修改了主页，优化手册跳转按钮?? ?? 1.3.0.0 --- 2023/2/6?? ^\1 更新了按钮反馈，实时将n2n运行状态反馈到按钮上，优化使用体验；?? 1/2 添加了自定义选项，优化启动选项?? US3 优化日志显示，逻辑更改为：只在新的n2n连接创建时刷新日志?? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??注意??.???? $
??Wrap=?#??[  ???? $ Viewer.Width??MK验证连接还在开发，不能使用，目前仅展示了大概样式；?? ??参数设置中不同页面之间参数不同步，以启动时的页面为主（例如一个在a页面勾选了中转而b页面没有，但是是在a页面启动的所以 还是中转了的，解决方案已经想好了，鉴于工程量下一个版本再出?? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??代办??.???? $
??Wrap=?#??[  ???? $ Viewer.Width??86ping小工具；虚拟ip显示；自动更新客户端?? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??提示??.???? $
??Wrap=?#??[  ???? $ Viewer.Width????当显示authentication error时，应当是先前连接时的连接没有释放掉, 通俗来讲，就是位置还占着，需要断开一阵时间等待他释放连接（空出来位置），再去连接?? ??提示：当日志中提示tap not install之类字样时候，请确认先前安装过虚拟网卡没有, 如果确定安装过了，重启电脑；否则使用文件夹中的安装包安装一个虚拟网卡:按windows键搜索 控制面板，点击后点击网络->网络和internet->网络和共享中心->更改适配器设置?? WU看看有没有TAP-Windows Adapter字样的网卡，没有就是没装需要自己装?? 多看日志?? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??图标??.???? .+??? $
??Wrap=?#??[  ???? $ Viewer.Width????KLTN TECH（关于图标：这是一个耗时较长的工作，晚些时间（可能在数个月后）会正式更换图标相关内容?? $??3q??? $??../Images/Klu.jpg???? $??1q?
???????9? $??Stretch=?$"??./Fonts/#小米兰亭 Pro VF)?$??其他??.???? $
??Wrap=?#??[  ???? $ Viewer.Width??mkui布局将要调整，多个“连接按钮”影响了用户使用的便利性，仍在思考怎么改；?? mk如果遇到问题，请务必反馈到qq群631336782，这将帮助我改进软件以及找到开发方向?? ?? 
???  ??.???警告：该软件仅用于辅助使用n2n windows平台客户端以此优化局域网游戏联机体验，禁止用于违法犯罪活动！?? ?? 
???  ??.???警告：该软件仅用于辅助使用n2n windows平台客户端以此优化局域网游戏联机体验，禁止用于违法犯罪活动！?? ?? 
???  ??.???警告：该软件仅用于辅助使用n2n windows平台客户端以此优化局域网游戏联机体验，禁止用于违法犯罪活动！