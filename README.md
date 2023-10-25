# Fuel Price Tracking Backend

This repository houses the backend code for the Fuel Price Tracking web application. The application is designed to track and manage fuel prices at various locations and provide users with real-time updates on fuel costs.

## Overview

Fuel Price Tracking is a full-stack web application consisting of both frontend (client-side) and backend(server-side) components. The backend, found in this repository, handles data storage, API endpoints, and communication with the frontend.

## Features

- API endpoints for retrieving and managing fuel price data.
- Integration with external data sources for live fuel price updates.
- Data formatting for user-friendly presentation.
- Error handling for server unavailability.
- Toast notifications for user feedback.

## Technologies Used

- Node.js
- Express.js
- MSSQL
- Axios
- React
- Redux

## Getting Started

To set up the backend, follow these steps:

1. Clone this repository to your local machine.
2. Install the required dependencies using `npm install`.
3. Configure environment variables for your database connection. Keep in mind connection string is not visible in the Github code base since it is hidden in `user secrets` for the safety purposes.
4. Run the server using `npm start`.

## API Endpoints

- `/api/prices`: Get fuel price data.
- `/api/locations`: Get location data.
- `/api/types`: Get fuel type data.
- `/api/station`: Get gas station type data.

## How to Contribute

We welcome contributions to our project! To get involved, please:

- Open an issue to report a bug or suggest an enhancement.
- Fork this repository, create a branch, and submit a pull request.

## License

This project is licensed under the MIT License.

Feel free to explore our #([https://github.com/your-username/fuel-price-frontend](https://github.com/Olgierd-Jankovski/GasPriceTracker.backend)https://github.com/Olgierd-Jankovski/GasPriceTracker.backend) for the server-side code.
