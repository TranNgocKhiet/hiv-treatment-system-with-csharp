   M S B A M L   `   `   `  ����  HivTreatmentAppWPF1    +HivTreatmentAppWPF.Patient.UserSchedulePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  Lịch sử khám bệnh��5       N� 
Background �#F5F6FA.��5      � $��60q�6   .+�5   
   �� 
������� �� CornerRadius$ 12��5      ���#E0E0E0$��1q�5       �� Padding$ 30q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 6��5      $ 10q�5      $��0 0 0 20q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6!   $��Center=�6:   $��Center=�6U   .+�5      �� $
��📅��6$   $��22(�5   $   $��0 5 8 0q�5   $   �� 5      $&�� Lịch sử ca khám của bạn��6$   $��20(�5   $   $
��Bold"�5   $   
�������5   $   5       5!      �� 5$      $ 
Horizontal=�6   $��0 0 0 10q�66   .+�5%      �� $%��Tìm kiếm theo tên bác sĩ:��6    $��Center=�5&       $
��Bold"�5'       $��0 0 8 0q�5(       �� 5)      -   5         ��Name$ 	SearchBox��5)      $	��300��5*      $��28��5+      $��5q�5,      $��Center=�5-      5.      5/      &   System.Windows.Controls.DataGrid  52      -   5          Name$ ScheduleDataGrid��52         AutoGenerateColumns$ False��53      $��14(�54      	   CanUserAddRows$	 False��55      
   
IsReadOnly$

 True��56         	RowHeight$ 35Q�57         AlternatingRowBackground �#F9F9F9   RowBackground
 ��������#E0E0E0$��1q�5;         HeadersVisibility$ Column=�5<      $��0,0,0,10q�5=         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5>         ColumnHeaderHeight$ 32Q�5?       � 	Resources 5A      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value��%�   '        �� 5B      "  6    .�5C      ��  � ��$
 Wrap=�6G   �� 5D       � ��$ Center=�6K   �� 5E       � ��$ Center=�6I   �� 5F       � ��$	 8,4q�68   5G      5H         Columns 5J      0  *System.Windows.Controls.DataGridTextColumn  5K      ,  &System.Windows.Controls.DataGridColumn   Header$ Ngày��6-      MinWidth$ 90Q�6d   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Date+ �� StringFormat$ d��6d     5L      $ Giờ��6-   $ 70Q�6S    6:   �� *Slot+6S     5M      $ Bác sĩ��6-   $	 120Q�6\    6=   �� *
DoctorName+6\     5N      $ Loại khám��6-   $	 120Q�6Y    6@   �� *Type+6Y   4  .System.Windows.Controls.DataGridTemplateColumn  5P      $ Trạng thái yêu cầu��61   $	 150Q�6M      CellTemplate 5Q      �� 5R   "   .R�5S   &   ��  �� Padding$ 4q�5T   0   $��Center=�5U   0   ��5S   0   �� *RequestStatus+��5V   *   �� 5W   .   " ��64   .�5X   2   ��  � ��
 ���� 6O   �� 5Y   2    � ��
 �   �6O   �� 5Z   2    � ��$ SemiBold"�6O    �� Triggers 5[   2   �� 5\   6    �� Binding 6B   �� *RequestStatus+ �� Value Đã duyệt6d   .a�5]   :   ��  � ��
 ����6W   �� 5^   :    � ��
 �   �6W   5_   7   �� 5`   6    6B   �� *RequestStatus+ Chờ duyệt6d   .a�5a   :   ��  � ��
 � ���6W   �� 5b   :    � ��
 �   �6W   5c   7   �� 5d   6    6B   �� *RequestStatus+ Từ chối6d   .a�5e   :   ��  � ��
 �����6W   �� 5f   :    � ��
 �����6W   5g   7   5i   /   5k   '   5l   #   5n        5p      $" Trạng thái hoạt động��61   $	 150Q�6O    5q      �� 5r   "   .R�5s   &   �� $ 4q�5t   0   $��Center=�5u   0   ��5s   0   �� *ActiveStatus+��5v   *   �� 5w   .   " ��64   .�5x   2   ��  � ��
 ���� 6O   �� 5y   2    � ��
 �   �6O   �� 5z   2    � ��$ SemiBold"�6O    5{   2   �� 5|   6    6B   �� *ActiveStatus+ Đang hoạt động6c   .a�5}   :   ��  � ��
 ����6W   �� 5~   :    � ��
 �   �6W   5   7   �� 5�   6    6B   �� *ActiveStatus+ 
Đã hủy6c   .a�5�   :   ��  � ��
 �����6W   �� 5�   :    � ��
 �����6W   5�   7   5�   /   5�   '   5�   #   5�        5�      $ 	Thao tác��61   $	 100Q�6C    5�      �� 5�   "   .R�5�   &   �� -   5        $��Hủy��5�   -   $��4q�5�   -   
�������
������� � Cursor$
 Hand��5�   -   
������ 
  � Tag  5�   -   �� *Id+5�   #   5�      5�      5�      5�      5�      5�      