export interface SalonSummary {
  salonId: string;
  name: string;
  street: string;
  district: string;
  rating: number | null;
  imageUrl: string;
  categories: string[];
}

export interface SalonDetails extends SalonSummary {
  phone: string | null,
  website: string | null,
  reviewsCount: number | null,
  locationUrl: string | null,
}


export interface UpdateSalonDTO {
  salonId: string;
  name: string;
  street: string;
  district: string;
  phone: string | null;
  website: string | null;
  locationUrl: string | null;
  imageUrl: string;
  categories: string[];
}