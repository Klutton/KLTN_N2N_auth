   M S B A M L   `   `   `  ????C  ?Nyan n2n, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Nyan_n2n.ViewsNyan_n2n.Views  5           Nyan_n2n.Views.AuthConView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      (localclr-namespace:Nyan_n2n.Views  5      .??5
      ? $??30,10q?6     ? RowDefinitions  5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6    ? ColumnDefinitions 5   
   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   ?? 5      $
??Auto ?6   .+?5   
   ?? $??0??6   $??0??6!   $'??!通过服务器自动获取节点??61      	MiLanFont#??[  6D   $??28(?6g   ?? 5   
   $??1??6   $??0??6"   $??20,20q?62   .+?5      ?? -   5         ??Name$ 
ServerAddr??5      $
??0,10q?5      $	??250??5        MaterialDesignFilledTextBox#??[ 5      $"??./Fonts/#小米兰亭 Pro VF)?5      $??13(?5       )  #MaterialDesignThemes.Wpf.HintAssist   Hint$, &主服务器域名或ip（含端口）??5!      ?? 5#      -   5        $ Username??5&      $??	0,30,0,10q?5$      $	??250??5%      #??[ 5'      $"??./Fonts/#小米兰亭 Pro VF)?5(      $??13(?5)      $ 账号??5*      G? 5,      -   5         G?Name$ Password??5/      $??	0,10,0,50q?5-      $	??250??5.      $"??./Fonts/#小米兰亭 Pro VF)?50      $??13(?51       ) %MaterialDesignFilledRevealPasswordBox#??[ 52      $ 密码??53      ?? 55      -   5        $??0,0,30,0q?56      $??70??57      $??30??58      $??14(?5:      +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 5??5;      $??Microsoft YaHei UI)?6>   .??5<      ?? $??连接??6   5=      5>      ?? 5@   
   $??1??6   $
??20,0q?6   $??1??6,   $??1q?6<   
??????? J? Opacity$	 0.4Q?6k   ?? 5C   
   $??1??6   $??2??6"   $
??20,0q?62    ?? Orientation$ Vertical=?6@   .+?5E      ?? $	??0,3q?6   $ 
Horizontal=?6&   .+?5F      ?? #??[  6   $??状态:??6?   ?? 5G      $??5q?6   ?? 5H      #??[  6   $??已连接（占位符）??6?   
??? ? ?6O   5I      ?? 5K      $	??0,3q?6   $ 
Horizontal=?6&   .+?5L      ?? #??[  6   $??
服务器:??6?   ?? 5M      $??5q?6   ?? 5N      #??[  6   $??Kltn-Tech（占位符）??6?   
??? ? ?6U   5O      ?? 5Q      $	??0,3q?6   $ 
Horizontal=?6&   .+?5R      ?? #??[  6   $??服务器信息:??6?   ?? 5S      $??5q?6   ?? 5T      #??[  6   $*??$欢迎使用Kltn-Tech（占位符）??6?   
??? ? ?6Y   5U      ?? 5W      $??10q?6   ?? 5Z      $
??0,10q?6   #??[  6&   $??可用节点：??6I   ]? 5[      $	??300??6   $	??150??6'   .+?5\      ?? $	??150??5^        MaterialDesignListBox#??[ 5_      {?5]      ?? *	IsChecked+ ?? ElementName$ EnableListBox??	 ? 	Resources	 5`      
 ?? 
TargetType " MaterialDesignScrollBarMinimal ?? BasedOn??%0   '??       7  ?? 5a      "
 ??6   8   63   5b      .@?5c      ?? #??[  6    $??Plain??6C   ?? 5d      #??[  6    $??Plain??6C   ?? 5e      #??[  6    $??Plain??6C   ?? 5f      #??[  6    $??Plain??6C   ?? 5g      #??[  6    $??Plain??6C   ?? 5h      #??[  6    $??Plain??6C   ?? 5i      #??[  6    $??Plain??6C   5j      5k      ?? 5n      $??30,10q?6   $ 
Horizontal=?6(   .+?5o      ?? -   5        $
??10,0q?5p      $??70??5q      $??30??5r      $ 5??5t      .??5u      ?? $??启动??6    5v      ?? 5w      -   5        $
??10,0q?5x      $??70??5y      $??30??5z       " MaterialDesignFlatDarkBgButton#??[ 5|      $ 5??5}      .??5~      ?? $??停止??6    5      5?      5?      5?      5?      