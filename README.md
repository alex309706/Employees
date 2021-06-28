# Employees
Implement a simple class that will be used as ORM for an in-memory database (class with List<Employee>) using any programming language. Don’t need to make a connection with a real SQL database and write SQL queries.
You need to:
create Employee class with following attributes
Id
FirstName
LastName
Age
Birthday
Position
StartDate
Email
create a class that will represent an in-memory database (class with List<Employee>) and store the table in the memory. In our case it will be list of Employee;
create class that will represent ORM with following methods:
save(FirstName, LastName, Age, Birthday, Position, StartDate, Email)
update(Id, FirstName, LastName, Age, Birthday, Position, StartDate, Email)
delete(Id)
findById(Id)
listByPosition(Position)
listAllSortByAge()
findBornAfter(Date)
findByFullName(Fullname)
listStartDateThisYear()
