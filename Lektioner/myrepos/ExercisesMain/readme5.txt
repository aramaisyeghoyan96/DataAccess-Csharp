Create a new GitBranch DnRepos

Create a new project DbRepos
	Add a class csAnimalRepo
	Move the public methods AfricanAnimals and Seed into csAnimal Repo
      Create an interface IAnimalRepo that contains the public methods from csAnimalRepo 
	Have csAnimalRepo implement IAnimalRepo

Refracture csAnimalService to use Methods in csAnimalRepo 1:1
Add a constructor to csAnimalService that injects a repo of type IAnimalRepo

In program.cs  initialize DI to inject a scoped csAnimalRepo when IAnimalRepo is used as constructor parameter.

Build and run