   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	   !    software_design.ManageClass   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  ManageClass��5   	   $	��450��6   $	��800��6*   .��5	      � ���	#FFFAF8D4.+�5
   
   �� -   5        $��查看问题��5
      $
��Left=�6    $��78��6;   $��
608,55,0,0q�6G   $	��Top=�6[   $	��136��6s   ���	#FFF1FCDD$��20(�6�   $��Arial Black)�6�   ��6�   Z� �� 5   
   -   5         ��Name$ MessageSend��5      $��消息��6&   $��85��63   $��608,138,49.6,0q�6?   $	��Top=�6W   ���	#FFD0FA88$��20(�6�   $��Arial Black)�6�   ��6�   Z� �� 5   
   -   5        $��文件��5      $
��Left=�6   $��84��69   $��608,228,0,0q�6E   $	��Top=�6Z   $	��136��6r   ���	#FFEAF9D1$��20(�6�   $��Arial Black)�6�   ��6�   Z� �� 5   
   -   5        $ Growth��5      $��学生成长档案��6!   $
��Left=�62   $��37��6M   $��	608,8,0,0q�6Y   $	��Top=�6l   $	��136��6�   $��Arial Black)�6�   $��16(�6�   ���	#FFE4E4E4��6�   Z� &   System.Windows.Controls.DataGrid  5   
   -   5        $	��DG3��5         AutoGenerateColumns .  $��51,50,190.6,10q�6R   ���	#FFFFFDED$��Arial Black)�6�   $��14(�6�   ��6   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
UserCode+6O     5      $ 姓名��6%   $	 100 6O    62   �� *
UserName+6O     5      $ 性别��6%   $ 80 6M    61   �� *	UserSex+6M     5      $ 班级��6%   $	 100 6O    61   �� *	UserClass+6O     5      $ 邮箱��6%   $	 100 6O    61   �� *	UserEmail+6O   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 60 6�    65   �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   $��班 级 管 理��6   $
��Left=�6"   $��35��6=   $��	51,10,0,0q�6I   $	��Top=�6\   $	��323��6t   	 J� RenderTransformOrigin$	 0.977,0.651&�6�   $��16(�6�   ���	#FFF6E7E7$��Arial Black)�6�   �� 5   
   -   5        $��删除��5      $
��Left=�6   $��37��69   $��	379,8,0,0q�6E   $	��Top=�6X   $	��108��6p   ���	#FFEBE9E9$��16(�6�   $��Arial Black)�6�   ��6�   Z� �� 5   
   -   5        $ 
RefreshStu��5      $��刷新��6%   $
��Left=�62   $��37��6M   $��	492,8,0,0q�6Y   $	��Top=�6l   $	��111��6�   $��Arial Black)�6�   $��16(�6�   ���	#FFE3E0FD��6�   Z� �� 5   
   -   5        $��设置提醒��5      $
��Left=�6    $��93��6;   $��608,317,0,0q�6G   $	��Top=�6\   $	��136��6t   ���	#FFFCE6DC$��20(�6�   $��Arial Black)�6�   ��6�   Z� 5      5      