import { useParams, Link } from "react-router-dom";
import { useSalon } from "../api/hooks/useSalon";
import "../styles/SalonDetailsPage.css";

export default function SalonDetailsPage() {
  const { id } = useParams<{ id: string }>();
  const { salon, loading } = useSalon(id);

  if (loading) {
    return (
      <div className="div-loading">
        <h2>⏳ Loading data...</h2>
      </div>
    );
  }

  if (!salon) {
    return (
      <div className="div-error">
        <h2>❌ Not Found</h2>
        <Link to="/salons" className="error-link">
          Return to salons
        </Link>
      </div>
    );
  }

  return (
    <div className="card-box">
      <Link to="/salons" className="back-link">
        ← Return to salons
      </Link>

      <div className="salon-card">
        {salon.imageUrl ? (
          <img src={salon.imageUrl} alt={salon.name} className="salon-image" />
        ) : (
          <div className="salon-image-placeholder" />
        )}

        <div className="salon-content">
          <div className="salon-header">
            <h1 className="salon-title">{salon.name}</h1>

            <div className="salon-rating-wrapper">
              {salon.rating ? (
                <>
                  <span className="rating-score">⭐ {salon.rating}</span>
                  <span className="rating-divider">•</span>
                  <span className="reviews-count">
                    Based on{" "}
                    <span style={{ fontWeight: "bold" }}>
                      {salon.reviewsCount || 0}
                    </span>{" "}
                    reviews
                  </span>
                </>
              ) : (
                <span className="no-rating">No ratings yet</span>
              )}
            </div>
          </div>

          <div className="salon-categories">
            {salon.categories.map((category, index) => (
              <span key={index} className="category-badge">
                {category}
              </span>
            ))}
          </div>

          <div className="salon-info-grid">
            <div className="info-section">
              <h3>Address</h3>
              <p>
                {salon.street}, {salon.district}
              </p>

              {salon.locationUrl && (
                <a
                  href={salon.locationUrl}
                  target="_blank"
                  rel="noreferrer"
                  className="info-link"
                >
                  View on map 🗺️
                </a>
              )}
            </div>

            <div className="info-section">
              <h3>Contacts</h3>
              <p>📞 {salon.phone || "Not specified"}</p>

              {salon.website && (
                <a
                  href={salon.website}
                  target="_blank"
                  rel="noreferrer"
                  className="info-link"
                >
                  🌐 Official website
                </a>
              )}
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
