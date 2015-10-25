
1. To run the app, first you need to create a database "AuctionDB" in SQL Server 
(be sure that the connection string in the config-file matches your SQL Server settings).

2. As a customer the application works as it should. 
But for an admin-role you need to manually change the role of the user in the database. 
(Only an admin can add products and auctions)
AuctionDB --> Tables --> Customers --> change Role-field to 0 (for admin permissions). (0 for admin and 1 for customer).

