   M S B A M L   `   `   `  ����S  OCryptoDesktopApplication, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:CryptoDesktopApplication.MainPages"CryptoDesktopApplication.MainPages  5      5    /CryptoDesktopApplication.MainPages.Instructions   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Blocal0clr-namespace:CryptoDesktopApplication.MainPages     5      $	��645��5      $
��1280��6   .��5	      � 
�������.+�5
   
   �� $
��Bold"�6   $��35(�6"   ���	#FF224BB6$��Center=�6G   $��
0,10,0,578q�6k   $��Instrukcja użytkowania��6   �� 5   
   $
��Bold"�6   $��24(�6"   ���	#FF224BB6$
��Left=�6G   $��10,92,917,510q�6i   $#��Zakładka "Generatory - opis"��6�   �� 5   
   $��20(�6   ���	#FF224BB6$��69,135,181,474q�6:   $f��`Zawiera teoretyczne informacje o zaimplementowanych generatorach wykorzystujących rejestr LFSR.��6R   �� 5   
   $
��Bold"�6   $��24(�6"   ���	#FF224BB6$
��Left=�6G   $��10,170,869,432q�6i   $)��#Zakładka "Generatory - działanie"��6�   �� 5   
   $
��Wrap=�6   $��20(�6(   ���	#FF224BB6$��69,354,42,198q�6M   $����Zawiera opis oraz przestawienie działania szyfru strumieniowego. Umożliwia wczytanie ciągu pseudolosowego jako klucza i użycie go do zaszyfrowania tektu z konsoli lub z pliku. Dodatkowo posiada opis oraz implementację szyfru A5/1 wraz z możliwością konfiguracji rejestrów LFSR.��6d   �� 5   
   $
��Bold"�6   $��24(�6"   ���	#FF224BB6$
��Left=�6G   $��10,306,869,296q�6i   $%��Zakładka "Szyfry strumieniowe"��6�   �� 5   
   $
��Wrap=�6   $��20(�6(   ���	#FF224BB6$��69,213,42,339q�6M   �� 6f   $���Zawiera implementację generatorów z możliwością konfiguracji rejestrów i wielomianów. Ciąg wyjściowy jest zapisywany w konsoli w formacie znaków lub Base64, któ��6j   �� 6  $:�4ry umożliwia łatwe przenoszenie danych binarnych. ��6  �� 6T  $[�UMożliwe jest także zapisanie stworzonego ciągu do pliku tekstowego lub binarnego. ��6X  �� 6�  $/�)Dla ciągów o długości powyżej 20 000��6�  �� 6�  $2�, automatycznie są przeprowadzane testy FIPS��6�  �� 6  $� ��6#  �� 6.  $�140-2��62  �� 6A  $�.��6E  6Q  �� 5   
   $
��Bold"�6   $��24(�6"   ���	#FF224BB6$
��Left=�6G   $��10,452,869,150q�6i   $��Zakładka "Testy FIPS"��6�   �� 5   
   $
��Wrap=�6   $��20(�6(   ���	#FF224BB6$��69,500,42,74q�6M   $����Zawiera opis oraz implementację testów FIPS 140-2. Umożliwia przetestowanie wygenerowanych ciągów pseudolosowych lub dowolnego zewnętrzengo pliku. Po przeprowadzonym teście wyświetla szczegółowe wyniki.��6c   5      5      