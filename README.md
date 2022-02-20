# Helmes WebAPI
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

## Development setup

Please ensure that SQL Server or SQL Server Express is installed and running;
Please make sure that ports 3001 and 5136 are not blocked;

## Couple of words about the project execution

Front end is not even finished. Sadly React was bit more complex then excpected and took too much time.
For api I used opportunity and tested out Minimal API. While it is okay, there are some difficulties to unit test end point (you will notice is by the fact, that I ended up using reflections for unit testing).

