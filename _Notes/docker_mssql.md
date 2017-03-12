##

## Setup Dock
### Docker for Mac

Click on the Docker logo on the top status bar.
Select Preferences.
Move the memory indicator to 4GB or more.
Click the restart button at the button of the screen.

###Docker for Windows:

Right-click on the Docker icon from the task bar.
Click Settings under that menu.
Click on the Advanced Tab.
Move the memory indicator to 4GB or more.
Click the Apply button.


## Reference
Run the SQL Server vNext Docker image on Linux, Mac, or Windows
https://docs.microsoft.com/en-us/sql/linux/sql-server-linux-setup-docker

### Download dock image
$ docker pull microsoft/mssql-server-linux

### Run sql image
$ docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Ben#1234' -p 1433:1433 -d microsoft/mssql-server-linux
$ docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Ben#1234' -p 1433:1433 microsoft/mssql-server-linux
$ docker run  -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=sqlben1234" -ti -p 1433:1433 microsoft/mssql-server-linux


Microsoft(R) SQL Server(R) setup failed with error code 1. Please check the setup log in /var/opt/mssql/log for more information.
>> It's most likely that your password is not complex enough.


## Use sql client
$ npm install -g sql-cli
$ mssql -u sa -p Ben#1234
