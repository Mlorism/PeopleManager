   M S B A M L   `   `   `  ����H  DPeopleManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PeopleManager.ViewsPeopleManager.Views  5      C&clr-namespace:PeopleManager.ViewModelsPeopleManager.ViewModels  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5      $    PeopleManager.Views.PeopleView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:PeopleManager.Views     5      5vm&clr-namespace:PeopleManager.ViewModels     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        N� Title$  
PeopleView��5      .��5      � 
������� � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6   �� 5      $
��auto �6   .+�5   
   �� $��0��6   $��5q�5      $��Center=�5      $
��Bold"�5      People List5      �� 5"   
   $��1��6   $��1q�5#      
���   � �� Padding$ 5q�5%      $��Center=�5&      ._�5'      &   System.Windows.Controls.DataGrid  -   5          Name$ PeopleTable��5'         AutoGenerateColumns$ False��5)         CanUserAddRows$
 True��5*      $��Center=�5+         SelectionMode$ Single=�5,      ��5(      �� *People+   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$ 
First Name��6)      basic-column-header	   HeaderStyle#	 [  52   )     row-content-center1  +System.Windows.Controls.DataGridBoundColumn
   ElementStyle#
 [ 53   )      Binding 51   )   �� *	FirstName+53   )     54      $ 	Last Name��6)   #	 [  56   )   #
 [ 57   )    55   )   �� *
LastName+57   )     58      $ Street��6)   #	 [  5:   )   #
 [ 5;   )    59   )   �� *
StreetName+5;   )     5<      $ House nr��6)   #	 [  5>   )   #
 [ 5?   )    5=   )   �� *HouseNumber+ �� StringFormat$ {0:0;;#}��5?   )     5@      $ Apartment nr��6)   #	 [  5B   )   #
 [ 5C   )    5A   )   �� *ApartmentNumber+$ {0:0;;#}��5C   )     5D      $ 	Post Code��6)   #	 [  5F   )   #
 [ 5G   )    5E   )   �� *
PostalCode+5G   )     5H      $
 Town��6)   #	 [  5J   )   #
 [ 5K   )    5I   )   �� *Town+5K   )     5L      $ Phone��6)   #	 [  5N   )   #
 [ 5O   )    5M   )   �� *PhoneNumber+5O   )     5P      $ Dathe of Birth��6)   #	 [  5S   )   #
 [ 5T   )    5Q   )   �� *DateOfBirth+$ 	yyy-MM-dd��5T   )     5U      $	 Age��6)      
IsReadOnly$
 True��5V   )   #	 [  5X   )   #
 [ 5Y   )    5W   )   �� *Age+5Y   )   4  .System.Windows.Controls.DataGridTemplateColumn  5Z         CellTemplate 5[      �� 5\       �� DataType$ vm:PeopleViewModel��6+   .R�5]   "   �� -   5        $��Delete��5]   )     btn-outline-red#��[ 5^   )   $��5 2 5 2q�5_   )   ��5`   )   ��  �� Path$ DataContext.DeleteCommand� �� RelativeSource ��  �� AncestorType"  ��5b   )   �� 5c   )   5d      5f      5i      5j      �� 5q   
   $��2��6    �� Orientation$ 
Horizontal=�5r      $��Center=�5s      .+�5t      �� -   5         ��Name$ btnSave��5t      $
��Save��5u        btn-outline-green#��[ 5v      $��5q�5w      $	��100��5x      ${�False��5z      ��5y      �� *SaveCommand+5{      �� 5|      -   5        $ 	btnCancel��5|      $��Cancel��5}        btn-outline-orange#��[ 5~      $��5q�5      $	��100��5�      ${�False��5�      ��5�      �� *CancelCommand+5�      5�      �� 5�   
   $��3��6   $��Right=�5�      $��5q�5�      ��5�      �� *LoggedInUser+5�      5�      