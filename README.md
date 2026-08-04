# 🛍️ Online Shopping Store API

A backend RESTful API for an e-commerce platform built using ASP.NET Core, C#, Entity Framework Core, and SQL Server. The application provides secure user authentication, product management, shopping cart functionality, order processing, and payment management using modern .NET development practices.
This project was developed to strengthen my backend development skills in ASP.NET Core and demonstrate practical experience in designing scalable REST APIs, implementing authentication and authorization, and working with relational databases.

## Features
**User Authentication & Authorization**
- User Registration
- User Login
- JWT Authentication
- ASP.NET Core Identity
- Role-Based Authorization (Admin & Customer)

**Product Management**
- Add Products
- Update Products
- Delete Products
- View Product Catalogue

  **Shopping Cart**
- Add Items to Cart
- Update Cart Items
- Remove Items from Cart
- View Shopping Cart

**Order Management**
- Place Orders
- View Customer Orders
- Order History

**Payment Module**

## Tech Stack
- **Framework**: ASP.NET Core 10
- **Database**: SQL Server
- **Authentication**: JWT Tokens

## Getting Started

### Prerequisites
- .NET 10 SDK
- SQL Server

### Installation
```bash
git clone https://github.com/YOUR_USERNAME/OnlineShoppingStore.git
cd OnlineShoppingStore
dotnet restore
dotnet ef database update
dotnet run
```

## API Endpoints

### Authentication
- `POST /api/account/register` - Register user
- `POST /api/account/login` - Login and get token

### Products
- `GET /api/product/all` - Get all products
- `POST /api/product/add` - Add product (Admin)
- `PUT /api/product/update/{id}` - Update product (Admin)
- `DELETE /api/product/delete/{id}` - Delete product (Admin)

### Cart
- `GET /api/cart` - View cart
- `POST /api/cart/add` - Add to cart
- `PUT /api/cart/update` - Update cart
- `DELETE /api/cart/remove/{id}` - Remove item

### Orders
- `POST /api/order` - Place order
- `GET /api/order/my` - View my orders

### Payments
- `POST /api/payment/process` - Process payment
- `GET /api/payment/user/history` - Payment history

## Author
Rohini Sreekumar - [GitHub](https://github.com/rohini-portfolio)
