# Notification Management Application

This project is a **C# and ASP.NET Core** application for managing and streaming notifications to clients via **Server-Sent Events (SSE)**. The application features an API for managing notifications, an in-memory storage for notifications, and a real-time data streaming mechanism.

---

## Features

1. **Add Notifications**:

   - Accepts a list of notifications via a POST API and stores them in an in-memory data structure.

2. **Real-Time Notification Streaming**:

   - Utilizes **Server-Sent Events (SSE)** to stream notifications to connected clients in real-time.

3. **In-Memory Data Management**:

   - Maintains a list of notifications in memory for fast access.

4. **Cross-Origin Resource Sharing (CORS)**:
   - Enables cross-origin requests for seamless integration with frontend clients.

---

## Installation

### Prerequisites

1. .NET SDK (version 6.0 or higher recommended)
2. Visual Studio or any preferred IDE
3. A web browser for testing the application

### Steps to Install

1. Clone the repository:

   ```bash
   git clone https://github.com/AvaniVaidya/Notification-Manager.git
   cd your-repository
   ```

2. Open the solution in Visual Studio or your preferred IDE.

3. Restore the required dependencies:

   ```bash
   dotnet restore
   ```

4. Build the application:

   ```bash
   dotnet build
   ```

5. The plug-and-play Notification Plugin is available at the following repository - [https://github.com/AvaniVaidya/Notification-Plugin.git]
   To integrate the plugin into your project, clone the repository using the command below and follow the installation steps outlined in its README.md file.

---

## Usage

### API Endpoints

1. **Add Notifications**

   - Endpoint: `/Notification`
   - Method: `POST`
   - Body:
     ```json
     [
       {
         "summary": "Test Notification",
         "description": "This is a test notification",
         "severity": 1
       }
     ]
     ```

2. **Stream Notifications**
   - Endpoint: `/Notification`
   - Method: `GET`
   - Description:
     Streams notifications to clients using Server-Sent Events (SSE). If there are no notifications, it sends a "wait" message until new notifications arrive.

### Running the Application

1. Start the application:

   ```bash
   dotnet run
   ```

2. Use a tool like **Postman**, **curl**, or a browser to interact with the endpoints.

3. Example `curl` commands:
   - Add notifications:
     ```bash
     curl -X POST -H "Content-Type: application/json" -d '[{"summary": "Test", "description": "Sample notification", "severity": 1}]' http://localhost:5000/Notification
     ```
   - Stream notifications:
     ```bash
     curl http://localhost:5000/Notification
     ```

---

## Technologies Used

- **C#**
- **ASP.NET Core** (for API and SSE support)
- **System.Text.Json** (for JSON serialization)
- **Server-Sent Events (SSE)**

---

## Contributions

Contributions are welcome! If you'd like to contribute to this project, please follow these steps:

- Fork the repository.
- Create a new branch (git checkout -b feature/your-feature).
- Make your changes and commit them (git commit -am 'Add some feature').
- Push to the branch (git push origin feature/your-feature).
- Create a new Pull Request.

---

## License

This project is licensed under the MIT License. See the `LICENSE` file for details.
