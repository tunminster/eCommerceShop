1. Create database with this name 'EcommerceShop' on sql server 2016 or less.
2. Run database_setup script
3. Run EcommerShop_servicebrokder.sql
4. Run eCommerceShop.Web
5. Register with an email and password
6. Go to order page
7. Place order
8. Run eCommerceShop.windowservice
9. Leave it run about 2 mins.  

The Result:
Purchase orders will be parked in Service Broker queues. Then, an simple window service will retrieve messages and process purchased order 
with busines rules B1 and B2.

Notes: please update connection strings in Web.config in eCommerceShop.Web and App.config in eCommerShop.WindowService.



