   M S B A M L   `   `   `  ???? C  ?Nyan n2n, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Nyan_n2n.ExtensionsNyan_n2n.Extensions  /clr-namespace:Nyan_n2n.ViewsNyan_n2n.Views      Nyan_n2n.Views.MainView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    _ [MaterialDesignThemes.Wpf, Version=4.7.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  :d2http://schemas.microsoft.com/expression/blend/2008  R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     T PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59[ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/   _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  +ext!clr-namespace:Nyan_n2n.Extensions  (localclr-namespace:Nyan_n2n.Views     MaterialDesignBody#???   $??Regular"?$??13(?&   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=?   TextRenderingMode$
 Auto=?  MaterialDesignPaper#???    MaterialDesignFont#???   ? Title$
 Nyan??$	??450??$	??700?? ? AllowsTransparency .  ? WindowStyle$
 None=? ? WindowStartupLocation$ CenterScreen=?.??)  #MaterialDesignThemes.Wpf.DialogHost     DialogTheme$ Inherit=?   
Identifier$ 
RootDialog??   SnackbarMessageQueue ?? 	 ?? ElementName$	 MainSnackbar??
 ?? Path$
 MessageQueue?.??)  #MaterialDesignThemes.Wpf.DrawerHost  -     Name$ 
drawerHost??   IsLeftDrawerOpen ?? $	 MenuToggleButton??$
 	IsChecked?   LeftDrawerContent ]? $	??150??.+??? -    ??Name$ menuBar??  NyanListBoxItem#??[ ???? *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers +  %Microsoft.Xaml.Behaviors.EventTrigger     	EventName$ SelectionChanged??*  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command ?? *NavigateCommand+   CommandParameter ?? $	 menuBar??$
 SelectedItem????? .R??? 
??????  ?? Orientation$ 
Horizontal=?$??30??.+?'  !MaterialDesignThemes.Wpf.PackIcon  $??17,15q?   Kind ?? *Icon+?? $??-2,15q?  	MiLanFont#??[ ???? *Title+.???  ? RowDefinitions ?? ?? $
??Auto ?.+?]? $??0??.+?(	  "MaterialDesignThemes.Wpf.ColorZone	  -    	 Name$ 	guideLine??$??16q?.
  (MaterialDesignThemes.Wpf.ElevationAssist 
  	Elevation$	 Dp4=?$	??Top=? 	  Mode$ 
PrimaryMid=?.??]? ??. .+??? $??Right=?$ 
Horizontal=?.+??? -    ??Name$ btnMin??$	??—??$??17(? ! MaterialDesignFlatMidBgButton#??[ ?? -   $ btnMax??$	??☐??$??17(?#??[ ?? -   $ btnClose??$	??✕??$??17(?#??[ ?? $ 
Horizontal=?.+?d? -    d?Name$ MenuToggleButton??4  .System.Windows.Automation.AutomationProperties   Name$ HamburgerToggleButton?? d? 	IsChecked$ FalseY? ' #MaterialDesignHamburgerToggleButton#??[ ?? $??80,0,0,0q?$
??Left=?$??Center=?$ Nyan n2n??$??20(?$??Nyan n2n???? &    Nyan_n2n.Extensions.PrismManager   MainViewRegionName!  Prism.Regions.RegionManager   
RegionName# Z '  !MaterialDesignThemes.Wpf.Snackbar  -      Name$  Snackbar??!   MessageQueue! ?? *
Snackbar+