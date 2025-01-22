Exercise 2:

1. In Models Create a model of an Attraction calles csAttraction

    Attraction shall have a name (string) and List of Comments (List<string>) , 5-20.
    Use csSeeder to seed an instance of csAttraction.

2. In Controllers.csAdminController 

    Create a new WebApi endpoint Attractions
    A call to the endpoint shall carry a parameter count and return a seeded list of csAttraction
    with count nr of Attraction

3. Create a service csTravelService, with a method, Attractions(int count), that delivers the list of Attractions
   Modify Controller enpoint to use the service

4. Use Dependency Injection to inject the ITravelService into the controller and use it in the endpoint.
   In program.cs use DI to couple ITravelService with csTravelService

