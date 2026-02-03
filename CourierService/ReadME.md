# 🚚 Courier Service Application

A modular, scalable courier service console application built using **.NET**, designed with clean architecture principles and extensible design patterns.

This application calculates delivery costs, applies promotional offers, and schedules shipments across available vehicles while estimating delivery times.

---

# ✅ Features

* Calculate delivery cost based on weight and distance
* Apply discount offers using **Strategy + Factory Pattern**
* Intelligent shipment building to maximize vehicle utilization
* Delivery time estimation
* Dependency Injection enabled
* Unit test ready
* Code coverage supported

---

# 🧱 Architecture

The solution follows a **Clean Architecture / Layered Architecture** approach:

```
CourierService
 ├── CourierService.KikiApp        → Entry point
 ├── CourierService.Application    → Business logic
 ├── CourierService.Domain         → Core entities
 ├── CourierService.Infrastructure → External concerns (Offers, DI, Input)
 └── CourierService.Tests        → Unit tests
```

---

## 📌 Domain Layer

Contains enterprise business objects:

* Package
* Vehicle
* Shipment

No external dependencies.

---

## 📌 Application Layer

Implements business rules using interfaces:

### Services

* `CourierServiceProcessor`
* `DeliveryScheduler`
* `ShipmentBuilder`
* `DeliveryCostCalculator`
* `DiscountService`

### Interfaces

* IOffer
* IOfferFactory
* IDeliveryScheduler
* IShipmentBuilder
* IDeliveryCostCalculator
* IDiscountService

---

## 📌 Infrastructure Layer

Provides concrete implementations:

* Offer strategies (OFR001, OFR002, OFR003)
* OfferFactory
* ConsoleInputService
* Dependency Injection setup

Adding a new offer requires **ZERO modification** to existing logic — simply implement `IOffer` and register it.

---

# 🎯 Design Patterns Used

## ✅ Strategy Pattern

Each offer implements `IOffer`, enabling runtime selection of discount logic.

## ✅ Factory Pattern

`OfferFactory` resolves the correct strategy without conditional logic.

## ✅ Dependency Injection

Promotes loose coupling and improves testability.

---

# ▶️ How To Run The Application

### 1️⃣ Clone the repository

```
git clone <repo-url>
cd CourierService
```

---

### 2️⃣ Restore packages

```
dotnet restore CourierService.sln
```

---

### 3️⃣ Build solution

```
dotnet build CourierService.sln
```

---

### 4️⃣ Run the console app

```
dotnet run --project CourierService.Console
```

---

# 🧪 Running Unit Tests

Navigate to solution root:

```
dotnet test CourierService.sln
```

---

# 📊 Viewing Code Coverage

This project uses **Coverlet** for cross-platform coverage.

---

## Generate Coverage

```
dotnet test CourierService.sln --collect:"XPlat Code Coverage"
```

---

# 👨‍💻 Author

**Swapnil Dicholkar**
Engineering Lead | Frontend & Full-Stack Developer

---

If you have any questions or feedback, feel free to reach out!
