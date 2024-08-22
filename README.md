# Welcome to our Books store

## How to use our project:

In order to run this project you need:  
VS 2022 version (and on).  
.net 8 (and on).  
DB- SQL server.  

For creating the DB, you can use code-first abilities.  
All what you need is:  
Open your package manager console,  
Write: `add-migration [DataBaseName]`  
and then: `Update-Database`.  

And the DB is ready for use!  

## About our project:

The project represents a Books store.  

It includes a login page, when the user gets an option of registering in case of new user.  
After a successful login, you get to a page that offers you to update your user details, or getting into the store.  
In the store page you can add products to your cart, that is saved in the session storage.  
There is an option of filtering the products that you see using category, words from product description, minimum price or maximum price as parameters.  
You can click and go to your cart page, where you can see your cart, remove products from it, and save your order.  

Our project in .net8, written by web API .net core and follows the REST architecture principles.  
We used SQL server database.  
We used ORM of Entity Framework by database first.  

We have maintained password strength using the nuget package `zxcvbn-core`.  

The struct's project made from layers who connect between them with Dependency Injections, in order to earn the advantages of the DI as making the application more encapsulated and flexible,  
Enables parallel development, decoupling between the class and its dependencies.  

We used Asynchronous function for adding Scalability.  

We have a swagger that describes our project structure, if you want to, you can use it by the path: `localhost:[PORT NUMBER]/swagger` and see everything documented neatly.  

We used DTO's layer for in order of preventing circular dependency.  

The project maps the objects using package `AutoMapper`.  

We used configuration files for saving sensitive and unconstant data.  

We kept on logging.  
The Logger sends an email if exception or error occurs and saves information in a dedicated file.  

We created middlewares for Handling errors and for Rating our site.  
The rating data saves in a table in the DB.  

In addition, we added tests of the two common types: unit test, integration test.  
So that we can monitor the correctness of the code.  

Hope you enjoyed reading and benefited from it.
