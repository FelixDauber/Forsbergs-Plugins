
Created by:
Felix Dauber
Ruben Rådelius
Ozan Ugur Öztürk


-----------------------------------------------------------------------
-------------------------List Menu Plugin------------------------------
-----------------------------------------------------------------------



Made to simplify the setup and usage of menus

In order to set up a menu you have to have two scripts on the same gameObject.
Menu and MenuSpawner.

Set up the desired menu in the Menu script by adding a menu with the NewMenu button and add at least one button to that new menu.

Afterwards set up the menuSpawner by providing it with a button prefab.

*The button prefab has to have unity's button component and this plugin's buttonObject attached to it.
*Any menues added to the Menu script after the first one automatically recieves a back button which returns the user to the menu located at the top of the list.