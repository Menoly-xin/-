   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	       software_design.FileAdmin   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  	FileAdmin��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ Upload��5
      $��上传��6!   $
��Left=�6.   $��36��6I   $��
520,10,0,0q�6U   $	��Top=�6i   $��95��6�   ���	#FF7AF653$��16(�6�   ��6�   Z� �� 5   
   -   5        $ download��5      $��下载��6#   $
��Left=�60   $��36��6K   $��	615,9,0,0q�6W   $	��Top=�6j   $��95��6�   ���	#FF89F7DE$��16(�6�   ��6�   Z� &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	DG_FilStu��5         AutoGenerateColumns .  $��10,51,9.6,10q�6Z   ���	#FFFFFDF2$��Arial Black)�6�   $��14(�6�   ��6&   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	上传人��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
Uploader+6O     5      $ 	文件名��6%   $	 580 6Q    63   �� *	File_Name+6Q   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 70 6�    65   �� *
FileSelect+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   5      �� 5   
   $��
上传者:��6   $
��Left=�6   $��34��6:   $��	10,12,0,0q�6F   $	��Top=�6Y   $��65��6q   $��16(�6|   $��Arial Black)�6�   ���	#FFDCD7D76�   �� 5   
   -   5        $ 
SearchFile��5      $��查询��6%   $
��Left=�62   $��36��6M   $��
330,10,0,0q�6Y   $	��Top=�6m   $��95��6�   ���	#FFE0E0E0$��16(�6�   $��Arial Black)�6�   ��6�   Z� �� 5   
   -   5        
 ��Name$
 FileBox��5      $
��Left=�6#   $��34��6>   $��	80,12,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��245��6�   ���	#FFFFEAEA$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   �� 5   
   -   5        $��刷新��5      $
��Left=�6   $��36��69   $��	425,9,0,0q�6E   $	��Top=�6X   $��95��6p   ���	#FFEAE66B$��16(�6�   $��Arial Black)�6�    J� RenderTransformOrigin$ 0.487,0.391&�6�   ��6�   Z� 6�   �� 5   
   -   5        $ Delete��5      $��删除��6!   $
��Left=�6.   $��33��6I   $��
715,12,0,0q�6U   $	��Top=�6i   $��69��6�   ���	#FFF98F8F$��16(�6�   6�   5      5      