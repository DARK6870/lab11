   M S B A M L   `   `   `  ����@  <lab11, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab11lab11  5   	       lab11.MainWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:lab11     5   	   _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	      MaterialDesignBody#���   5	      $��Regular"�5
      $��13(�5      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5       � Title$ 
MainWindow��5   	   $	��700��6   $
��1200��6)   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
myDataGrid��5   {      
IsReadOnly$
 True��6      SelectionMode$ Extended=�6%   $��16(�6>   $��	0,110,0,0q�6�   �� 5   
   -   5         ��Name$ table_cb��5      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Select table��6%      
IsFloating$
 True��6S   $
��Left=�6   $��	21,16,0,0q�6�   $	��Top=�6�   $	��177��6�   $��16(�6�   .@�5      �� $��Products��6   �� 5      $��Orders��6   �� 5      $��Status��6   �� 5      $��Category��6   �� 5      $��Users��6   5      �� 5   
   -   5        	 ��Name$	 edit_btn��5      $��Right=�6:   $��	0,70,30,0q�6V   $	��Top=�6i   ���	#FFC78F3D���	#FFD4964A.��5      '  !MaterialDesignThemes.Wpf.PackIcon  
   Kind$

 Edit=�6&   5      �� 5   
   -   5        $	 NewRecord_btn��5      $��Right=�6D   $��	0,70,90,0q�6`   $	��Top=�6s   ���	#FF056DA4���	#FF035990.��5        $

 Plus=�6&   5       �� 5!   
   -   5         ��Name$ 	search_tb��5!      $ Search��6I   $
 True��6q   $��Right=�6�   $��	0,15,30,0q�6�    �� TextWrapping$
 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��221��6   $��16(�6  5#      5$      