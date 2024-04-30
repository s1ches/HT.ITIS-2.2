import Login from "./pages/Login.jsx";
import Register from "./pages/Register.jsx";
import User from "./pages/User.jsx";
import Admin from "./pages/Admin.jsx";

export const notAuthRoutes = [
    {
        path: "/login",
        Component: Login
    },
    {
        path: "/register",
        Component: Register
    }
];

export const userRoutes = [
    {
        path: "/user",
        Component: User
    },
];

export const adminRoutes = [
    {
        path: "/admin",
        Component: Admin
    }
];