Hi,

This API has been built to run as window service. Instead of MySQL, I have used SQL server, hence it is recommended to have sql server installed in your machine.

##Steps to run this project:
#1. There is build.bat file in root directory, please run that file first. Make sure to run all bat files in administrator mode. After build file execution complete, exe files and their dependencies will be placed in \bin\EcommerceAPI\ folder.

#2. Now open `\bin\EcommerceAPI\Install.bat` file in editor mode and change strDBServer, LoginUser and LoginPass as per your sql server name and database credentials and similary open `\bin\EcommerceAPI\appsettings.json` file in editor mode and change data source, Uid and Pwd as per your sql database server and credentials. Use same credentials and server name in both the files.

#3. Now we will create database namely:- Ecommerce SQL server and install this API as window service.To do that please run Install.bat file from `\bin\EcommerceAPI\` folder in administrator mode.

#4.After successfull installation of this service, go to browser, open this url >> `http://localhost:7123/swagger/index.html` . Now you will be able to consume all the APIs exposed in this service. Note: here instead of OTP, we are taking userid and password from user and saving it in database in encrypted format. And also user can update his/her information like UserName and EmailId by one the APIs. UserId is unique hence there is one API which will check for userid if it is valid or not.

5. After testing APIs you can uninstall this service by executing `\bin\EcommerceAPI\Uninstall.bat` file in administrator mode.

Please ask any question if you have.

Thank you
