   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	   $    software_design.QuestionWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  QuestionWindow��5   	   $	��450��6    $	��800��6-   ���	#FFFCFFD5���	#FFFFFDDD���	#FFF7F3D0.��5	      � ���	#FFFCFBE8.+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $	��DG1��5
         AutoGenerateColumns .  $��10,10,9.6,69q�6R   ���	#FFFDFFF1$��Arial Black)�6�   $��14(�6�   ��6   �� ��6   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 状态��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6<   �� *Status+4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 问题��6)   $	 400 65      CellTemplate 5      �� 5      .R�5      �� $
��Wrap=�6(   ��6<   �� *
Question+ ^� ToolTip 6V   �� *
Question+5      5        5      $ 答案��6)   $	 350 65    5      �� 5      .R�5      �� $
��Wrap=�6(   ��6<   �� *Answer+ 6T   �� *Answer+5      5      5      �� 5   
   -   5         ��Name$ QuestionBox��5      $
��Left=�6'   $��54��6B   $��
10,356,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6b   $	��Top=�6v   $	��520��6�   ���	#FFEDFFEE$��Arial Black)�6�   ��6�   Z� 6�   �� 5   
   -   5        
 ��Name$
 
UploadQues��5      $��提交问题��6%   $
��Left=�64   $��54��6O   $��535,356,0,0q�6[   $	��Top=�6p   $	��150��6�   ���	#FFFFFCE8$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   �� 5    
   -   5        $��刷新��5       $
��Left=�6   $��54��69   $��690,356,0,0q�6E   $	��Top=�6Z   $��94��6r   ���	#FFFDF4FF$��Arial Black)�6�   $��16(�6�   ��6�   Z� 5"      5#      