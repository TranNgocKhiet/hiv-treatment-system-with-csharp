   M S B A M L   `   `   `  ����M  IHivTreatmentAppWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:HivTreatmentAppWPFHivTreatmentAppWPF  5   	   $    HivTreatmentAppWPF.LoginWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:HivTreatmentAppWPF     5   	     � Title$   Đăng nhập hệ thống��5   	    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   $	��600��5   	   $	��350��6   ���#F5F9FF.��5      ��  �� CornerRadius$ 10��6   
�������$��20q�62    �� Padding$ 20q�6>   ���#0096FF$��2q�6a   ._�5   
   �  � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    �� 5      $
��Auto �6    .+�5      �� $��Đăng nhập��6   $��24(�6)   $
��Bold"�67   ���#0096FF$��Center=�5      $��0,0,0,20q�65   � 5      $��1��6   $��0,0,0,10q�6     � ColumnDefinitions 5      �� 5      $	��150 �6'   �� 5      $��* �6'   .+�5      �� $��Tên tài khoản��6   $��Center=�61   $��SemiBold"�6L   $��0��6b   $��5q�6r   �� 5       -   5         ��Name$ txtUsername��5       $	��260��6/   $��30��6;   $��14(�6G   $��5q�6U   $��1��6a   5!      � 5#      $��2��6   $��0,0,0,10q�6     5$      �� 5%      $	��150 �6'   �� 5&      $��* �6'   .+�5)      �� $��Mật khẩu��6   $��Center=�6,   $��SemiBold"�6G   $��0��6]   $��5q�6m   �� 5+      $��1��6   .+�5,      G� -   5         G�Name$ txtPassword��5,   "   $	��260��67   $��30��6C   $��14(�6O   $��5q�6]   $y�Visible=�6i   6~   �� 5-      -   5        $ txtPasswordVisible��5-      $	��260��6:   $��30��6F   $��14(�6R   $��5q�6`   $y�	Collapsed=�6l   6�   �� 5.      -   5        	 ��Name$	 chkShowPassword��5.      $	��260��68   $��Hiện mật khẩu��6D   $��5,5,0,0q�6\   6�   5/      50      �� 53      $��3��6   
 �� Orientation$
 
Horizontal=�6&   $��Center=�6?   $��0,20,0,0q�6\   .+�54      �� -   5        $��Đăng nhập��54      $	��120��6-   $��35��69   $��5q�6E   ���#0096FF
�������$
��Bold"�56   A   $��0q�57       � Cursor$
 Hand��6-   ��58      �� 59       �� 
TargetType" ��6    .�5:      ��  �� Property � �� �� Value �#0096FF6;   �� 5;       � ��
 �����6;   �� 5<       � �� 5=   "   �� 5>   &    �� 
TargetType" ��66   .R�5?   *   �� #��z��61   $ 5��6[   $ 5q�6l   ._�5@   .   �� $��Center=�6?   $��Center=�6\   5A   +   5B   '   5D       �� Triggers 5E      P� 5F   "    P� Property �@J�IsMouseOver P� Value$
 True��6A   . �5G   &   ��  � �� �#0078D76C   5H   #   5J      5L      �� 5N      -   5        $��Thoát��5N      $	��100��6)   $��35��65   $��5q�6A   
�������
�������$
��Bold"�5P   >   $��0q�5Q      $
 Hand��6-   5R      5S      5T      5U      