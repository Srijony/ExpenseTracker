# ExpenseTracker

# Expense Tracker

In this system, user can track their daily expenses.
Expenses can be differenciate with different expense categories.
By this system anyone can easily track their daily expenses and save money.

# What is used in this project

**Language :** C#

**FrameWorks :**  
  - ASP.NET Core MVC.
  - ASP.NET Core Framework 6.
  - Entity Framework Core.
  - Bootstrap 5 CSS Framework.


**Server:** MS Sql Server.

**Approach :** Code-First approach of system development. 


**Architecture :**  Repository pattern
## How to Run

To run tests, run the following command

```bash
  1. Download the Project.
  2. Open the project in Visual Studio 2022.
  3. Go to appsettings.json and change the ConnectionString accoriding to your  MS SQl Server.
  4. In Visual Studio go to ,
        Tools-> NuGet Package Manager-> Package Manager Console.
  5. In Package Manager Console, write update-database
  6. Build the project.
  7. Run the project.
```


## How To Use

This project is used by the following companies:

- In the browser, Click on the ```Expense Category ``` then click on the ```Create New ``` Button to create a Expense Category.
- Give a name to the Expense Category.

- By Clicking on the ``` Edit ```, ```Delete``` button Expense Category Name can be edited or deleted.
- Click on ```Home ``` then click on the ```Create New ``` Button to create a Expense.

- Fill the ```Date Of expense```(Only two days from TODAY will be show), ``` Expense Amount ```, ```Expense Category``` field to Create a expense.

- In the screen, a list of expense will be shown.

- Each expense can be Edit or Delete By Clicking on the ``` Edit ```, ```Delete``` button.

