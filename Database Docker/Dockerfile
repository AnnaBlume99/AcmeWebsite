# Copied from https://github.com/microsoft/mssql-docker/tree/master/linux/preview/examples/mssql-customize
FROM mcr.microsoft.com/mssql/server:2022-latest

USER root

# Create a config directory
RUN mkdir -p /usr/config
WORKDIR /usr/config

# Bundle config source
COPY . /usr/config

# Grant permissions for to our scripts to be executable
RUN chmod +x /usr/config/entrypoint.sh
RUN chmod +x /usr/config/configure-db.sh

USER mssql

ENTRYPOINT ["./entrypoint.sh"]