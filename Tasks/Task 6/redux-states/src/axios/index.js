import axios from "axios";
import {exampleUrl} from "./axiosUrls/baseUrl.js";

const $exampleAxios = axios.create({
    baseURL: exampleUrl,
    url: exampleUrl,
    method: "get"
})

export  {
    $exampleAxios
}

