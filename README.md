# WebAPI
## Installation

Clone the repo
   ```sh
   git clone https://github.com/6demon89/Helmes.WebApi.git
   ```
   
## Usage example
``
To start WebApi navigate into the project folder and execute command 'dotnet publish -o"Path"'. From this path start Helmes.WebApi.exe
To start React App, navigate to '\Helmes.Front\my-app' ans start with npm start command
``

Please make sure that react js utilize uses correct port for fetching data as WeApi.


## Development setup

Please ensure that SQL Server or SQL Server Express is installed and running;
In DbDump is an SQLsript to generate SQL database with seeded data values. However by design this should not be needed and on first application start (database call)
the Schema and initial Data-Seed should be created automaticly.


## Couple of words about the project execution

Front end is not even finished. Sadly React was bit more complex then excpected and took too much time.
For api I used opportunity and tested out Minimal API. While it is okay, there are some difficulties to unit test end point (you will notice is by the fact, that I ended up using reflections for unit testing).

