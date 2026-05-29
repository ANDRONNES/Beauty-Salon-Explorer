import { useState, useMemo } from "react";
import { Link } from "react-router-dom";
import { useSalons } from "../api/hooks/useSalons";
import "../styles/SalonDashboard.css";

export default function SalonDashboard() {
  const { salons, loading, error } = useSalons();
  const [selectedDistrict, setSelectedDistrict] = useState("");
  const [currentPage, setCurrentPage] = useState(1);
  const itemsPerPage = 9;

  const availableDistricts = useMemo(() => {
    const allDistricts = salons.map((s) => s.district);
    return [...new Set(allDistricts)].filter(Boolean);
  }, [salons]);

  const filteredSalons = useMemo(() => {
    if (!selectedDistrict) return salons;
    return salons.filter((s) => s.district === selectedDistrict);
  }, [salons, selectedDistrict]);

  const totalPages = Math.ceil(filteredSalons.length / itemsPerPage) || 1;
  const paginatedSalons = useMemo(() => {
    const startIndex = (currentPage - 1) * itemsPerPage;
    return filteredSalons.slice(startIndex, startIndex + itemsPerPage);
  }, [filteredSalons, currentPage]);

  const handleDistrictChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setSelectedDistrict(e.target.value);
    setCurrentPage(1);
  };

  const handlePageChange = (newPage: number) => {
    setCurrentPage(newPage);
    window.scrollTo({ top: 0, behavior: "smooth" });
  };

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

      <div className="filters-container">
        <label>Filter by District:</label>
        <select value={selectedDistrict} onChange={handleDistrictChange}>
          <option value="">All Districts</option>
          {availableDistricts.map((district) => (
            <option key={district} value={district}>
              {district}
            </option>
          ))}
        </select>
        <span>Found: {filteredSalons.length}</span>
      </div>

      <div className="sal-grid">
        {paginatedSalons.length === 0 ? (
          <div className="div-error">
            <h2>❌ No salons found in this district.</h2>
          </div>
        ) : (
          paginatedSalons.map((salon) => (
            <div className="grid-card" key={salon.salonId}>
              {salon.imageUrl && (
                <img
                  className="card-img"
                  src={salon.imageUrl}
                  alt={salon.name}
                  referrerPolicy="no-referrer"
                  onError={(e) => {
                    e.currentTarget.onerror = null;
                    e.currentTarget.src = "https://placehold.co/600x400/eeeeee/999999?text=No+Image+Available";
                  }}
                />
              )}

              <h3>{salon.name}</h3>
              <p>
                📍 {salon.street}, {salon.district}
              </p>

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

              <div className="meta">
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
                  className="link-salon-info"
                  to={`/salons/${salon.salonId}`}
                >
                  Details
                </Link>
              </div>
            </div>
          ))
        )}
      </div>

      {totalPages > 1 && (
        <div className="pagination-box">
          <button
            onClick={() => handlePageChange(Math.max(1, currentPage - 1))}
            disabled={currentPage === 1}
            style={{
              cursor: currentPage === 1 ? "not-allowed" : "pointer",
            }}
          >
            ← Prev
          </button>

          <span style={{ fontWeight: "bold" }}>
            Page {currentPage} of {totalPages}
          </span>

          <button
            onClick={() => handlePageChange(Math.max(1, currentPage + 1))}
            disabled={currentPage === totalPages}
            style={{
              cursor: currentPage === totalPages ? "not-allowed" : "pointer",
            }}
          >
            Next →
          </button>
        </div>
      )}
    </div>
  );
}
