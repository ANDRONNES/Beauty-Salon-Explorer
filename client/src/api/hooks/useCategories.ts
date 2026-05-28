import { useEffect, useState } from "react";
import agent from "../agent";

export function useCategories() {
    const [categories, setCategories] = useState<string[]>([]);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        const fetchCategories = async () => {
            try {
                setLoading(true);
                const res = await agent.get<string[]>("/categories");
                setCategories(res.data);
            } catch (error) {
                console.error("error loading categories", error);
            } finally {
                setLoading(false);
            }
        };

        fetchCategories();
    }, []);

    return { categories, loadingCategories: loading };
}