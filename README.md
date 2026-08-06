# Online Shopping Store API

A backend REST API for an online shopping platform built using **ASP.NET Core**, **Entity Framework Core**, **SQL Server**, and **ASP.NET Core Identity**. The application provides secure authentication, role-based authorization, product management, shopping cart functionality, order processing, and mock payment processing.

This project was developed to strengthen backend development skills using Microsoft's .NET ecosystem and demonstrates layered architecture, REST API development, authentication, authorization, and database integration.

## Features

### Authentication & Authorization
- User Registration
- User Login
- JWT Authentication
- ASP.NET Core Identity
- Role-Based Authorization (Admin & Customer)

### Product Management
- Add Product (Admin)
- Update Product (Admin)
- Delete Product (Admin)
- Get Product by ID
- View All Products (Public)

### Shopping Cart
- Create Cart Automatically
- Add Products to Cart
- Update Cart Items
- Remove Cart Items
- Clear Cart
- Calculate Total Amount

### Order Management
- Place Orders
- View Customer Orders
- View All Orders (Admin)
- Update Order Status (Admin)
- Automatic Stock Validation
- Automatic Stock Reduction

### Payment Module
- Mock Payment Processing
- Transaction ID Generation
- Payment History
- Payment Status Tracking
- Automatic Order Status Update


# Technology Stack

### Backend
- ASP.NET Core
- C#
- REST API

### Database
- SQL Server
- Entity Framework Core
- Code First Approach

### Authentication
- ASP.NET Core Identity
- JWT Authentication

### Architecture
- Layered Architecture
- Repository Pattern
- Service Layer
- Dependency Injection

### Tools
- Visual Studio 2022
- Git
- GitHub
- Postman


#  Project Structure

OnlineShoppingStore
│
├── Controllers
├── Services
├── Repository
├── Models
├── Dtos
├── Data
├── Common
├── Program.cs
└── appsettings.json


# User Roles

## Admin

- Manage Products
- View All Orders
- Update Order Status

## Customer

- Register & Login
- Browse Products
- Manage Shopping Cart
- Place Orders
- Make Payments
- View Payment History

# API Modules

## Account

| Method | Endpoint |
|---------|-----------|
| POST | /api/account/register |
| POST | /api/account/login |
| POST | /api/account/logout |


## Products

| Method | Endpoint |
|---------|-----------|
| GET | /api/product/all |
| GET | /api/product/{id} |
| POST | /api/product/add |
| PUT | /api/product/update/{id} |
| DELETE | /api/product/delete/{id} |


## Cart

| Method | Endpoint |
|---------|-----------|
| GET | /api/cart |
| POST | /api/cart/add |
| PUT | /api/cart/update |
| DELETE | /api/cart/remove/{cartItemId} |
| DELETE | /api/cart/clear |

## Orders

| Method | Endpoint |
|---------|-----------|
| POST | /api/order |
| POST | /api/order/my |
| GET | /api/order/all |
| PUT | /api/order/{orderId}/status |


## Payments

| Method | Endpoint |
|---------|-----------|
| POST | /api/payment/process |
| GET | /api/payment/{paymentId} |
| GET | /api/payment/user/history |


# Authentication

The application uses **JWT (JSON Web Tokens)** for securing protected endpoints.

Workflow:

- Register a user
- Login to receive a JWT token
- Include the token in the Authorization header

Authorization: Bearer <your_token>

# Database

The application uses SQL Server with Entity Framework Core Code-First.

Main entities include:

- ApplicationUser
- Product
- Cart
- CartItem
- Order
- OrderItem
- Payment

# Getting Started

## Prerequisites

- .NET SDK
- SQL Server
- Visual Studio 2022

## Clone Repository

```bash
git clone https://github.com/rohini-portfolio/OnlineShoppingStore.git

## Navigate to Project

```bash
cd OnlineShoppingStore
```
## Restore Packages

```bash
dotnet restore
```
## Update Database

```bash
dotnet ef database update
```
## Run Application

```bash
dotnet run
```

# Learning Outcomes

This project helped strengthen practical experience with:

- ASP.NET Core Web API Development
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Authentication
- Role-Based Authorization
- Repository Pattern
- Dependency Injection
- REST API Design
- Layered Architecture
- CRUD Operations


# Future Improvements

- Integrate a real payment gateway (e.g., Stripe or Razorpay)
- Product search and filtering
- Pagination
- Refresh Tokens
- Email Verification
- Password Reset
- API Documentation (Swagger)
- Unit Testing
- Docker Support
- Azure Deployment

# Author

**Rohini Sreekumar**

GitHub: https://github.com/rohini-portfolio

---

## If you found this project helpful, consider giving it a star!
