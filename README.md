# Acme Prize Draw Website

Made by: Anna Blume Jakobsen

For: Umbraco Code Trial

The project is an ASP.NET Core backend with a Blazor frontend. The project is backed by an MSSQL database.

## Getting started

**Prerequisites**

- Install .NET 8 SDK
- Install Docker

**How to set up**

- Clone the repository to your computer
- Start the database by running the following command:
    ```bash
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=verycoolPassword1" -p 1433:1433 --rm -d --name "acme-database" ghcr.io/annablume99/acme-database
    ```
    If you want the database to be persistent use this command:
    ```bash
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=verycoolPassword1" -p 1433:1433 -v sqlvolume:/var/opt/mssql --rm -d --name "acme-database" ghcr.io/annablume99/acme-database
    ```
- Launch the project using either:
    - The launch configuration `https` from the `AcmeWebsite/AcmeWebsite` project through Visual Studio
    - Navigate to `AcmeWebsite/AcmeWebsite` and run `dotnet run` in a terminal

**Security**

The default password for the Submissions page is `Umbraco`.

**Database**

The database image is built on the Dockerfile in `Database Docker`. It automatically creates the database and inserts 100 valid serial numbers. They can be found in `Serialnumbers.md`.