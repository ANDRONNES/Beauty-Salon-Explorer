import { Link } from "react-router-dom";
import { useSalons } from "../api/hooks/useSalons";
import "../styles/SalonDashboard.css";

export default function SalonDashboard() {
  const { salons, loading, error } = useSalons();

  if (loading) {
    return (
      <div className="div-loading">
        <h2>⏳ Loading data...</h2>
      </div>
    );
  }

  if (error) {
    return (
      <div className="div-error">
        <h2>❌ {error}</h2>
      </div>
    );
  }

  return (
    <div className="grid-box">
      <h1>Salons presented:</h1>

      <div className="sal-grid">
        {salons.map((salon) => (
          <div className="grid-card" key={salon.salonId}>
            {salon.imageUrl && (
              <img className="card-img" src={salon.imageUrl} alt={salon.name} />
            )}

            <h3>{salon.name}</h3>
            <p>📍 {salon.shortAddress}</p>

            <div className="category-tags">
              {salon.categories.slice(0, 1).map((category, index) => (
                <span className="def" key={index}>
                  {category}
                </span>
              ))}

              {salon.categories.length > 1 && (
                <span className="greater">
                  And +{salon.categories.length - 1} more
                </span>
              )}
            </div>
            <div className="meta" style={{}}>
              <span>
                Average Rating:
                <span
                  style={{
                    fontWeight: "bold",
                    color: "#052",
                    marginLeft: "3px",
                  }}
                >
                  {salon.rating ? salon.rating : "Be the first!"}
                </span>{" "}
                ⭐
              </span>

              <Link
                to={`/salons/${salon.salonId}`}
                style={{
                  padding: "8px 16px",
                  backgroundColor: "#A36A3F",
                  color: "white",
                  textDecoration: "none",
                  borderRadius: "4px",
                  fontSize: "0.9rem",
                }}
              >
                Details
              </Link>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
