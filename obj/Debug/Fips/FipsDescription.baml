   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:CryptoDesktopApplication.FipsCryptoDesktopApplication.Fips  5      3    -CryptoDesktopApplication.Fips.FipsDescription   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:CryptoDesktopApplication.Fips     5      $	��645��5      $
��1280��6   
�������.��5	      � .+�5
   
   �� $
��Bold"�6   $��35(�6"   ���	#FF224BB6$��Center=�6G   $��-10,0,0,594q�6k   .��6�   TESTY FIPS 140-25      �� 5   
   ���	#FF224BB6$��20(�6+   $
��Left=�69   $��	63,56,0,0q�6T   $
��Wrap=�6g   $	��Top=�6{   $���� W standardzie FIPS 140-2 rekomenduje się 4 testy statystyczne badania losowości ciągu. W każdym teście przyjmuje się, że badana próbka ma długość 20 000 bitów.��6�   $
��1102��6<  �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��
63,165,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $��33��6�   $	��739��6�   �� 6�   $U�OLiczba n jedynek w badanym ciągu powinna spełniać warunek: 9725 < n < 10 275��6�   �� 6  $�.��6  �� 6  �� 6(  $� ��6,  67  �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��
63,240,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $	��109��6�   $	��892��6�   ��Seria - maksymalny podciąg następujących po sobie zer albo jedynek. Dla próbki należy wyznaczyć liczbę wystąpień serii o długości n>1 dla zer i dla jedynek osobno. Test zakończy się sukcesem, jeśli liczba seri o długości 1 do 6 (serie o długości większej niż 6 są traktowane jako serie o długości 6) mieści się w przedziałach wyspecyfikowanych w tabeli obok.6  �� 5   
   $
��Left=�6   $	��293��6+   $��
988,93,0,0q�68   $	��Top=�6L   $	��267��6d   $��/Images/fipsTable.jpg��6p   �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $
��Wrap=�6T   $	��Top=�6h   $��
63,475,0,0q�6�   $
��1192��6�   �� 6�   $���Badaną próbkę dzielimy na 5000 segmentów 4-bitowych. Następnie liczymy ilość wystąpień każdej z 16 możliwych 4-bitowych wartości. Niech s(i), 0 <��6�   �� 6D  $�=��6H  �� 6S  $� ��6W  �� 6b  $�i ��6f  �� 6r  $� <��6v  �� 6�  $�=��6�  �� 6�  $@�:15, oznacza liczbę wystąpień swgmentów o wartości i. ��6�  �� 6�  �� 6�  $�
Wówczas: ��6�  6�  �� 5   
   $
��Left=�6   $��57��6+   $	��Top=�68   $	��315��6P   $��/Images/pokerFormula.PNG��6\   $��
63,560,0,0q�6~   �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $
��Wrap=�6U   $	��Top=�6i   $	��535��6�   $��407,574,0,0q�6�     J� RenderTransformOrigin$  0.5,0.5&�6�   z�5      V� 5      .~�5      �� �� 5      �� 5       �� Angle$ 0.164Q�6&   T� 5      5      �� 5   *   $�Test zakończy si��6.   �� 6H   $+�%ę sukcesem, jeśli 2,16 < X < 46,17.��6L   �� 6   $� ��6�   6�   �� 5   
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��26,109,362,480q�6i   $��Test pojedynczych bitów��6�   �� 5   
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��26,189,357,405q�6i   $��
Test serii��6�   �� 5   
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��26,349,357,240q�6i   $��Test długiej serii��6�   �� 5   
   $��20(�6   ���	#FF224BB6$
��Left=�69   $��
63,391,0,0q�6T   $
��Wrap=�6h   $	��Top=�6|   $��33��6�   $
��1192��6�   �� 6�   $�Długa seria��6�   �� 6�   $� ��6�   �� 6�   $��{- seria zer albo jedynek o długości 26 lub więcej. Test zakończy się sukcesem, jeśli w próbce nie ma długiej serii.��6�   6X  �� 5    
   $
��Bold"�6   $��30(�6"   ���	#FF224BB6$
��Left=�6G   $��26,424,357,170q�6i   $��Test pokerowy��6�   5"      5#      