import {getCookie} from "../functions/getCookieByName.js";
import axios from "axios";

const $host = axios.create({
    baseURL: "https://localhost:44381/",
    validateStatus: status => true
})

const $authHost = axios.create({
    baseURL: "https://localhost:44381/",
    validateStatus: status => true
})

function authInterceptor(config) {
    let token = localStorage.getItem("accessToken");
    config.headers.Authorization = `Bearer ${token}`

    return config
}

$authHost.interceptors.request.use(authInterceptor)

export {
    $host,
    $authHost
}