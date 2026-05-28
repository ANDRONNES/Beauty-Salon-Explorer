import { Link } from "react-router-dom";
import "../styles/HomePage.css";

export default function HomePage() {
  return (
    <div className="home-container">
      <h1 className="home-title">Beauty Explorer</h1>

      <p className="home-description">
        Your personal guide to the world of aesthetics and care. Our marketplace
        brings together the city's best beauty salons. Search by district,
        choose your desired treatments, and trust only verified reviews.
      </p>

      <Link to="/salons/" className="home-button">
        Find Your Salon
      </Link>
    </div>
  );
}
