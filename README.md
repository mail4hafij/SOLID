# HelloWorld

There are 7 projects. 


API 
  - The contract.
  - ServiceFactory to determine which service end points (WCF, WCFIIS, DEV) to listen to via http or tcp protocol.


SRC
  - Default implementation of the API contract.
  - UnitOfWork, Databases, Repositories, Logics, Mappers, etc. 
  - Depends on API.


WCF 
  - Host a WCF service to expose SRC via http or tcp protocol.
  - Depends on API, SRC.
  
  
WCFISS 
  - IIS hosted WCF service. (At the moment it is not exposing SRC). Only some dummy implementation of the API contract.
  - Depends on API, SRC.
  
  
DEV
  - This is the developers page. It has a reference to SRC and route all api requests internally to SRC.
  - Depends on API, SRC.
  

RESTAPI
  - This is the restful API implentation project. It can listen to WCF / WCFIIS / DEV.
  - Depends on API.
  

WEB 
  - This is the public website. It can listen to WCF / WCFISS/ DEV.
  - Depends on API.
  
  
How to run locally: Make sure to update the connection strings in WCF, DEV with your local database host address. Create two databases "HelloWorld" and "LoremIpsum". Create tables Cats, Dogs, and Tigers. Populate some default data.
