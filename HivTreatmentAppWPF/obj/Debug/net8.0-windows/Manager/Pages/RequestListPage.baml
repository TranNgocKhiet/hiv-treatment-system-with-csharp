   M S B A M L   `   `   `  ����  HivTreatmentAppWPF0    *HivTreatmentAppWPF.Manager.RequestListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  RequestList��5      .��5
      �� $
��Auto=�6   .��5   
   � $��40q�6   .+�5      �� 
������� �� CornerRadius$ 10��5       �� Padding$ 30q�5      ���#E0E0E0$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 8��5      $ 10q�5      $��0 0 0 20q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��🔔��6(   $��28(�5   (   $��0 5 10 0q�5   (   �� 5      $%��Yêu cầu đang cần xử lý��6(   
�������$��20(�5   (   $
��Bold"�5    (   $��Center=�5!   (   5"      5#      �� 5&      $ 
Horizontal=�6!   $��0 0 0 10q�6:   .+�5'      �� $?��9Tìm kiếm mã phòng, tên bác sĩ, tên bệnh nhân:��6$   $��Center=�5(   $   $
��Bold"�5)   $   $��0 0 8 0q�5*   $   �� 5+      -   5         ��Name$ 	SearchBox��5+   "   $	��300��5,   !   $��28��5-   !   $��5q�5.   !   $��Center=�5/   !   50   !   51      &   System.Windows.Controls.DataGrid  54      -   5          Name$ ScheduleDataGrid��54         AutoGenerateColumns$ False��55         
IsReadOnly$
 True��56      	   HeadersVisibility$	 Column=�57      $��14(�58      
   AlternatingRowBackground
 �#f5f5f5   GridLinesVisibility$ 
Horizontal=�5:         RowBackground
 �����$��1q�5<      ���#E0E0E0   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5>      $	��400��5?         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã phòng khám��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6H   �� *
RoomCode+  5C      $ Ngày��61    6?   �� *Date+ �� StringFormat$ {0:dd/MM/yyyy}��  5D      $ Ca��61    6=   �� *Slot+  5E      $ Bác sĩ��61    6A   �� *
DoctorName+  5F      $ Loại��61    6?   �� *Type+  5G      $ Bệnh nhân��61    6D   �� *PatientName+4  .System.Windows.Controls.DataGridTemplateColumn  5I      $ Trạng thái xử lý��65      CellTemplate 5J   "   �� 5K   &   .R�5L   *   ��  �� Padding$ 4q�5M   4   $��Center=�5N   4   ��5L   4   �� *RequestStatus+��5O   .   �� 5P   2    �� 
TargetType" ��68   .�5Q   6   ��  �� Property � �� �� Value
 ���� 6S   �� 5R   6    � ��
 �   �6S   �� 5S   6    � ��$ SemiBold"�6S    �� Triggers 5T   6   �� 5U   :    �� Binding 6F   �� *RequestStatus+ �� Value Đã duyệt6h   .a�5V   >   ��  � ��
 ����6[   �� 5W   >    � ��
 �   �6[   5X   ;   �� 5Y   :    6F   �� *RequestStatus+ Chờ duyệt6h   .a�5Z   >   ��  � ��
 � ���6[   �� 5[   >    � ��
 �   �6[   5\   ;   �� 5]   :    6F   �� *RequestStatus+ Từ chối6h   .a�5^   >   ��  � ��
 �����6[   �� 5_   >    � ��
 �����6[   5`   ;   5b   3   5d   +   5e   '   5g        5i      $" Trạng thái hoạt động��65    5j   "   �� 5k   &   .R�5l   *   �� $ 4q�5m   4   $��Center=�5n   4   ��5l   4   �� *ActiveStatus+��5o   .   �� 5p   2   " ��68   .�5q   6   ��  � ��
 ���� 6S   �� 5r   6    � ��
 �   �6S   �� 5s   6    � ��$ SemiBold"�6S    5t   6   �� 5u   :    6F   �� *ActiveStatus+ Đang hoạt động6g   .a�5v   >   ��  � ��
 ����6[   �� 5w   >    � ��
 �   �6[   5x   ;   �� 5y   :    6F   �� *ActiveStatus+ 
Đã hủy6g   .a�5z   >   ��  � ��
 �����6[   �� 5{   >    � ��
 �����6[   5|   ;   5~   3   5�   +   5�   '   5�      5�      �� 5�      $ 
Horizontal=�6!   $��Right=�5�   !   $��0 20 0 0q�5�   !   .+�5�      �� -   5        $��Lọc Chờ Duyệt��5�   !   $	��130��5�   !   $��35��6-   $��5q�69     NavButtonStyle#��[ 5�   !   
�������
�������$��14(�5�   !   $��SemiBold"�5�   !   $��0q�5�   !    � Cursor$
 Hand��5�   !   5�   !   �� 5�      -   5        $��Hiển thị tất cả��5�   !   #��[ 5�   !   $	��130��5�   !   $��5q�6-   5�   !   5�      5�      5�      5�      5�      5�      