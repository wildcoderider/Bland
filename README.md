# Bland

  

- To run the Angular Project you must install angular and node, go in the console to the folder BlandGroupAgeAngular and run ng serve --open. Then you must run the BlandGroupApi from visual studio as well.

- BlandGroup project contains a console app with the 2 first exercises. Palindrome and Quicksort.

- The BlandGroupApi provides Services for the Exercises 3, 4 and 5. From the controller, you can query the Plates, accept the files input and also has its endpoint for the Angular app for the age.

- BlandGroupCamera contains the console app that reads the camera files and stores the info in db.
I only wrote the feature for the real time drop of the files, but did not write the functionality to iterate through the existing ones.

- I am a Mac user so I did not create a windows service, since I can only run it from a Windows Machine, unless I would install some windows virtual machine. Instead I created a console app that watches for the files. Other solutions would be to create a .net Background service.

- Also there is not local Azure Storage for Mac, so I provided the configuration of the connection string to a real Azure Storage account.

- BlandGroupShared - Contains all the EF implementation which at this point I am having some issue for running the command dotnet ef database update, so I can not create the database and run the migrations. And test the features that require a db.But the implementation is there.

- Unittests project contains the unit tests for all the exercises.

- I could also implemented the Repo patter for ef, and return some genericApiResponses from the controllers but I did not want to over complicate the insfraestructure.