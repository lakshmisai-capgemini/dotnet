   M S B A M L   `   `   `  ����I  EMiniProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MiniProjectNewMiniProjectNew  5   	        MiniProjectNew.AdminAccess   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MiniProjectNew     5   	     � Title$  AdminAccess��5   	   $	��500��6   $	��900��6*   .��5	      � $��0,0,2,-2q�6   ��5
   
   �� 5       �� EndPoint$ 0.5,1&�6"    �� 
StartPoint$ 0.5,0&�63   .��5      �  � Color$ Black��6    � Offset$ 0Q�6-   � 5      $ 	#FFF7F4F4��6   $ 1Q�61   5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��grid2��5      $
��Left=�68   $	��168��6S   $��	46,38,0,0q�6`   $	��Top=�6s   $	��324��6�   ��6    �� 6�   �� 5   
   $��Endorsement Table��6   $
��Left=�6,   $��
105,10,0,0q�6G   $	��Top=�6[   $	��196��6s   $��16(�6   $
��Bold"�6�   ���	#FFF3ECEC6�   �� 5   
   -   5        $��View Changes��5      $
��Left=�6(   $��394,120,0,0q�6C   $	��Top=�6X   $��99��6p   $��28��6{   ���	#FFFFF5F5$
��Bold"�6�     5   
   -   5        $��gridCus��5         CanUserAddRows .    CanUserDeleteRows .    AutoGenerateColumns . $
��Left=�6�   $	��150��6�   $��
10,291,0,0q�6�   $	��Top=�6�   $	��364��6�   ��6m   �� 6�     5   
   -   5        $��
gridPolicy��5       .  .  . $
��Left=�6�   $	��168��6�   $��
538,38,0,0q�6�   $	��Top=�6�   $	��307��6�   ��6o   �� 6�     5   
   -   5        $��gridProducts��5       . $
��Left=�6Z   $	��150��6u   $��482,291,0,0q�6�   $	��Top=�6�   $	��318��6�   ��6B   �� 6�   �� 5   
   $��Customer Table��6   $
��Left=�6)   $��147,246,0,0q�6D   $	��Top=�6Y   $��16(�6q   $
��Bold"�6    J� RenderTransformOrigin$ 0.379,0.893&�6�   �� 5   
   $��Policy Table��6   $
��Left=�6'   $��	648,2,0,0q�6B   $	��Top=�6U   $��16(�6m   $
��Bold"�6{   ���	#FFF7F2F26�   �� 5   
   $��Products Table��6   $
��Left=�6)   $��598,246,0,0q�6D   $	��Top=�6Y   $ 
0.48,1.649&�6q   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $��btnAddCustomer��5      $��Add Customer��6'   $
��Left=�6>   $��379,374,0,0q�6Y   $	��Top=�6n   $��98��6�   $��27��6�   ���	#FF151414���	#FFFBF2F2$
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 btnAddProducts��5      $��Add Products��6)   $
��Left=�6@   $��805,374,0,0q�6[   $	��Top=�6p   $��75��6�   ���	#FF110101���	#FFF7F2F2$
��Bold"�6�   6�   �� 5   
   -   5        $��btnInsertPolicy��5      $��Insert Policy��6(   $
��Left=�6@   $��769,231,0,0q�6[   $	��Top=�6p   $��94��6�   $��28��6�   ���	#FFF7F5F5$
��Bold"�6�   6�   5      5      