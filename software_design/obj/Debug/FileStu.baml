   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	       software_design.FileStu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  FileStu��5   	   $	��450��6   $	��800��6&   .��5	      � -   5         �Name$ Refresh��5	      ���	#FFFFFEF2.+�5
   
   �� -   5         ��Name$ Upload��5
      $��上传��6!   $
��Left=�6.   $��31��6I   $��
572,15,0,0q�6U   $	��Top=�6i   $	��106��6�   ���	#FFB6FFFE$��16(�6�   ���	#FFFFFFC86�   �� 5   
   -   5        $ download��5      $��下载��6#   $
��Left=�60   $��31��6K   $��
683,15,0,0q�6W   $	��Top=�6k   $	��101��6�   ���	#FF7F7EAD$��16(�6�   ���	#FFFFFFC86�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	DG_FilStu��5         AutoGenerateColumns .  $��10,51,9.6,10q�6X   ���	#FFFFFEEB���	#FFFFFFC8$��Arial Black)�6�   $��14(�6�   ��6$   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	上传人��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
Uploader+6O     5      $ 	文件名��6%   $	 580 6Q    63   �� *	File_Name+6Q   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 70 6�    65   �� *
FileSelect+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=�6�   5      �� 5   
   $��
上传人:��6   $
��Left=�6   $��31��6:   $��	10,15,0,0q�6F   $	��Top=�6Y   $��60��6q   $��16(�6|   ���	#FFE2E2E2���	#FFFFFFC86�   �� 5   
   -   5        $ 
SearchFile��5      $��查询��6%   $
��Left=�62   $��29��6M   $��
323,17,0,0q�6Y   $	��Top=�6m   $	��124��6�   ���	#FFFFEEB9$��16(�6�   ���	#FFFFFFC86�   �� 5   
   -   5        
 ��Name$
 FileBox��5      $
��Left=�6#   $��31��6>   $��	75,15,0,0q�6J    �� TextWrapping$
 Wrap=�6]   $	��Top=�6q   $	��243��6�   ���	#FFFFEDED���	#FFFFFFC8$��Arial Black)�6�   $��16(�6�   �� 5   
   -   5        $��刷新��5      $
��Left=�6   $��29��69   $��
452,17,0,0q�6E   $	��Top=�6Y   $	��115��6q   ���	#FFCCFDB9$��16(�6�   ���	#FFFFFFC86�   5      5      