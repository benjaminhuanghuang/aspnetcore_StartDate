# Reference 
##Creating a .NET Core 1.1 MVC Web Application from scratch - Part 1 - Adding MVC to an Empty Project
    https://www.youtube.com/watch?v=y_J8geOgO-Y&list=PL7u53lOSm0rxzkpOsswWZS4SzhODcex-F

##Creating a .NET Core 1.1 MVC Web Application from scratch - Part 9 - Dating Profile Model Class
https://www.youtube.com/watch?v=9d6qJFVSbbw&t=44s

##Creating a .NET Core 1.1 MVC Web Application from scratch - Part 10 - Adding Scaffolding
https://www.youtube.com/watch?v=7ZUIP9y7VYw

##Creating a .NET Core 1.1 MVC Web Application from scratch - Part 11 - Edit profile, upload picture
https://www.youtube.com/watch?v=g1nJBtKzz7w&list=PL7u53lOSm0rxzkpOsswWZS4SzhODcex-F&index=11

### Inject auth checking into pages
     Modify _Layout.cshtml
     Display / Show menu 

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

