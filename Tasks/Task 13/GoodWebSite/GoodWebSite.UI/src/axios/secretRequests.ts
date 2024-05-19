import {$host} from "./mainAxios.ts";
import {GetSecretDto} from "../dtos/secret/getSecret/getSecretDto.ts";

export const sendGetSecretRequest = async () : Promise<GetSecretDto> => {
    let response = await $host.get('api/Secret/GetSecret');

    return new GetSecretDto(response.data.secretMessage)
}