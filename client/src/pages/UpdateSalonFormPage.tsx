import { useParams, Link } from "react-router-dom";
import { useSalon } from "../api/hooks/useSalon";
import { useUpdateSalonForm } from "../api/hooks/useUpdateSalon";
import "../styles/UpdateSalonForm.css";
import { useCategories } from "../api/hooks/useCategories";
import { Controller } from "react-hook-form";
import Select from "react-select";

export default function UpdateSalonForm() {
  const { id } = useParams<{ id: string }>();

  const { salon, loading, error: fetchError } = useSalon(id);
  const { register, control, onSubmit, errors, isSubmitting } =
    useUpdateSalonForm(id, salon);
  const { categories, loadingCategories } = useCategories();
  const categoryOptions = categories.map((cat) => ({ value: cat, label: cat }));

  if (loading || loadingCategories)
    return (
      <div className="div-loading">
        <h2>⏳ Loading data...</h2>
      </div>
    );

  if (fetchError || !salon)
    return (
      <div className="div-error">
        <h2>❌ {fetchError}</h2>
        <Link to="/salons" className="error-link">
          Return to salons
        </Link>
      </div>
    );

  return (
    <div className="update-form-container">
      <Link to={`/salons/${id}`} className="back-link">
        ← Cancel
      </Link>

      <h1 className="form-title">Edit: {salon.name}</h1>

      {errors.root && (
        <div className="global-error">❌ {errors.root.message}</div>
      )}

      <form onSubmit={onSubmit} className="salon-form">
        <div className="form-group">
          <label className="form-label">Name *</label>
          <input
            className="form-input"
            {...register("name", { required: "Name is required" })}
          />
          {errors.name && (
            <span className="input-error">{errors.name.message}</span>
          )}
        </div>

        <div className="form-row">
          <div className="form-group">
            <label className="form-label">Street *</label>
            <input
              className="form-input"
              {...register("street", {
                required: "Street is required",
                pattern: {
                  value: /^(?=.*[a-zA-ZA-Яа-яąćęłńóśźżĄĆĘŁŃÓŚŹŻ]).+$/,
                  message: "Street must contain at least one letter",
                },
              })}
            />
            {errors.street && (
              <span className="input-error">{errors.street.message}</span>
            )}
          </div>
          <div className="form-group">
            <label className="form-label">District *</label>
            <input
              className="form-input"
              {...register("district", {
                required: "District is required",
                pattern: {
                  value: /^[^0-9]+$/,
                  message: "District cannot contain numbers",
                },
                validate: (value) => {
                  return (
                    value.trim().length > 0 || "District cannot be empty spaces"
                  );
                },
              })}
            />
            {errors.district && (
              <span className="input-error">{errors.district.message}</span>
            )}
          </div>
        </div>

        <div className="form-group">
          <label className="form-label">Phone</label>
          <input
            className="form-input"
            {...register("phone", {
              validate: (value) => {
                if (!value) return true;
                const normalized = value.replace(/[\s\-\\(\\)]/g, "");
                const isValid = /^(\+48\d{9}|48\d{9}|\d{9})$/.test(normalized);
                return (
                  isValid ||
                  "Invalid phone number format. Use 9 digits (e.g., +48 123 456 789)"
                );
              },
            })}
          />
          {errors.phone && (
            <span className="input-error">{errors.phone.message}</span>
          )}
        </div>

        <div className="form-group">
          <label className="form-label">Image URL *</label>
          <input
            className="form-input"
            type="url"
            {...register("imageUrl", { required: "ImageUrl is required" })}
          />
          {errors.imageUrl && (
            <span className="input-error">{errors.imageUrl.message}</span>
          )}
        </div>

        <div className="form-group">
          <label className="form-label">Location URL</label>
          <input
            className="form-input"
            type="url"
            {...register("locationUrl")}
          />
        </div>

        <div className="form-group" style={{ marginBottom: "50px" }}>
          <label className="form-label">Categories *</label>
          
          <Controller
            name="categories"
            control={control}
            rules={{ required: "At least one category is required" }}
            render={({ field: { onChange, onBlur, value, name } }) => (
              <Select
                isMulti
                options={categoryOptions}
                placeholder="Select or type to search..."
                className="react-select-container"
                classNamePrefix="react-select"
                name={name}
                onBlur={onBlur}
                value={categoryOptions.filter(c => value && value.includes(c.value))}
                onChange={(selectedOptions) => {
                  onChange(selectedOptions ? selectedOptions.map(option => option.value) : []);
                }}
              />
            )}
          />
          
          {errors.categories && <span className="input-error">{errors.categories.message}</span>}
        </div>

        <button type="submit" disabled={isSubmitting} className="submit-button">
          {isSubmitting ? "Saving..." : "Save Changes"}
        </button>
      </form>
    </div>
  );
}
