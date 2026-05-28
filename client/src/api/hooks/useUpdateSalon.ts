import { useNavigate } from "react-router-dom";
import type { SalonDetails, UpdateSalonDTO } from "../../types/salon.types";
import { useForm } from "react-hook-form";
import agent from "../agent";

export type SalonFormData = Omit<UpdateSalonDTO, "categories"> & { categories: string };

export function useUpdateSalonForm(id: string | undefined, salon: SalonDetails | null) {
    const navigate = useNavigate();

    const {
        register,
        handleSubmit,
        setError,
        control,
        formState: { errors, isSubmitting }
    } = useForm<UpdateSalonDTO>({
        values: salon ? {
            salonId: salon.salonId,
            name: salon.name,
            street: salon.street,
            district: salon.district,
            phone: salon.phone,
            website: salon.website,
            locationUrl: salon.locationUrl,
            imageUrl: salon.imageUrl || "",
            categories: salon.categories
        } : undefined
    });


    const onSubmit = async (data: UpdateSalonDTO) => {
        if (!id) return;
        try {
            const dto: UpdateSalonDTO = {
                ...data,
                phone: data.phone || null,
                website: data.website || null,
                locationUrl: data.locationUrl || null,
            };

            await agent.put(`/salons/${id}`, dto);
            navigate(`/salons/${id}`);
        } catch (err: any) {
            setError("root", {
                message: err.response?.data?.message || "Failed to update salon."
            });
        }
    };

    return {
        register,
        control,
        errors,
        isSubmitting,
        onSubmit: handleSubmit(onSubmit)
    };
}