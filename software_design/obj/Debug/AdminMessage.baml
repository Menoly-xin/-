   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	   "    software_design.AdminMessage   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  AdminMessage��5   	   $	��450��6   $	��800��6+   .��5	      � ���	#FFFFFEED.+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $
��DG12��5
         AutoGenerateColumns .  $��26,45,397.6,150q�6S    J� RenderTransformOrigin$ 0.628,0.501&�6l   ���	#FFF7F6EB$��Arial Black)�6�   $��16(�6�   ��6   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
UserCode+6O     5      $ 姓名��6%   $ 75 6O    62   �� *
UserName+6O     5      $ 性别��6%   $ 50 6M    61   �� *	UserSex+6M     5      $ 班级��6%   $ 80 6O    61   �� *	UserClass+6O   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 50 6�    65   �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   -   5        	 ��Name$	 Message��5      $
��Left=�6#   $	��140��6>   $��
26,270,0,0q�6K   
 �� TextWrapping$

 Wrap=�6_   $	��Top=�6s   $	��645��6�   ���	#FFFFE4E4$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ SendMessage��5      $��发送��6&   $
��Left=�63   $	��140��6N   $��671,270,0,0q�6[   $	��Top=�6p   $��98��6�    �� IsCancel . ���	#FFCECECE$��Arial Black)�6�   $��20(�6�   ��6�   Z�   5   
   -   5          Name$
 DG13��5       .  $��401,45,19.6,150q�6U   ���	#FFF4FCF4$��Arial Black)�6�   $��16(�6�   ��6!   �� ��6�   Z�  5        5      $ 	职工号��6%   $	 100 6P    62   �� *
UserCode+6P     5      $ 姓名��6%   $ 75 6O    62   �� *
UserName+6O     5      $ 性别��6%   $ 50 6M    61   �� *	UserSex+6M     5      $ 管理班级��6%   $ 80 6Q    63   �� *	UserClass+6Q     5      $ 选定��6)   $ 50 6�    65   �� *
UserSelect+$ TwoWay=�$ PropertyChanged=�6�   5      �� 5   
   $��学生��6   $
��Left=�6   $��35��68   $��	26,10,0,0q�6D   $	��Top=�6W   $	��370��6o   �� 5   
   $��教师��6   $
��Left=�6   $��35��68   $��
401,10,0,0q�6D   $	��Top=�6X   $	��368��6p   5!      5"      