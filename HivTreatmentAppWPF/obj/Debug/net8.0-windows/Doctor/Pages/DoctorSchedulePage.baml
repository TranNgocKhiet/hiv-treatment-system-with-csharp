   M S B A M L   `   `   `  ����  HivTreatmentAppWPF2    ,HivTreatmentAppWPF.Doctor.DoctorSchedulePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  DoctorSchedulePage��5       N� 
Background �#F5F6FA.��5      �� $
��Auto=�6   .��5   
   � $��40q�6   .+�5      �� 
������� �� Padding$ 40q�5       �� CornerRadius$ 12��5      ���#E0E0E0$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 6��5      $ 10q�5      $��0 0 0 30q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��📅��6(   $��28(�5   (   $��0 5 10 0q�5   (   �� 5      $#��Lịch làm việc của tôi��6(   $��24(�5    (   $
��Bold"�5!   (   
�������$��Center=�5#   (   5$      5%      �� 5(      $ 
Horizontal=�6!   $��0 0 0 20q�6:   .+�5)      �� $$��Tìm kiếm tên bệnh nhân:��6$   $��Center=�5*   $   $
��Bold"�5+   $   $��0 0 10 0q�5,   $   �� 5-      -   5         ��Name$ SearchTextBox��5-   "   $	��300��5.   "   $��28��5/   "   $��5q�50   "   $��Center=�51   "   52   "   53      &   System.Windows.Controls.DataGrid  56      -   5          Name$ ScheduleDataGrid��56         AutoGenerateColumns$ False��57      	   
IsReadOnly$
	 True��58      
   HeadersVisibility$
 Column=�59      $��0q�5:      $��14(�5;         RowBackground
 �����   AlternatingRowBackground �#F9F9F9   GridLinesVisibility$
 None=�5>      $��1q�5?      ���#E0E0E0   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5A      ��5B      ��    Columns 5D      0  *System.Windows.Controls.DataGridTextColumn  5E      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã phòng khám��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
RoomCode+  5F      $ Ngày��61    6?   �� *Date+ �� StringFormat$ d��  5G      $ Ca��61    6=   �� *Slot+  5H      $ Bệnh nhân��61    6D   �� *PatientName+4  .System.Windows.Controls.DataGridTemplateColumn  5J      $! Trạng thái điều trị��65      CellTemplate 5K   "   �� 5L   &   .R�5M   *   �� $ 4��61   $ 4q�6B   $��2q�6N   ._�5N   .   �� $
��Bold"�5O   8   $��Center=�5P   8   ��5N   8   �� *TreatmentStatus+5P   8   ��5Q   .   �� 5R   2    �� 
TargetType" ��68   .�5S   6   ��  �� Property � �� �� Value
 �����6S    �� Triggers 5T   6   �� 5U   :    �� Binding 6F   �� *TreatmentStatus+ �� Value Chờ khám6j   .a�5V   >   ��  � ��
 � ���6[   5W   ;   �� 5X   :    6F   �� *TreatmentStatus+ 
Đã khám6j   .a�5Y   >   ��  � ��
 ����6[   5Z   ;   �� 5[   :    6F   �� *TreatmentStatus+ Đã tư vấn6j   .a�5\   >   ��  � ��
 ����6[   5]   ;   �� 5^   :    6F   �� *TreatmentStatus+ Không đến6j   .a�5_   >   ��  � ��
 �����6[   5`   ;   5b   3   5d   +   5e   '   5g      5i      5j      5k      5l      5m      5n      