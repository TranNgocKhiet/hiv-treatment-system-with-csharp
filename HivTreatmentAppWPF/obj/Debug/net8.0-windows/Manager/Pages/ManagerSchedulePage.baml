   M S B A M L   `   `   `  ����  HivTreatmentAppWPF4    .HivTreatmentAppWPF.Manager.ManagerSchedulePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ManagerSchedule��5       N� 
Background �#F5F6FA.��5      �� $
��Auto=�6   .��5   
   � $��40q�6   .+�5      �� 
������� �� Padding$ 40q�5       �� CornerRadius$ 12��5      ���#E0E0E0$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 6��5      $ 10q�5      $��0 0 0 30q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��📋��6(   $��28(�5   (   $��0 5 10 0q�5   (   �� 5      $+��%Bảng phân công lịch làm việc��6(   $��24(�5    (   $
��Bold"�5!   (   
�������$��Center=�5#   (   5$      5%      �� 5(      $ 
Horizontal=�6!   $��0 0 0 10q�6:   .+�5)      �� $ ��Tìm kiếm tên bác sĩ:��6$   $��Center=�5*   $   $
��Bold"�5+   $   $��0 0 8 0q�5,   $   �� 5-      -   5         ��Name$ 	SearchBox��5-   "   $	��300��5.   !   $��28��5/   !   $��5q�50   !   $��Center=�51   !   52   !   53      &   System.Windows.Controls.DataGrid  56      -   5          Name$ ScheduleDataGrid��56         AutoGenerateColumns$ False��57      	   
IsReadOnly$
	 True��58      
   HeadersVisibility$
 Column=�59      $��0q�5:      $��14(�5;         RowBackground
 �����   AlternatingRowBackground �#F9F9F9   GridLinesVisibility$
 None=�5>      $��1q�5?      ���#E0E0E0   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5A      ��5B      ��    Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã phòng khám��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
RoomCode+  5F      $ Ngày��61    6?   �� *Date+ �� StringFormat$ {0:dd/MM/yyyy}��  5G      $ Ca��61    6=   �� *
SlotString+  5H      $ Bác sĩ��61    6A   �� *
DoctorName+5J      �� 5M      $ 
Horizontal=�6!   $��Right=�6:   $��0 20 0 0q�6V   .+�5N      �� -   5        $��Tạo��5N   !     NavButtonStyle#��[ 5O   !   5P   !   �� 5R      -   5        $
��Xóa��5R   !     DangerButtonStyle#��[ 5S   !   5T   !   5U      5W      5X      5Y      5Z      5[      