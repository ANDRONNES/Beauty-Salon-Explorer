import { useEffect, useState } from "react";
import type { SalonDetails } from "../../types/salon.types";
import agent from "../agent";


export function useSalon(id: string | undefined) {
    const [salon, setSalon] = useState<SalonDetails | null>(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        if (!id) {
            setLoading(false);
            setError("Salon Not Found")
            return;
        }

        const fetchSalon = async () => {
            try {
                setLoading(true);
                const res = await agent.get<SalonDetails>(`/salons/${id}`);
                setSalon(res.data);
            } catch (error) {
                console.error("error loading salons info", error);
                setError("An error has occurred.")
            } finally {
                setLoading(false);
            }
        };

        fetchSalon();
    }, [id]);

    return { salon, loading, error };
}