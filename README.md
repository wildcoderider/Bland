# Bland

- First of all you will need to create the BlandGroup database with blandgroup password. Remove the migrations and add run ef tools in a console as I indicate here: dotnet ef migrations add Initial. Then to run the migrations type: dotnet ef database update.  

- To run the Angular Project you must install angular and node, go in the console to the folder BlandGroupAgeAngular and run ng serve --open. Then you must run the BlandGroupApi from visual studio as well.

- BlandGroup project contains a console app with the 2 first exercises. Palindrome and Quicksort.

- The BlandGroupApi provides Services for the Exercises 3, 4 and 5. From the controller, you can query the Plates, accept the files input and also has its endpoint for the Angular app for the age.

- BlandGroupCamera contains the console app that reads the camera files and stores the info in db.
I only wrote the feature for the real time drop of the files, but did not write the functionality to iterate through the existing ones. To test it you will need to create the db first, then change the path to your local CameraPlates folder inside this project and drop any ltr file inside. Then you can query it by running the Api with Swagger.

- I am a Mac user so I did not create a windows service, since I can only run it from a Windows Machine, unless I would install some windows virtual machine. Instead I created a console app that watches for the files. Other solutions in Mac would be to create a .net Background service, that simulates a windows service.

- Also there is not local Azure Storage for Mac, so I provided the configuration of the connection string to a real Azure Storage account.

- Create a "BlandGroup" database name with a password "blandgroup". Then delete the Migrations folder. To add the migrations navigate to the BlandGroupApi project through the console and type: dotnet ef migrations add Initial. Then to run the migrations type: dotnet ef database update. 

- Unittests project contains the unit tests for all the exercises.

- I could also implemented the Repo patter for ef, and return some genericApiResponses from the controllers but I did not want to over complicate the insfraestructure.