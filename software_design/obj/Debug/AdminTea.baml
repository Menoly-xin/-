   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	       software_design.AdminTea   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  AdminTea��5   	   $	��450��6   $	��800��6'   .��5	      � ���	#FFFEFFE0.+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $
��DG10��5
         AutoGenerateColumns .  $��10,50,9.6,10q�6S   ���	#FFF9F3EE$��Arial Black)�6�   $��16(�6�   ��6   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 	职工号��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 62   �� *
UserCode+6P     5      $ 姓名��6%   $	 100 6O    62   �� *
UserName+6O     5      $ 性别��6%   $	 100 6M    61   �� *	UserSex+6M     5      $ 管理班级��6%   $	 150 6Q    63   �� *	UserClass+6Q     5      $ 邮箱��6%   $	 200 6O    61   �� *	UserEmail+6O   4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 选定��6)   $ 75 6�    65   �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5      �� 5   
   -   5         ��Name$ Delete��5      $��删除��6!   $
��Left=�6.   $��31��6I   $��	10,14,0,0q�6U   $	��Top=�6h   $	��181��6�   ���	#FFFF94EC	 J� RenderTransformOrigin$	 0.675,0.517&�6�   $��16(�6�   $��Arial Black)�6  ��6�   Z� 6  �� 5   
   -   5        $ 
RefreshStu��5      $��刷新��6%   $
��Left=�62   $��31��6M   $��
196,14,0,0q�6Y   $	��Top=�6m   $	��200��6�   ���	#FFF492CE$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   �� 5   
   -   5        $��信息修改��5      $
��Left=�6    $��31��6;   $��
603,14,0,0q�6G   $	��Top=�6[   $	��181��6s   ���	#FF98F78A$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   �� 5   
   -   5        $��添加账户��5      $
��Left=�6    $��31��6;   $��
401,14,0,0q�6G   $	��Top=�6[   $	��197��6s   ���	#FFCEBFC9$��Arial Black)�6�   $��16(�6�   ��6�   Z� 6�   5      5      