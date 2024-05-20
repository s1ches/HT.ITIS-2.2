import {PostLoginDto} from "../dtos/auth/login/postLoginDto.ts";
import {$host} from "./mainAxios.ts";
import {PostRegisterDto} from "../dtos/auth/register/postRegisterDto.ts";

export const sendLoginRequest = async (dto: PostLoginDto): Promise<void> => {
    let response = await $host.post("api/Auth/Login", {
        userName: dto.userName,
        password: dto.password,
        isPersistent: dto.isPersistent,
    });

    if (response.status !== 200) {
        alert(response.data.message);
    }
}

export const sendRegisterRequest = async (dto: PostRegisterDto): Promise<void> => {
    let response = await $host.post("api/Auth/Register", {
        userName: dto.userName,
        password: dto.password,
    });

    if (response.status !== 200)
        alert(response.data.message);
}