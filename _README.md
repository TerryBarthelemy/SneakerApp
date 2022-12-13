# SneakerHub
This project is an E-Commerce Website for selling merchandise such as sneakers and clothes.

The technologies used were: MVC .NET CORE, C#, SQL, HTML, CSS, JavaScript

In .NET CORE, You do not need to design the database prior to creating your app. It has a 
function called "Code First Approach" where you set the model classes as you would in 
a database. I scaffolded the database so I could have CRUD functionality. To create, read, 
update and delete, I used DataTable API to manage what was in the database. The API came 
with a search, pages and multiple sort options. The Unit of Work design pattern was used 
in this project to be able to reuse redundant functionality such as CRUD. Nuget Packages
such as Identity is also used in this project to create users and accounts for SneakerHub.
Stripe API was implemented so users can make payments to purchase items. 

There were 4 roles who could access SneakerHub : Individual, Company, Employee, Admin

* Individuals HAVE to purchase item if they want it to be delivered.
* Companies can order an item and have 30 days to make payment.

Individual: Create an account. Browse the main pages. Purchase items.

Company: Create an account. Browse the main pages. Purchase items.

Employee: Create an account. Browse the main pages. Purchase items. Can control workflow.
If an individual or company call the employee to cancel an order or make a payment. The 
employee has the control to make that decision. 

Admin: Create an account. Browse the main pages. Purchase items. Create, Read, Update, 
Delete any product or user in the database. The admin has all round access to all reources
SneakerHub

