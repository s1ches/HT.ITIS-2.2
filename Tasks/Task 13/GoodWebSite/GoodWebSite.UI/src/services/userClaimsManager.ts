import {getAccessToken} from "./accessTokenManager.ts";
import {claimTypes} from "../common/claimTypes.ts";

export const getUserClaims: (accessToken: string) => any = (accessToken) => {
    const [_, encodedPayload, __] = accessToken.split('.');

    return JSON.parse(base64UrlDecode(encodedPayload));
}

export const getUserName = () => {
    let accessToken = getAccessToken();
    let claims = getUserClaims(accessToken!);
    return claims[claimTypes.name];
}

function base64UrlDecode(str: string) {
    if (!str)
        return '';

    str = str.replace(/-/g, '+').replace(/_/g, '/');

    while (str.length % 4 !== 0)
        str += '=';

    return decodeURIComponent(escape(atob(str)));
}