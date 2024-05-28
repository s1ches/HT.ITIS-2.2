import {routesValues} from "./routesNames.js";
import MainPage from "../pages/mainPage/MainPage.jsx";
import ImagesPage from "../pages/imagesPage/ImagesPage.jsx";
import CreateNotificationPage from "../pages/createNotificationPage/CreateNotificationPage.jsx";

export const routes = [
    {
        routeName: routesValues.mainPage,
        Component: MainPage
    },
    {
        routeName: routesValues.imagesPage,
        Component: ImagesPage
    },
    {
        routeName: routesValues.createNotificationPage,
        Component: CreateNotificationPage
    },
]