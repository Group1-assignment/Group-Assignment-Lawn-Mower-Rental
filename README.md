# LawnMower Rental Assignment
This is a group effort of Thord, Bledon, Sneha and Mohammed to create a console app that manages the rentals of LawnMowers
## what we currently have:
A working console app that can process:
- registering a customer
- processing and applying a rental to a customer
- displaying currently renting customers and their rental details
- displaying the stock values of all different items for rental
- returning a rental

The app has a list of Customer objects which each holds a list of Rentals. Each rental holds a LawnMower object for now which is inherited by an abstract class RentalItem.
We currently have the class working for different LawnMower models, but we still need to implement a way of choosing which model to rent in the console.

## What we need to do/are doing
Here are some things we are working on
### Bledon
Works on the Customer classes to feature prime and basic Customers. The current plan is to have new classes that inherit the original Customer class, with properties or methods of info related to how rentals should be processed.
### Sneha
Has worked on the new LawnMower classes with different model and is now working on implementation of processing a rental and choosing different types of models in the console. in the ProcessRental() method.
### Thord
Has designed much of the architecture we are currently working on and assists the others and keeps an eye of the direction the project goes.
