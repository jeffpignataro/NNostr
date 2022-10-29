# nostr 1. Notes and Other Stuff Transmitted by Relays

[Additional details regarding NNOSTR protocol](https://github.com/nostr-protocol/nostr)

## Setup Instructions

### Relay

_Prerequiste_ Install Postgres, set port, and create database

1. Install and start

```
sudo apt install postgresql postgresql-client -y
sudo systemctl start postgres.service
```

2. Set port to `65466`

```
sudo vim /etc/postgresql/14/main/postgresql.conf
```

3. Find `port=` and set to `65466`, save, and restart the service.

```
sudo systemctl restart postgres.service
```

4. Create database

```
sudo -u postgres createdb ssdsd
```

5. Verify correct connection info

```
sudo -u postgres psql -d ssdsd
\conninfo
```

6. Should return:

```
You are connected to database "ssdsd" as user "postgres" via socket in "/var/run/postgresql" at port "65466".
```

7. _Optional_ Change `postgres` admin user password

```
ALTER USER postgres PASSWORD 'strong_password_here';
```

8. _Optional_ Store DB password as environment variable

```
export POSTGRES_PASSWORD=strong_password_here
or
echo "POSTGRES_PASSWORD=strong_password_here" >> .env
```

### NNOSTR-UI

_Prerequiste_ Install `wasm-tools`

```
dotnet workload restore
```
