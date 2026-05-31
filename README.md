# 🛍️ Online Shopping Store API

A production-ready e-commerce REST API built with ASP.NET Core 10.

## Features
-  JWT Authentication
-  Role-based Access Control
-  Product Management
-  Shopping Cart
-  Order Management
-  Payment Processing

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