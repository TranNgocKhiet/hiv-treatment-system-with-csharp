   M S B A M L   `   `   `  ����  HivTreatmentAppWPF-    'HivTreatmentAppWPF.Manager.UserListPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  UserListPage��5      .��5
      �� $
��Auto=�6   .��5   
   � $��40q�6   .+�5      �� 
������� �� CornerRadius$ 12��5       �� Padding$ 30q�5      ���#DDD$��1q�5         
CardShadow J� Effect# [  5      ._�5      �� .+�5      �� ���#0096FF$ 8��5      $ 12q�5      $��0 0 0 20q�5      ._�5      ��  �� Orientation$ 
Horizontal=�6%   $��Center=�6>   .+�5      �� $
��👤��6(   $��22(�62   $��0 0 10 0q�6@   �� 5      $��Danh sách người dùng��6(   
�������$��20(�5   (   $
��Bold"�5   (   5      5       �� 5#      $ 
Horizontal=�6!   $��0 0 0 10q�6:   .+�5$      �� $=��7Tìm kiếm họ và tên, số điện thoại, email:��6$   $��Center=�5%   $   $
��Bold"�5&   $   $��0 0 8 0q�5'   $   �� 5(      -   5         ��Name$ 	SearchBox��5(   "   $	��300��5)   "   $��28��5*   "   $��5q�5+   "   $��Center=�5,   "   5-   "   5.      &   System.Windows.Controls.DataGrid  51      -   5          Name$ UserDataGrid��51         AutoGenerateColumns$ False��52         
IsReadOnly$
 True��53      	   HeadersVisibility$	 Column=�54      $��14(�55      
   AlternatingRowBackground
 �#f5f5f5   GridLinesVisibility$ 
Horizontal=�57         RowBackground
 ��������#E0E0E0$��1q�5:         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5;      $	��400��5<         Columns 5>      0  *System.Windows.Controls.DataGridTextColumn  5?      ,  &System.Windows.Controls.DataGridColumn   Header$ Vai trò��61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6B   �� *
RoleName+  5@      $ Họ và tên��61    6D   �� *
FullName+  5A      $ Số điện thoại��61    6H   �� *PhoneNumber+  5B      $ Email��61    6@   �� *Email+4  .System.Windows.Controls.DataGridTemplateColumn  5C      $  Trạng thái tài khoản��65      CellTemplate 5D   "   �� 5E   &   .R�5F   *   ��  �� Padding$ 4q�5G   4   $��Center=�5H   4   ��5F   4   �� *AccountStatus+��5I   .   �� 5J   2    �� 
TargetType" ��68   .�5K   6   ��  �� Property � �� �� Value
 ���� 6S   �� 5L   6    � ��
 �   �6S   �� 5M   6    � ��$ SemiBold"�6S    �� Triggers 5N   6   �� 5O   :    �� Binding 6F   �� *AccountStatus+ �� Value Đang hoạt động6h   .a�5P   >   ��  � ��
 ����6[   �� 5Q   >    � ��
 �   �6[   5R   ;   �� 5S   :    6F   �� *AccountStatus+ 
Bị khóa6h   .a�5T   >   ��  � ��
 �����6[   �� 5U   >    � ��
 �����6[   5V   ;   5X   3   5Z   +   5[   '   5]      5_      �� 5b      $ 
Horizontal=�6!   $��Right=�5c   !   $��0 20 0 0q�5d   !   .+�5e      �� -   5        $��Tạo��5e   !   $	��100��5f   !   $��35��5g   !   $��5q�5h   !     NavButtonStyle#��[ 5i   !   5j   !   �� 5k      -   5        $
��Xóa��5k   !   $	��100��5l   !   $��35��5m   !   $��5q�5n   !     DangerButtonStyle#��[ 5o   !   5p   !   5q      5r      5s      5t      5u      5v      