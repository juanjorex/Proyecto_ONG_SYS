   M S B A M L   `   `   `  ����B  >ONG_SYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ONG_SYSONG_SYS  5   	   '    !ONG_SYS.FRM_Principal_facturacion   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ONG_SYS     5   	     � Title$!  Administración de Clientes��5   	    � WindowState$ 	Maximized=�5	   	   $��Microsoft JhengHei)�6"   $��14(�6B   $
��Bold"�6P    � WindowStyle$ ThreeDBorderWindow=�6b   $y�Visible=�6�   
���   �$��1210.117��6�   $��728.638��6�    � Icon$ 	Logo.jpeg��6�    J� OpacityMask 5      �� 5   
    �� EndPoint$ 0.5,1&�6    �� 
StartPoint$ 0.5,0&�6/   .��5      �  � Color$ Black��6    � Offset$ 0Q�6)   � 5      $ 	#FF8A5B5B��6   $ 1Q�6-   5      ��5      �� 5   
   $ 0.5,1&�6   $ 0.5,0&�6/   .��5      � $ Black��6   $ 0Q�6)   � 5      $ 	#FFF60000��6   $ 1Q�6-   5      .��5      � $	��691��6   $
��1190��6   	 � RowDefinitions	 5   
   �� 5      
 � ColumnDefinitions
 5   
   �� 5      .+�5   
   �� $3��-          ADMINISTRACIÓN DE FACTURAS        ��6   $��Center=�6G   $��413,56,299,0q�6d   $	��Top=�6z   $��57��6�   $	��478��6�    J� RenderTransformOrigin$ 0.415,-2.621&�6�   
�������$��24(�6�   �� 5    
   $
��Left=�6   $��62��6+   $��
360,51,0,0q�67   $	��Top=�6K   $��48��6c   $��icons8-invoice-100.png��6n   $ 0.009,0.419&�6�   �� 5!   
   $��456,212,365,197.667q�6   .+�5"      �� -   5         ��Name$ BTN_Nuevo_Factura��5"      $��Nuevo Factura��60   $
��Left=�6H   $	��Top=�6c   $	��266��6{   ���	#FFFFFBFB
���  �����	#FF252323$��50��6�   $��16(�6�    �� Left$	 103��6�   6�   �� 5#      -   5        $! btn_Administracion_Facturas��5#      $��Facturas Emitidas��6:   $��Center=�6V   $	��Top=�6s   $	��266��6�   ���	#FFFFFBFB
���  �����	#FF252323$��50��6�   $��16(�6�   $	 103��6�   
 �� Top$	 118��6  6  �� 5$      -   5        $ btn_regresar_AC��5$      $��Regresar��6.   $��Center=�6A   $	��Top=�6^   $	��266��6v   ���	#FFFFFBFB
���  �����	#FF252323$��50��6�   $��16(�6�   $	 103��6�   $	 231��6�   6�   �� 5%      $��Right=�6   $��50��60   $	��Top=�6<   $��44��6T   $#��icons8-agregar-recibo-100.png��6_   $ -4.822,0.271&�6�   $	 118��6�   �� 5&      $��Right=�6   $��50��60   $	��Top=�6<   $��44��6T   $��
cuenta.png��6_   $ -4.822,0.271&�6s   �� 5'      $��Right=�6   $��50��60   $	��Top=�6<   $��44��6T   $(��"flecha-curva-trasera-izquierda.png��6_   $ -4.822,0.271&�6�   $	 231��6�   5*      �� 5+   
   $��99,212,837,197.667q�6   .+�5.      �� $
��Left=�6   $	��281��6/   $	��Top=�6<   $	��254��6T   $��	Logo.jpeg��6`   50      52      54      