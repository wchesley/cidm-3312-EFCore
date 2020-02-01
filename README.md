# CIDM 3312 Homework 2 – Entity Framework Core Part 1


Create a C# app using Entity Framework Core that will store patient records for the West Texas Sanatorium. Your app should meet the following requirements:
1. The app should be a console app with Entity Framework Core using a SQLite database.
2. Create a model to store the patient’s first name, last name, age, gender, admittance date, and whether or not they have had an examination with the doctor. Use the appropriate data types.
3. User should be able to add a new patient along with all the information from step 2 to the database. Put this functionality in a separate method that you call.
4. User should be able to list all patients. This should print out every patient and their information to the console. Use a separate method.
5. User should be able to update a patient record and change any of their information from step 2. Use a separate method.
6. User should be able to remove a patient from the database. Use a separate method.
7. You do not need to validate user input…yet.
8. The following patient records should already be stored in the database at the start:


 First Name | Last Name | Age | Gender | Admit Date | Had Exam? 
---|---|---|---|---|---
 Roxie | Hart|  34| F| 5/28/1924 | Y
Grace | Bertrand | 24 | F | 1/15/1939 | Y
 Harold | Hill | 52 | M |  7/1/1943 | N 
Herman | Dietrich | 47 | M | 9/12/1936 | Y 


## Useful Entity Framework Core Tutorials:
- https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite
- https://docs.microsoft.com/en-us/ef/core/saving/basic
We will create the database with `db.Database.EnsureCreated()` instead of migrations. **Migrations will be introduced later.** 

 Please remember to comment your code.
Homework is meant to be completed INDIVIDUALLY. Cheating or copying on a homework will result in a ZERO for the assignment and at the professor’s discretion, a zero for the entire course.
###  Homework 2 Due Date: Thursday February 6, 2020 by 11:00 PM
## How to submit:
1. Navigate to your project folder in Windows Explorer or the U: drive or wherever you saved your project and find the folder named for your Visual C# Project.
2. Compress or zip the entire folder into one zip file. You can right click on the folder and click Send To ➔ Compressed (Zipped) Folder
3. Upload the zipped file to the appropriate WTClass Drop Box.