import axios from "axios";

const instance = axios.create({
  baseURL: import.meta.env.VITE_BACKEND_URL || "http://localhost:5000/api/v1",
  httpsAgent: false,
  timeout: 5000,
  headers: {
    "Content-Type": "application/json",
  },
});

// Optional: interceptors for auth, logging, etc.
instance.interceptors.response.use(
  (response) => response,
  (error) => {
    // You could handle global errors here (e.g., toast, redirect)
    return Promise.reject(error);
  }
);

export default instance;
