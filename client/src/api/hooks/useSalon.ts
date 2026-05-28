import { useEffect, useState } from "react";
import type { SalonDetails } from "../../types/salon.types";
import agent from "../agent";


export function useSalon(id: string | undefined) {
    const [salon, setSalon] = useState<SalonDetails | null>(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (!id) {
            setLoading(false);
            return;
        }

        const fetchSalon = async () => {
            try {
                setLoading(true);
                const res = await agent.get<SalonDetails>(`/salons/${id}`);
                setSalon(res.data);
            } catch (error) {
                console.error("Ошибка при загрузке деталей салона:", error);
            } finally {
                setLoading(false);
            }
        };

        fetchSalon();
    }, [id]);

    return { salon, loading };
}