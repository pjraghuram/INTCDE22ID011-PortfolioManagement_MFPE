# **Portfolio Management**

>## **Project Members:
P. Jaya Raghu Ram  (2135391)
P. Adarsh (2134216)
Poojitha Naidu (2137076)
G. Dileep (2136832)
P. Sai Avinash (2135418)**
>##Project Overview

A customer Portal is developed as a part of this project that consumes all of the Microservices to view their portfolio information and sell their assets.

### About Microservices:

As part of the build, the web application has been divided into 5 parts that includes four 'Web Api microservices' and one 'Customer Login Portal'. The individual components
(web apis) provide the required rest-end points and all end-points have been configured and called internally using 'HttpClient' in other microservices and the portal as required. An algorithm has been developed in order to calculate user's investment portfolio's networth.  

The projects contains four web-apis as microservices: 

- Share Price Microservice -
  This is a Microservice that performs following operation: 
  - Gets the daily share price of stocks listed in the marketplace.
  
- Mutual Fund Microservice - 
  This is a Microservice that performs following operation: 
  - Gets NAV value of Mutual Funds listed in the marketplace.

- Calculate Net worth Microservice - 
  This is a Microservice that performs following operation: 
  - Calculates the current value of share details and mutual fund holdings of a user and find out the total current value or net-worth of its investment portfolio based on some developed algorithm.
  - Sell Assets and calculate the final net-worth.
  
- Authorization Microservice: - 
  - Pass End User details across Microservices.
  - Have the token expired after specific amount of time say 15 minutes.
  - Have this service configured in the cloud along with other services.
  
- Customer Portal - 
  A Web Portal that allows a customer to perform the following operations:
  - Login 
  - View the portfolio details & networth 
  - Sell assets
  
 
>##Documentation Requirements
- All the Microservices are configured with Swagger for documentation.
- Registerd the swagger resources in the Swagger Microservice and enabled them as REST end points.
- Configured this service along with other services in the cloud (AWS).

>##Individual Components of the System
- [Customer Portal]
- [Authorization MicroService]
- [Share Price Microservice]
- [Mutual Fund Microservice]
- [Daily Net Worth Microservice]

>##System Requirements
- Visual Studio 
- SQL Server
- AWS
