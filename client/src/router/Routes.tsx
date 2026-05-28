import { createBrowserRouter, Navigate } from "react-router-dom";
import App from "../App";
import HomePage from "../pages/HomePage";
import SalonDashboard from "../pages/SalonDashboard";
import SalonDetailsPage from "../pages/SalonDetailsPage";
import UpdateSalonForm from "../pages/UpdateSalonFormPage";

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
      {path: "salons/:id/edit", element: <UpdateSalonForm />},
      { path: "*", element: <Navigate replace to="" /> },
    ],
  },
]);
