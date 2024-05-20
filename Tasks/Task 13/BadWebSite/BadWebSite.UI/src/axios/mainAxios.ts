import axios from "axios";

const $host = axios.create({
    baseURL: 'https://localhost:44366/',
    validateStatus: (_status: number) => true
})

function hostInterceptor(config: any){
    config.withCredentials = true;
    config.responseType = 'json';
    config.headers = {'content-type': 'application/json'}

    return config;
}

$host.interceptors.request.use(hostInterceptor);

export {
    $host
}