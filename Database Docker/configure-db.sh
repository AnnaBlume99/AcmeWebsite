#!/bin/bash

# Sleep so the database is ready
sleep 20

# Run the setup script to create the DB and the schema in the DB
/opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -d master -C -i setup.sql