

## Create ViewModel

## Create View

## Create Database
 $ dotnet ef migrations add Initial
 $ dotnet ef database update 


## Client side validation
add js package in bower.json
add js fine into _Layout.cshtml

## ViewStart an ViewImport

## Add model and update database
 $ dotnet ef migrations add Profile
 $ dotnet ef database update 
 Because user has a profile as FK, we need remove all existed user before update database

 $ ef migrations remove  # Undo action  


## Add auth check on pages
    Modify _Layout.cshtml