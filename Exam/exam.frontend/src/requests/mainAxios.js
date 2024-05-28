import axios from "axios";

const $host = axios.create({
    baseURL: '',
    validateStatus: status => true
})

export {
    $host,
}