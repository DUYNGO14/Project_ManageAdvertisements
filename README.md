# ManageAdvertisements

## Use Case
Display content on TVs and LEDs in a shopping mall.

## Actors
- Admin
- Device

## Description
MallMedia is a content management system designed to help admins manage the display of multimedia content on various TVs and LED screens throughout a shopping mall. Admins can schedule content to be shown at specific times and can ensure that devices connected to the system receive the appropriate content based on their schedules.

## Preconditions
- Devices must be registered with the system.
- Content must be available and properly categorized.

## Postconditions
- Devices display content after a successful request.
- Content can be updated in real-time.
- Admin can assign content to specific devices.

## Features
1. **Device Management**: Admins can register and manage TVs and LED devices connected to the system.
2. **Content Management**:
3. **Display Content**: Admins can upload and categorize multimedia content for display on devices.
4. **Schedule Management**: Admins can create and manage schedules for when specific content should be displayed.
5. **Real-time Updates**: Content can be updated and scheduled in real-time without needing to restart the application.

## Technology Stack
- **Backend**: ASP.NET Core
- **Database**: SQL Server or SQLite (configured in `appsettings.json`)
- **Frontend**: Razor page
- **Libraries**: Entity Framework Core, ASP.NET Identity, SignalR

## How to Run the Project

### Prerequisites
1. **.NET SDK**: Ensure you have the .NET SDK installed on your machine. Download it from the [.NET download page](https://dotnet.microsoft.com/download).
2. **Database**: Ensure that you have a database set up (e.g., SQL Server, SQLite) and that your connection string in the `appsettings.json` file is correctly configured.
3. **IDE**: It is recommended to use an IDE like Visual Studio or Visual Studio Code for development.

### Step 1: Clone the Repository
If you haven't cloned the repository yet, do so by running:
```bash
git clone https://github.com/DUYNGO14/Project_ManageAdvertisements.git
```
### Step 2: Apply Migration
```bash
update-database
```
### Step3: Run application
