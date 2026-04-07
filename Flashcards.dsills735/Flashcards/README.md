# Flashcards 
This app is a Console app that will allow users to create and manage stacks of flashcards. Flashcards are managed through a stacks and flashcards table linked via foreign key. In this app you can add, delete, and quiz yourself on flashcards. You can also see your history for each stack. 

**Tech used:** C#, MSSQL, SQL Server Managment, VS 2026, Spectre, Dapper

I used C# along with Dapper and Spectre to design the application. SQL, Dapper ORM, MSSQL and SQL Server management was used to manage the database. I really enjoyed using Spectre more and learning more about how to create a vibrant and pleasant user interface with it!

## Optimizations

I would like to enhance the user experience and allow a more seamless use of the interface, being able to add/delete/change cards from the study session would be great. I also would like to streamline the areas where cards are created, as the process seems very convoluted to me as it sits now. I would also like to streamline the SQL management, as the single class for that quickly got out of hand. 


## Lessons Learned

I learned a ton throughout this process. This was my first real introduction to object mapping, and DTOs. Those felt overly complicated when I started, but quickly became something that felt easy, and very intuitive. 
I also expanced on my SQL usage from my previous project (Coding Tracker, found here: https://github.com/DSills735/CodingTracker). In that project I did a similar thing with my SQL storing them all in one class. 
It worked well on that project with a limited number of queries, but on this project it started to get really confusing. I would like to organize this better in the future, maybe create a class per type of query, or create a SQL class within each namespace. I really thoroughly enjoyed the challenges intorduced to me on this project!

The more I work on this project, the more I realize the importance of sticking with a single naming convention. Nearning the end of the project, I was struggling with some of the names I created. I will definitely put more time and thought into on the next project I do. 

During this project I started taking notes on issues I encountered, and the solutions I found. Not sure if this will help me in the future or not, but seems like a best practice as of now. It has helped me a few times already in the short term, so I think this will be really valuable. 

## Reflections

I think for me, the most obvious thing is identifying a naming convention and sticking to it. Also naming my functions better would be excelent and create less confusion for me near the end of the project. When I was finishing up the study and history section I spent more time clicking around trying to find the right file. That cant happen, and wont happen again hopefully. 

Also this is a tough one, since the project was required to be a console app, but in my opinion, this project needed to have a GUI. Navigating an app this complex feels like a chore (or maybe its just bad UI design). I felt I cleaned it up the best I could, but im sure it could improve. 


## Project Requirements


 - You'll need two different tables for stacks and flashcards. The tables should be linked by a foreign key.

 - Stacks should have an unique name.

 - Every flashcard needs to be part of a stack. If a stack is deleted, the same should happen with the flashcard.

 - You should use DTOs to show the flashcards to the user without the Id of the stack it belongs to.

 - When showing a stack to the user, the flashcard Ids should always start with 1 without gaps between them. If you have 10 cards and number 5 is deleted, the table should show Ids from 1 to 9.

 - After creating the flashcards functionalities, create a "Study Session" area, where the users will study the stacks. All study sessions should be stored, with date and score.

 - The study and stack tables should be linked. If a stack is deleted, it's study sessions should be deleted.

 - The project should contain a call to the study table so the users can see all their study sessions. This table receives insert calls upon each study session, but there shouldn't be update and delete calls to it.


 ## RUN INFORMATION

 This ran in a console app, so you will need to clone the repo and run it in your terminal. You will also need to have SQL Server Management Studio and MSSQL installed to manage the database.
 Upon running the app, you will be prompted with a menu. You can navigate through the menu to create stacks, add flashcards, and quiz yourself on the flashcards. You can also view your study history for each stack.
 The connection string for the database is currently set to a local database entitled Flashcards, so you will need to create that database in your SQL Server Management Studio before running the app.
 You can also change the connection string in the appsettings.json file to point to a different database if you prefer.