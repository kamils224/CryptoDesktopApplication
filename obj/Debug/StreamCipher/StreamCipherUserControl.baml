   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CryptoDesktopApplication.StreamCipher%CryptoDesktopApplication.StreamCipher  5      a5clr-namespace:CryptoDesktopApplication.LoadingControl'CryptoDesktopApplication.LoadingControl  5      C    =CryptoDesktopApplication.StreamCipher.StreamCipherUserControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:CryptoDesktopApplication.StreamCipher     5      Icontrol5clr-namespace:CryptoDesktopApplication.LoadingControl     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      $	��645��5
      $
��1280��6   .��5      � 
�������.+�5   
   �� -   5          ��Name$  inputEncrypt��5       $��20(�6   $
��Left=�66   $	��215��6Q   $	��100��6a   $��766,260,0,0q�6n    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��480��6�   �� 5   
   -   5         ��Name$ 
loadKeyBtn��5   g    � ToolTip$G AJeżeli klucz jest krótszy od wiadomości, to zostaje zapętlony��6   $��20(�6Y   $��Wczytaj klucz��6{   $
��Left=�6�   $��
766,68,0,0q�6�   $	��Top=�6�   $	��171��6�   $��58��6�   6�   �� 5   
   -   5         ��Name$ txtFile��5   i   $F @Plik zawierający znaki 0 lub 1, które symulują pojedynczy bit��6   $��20(�6[   ���	#FF224BB6$��z pliku tekstowego (.txt)��6�   $
��Left=�6�   $��
948,68,0,0q�6�   $	��Top=�6�   6�   �� 5   
   -   5        $ binFile��5   @   $ Dowolny plik binarny��6   $��20(�62   ���	#FF224BB6 d� 	IsChecked$
 TrueY�6h   $��z pliku binarnego (.bin)��6y   $
��Left=�6�   $��
948,96,0,0q�6�   $	��Top=�6�   $	��232��6�   6�   �� 5   
   ���	#FF224BB6$��20(�6,   $��Wejście��6:   $��766,220,289,391q�6I   �� 5   
   -   5        $  outputEncrypt��5   2    �� 
IsReadOnly . $��20(�6$   $
��Left=�6I   $	��215��6d   $	��100��6t   $��766,404,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��480��6�   �� 5   
   ���	#FF224BB6$��20(�6+   $��Wyjście��69   $��766,364,429,247q�6H   �� 5   
   ���	#FF224BB6$��20(�6+   $5��/Wpisz tekst do zaszyfrowania lub zaszyfruj plik��69   $��766,182,34,429q�6p   �� 5   
   -   5        $ loadFileEncrypt��5      $��Wczytaj plik��6*   $
��Left=�6A   $��766,508,0,0q�6\   $	��Top=�6q   $	��129��6�   $��36��6�   6�   �� 5   
   -   5        $ encryptFileBtn��5      $��Szyfruj plik��6)   $
��Left=�6@   $��906,508,0,0q�6[   $	��Top=�6p   $	��129��6�   $��36��6�   6�   �� 5   
   -   5        $ 
encryptBtn��5      $��Szyfruj tekst��6%   $
��Left=�6=   $��843,364,0,0q�6X   $	��Top=�6m   $	��129��6�   $��34��6�   6�   >   8CryptoDesktopApplication.LoadingControl.LoadingAnimation  5   
   -	   5          Name$ LoadingCircle��5   :   $y�	Collapsed=�6#   $��Center=�6Q   $��Center=�6n   $��82��6�   $��1144,522,37,41q�6�   $��99��6�   �� 5   
   -
   5         ��Name$ filenameInfo��5      ���	#FF224BB6$��12(�6B   $�� ��6P   $��766,552,245,76q�6X   � 5   
   -   5        	 �Name$	 inputFormat��5      $��820,181,34,387q�6$   .+�5      	� 
 � DataContext$
 ascii��6    	� 	GroupName$ inputFormat��6.   $
 TrueY�6F   $��163,46,208,0q�6W   .��5      �� $��ASCII��6   ���	#FF224BB66)   5      	� 5      $	
 hex��6   $ inputFormat��6,   $��223,46,152,4q�6D   .��5      �� $	��Hex��6   ���	#FF224BB66'   5       	� 5!      $
 base64��6   $ inputFormat��6/   $��279,46,82,2q�6G   .��5"      �� $��Base64��6   ���	#FF224BB6$��48��6A   5#      	� 5$      $
 unicode��6   $ inputFormat��60   $��
349,46,0,4q�6H   .��5%      �� $��Unicode��6   ���	#FF224BB66+   5&      5'      '  !MaterialDesignThemes.Wpf.PackIcon  5)   
   -   5          Name$ 
seriesTest��5)   �   $� |W normalnym zastosowaniu klucz jest generowany podczas szyfrowania, jednak dla potrzeb edukacyjnych wczytuje się go z pliku��6"   $��1189,68,0,520q�6�   ���	#FF2196F3�  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Information=�6�   $��81��6�   $��57��6  $��Center=�6  �� 5*   
   $��35(�6   ���	#FF224BB6$
��Bold"�69   $��Szyfr strumieniowy��6K   $��493,0,412,582q�6e   �� 5+   
   -   5        $ keyFileInfo��5+      ���	#FF224BB6$��12(�6@   $��766,150,10,476q�6N   � 5,   
   -   5        $	 outputFormat��5,      $��820,327,34,241q�6%   .+�5-      	� -   5        $
 ascii��5-   8   $ outputFormat��6L   $
 TrueY�6e   $��163,46,208,0q�6v   .��5.      �� $��ASCII��6   ���	#FF224BB66)   5/      	� 50      -   5        $	
 hex��50   6   $ outputFormat��6H   $��223,46,152,4q�6a   .��51      �� $	��Hex��6   ���	#FF224BB66'   52      	� 53      -   5        $
 base64��53   9   $ outputFormat��6N   $��279,46,82,2q�6g   .��54      �� $��Base64��6   ���	#FF224BB6$��48��6A   55      	� 56      -   5        $
 unicode��56   :   $ outputFormat��6P   $��
349,46,0,4q�6i   .��57      �� $��Unicode��6   ���	#FF224BB66+   58      59      �� 5:   
   -   5        $ keyFilenameInfo��5:      $�� ��6   ���	#FF224BB6$��12(�6L   $��766,131,10,495q�6Z   �� 5;   
   -   5        $ fileLengthInfo��5;      ���	#FF224BB6$��12(�6D   $�� ��6R   $��766,569,245,59q�6Z   �� 5<   
   $
��Left=�6   $��38��6+   $��171,221,0,0q�67   $	��Top=�6L   $	��223��6d   $B��</CryptoDesktopApplication;component/Images/streamcipher1.png��6p   �� 5=   
   $
��Left=�6   $��38��6+   $��171,366,0,0q�67   $	��Top=�6L   $	��386��6d   $B��</CryptoDesktopApplication;component/Images/streamcipher2.png��6p   �� 5>   
   $
��Wrap=�6   ���	#FF224BB6$��20(�6?   $��33,68,537,476q�6M   �� 6e   $�Szyfry strumieniowe tworz��6i   �� 6�   $�ą��6�   �� 6�   $O�I pseudolowy strumien bitów nazywanych strumieniem klucza. Aby zaszyfrowa��6�   �� 6�   $�ć��6�   �� 6   $� wiadomo��6  �� 6  $
�ść��6  �� 6&  $� strumie��6*  �� 6<  $�ń��6@  �� 6K  $$� klucza i tekst jawny podlegaj��6O  �� 6w  $�ą��6{  �� 6�  $� operacji XOR.��6�  �� 6�  �� 6�  �� 6�  �� 6�  6�  �� 5?   
   $
��Wrap=�6   ���	#FF224BB6$��20(�6?   $��33,181,537,429q�6M   $4��.Szyfrowanie wiadomości można opisać wzorem:��6e   �� 5@   
   $
��Wrap=�6   ���	#FF224BB6$��20(�6?   $��33,264,537,346q�6M   �� 6f   $4�.S oznacza bity klucza, a M bity tekstu jawnego��6j   �� 6�   $�.��6�   6�   �� 5A   
   $
��Wrap=�6   ���	#FF224BB6$��20(�6?   $��33,305,537,285q�6M   �� 6f   $X�RFunkcje szyfrowania i odszyfrowywania są takie same, odszyfrowywanie opisuje się��6j   �� 6�   $� ��6�   �� 6�   $�wzorem:��6�   6�   5B      5C      