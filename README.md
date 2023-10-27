# LawnMower Rental Assignment
This is a group effort of Thord, Bledon, Sneha and Mohammed to create a console app that manages the rentals of LawnMowers
## what we currently have:
A working console app that can process:
- registering a customer, with added prime or basic mechanics
- processing and applying a rental to a customer, with added lawnmower models and their stats
- displaying currently renting customers and their rental details
- displaying the stock values of all different items for rental
- returning a rental

The app has a list of Customer objects which each holds a list of Rentals. Each rental holds a LawnMower object for now which is inherited by an abstract class RentalItem. Lawnmower class was then expanded with enums to decide different models. Customer class uses only a bool to decide if its prime or basic. We wanted to implement Customer with inheritence first, but realized that a customer might want to be able to upgrade or downgrade with the mentioned subscription. Therefore it didnt feel practical to have to create and delete objects everytime that happens.

## What we have done
Here are some things we are working on
### Bledon
Worked much with the customer class and console 
### Sneha
Worked much on the Lawnmower class and console
### Thord
Has designed much of the object oriented architecture, assisted the others when asked for and kept an eye of the direction the project goes.
