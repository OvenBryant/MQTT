   M S B A M L   `   `   `  ����E  AMqttClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MqttClient
MqttClient  5   	       MqttClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MqttClient     5   	     � Title$  
MqttClient��5   	   $��394.8��6   $��645.6��6+    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      � .+�5
   
   �� -   5         ��Name$ label��5
      $��IP��6   $
��Left=�6,   $��8,11,0,0q�6G   $	��Top=�6Y   $��34��6q   �� 5   
   -   5         ��Name$ 
textBox_IP��5      $
��Left=�6&   $��23��6A   $��	30,10,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��100��6�   �� 5   
   -   5        $ 
label_Copy��5      $
��Port��6$   $
��Left=�63   $��
146,11,0,0q�6N   $	��Top=�6b   �� 5   
   -   5        $ textBox_Port��5      $
��Left=�6(   $��23��6C   $��
185,10,0,0q�6O   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $��67��6�   �� 5   
   -   5         ��Name$ button_Connect��5      $��连接��6)   $
��Left=�66   $��
354,11,0,0q�6Q   $	��Top=�6e   $��96��6}   $��25��6�   6�   �� 5   
   -   5        $ label_Copy1��5      $��主题��6%   $
��Left=�62   $��8,58,0,0q�6M   $	��Top=�6_   �� 5   
   -   5        $ textBox_Title��5      $
��Left=�6)   $��23��6D   $��	60,58,0,0q�6P   $
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��120��6�   �� 5   
   -   5        $ label_Copy2��5      $��内容��6%   $
��Left=�62   $��
10,145,0,0q�6M   $	��Top=�6a   �� 5   
   -	   5        $ textBox_Content��5      $
��Left=�6+   $	��201��6F   $��
49,145,0,0q�6S   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $	��192��6�   �� 5   
   -
   5        $ button_Publish��5      $��发布��6)   $
��Left=�66   $��
85,110,0,0q�6Q   $	��Top=�6e   $	��110��6}   $��30��6�    J� RenderTransformOrigin$ -1.815,2.577&�6�   �� 5   
   -   5        $ button_Subscribe��5      $��订阅��6+   $
��Left=�68   $��
199,58,0,0q�6S   $	��Top=�6g   $��76��6   $��23��6�   6�   �� 5   
   -   5        $ button_Unsubscribe��5      $��取消订阅��6-   $
��Left=�6<   $��
295,58,0,0q�6W   $	��Top=�6k   $��76��6�   $��23��6�   6�   �� 5   
   -   5         ��Name$ listBox_Record��5      $
��Left=�6*   $	��248��6E   $��
270,98,0,0q�6R   $	��Top=�6f   $	��348��6~   �� 5   
   -   5        $ button_DisConnect��5      $��断开��6,   $
��Left=�69   $��
480,12,0,0q�6T   $	��Top=�6h   $��80��6�   $��24��6�   6�   �� 5   
   -   5        $ btnClear��5      $��清除列表��6#   $
��Left=�62   $��
543,66,0,0q�6M   $	��Top=�6a   $��75��6y   $��25��6�   6�   5      5      