   M S B A M L   `   `   `  ����  HivTreatmentAppWPFA    ;HivTreatmentAppWPF.LabTechnician.Pages.HealthRecordListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$1  +Danh sách bệnh nhân cần xét nghiệm��5      .��5      �� $
��Auto=�6   .��5   
   � ���#F5F7FA.+�5      �� 
������� �� Padding$ 30q�5	       �� CornerRadius$ 12��5
      ���#DDD$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 8��5      $ 12q�5      $��0 0 0 20q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��📋��6(   $��18(�5   (   $��0 0 8 0q�5   (   �� 5      $1��+Danh sách bệnh nhân cần xét nghiệm��6(   
�������$
��Bold"�5   (   $��18(�5   (   5      5      �� 5!      $ 
Horizontal=�6!   $��0 0 0 10q�6:   .+�5"      �� $$��Tìm kiếm tên bệnh nhân:��6$   $��Center=�5#   $   $
��Bold"�5$   $   $��0 0 8 0q�5%   $   �� 5&      -   5         ��Name$ SearchTextBox��5&   "   $	��300��5'   "   $��28��5(   "   $��5q�5)   "   $��Center=�5*   "   5+   "   5,      &   System.Windows.Controls.DataGrid  5/      -   5          Name$ PatientDataGrid��5/         AutoGenerateColumns$ False��50         
IsReadOnly$
 True��51      $��14(�52      	   SelectionMode$	 Single=�53      
   AlternatingRowBackground
 �#F9F9F9   RowBackground
 ��������#E0E0E0$��1q�57         HeadersVisibility$ Column=�58         ColumnHeaderHeight$ 32Q�59         	RowHeight$ 35Q�5:         GridLinesVisibility$
 None=�5;         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5<         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ 	Họ tên��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *PatientName+  5@      $ Ngày��61      Width$	 120 6w    6?   �� *Date+ �� StringFormat$ {0:dd/MM/yyyy}��6w     5A      $ Ca��61   $ 80 6V    6=   �� *Slot+6V     5B      $ 
Mã phòng��61   $	 120 6`    6C   �� *
RoomCode+6`   5D      5E      5F      5G      5H      5I      