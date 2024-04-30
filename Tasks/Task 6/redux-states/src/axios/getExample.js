import {$exampleAxios} from "./index.js";

export const getExampleData = async () => {
    const response = await $exampleAxios();
    return response.status === 200 && Math.random() > 0.5
        ? response.data
        : {message: "error"};
}