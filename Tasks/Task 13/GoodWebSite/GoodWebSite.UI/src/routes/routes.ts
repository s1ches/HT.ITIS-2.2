import {routesValues} from "./routesValues.ts";
import LoginPage from "../pages/login/LoginPage.tsx";
import RegisterPage from "../pages/register/RegisterPage.tsx";
import MainPage from "../pages/main/MainPage.tsx";

export const notAuthRoutes = [
    {
        route: routesValues.login,
        page: LoginPage
    },
    {
        route: routesValues.register,
        page: RegisterPage
    }
]

export const authRoutes = [
    {
        route: routesValues.main,
        page: MainPage
    }
]