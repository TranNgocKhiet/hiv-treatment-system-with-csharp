   M S B A M L   `   `   `  ����  HivTreatmentAppWPF6    0HivTreatmentAppWPF.Doctor.HealthRecordEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$(  "Hồ sơ sức khỏe bệnh nhân��5   	   $	��800��5   	   $
��1400��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ 	CanResize=�5   	   ���#F5F6FA.��5	      ]� $��20q�6   .+�5   
   �� ���#0096FF �� Padding$ 20q�6&    �� CornerRadius$ 8��63   $	��Top=�6D   $��0,0,0,20q�6Y      
CardShadow J� Effect# [  6k   ._�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   .+�5      �� $��/Assets/health_icon.png��6   $��40��69   $��40��6D   $��0,0,15,0q�6P   �� 5      $(��"Hồ sơ sức khỏe bệnh nhân��6   $��20(�6<   $
��Bold"�6J   
�������$��Center=�6o   5      5      �� 5   
   $��Bottom=�6   $ 
Horizontal=�6-   $��Right=�6F   $��0,10,0,0q�6b   .+�5      �� -   5        $��Thêm kết quả��5        NavButtonStyle#��[ 6H   �� 5      -   5        $��Xóa kết quả��5        DangerButtonStyle#��[ 6J   �� 5      -   5        $
��Lưu��5      #��[ 6<   �� 5      -   5        $��Đóng��5      #��[ 5      
��� ���5      5      �� 5   
   $	��Top=�6   $
��Auto=�6,   .��5       � $��0,0,0,10q�6    � ColumnDefinitions 5!      �� 5"      $	��350 �6'   �� 5#      $��* �6'   .+�5'      �� $��0��6   $��0,0,20,0q�6-   .+�5(      �� 
�������$ 8��60   $ 10q�6A   $��0,0,0,20q�6N   # [  6`   ._�5)      �  � RowDefinitions 5*      �� 5+   "   $
��Auto �60   �� 5,   "   $
��Auto �60   �� 5-   "   $
��Auto �60   �� 5.   "   $
��Auto �60   �� 5/   "   $
��Auto �60    51      �� 52   "   $	��160 �63   �� 53   "   $��* �63   .+�56      �� $��Chiều cao (cm):��6(   $��0��6?   $��0��6L   $��5q�6\   �� 57      $��0��6K   $��1��6X   $��5q�6h   ��6&   �� *HealthRecord.Height+6h   �� 59      $��Cân nặng (kg):��6(   $��1��6>   $��0��6K   $��5q�6[   �� 5:      $��1��6K   $��1��6X   $��5q�6h   ��6&   �� *HealthRecord.Weight+6h   �� 5<      $��Nhóm máu:��6(   $��2��69   $��0��6F   $��5q�6V   �� 5=      $��2��6P   $��1��6]   $��5q�6m   $��Center=�6x   ��6(   �� *HealthRecord.BloodType+6x   �� 5?      $��Tình trạng HIV:��6(   $��3��6?   $��0��6L   $��5q�6\   �� 5@      $��3��6P   $��1��6]   $��5q�6m   $��Center=�6x   ��6(   �� *HealthRecord.HivStatus+6x   �� 5B      $��Tình trạng xử lí:��6(   $��4��6A   $��0��6N   $��5q�6^   �� 5C      $��4��6'   $��1��64   $��5q�6D   	 �� SelectedValuePath$	 Content��5E   '   
 �� SelectedValue
 5D   '   �� *HealthRecord.TreatmentStatus+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�.@�5F   "   �� $��Chờ khám��6/   �� 5G   "   $��
Đã khám��6/   �� 5H   "   $��Đã tư vấn��6/   �� 5I   "   $��Không đến��6/   5J      5K      5L      �� 5N      $��Phác đồ điều trị��6    $
��Bold"�68   $��5,0,5,5q�6J   �� 5O      -   5         ��Name$ RegimenSearchBox��5O      $��5q�68   6C   �� 5P      -   5         ��Name$ RegimenComboBox��5P      $��5q�5Q       �� 
IsEditable$
 True��5R       �� DisplayMemberPath$ RegimenName��5T      $	 Id��5U      ��5S      �� *
Regimens+
 5V      �� *HealthRecord.RegimenId+$ TwoWay=�$ PropertyChanged=�5W      �� 5Y      
�������$ 8��60   $ 10q�6A   $��5q�6N   # [  6Y   ._�5Z      �� .+�5[      �� $��Thông tin phác đồ��6(   $
��Bold"�6A   $��14(�6S   ���#0096FF$��0,0,0,5q�6v   �� 5]      $��Tên phác đồ:��6(   $
��Bold"�6<   �� 5^      $��13(�6U   $��0,0,0,5q�6c   ��6(   �� *SelectedRegimen.RegimenName+6c   �� 5`      $��Thành phần:��6(   $
��Bold"�6;   �� 5a      $
��Wrap=�6T   $��12(�6h   $��0,0,0,5q�6v   ��6(   �� *SelectedRegimen.Components+6v   �� 5c      $��Chỉ định:��6(   $
��Bold"�69   �� 5d      $
��Wrap=�6U   $��12(�6i   $��0,0,0,5q�6w   ��6(   �� *SelectedRegimen.Indications+6w   �� 5f      $��Chống chỉ định:��6(   $
��Bold"�6?   �� 5g      $
��Wrap=�6[   $��12(�6o   $��0,0,0,5q�6}   ��6(   �� *#!SelectedRegimen.Contraindications+6}   �� 5i      $��	Mô tả:��6(   $
��Bold"�66   �� 5j      $
��Wrap=�6U   $��12(�6i   ��6(   �� *SelectedRegimen.Description+6i   5k      5l      5m      �� 5p      $��1��6   
�������$ 8��6<   $ 10q�6M   # [  6Z   ._�5q      �� $��Kết quả xét nghiệm��6   $
��Bold"�6;   .��5r      ]� .+�5s      &   System.Windows.Controls.DataGrid  -   5          Name$ TestResultDataGrid��5s   '      AutoGenerateColumns$ False��5u   '      CanUserDeleteRows$
 True��5v   '      
IsReadOnly$
 True��5w   '   $��14(�5x   '   $��0,0,0,10q�5y   '   $
��Auto=�5z   '   $	��Top=�5{   '   ��5t   '   �� *TestResults+   Columns 5|   "   0  *System.Windows.Controls.DataGridTextColumn  5}   &   ,  &System.Windows.Controls.DataGridColumn   Header$ Loại��69      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6G   �� *Type+6`     5~   &   $ Kết quả��69   $	 100 6e    6J   �� *Result+6e     5   &   $ 
Đơn vị��69   $	 100 6b    6I   �� *Unit+6b     5�   &   $ Ghi chú��69   $ * 6c    6J   �� *Note+6c   4  .System.Windows.Controls.DataGridTemplateColumn  5�   &   $ Dự kiến��6=   $	 200 6N      CellTemplate 5�   *   �� 5�   .   .R�5�   2   �� ��6<   �� *ExpectedResultTime+ �� StringFormat$ {0:dd/MM/yyyy HH:mm}��5�   /   5�   '     5�   &   $ Thực tế��6=   $	 200 6N    5�   *   �� 5�   .   .R�5�   2   �� ��6<   �� *ActualResultTime+$ {0:dd/MM/yyyy HH:mm}��5�   /   5�   '   5�      5�      5�      5�      5�      5�      5�      5�      