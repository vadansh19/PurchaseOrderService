# Purchase Order Service

This project is a **Purchase Order Management System** built using **C# .NET Core** with a **Repository Pattern** and hosted via **IIS**. The service supports full CRUD (Create, Read, Update, Delete) operations and maintains order history, backed by **SQL Server**. It has been containerized using **Docker** for easy deployment.

---

## 📚 **Features**
- ✅ CRUD operations for managing purchase orders.
- ✅ Maintains order history for tracking.
- ✅ Implements **Repository Pattern** and **Unit of Work** for maintainable and modular code.
- ✅ SQL Server integration for data persistence.
- ✅ Dockerized for seamless deployment across environments.
- ✅ Configured to run on IIS.

---

## 🚀 **Technologies Used**
- **Backend:** C# .NET Core
- **Database:** SQL Server
- **Architecture:** Repository Pattern, Unit of Work
- **Containerization:** Docker
- **Hosting:** IIS

---

---

## 🛠️ **Getting Started**

### 1. **Clone the Repository**
```bash
git clone https://github.com/vadansh19/PurchaseOrderService.git
cd PurchaseOrderService
```

---

### 2. **Update Configuration**
- Modify `appsettings.json` to configure SQL Server connection string:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=your_server;Database=PurchaseOrderDB;User Id=your_user;Password=your_password;"
}
```

---

### 3. **Database Migration**
Run the following command to apply database migrations:
```bash
Update-Database
```

---

### 4. **Run the Application**
```bash
dotnet run
```
The application will be available at:
```
http://localhost:5000
```

---

## 🐳 **Docker Instructions**

### 1. **Build Docker Image**
```bash
docker build -t purchase-order-service .
```

---

### 2. **Run Docker Container**
```bash
docker run -d -p 8080:80 --name pos-container purchase-order-service
```
Access the service at:
```
http://localhost:8080
```

---

## 🌐 **IIS Hosting**
1. Publish the application:
```bash
dotnet publish -c Release -o ./publish
```
2. Deploy to IIS using the published files.

---


## 🧪 **Testing**
Run the tests:
```bash
dotnet test
```

---

## 🤝 **Contributing**
Contributions are welcome! Please follow these steps:
1. Fork the repository.
2. Create a feature branch: `git checkout -b feature-name`.
3. Commit changes: `git commit -m "feat: Add new feature"`.
4. Push to the branch: `git push origin feature-name`.
5. Create a Pull Request.

---

## 💎 **Contact**
For any questions or feedback, please contact:

**Vadansh Kulshreshtha**  

---

Happy Coding! 🎉

