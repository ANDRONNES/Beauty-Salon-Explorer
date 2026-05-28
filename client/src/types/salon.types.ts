export interface SalonSummary {
  salonId: string;
  name: string;
  shortAddress: string;
  rating: number | null;
  imageUrl: string;
  categories: string[];
}

export interface SalonDetails extends SalonSummary {
  street: string,
  district: string,
  phone: string | null,
  website: string | null,
  reviewsCount: number | null,
  locationUrl: string | null,
}