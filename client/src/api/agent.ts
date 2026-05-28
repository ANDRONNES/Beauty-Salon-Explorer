import axios from "axios";

const API_URL = "http://localhost:5273/api"

const agent = axios.create({
    baseURL: API_URL,
    headers: {
        "Content-Type": "application/json",
    }
});

export default agent;

