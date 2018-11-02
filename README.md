# Administration modul for Embedded Stock
## How to access
Link here
## Assignment
#### Purpose:
To demonstrate fulfilment of the learning objectives:
- Explain the principles for using a MVC framework in a web server
- Design and implement a web site that include persistence of data in a database
- Basic knowledge regarding hosting of web applications including cloud based hosting
#### Technology requirements
The web app must use ASP.Net Core as MVC framework, Razor as view engine and must use Entity
Framework Core to access a SQL database. It is recommended to use Azure as Cloud provider.
#### Description of the problem domain
The electronic shop at ASE uses a database to keep track of its stock of electronic components. The staffs
in the electronic shop uses a PC-program to maintain this database, and students can browse the database
with a web app (https://stockmanager.ase.au.dk/).
The staff wises to use other platforms (e.g. an iPad) to maintain the database, so the goal for this assignment
is to develop the first iteration of the new administration module for Embedded Stock.
You can see in the model classes on the last page which data that must be stored in the database. Notice
that a component type can belong to more than one category (which complicates the design).
The application should include user registration and login, and only users with the admin role is allowed to
add new Categories, ComponentTypes or Components.

#### Userstories to implement
[ ] Create component category
As a staff member, I can create a new component category

[ ] Delete component category
As a staff member, I can delete a component category

[ ] Update component category
As a staff member, I can update a component category

[ ] Create component type
As a staff member, I can create a new component type

[ ] Delete component type
As a staff member, I can delete a component type

[ ] Update component type
As a staff member, I can update a component type

[ ] Create component
As a staff member, I can create a new component

[ ] Delete component
As a staff member, I can delete a component

[ ] Update component
As a staff member, I can update a component

[ ] List component types for a category
As a staff member, I can see all component types for a chosen category

[ ] List components for a component type
As a staff member, I can see all components for a chosen component type