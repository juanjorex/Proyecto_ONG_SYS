   M S B A M L   `   `   `  ����B  >ONG_SYS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:ONG_SYSONG_SYS  5   	       ONG_SYS.FRM_Facturas   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:ONG_SYS     5   	     � WindowState$  	Maximized=�5   	   $��Microsoft JhengHei)�5	   	   $��14(�5
   	   $
��Bold"�5   	    � WindowStyle$ ThreeDBorderWindow=�5   	   $y�Visible=�5   	   
���   � � Icon$ 	Logo.jpeg��5   	    � Title$ Facturas��5   	   $	��450��5   	   $	��800��5   	   .��5      � .+�5   
   �� -   5         ��Name$
 Logo��5      $
��Left=�6   $��89��69   $��10,145,0,165q�6D   $��	Logo.jpeg��6Z    � Cursor$  ��6m   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgv_facturas��5      $��104,97,55,81q�6)      
IsReadOnly . 6Q   �� 5   
   -   5         ��Name$ btn_Regresar��5      $��REGRESAR��6'   $��Bottom=�6:   $��30��6V   ���	#FF252323
�������
���  ��	 J� RenderTransformOrigin$	 
0.51,0.173&�6�   $��Right=�6�   $	��160��6�   $��12(�6�   $��	0,0,55,23q�6�   6
  �� 5   
   -   5        
 ��Name$
 tstBusf��5      $
��Left=�6#   $��24��6>   $��
255,68,0,0q�6J    �� TextWrapping$
 Wrap=�6^   $	��Top=�6r   $	��185��6�   6�   �� 5   
   $��Buscar por nombre��6   $
��Left=�6,   $��
104,64,0,0q�6G   $	��Top=�6[   $	��146��6s   $��28��6   
�������6�   �� 5   
   -   5        $ btn_Regresar_Copy��5      $��Visualizar Facturas��6,   $��Bottom=�6J   $��30��6f   ���	#FF252323
�������
���  ��$	 
0.51,0.173&�6�   $��Right=�6�   $	��160��6�   $��12(�6�   $��0,0,529.333,22.667q�6  6#  5      5      