   M S B A M L   `   `   `  ����  HivTreatmentAppWPF/    )HivTreatmentAppWPF.Doctor.RegimenListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� 
Background  �#F5F6FA.��5
      �� $
��Auto=�6   .��5   
   � $��40q�6   .+�5      �� 
������� �� Padding$ 40q�5       �� CornerRadius$ 12��5      ���#E0E0E0$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 6��5      $ 10q�5      $��0 0 0 30q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��💊��6(   $��28(�62   $��0 5 10 0q�6@   �� 5      $*��$Danh sách phác đồ điều trị��6(   $��24(�5   (   $
��Bold"�5   (   
�������5   (   5       5!      �� 5$      $ 
Horizontal=�6!   $��0 0 0 20q�6:   .+�5%      �� $��Tìm kiếm:��6$   $��Center=�5&   $   $
��Bold"�5'   $   $��0 0 10 0q�5(   $   �� 5)      -   5         ��Name$ SearchTextBox��5)   "   $	��300��5*   "   $��28��5+   "   $��5q�5,   "   $��Center=�5-   "   5.   "   5/      &   System.Windows.Controls.DataGrid  52      -   5          Name$ RegimenDataGrid��52         AutoGenerateColumns$ False��53         
IsReadOnly$
 True��54      	   HeadersVisibility$	 Column=�55      $��0q�56      $��14(�57      
   RowBackground

 �����   AlternatingRowBackground �#F9F9F9   GridLinesVisibility$
 None=�5:      $��1q�5;      ���#E0E0E0   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5=         SelectionMode$ Single=�5>         Columns 5@      0  *System.Windows.Controls.DataGridTextColumn  5A      ,  &System.Windows.Controls.DataGridColumn   Header$ Tên phác đồ��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6L   �� *RegimenName+  5B      $ Thành phần��61    6L   �� *
Components+  5C      $ Chỉ định��61    6L   �� *Indications+  5D      $ Chống chỉ định��61    6L   �� *Contraindications+  5E      $ Mô tả��61    6L   �� *Description+5G      �� 5J      $ 
Horizontal=�6!   $��Right=�6:   $��0 25 0 0q�6V   .+�5K      �� -   5        $��Thêm��5K   !   $	��120��5L   !   $��40��6-   $��5q�69     NavButtonStyle#��[ 5M   !   5N   !   �� 5O      -   5        $
��Xoá��5O   !   $	��120��5P   !   $��40��6-   $��5q�69     DangerButtonStyle#��[ 5Q   !   5R   !   5S      5U      5V      5W      5X      5Y      