   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	        software_design.MessageTea   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  
MessageTea��5   	   $	��450��6   $	��800��6)   .��5	      � ���	#FFFFFAE4.+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $	��DG5��5
         AutoGenerateColumns .  $��25,10,24.6,130q�6R   ���	#FFFFFFF2$��Arial Black)�6�   $��14(�6�   
���������6   ��    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
UserCode+6O     5      $ 姓名��6%   $	 100 6O    62   �� *
UserName+6O     5      $ 性别��6%   $ 50 6M    61   �� *	UserSex+6M     5      $ 班级��6%   $	 150 6O    61   �� *	UserClass+6O     5      $ 邮箱��6%   $	 200 6O    61   �� *	UserEmail+6O   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 90 6�    65   �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   -   5         ��Name$ Message��5      $
��Left=�6#   $	��115��6>   $��
25,295,0,0q�6K   	 �� TextWrapping$
	 Wrap=�6_   $	��Top=�6s   $	��664��6�   $��Arial Black)�6�   $��16(�6�   ���	#FFE3FFE0��6�   Z� �� 5   
   -   5        
 ��Name$
 SendMessage��5      $��发送��6&   $
��Left=�63   $	��115��6N   $��694,295,0,0q�6[   $	��Top=�6p   $��75��6�    �� IsCancel . ���	#FFEEFFFD$��Arial Black)�6�   $��20(�6�   ��6�   Z� 5      5      