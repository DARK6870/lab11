   M S B A M L   `   `   `  ����@  <lab11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:lab11.WindowsCRUDlab11.WindowsCRUD  5   	   d `Microsoft.Web.WebView2.Wpf, Version=1.0.864.35, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf 5      $    lab11.WindowsCRUD.CategoryCRUD   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:lab11.WindowsCRUD     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      VWpfLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf  5         MaterialDesignBody#���   5
      $��Regular"�5      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ CategoryCRUD��5   	   $	��450��6   $	��400��6+    � 
ResizeMode$ CanMinimize=�67   .��5      � .+�5   
   �� $��Edit Category��6   $��Center=�6(   $��0,30,0,0q�6E   $	��Top=�6W   $��18(�6o   �� 5   
   -   5         ��Name$ Category_tb��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ CategoryName��6'      
IsFloating$
 True��6U   $��Center=�6�   $��	0,100,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��250��6�   $��16(�6�   �� 5   
   -   5         ��Name$ Save_changes_btn��5      $��Save changes��6J   $
��Left=�6a   $��
75,185,0,0q�6|   $	��Top=�6�   $	��182��6�   �� 5   
   -   5        $ 
Delete_btn��5      $
��Left=�6>   $��277,222,0,0q�6Y   $	��Top=�6n   ���	#FFB7453A���	#FFC74949.��5      '  !MaterialDesignThemes.Wpf.PackIcon  	   Kind$	 Delete=�6&   5      �� 5   
   -   5        $ NewRecord_btn��5      $
��Left=�6D   $��277,185,0,0q�6_   $	��Top=�6t   ���	#FF3D87CC���	#FF004D88.��5        $
	 Plus=�6&   5      5      5      