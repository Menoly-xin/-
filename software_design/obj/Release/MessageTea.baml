   M S B A M L   `   `   `  ���� J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design       software_design.MessageTea   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:software_design       � Title$  
MessageTea��$	��450��$	��800��.��� .+�&   System.Windows.Controls.DataGrid  -   $	��DG5��   AutoGenerateColumns .  $��10,10,231.6,185q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 学号��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
UserCode+  $ 姓名��$ 50  �� *
UserName+  $ 性别��$	 100  �� *	UserSex+  $ 班级��$	 100  �� *	UserClass+  $ 邮箱��$	 150  �� *	UserEmail+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 选定��$ 50  �� *
UserSelect+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -    ��Name$ Message��$
��Left=�$	��157��$��
13,253,0,0q�	 �� TextWrapping$
	 Wrap=�$	��Top=�$	��549���� -   
 ��Name$
 SendMessage��$��发送��$
��Left=�$��43��$��604,342,0,0q�$	��Top=�$	��142�� �� IsCancel . 