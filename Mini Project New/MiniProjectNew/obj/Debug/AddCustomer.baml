   M S B A M L   `   `   `  ����I  EMiniProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MiniProjectNewMiniProjectNew  5   	        MiniProjectNew.AddCustomer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MiniProjectNew     5   	     � Title$  AddCustomer��5   	   $	��450��6   $	��500��6*   .��5	      � ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ 	#FFA29999��6    � Offset$ 0Q�61   � 5      $ White��6   $ 1Q�6-   5      .+�5   
   �� $��CusId��6   $
��Left=�6    $��
154,63,0,0q�6;   $	��Top=�6O   �� 5   
   $
��Name��6   $
��Left=�6   $��
152,94,0,0q�6:   $	��Top=�6N   �� 5   
   $��Address��6   $
��Left=�6"   $��149,125,0,0q�6=   $	��Top=�6R    J� RenderTransformOrigin$ 0.489,0.275&�6j   �� 5   
   $��	Telephone��6   $
��Left=�6$   $��141,174,0,0q�6?   $	��Top=�6T   $ 0.534,0.187&�6l   �� 5   
   $��Gender��6   $
��Left=�6!   $��152,219,0,0q�6<   $	��Top=�6Q   $ 0.659,-0.426&�6i   �� 5   
   $	��DOB��6   $
��Left=�6   $��152,250,0,0q�69   $	��Top=�6N   �� 5   
   $��Smoker��6   $
��Left=�6!   $��152,300,0,0q�6<   $	��Top=�6Q   �� 5   
   $��Hobbies��6   $
��Left=�6"   $��152,350,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $��	txtCustid��5      $
��Left=�6#   $��23��6>   $��
251,63,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5         ��Name$ txtName��5      $
��Left=�6#   $��23��6>   $��
251,94,0,0q�6J   $
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��120��6�   �� 5   
   -   5        $ 
txtAddress��5      $
��Left=�6&   $��23��6A   $��251,128,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5   
   -   5        $ txtTelephone��5      $
��Left=�6(   $��23��6C   $��251,177,0,0q�6O   $
 Wrap=�6d   $�� ��6x   $	��Top=�6�   $	��120��6�   	� 5   
   -   5        $��btnMale��5       	� 	GroupName$
 grp1��6%   $
��Male��66   $
��Left=�6E   $��251,219,0,0q�6`   $	��Top=�6u   	� 5   
   -   5        $��	btnFemale��5      $
 grp1��6'   $��Female��68   $
��Left=�6I   $��385,219,0,0q�6d   $	��Top=�6y   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpDob��5      $
��Left=�6"   $��267,250,0,0q�6=   $	��Top=�6R   	� 5   
   -   5        $��	btnSmoker��5      $
 grp2��6'   $��Smoker��68   $
��Left=�6I   $��267,300,0,0q�6d   $	��Top=�6y   	� 5    
   $
 grp2��6   $��
Non Smoker��6'   $
��Left=�6<   $��385,300,0,0q�6W   $	��Top=�6l   �� 5!   
   -	   5        $ 
txtHobbies��5!      $
��Left=�6&   $��23��6A   $��251,350,0,0q�6M   $
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��120��6�   �� 5"   
   -
   5        $��	btnInsert��5"      $��Insert��6"   $
��Left=�63   $��221,389,0,0q�6N   $	��Top=�6c   $��75��6{   ���	#FF0F0E0E���	#FFFBFBFB$
��Bold"�6�   5$      5%      