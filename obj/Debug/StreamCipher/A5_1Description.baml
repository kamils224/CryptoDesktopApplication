   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null]3clr-namespace:CryptoDesktopApplication.StreamCipher%CryptoDesktopApplication.StreamCipher  5      ;    5CryptoDesktopApplication.StreamCipher.A5_1Description   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Elocal3clr-namespace:CryptoDesktopApplication.StreamCipher     5      $	��645��5      $
��1280��6   
�������.��5	      � .+�5
   
   �� $
��Bold"�6   $��35(�6&   ���	#FF224BB6  �� TextAlignment$  Center=�6K   $��-10,10,0,573q�6b   $��
Szyfr A5/1��6x   �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��
50,128,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $	��353��6�   $	��778��6�   �� 6�   $�   A5/1 ��6�   �� 6�   $Z�Tjest szyfrem strumieniowym, który był używany do szyfrowania telefoni komórkowej��6�   �� 6"  $S�M 2G. A5/1 korzysta z trzech rejestrów LFSR o długościach 19, 22 i 23 bity.��6&  �� 6z  �� 6�  �� 6�  �� 6�  $?�9Mechanizm aktualizacji rejestrów wygląda następująco:��6�  �� 6�  �� 6�  �� 6�  �� 6�  $1�+1. Sprawdzenie wartości dziewiątego bitu ��6�  �� 60  $
��Bold"�64  $�LFSR 1��6F  �� 6V  $�, jedenastego bitu ��6Z  �� 6w  $
��Bold"�6{  $�LFSR 2 ��6�  �� 6�  �� 6�  �� 6�  $�i jedenastego bitu ��6�  �� 6�  $
��Bold"�6�  $�LFSR 3��6�  �� 6�  $4�.. Wybrane bity nazywa się bitami taktowania (��6�  �� 62  $��Italic$�66  $�ang. clocking bits��6I  �� 6e  $B�<). Trzy wybrane bity mają zawsze tę samą wartość (0 lub��6i  �� 6�  $� 1��6�  �� 6�  $<�6) lub dokładnie dwa z nich mają tę samą wartość.��6�  �� 6�  �� 6  �� 6
  �� 6  $9�32. Następuje taktowanie rejestrów, których bity ��6  �� 6T  $���taktujące są równe przeważającej wartości 0 lub 1. Z tego wynika, że przy każdej aktualizacji są taktowane dwa lub trzy rejestry.��6X  �� 6�  �� 6�  �� 6�  �� 6  �� 6  �� 6  6   �� 5   
   $
��Left=�6   $	��413��6+   $��828,128,0,0q�68   $	��Top=�6M   $	��410��6e   $��/Images/A5_1.jpg��6q   �� 5   
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��50,67,918,522q�6i   $
��Opis��6�   �� 5   
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��50,486,701,103q�6i   $&�� Wielomiany dla każdego rejestru��6�   �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��
50,542,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $��84��6�   $	��529��6�   �� 6�   $�LFSR 1��6�   �� 6�   $� (19-bitowy)��6�   �� 6�   $�:	��6�   �� 6�   $�x��6�   �� 6�   $� ��6  �� 6  $�19��6   K� Variants$ Superscript=�6  �� 6?  $� ��6C  �� 6N  $�+��6R  �� 6]  $� ��6a  �� 6l  $�x��6p  �� 6{  $� ��6  �� 6�  $�18��6�  $ Superscript=�6�  �� 6�  $� ��6�  �� 6�  $�+��6�  �� 6�  $� ��6�  �� 6�  $�x��6�  �� 6�  $� ��6�  �� 6  $�17��6  $ Superscript=�6  �� 69  $� ��6=  �� 6H  $�+��6L  �� 6W  $� ��6[  �� 6f  $�x��6j  �� 6u  $� ��6y  �� 6�  $�14��6�  $ Superscript=�6�  �� 6�  $� ��6�  �� 6�  $	�+ 1��6�  �� 6�  �� 6�  $�LFSR 2��6�  �� 6�  $� (22-bitowy)��6�  �� 6  $�:��6  �� 6  $�	��6#  �� 62  $�x��66  �� 6A  $� ��6E  �� 6P  $�22��6T  $ Superscript=�6^  �� 6�  $� ��6�  �� 6�  $�+��6�  �� 6�  $� ��6�  �� 6�  $�x��6�  �� 6�  $� ��6�  �� 6�  $�21��6�  $ Superscript=�6�  �� 6�  $� ��6  �� 6  $	�+ 1��6  �� 6  �� 6+  $�LFSR 3 (23-bitowy):��6/  �� 6L  $�	��6P  �� 6_  $�x��6c  �� 6n  $� ��6r  �� 6}  $�23��6�  $ Superscript=�6�  �� 6�  $� ��6�  �� 6�  $�+��6�  �� 6�  $� ��6�  �� 6�  $�x��6�  �� 6�  $� ��6�  �� 6�  $�22��6�  $ Superscript=�6  �� 6,  $� ��60  �� 6;  $�+��6?  �� 6J  $� ��6N  �� 6Y  $�x��6]  �� 6h  $� ��6l  �� 6w  $�21��6{  $ Superscript=�6�  �� 6�  $� ��6�  �� 6�  $�+��6�  �� 6�  $� ��6�  �� 6�  $�x��6�  �� 6�  $� ��6�  �� 6�  $�8��6�  $ Superscript=�6  �� 6%  $� ��6)  �� 64  $	�+ 1��68  �� 6E  �� 6Q  6X  �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��828,541,0,0q�6T   $
��Wrap=�6i   $	��Top=�6}   $��84��6�   $	��442��6�   �� 6�   $4�.Rysunek przedstawia uproszczony schemat A5/1. ��6�   �� 6�   $3�-Wyjście każdego rejestru jest sumowane XOR.��6�   6$  5      5      