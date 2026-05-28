import { useEffect, useState } from "react";
import type { SalonSummary } from "../../types/salon.types";
import agent from "../agent";

export function useSalons() {
    const [salons, setSalons] = useState<SalonSummary[]>([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);

    useEffect(() => {
        const getSalons = async () => {
            try {
                setLoading(true);
                const res = await agent.get<SalonSummary[]>("/salons");
                setSalons(res.data);
            } catch (err: any) {
                console.error("error loading salons", err);
                setError("An error has occurred.");
            } finally {
                setLoading(false);
            }
        };

        getSalons();
    }, []);

    return { salons, loading, error };
}