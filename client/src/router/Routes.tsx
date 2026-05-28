import { createBrowserRouter, Navigate } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/HomePage";
import SalonDashboard from "../pages/SalonDashboard";
import SalonDetailsPage from "../pages/SalonDetailsPage";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <HomePage />,
  },
  {
    path: "/",
    element: <App />,
    children: [
      { path: "salons", element: <SalonDashboard /> },
      { path: "salons/:id", element: <SalonDetailsPage /> },
      // {path: "edit/:id", element: <SalonEditForm />},
      { path: "*", element: <Navigate replace to="" /> },
    ],
  },
]);
