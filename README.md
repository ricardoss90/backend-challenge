# CNAB Importer - Frontend

This is the **Angular frontend** for the CNAB Importer project.  
It allows users to upload CNAB files and view stores and transactions in a simple web interface.

---

## 🚀 Accessing the App

Once the frontend is running (via Docker or locally):

- Open your browser and go to: [http://localhost:4200](http://localhost:4200)

---

## 🖥 User Interface Overview

The web app is structured with a **menu and main content area**:

### 1. Menu

- **Upload CNAB**: Opens the form to upload a CNAB file.
- **Stores**: Shows a table of stores and their transactions, including totals.

### 2. Upload CNAB Form

- **File Input**: Select a `.cnab` file from your computer.
- **Upload Button**: Submits the file to the API.
- **Behavior**:
  - Displays success or error messages after uploading.
  - Uses reactive forms for validation.

### 3. Stores Table

- Displays **all stores** imported from CNAB files.
- Columns include:
  - **Store Name**
  - **Owner**
  - **Total Transactions Value**
- Clicking a store can show detailed **transactions** if implemented.

---

## 🛠 Features

- Standalone Angular components with `ReactiveFormsModule`.
- Material design UI for buttons and cards.
- Communicates with the backend API at: http://localhost:7195/api
- File upload handled as text to the `/cnab/import` endpoint.
- CORS enabled on the API for localhost.

## Usage Instructions

1. Go to the **Upload CNAB** page.
2. Select a `.cnab` file from your computer.
3. Click **Upload** to send it to the backend API.
4. After a successful upload, navigate to **Stores** to view all stores and their transactions.

## Local Development

Install dependencies:

```bash
cd frontend/cnab-importer-frontend
npm install
```
Run the development server:

```bash
ng serve --host 0.0.0.0 --port 4200
```
The frontend will communicate with the backend API at:

```bash
http://localhost:7195/api
```
##Running with Docker
From the backend folder containing docker-compose.yml:

bash
```bash
docker compose up --build
```
Frontend container: http://localhost:4200

API container: http://localhost:7195/api

## Notes
The frontend uses Reactive Forms; ensure ReactiveFormsModule is imported in standalone components.

Angular Material UI is used for styling (MatButtonModule, MatCardModule).

The app can be extended with navigation menus, additional pages, and detailed transaction views.