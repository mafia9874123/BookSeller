# BookSeller

TOPIC: 
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
John Doe owns a book reseller store. The store allows users to purchase books from multiple partner stores. John is about to create an online service that would allow users to order books online. A website developer John works with, suggests creating a Single Page Application. The developer is ready to do the implement the site, but he needs an API to integrate with. 
You have been asked to develop a REST API for the site. 
The background you were given. John currently works with 2 stores, Store A and Store B. Both stores provide a list of available books via XML files, files are sent daily via email. Files formats are different. Properties each book has a name, author, ISBN code, number of books left in stock, and unit price in USD. Orders are created as raw text files in the site directory. Each file contains the ISBN code, of an ordered book and user email. The API methods you need to create: 
1.	A method to return a list of available books: 
  -	ISBN code 
  -	Book name 
  -	Author 
  -	Price range: minimum and maximum price 
  -	Total number of books left in stocks 
2.	A search method to find a book by containing string. It returns the data in the same format as method 1 
3.	A method to return information about a specific book: 
  -	ISBN code 
  -	Book name 
  -	Author 
  -	Book price and availability per store 
    +	Store identifier 
    +	Store name 
    +	Price 
    +	Number of books in stock 
4.	A method to create an order for a specific book from a specific store: 
  -	ISBN code 
  -	Store identifier 
  -	Contact email 
John is keen to run the site as soon as possible but would like you to think (or even implement!) about: 
1.	Automated testing 
2.	API Security, especially of the 4th method 
3.	Architecture scalability as he’s about to sign contracts with more stores with other information exchange formats 
4.	Performance  
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Explain solution:
There are 4 REST API method have been implemented following describe:
- api/Book/CreateOrder: Method will use to to create a file which is store Order information. File store following format ddMMyyyy_HHmmss.xml in path which is defined in OrderConfiguration/Path (see sample in appsettings.Development.json)
- api/Book/GetAll: Method will use to to create a file which is store Order information. File store following format ddMMyyyy_HHmmss.xml in path which is defined in OrderConfiguration/Path (see sample in appsettings.Development.json)
- api/Book/GetBook/{id}: Method will use to to create a file which is store Order information. File store following format ddMMyyyy_HHmmss.xml in path which is defined in OrderConfiguration/Path (see sample in appsettings.Development.json)
- api/Book/Search: Method will use to to create a file which is store Order information. File store following format ddMMyyyy_HHmmss.xml in path which is defined in OrderConfiguration/Path (see sample in appsettings.Development.json)

Please follow Book.postman_collection.json to have example
