   M S B A M L   `   `   `  ���� J  Fsoftware_design, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:software_designsoftware_design      software_design.FileStu   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:software_design       � Title$  FileStu��$	��450��$	��800��.��� -    �Name$ Refresh��.+��� -    ��Name$ Upload��$��上传��$
��Left=�$��56��$��
589,98,0,0q�$	��Top=�$	��129���� -   $ download��$��下载��$
��Left=�$��64��$��589,225,0,0q�$	��Top=�$	��129��&   System.Windows.Controls.DataGrid  -   $��	DG_FilStu��   AutoGenerateColumns .  $��10,51,339.6,69q�����    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 	上传人��   Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *
Uploader+  $ 	文件名��$	 250  �� *	File_Name+4  .System.Windows.Controls.DataGridCheckBoxColumn  $ 选定��$ 50  �� *
FileSelect+ �� Mode$ TwoWay=�	 �� UpdateSourceTrigger$	 PropertyChanged=��� $��
上传人:��$
��Left=�$��36��$��	10,10,0,0q�$	��Top=�$��65���� -   $ 
SearchFile��$��查询��$
��Left=�$��21��$��
312,12,0,0q�$	��Top=�$��76���� -   
 ��Name$
 FileBox��$
��Left=�$��21��$��
110,12,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��165���� -   $��刷新��$
��Left=�$��21��$��
410,12,0,0q�$	��Top=�$��70��