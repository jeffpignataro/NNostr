# nostr - Notes and Other Stuff Transmitted by Relays

[Additional details regarding NNOSTR protocol](https://github.com/nostr-protocol/nostr)

## Setup Instructions

### Relay

1. _Prerequiste_ Install Postgres, set port, and create database

- Install and start

```
sudo apt install postgresql postgresql-client -y
sudo systemctl start postgres.service
```

- Set port to `65466`

```
sudo vim /etc/postgresql/14/main/postgresql.conf
```

- Find `port=` and set to `65466`, save, and restart the service.

```
sudo systemctl restart postgres.service
```

- Create database

```
sudo -u postgres createdb ssdsd
```

- Verify correct connection info

```
sudo -u postgres psql -d ssdsd
\conninfo
```

- Should return:

```
You are connected to database "ssdsd" as user "postgres" via socket in "/var/run/postgresql" at port "65466".
```

- _Optional_ Change `postgres` admin user password

```
ALTER USER postgres PASSWORD 'strong_password_here';
```

- _Optional_ Store DB password as environment variable

```
export POSTGRES_PASSWORD=strong_password_here
or
echo "POSTGRES_PASSWORD=strong_password_here" >> .env
```

2.
