   M S B A M L   `   `   `  ����J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  5   	   !    software_design.AdminQueAns   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:software_design     5   	     � Title$  AdminQueAns��5   	   $	��450��6   $	��800��6*   ���	#FFFCFDDF���	#FFFFFEED.��5	      � ��5
   
   �� 5       �� ImageSource$ timg.png��6    �� Opacity$	 0.3Q�60   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $
��DG11��5         AutoGenerateColumns .  $��10,10,9.6,69q�6S   ���	#FFFCF9ED$��Arial Black)�6�   $��14(�6�   ��6   �� ��6�   Z�    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 状态��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	TeaStatus+6O     5      $ 班级��6%   $ 70 6O    61   �� *	ClassName+6O     5      $ 	提问者��6%   $ 80 6O    63   �� *	TeaName+6O   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ 问题��6)   $	 250 65      CellTemplate 5      �� 5      .R�5      �� $
��Wrap=�6(   ��6<   �� *TeaQuestion+	 ^� ToolTip	 6Y   �� *TeaQuestion+5      5        5      $ 答案��6)   $	 255 65    5      �� 5      .R�5      �� $
��Wrap=�6(   ��6<   �� *	TeaAnswer+	 6W   �� *	TeaAnswer+5      5      4  .System.Windows.Controls.DataGridCheckBoxColumn  5       $ 提醒答疑��6)   $ 65 6�    67   �� *TeaSelectQues+
 �� Mode$
 TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   5"      �� 5#   
   $��日问题量��6   $
��Left=�6   $��42��6:   $��
10,356,0,0q�6F   $	��Top=�6Z   $��97��6r   $��Arial Black)�6}   $��20(�6�   ���	#FFF0E2E26�   �� 5$   
   -   5         ��Name$ DayQueTotal��5$      $�� ��6%   $
��Left=�60   $��42��6K   $��112,356,0,0q�6W   $	��Top=�6l   $	��240��6�   ���	#FFFFFEDD$��Arial Black)�6�   $��16(�6�   �� 5%   
   $��	答疑率��6   $
��Left=�6   $��42��69   $��357,356,0,0q�6E   $	��Top=�6Z   $��75��6r    J� RenderTransformOrigin$ 
0.54,0.117&�6}   $��Arial Black)�6�   $��20(�6�   ���	#FFDDF9FC6�   �� 5&   
   -   5        $ AnsRate��5&      $�� ��6!   $
��Left=�6,   $��42��6G   $��437,356,0,0q�6S   $	��Top=�6h   $	��189��6�   ���	#FFCDFAC9$��Arial Black)�6�   $��16(�6�   �� 5'   
   -   5        $��发送提醒��5'      $
��Left=�6    $��42��6;   $��631,356,0,0q�6G   $	��Top=�6\   $	��153��6t   ���	#FFEDEDED$��Arial Black)�6�   $��20(�6�   ��6�   Z� 6�   5(      5)      