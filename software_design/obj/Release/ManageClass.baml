   M S B A M L   `   `   `  ���� J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design  !    software_design.ManageClass   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:software_design       � Title$  ManageClass��$	��450��$	��800��.��� .+��� -   $��查看问题��$
��Left=�$��35��$��
602,50,0,0q�$	��Top=�$	��142���� -    ��Name$ MessageSend��$��消息��$
��Left=�$��32��$��602,135,0,0q�$	��Top=�$	��142���� -   $��文件��$
��Left=�$��29��$��602,205,0,0q�$	��Top=�$	��142���� -   $ Growth��$��学生成长档案��$
��Left=�$��33��$��602,270,0,0q�$	��Top=�$	��142��&   System.Windows.Controls.DataGrid  -   $	��DG3��   AutoGenerateColumns .  $��10,50,231.6,10q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
UserCode+  $ 姓名��$ 50  �� *
UserName+  $ 性别��$	 100  �� *	UserSex+  $ 班级��$	 100  �� *	UserClass+  $ 邮箱��$	 150  �� *	UserEmail+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 选定��$ 50  �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   	 ��Name$	 	NameSeach��$
��Left=�$��21��$��	73,14,0,0q�
 �� TextWrapping$

 Wrap=�$	��Top=�$	��168���� $��姓名:��$
��Left=�$��35��$��	10,10,0,0q�$	��Top=�$��58���� -   $ Seach��$��查询��$
��Left=�$��21��$��
264,14,0,0q�$	��Top=�$��53���� -   $��删除��$
��Left=�$��21��$��
334,14,0,0q�$	��Top=�$��48���� -	   $ 
RefreshStu��$��刷新��$
��Left=�$��21��$��
405,14,0,0q�$	��Top=�$��41��