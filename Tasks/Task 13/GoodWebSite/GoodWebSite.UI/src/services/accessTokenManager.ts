import {getUserClaims} from "./userClaimsManager.ts";
import {accessTokenCookieName} from "../common/cookiesNames.ts";
import Cookies from "js-cookie";

export const getAccessToken = () :string|undefined => {
    return Cookies.get(accessTokenCookieName);
}

export const isAccessTokenExpired: () => boolean = () => {
    const accessToken: string|undefined = getAccessToken();

    if(!accessToken)
        return true;

    const userClaims: any  = getUserClaims(accessToken);

    let tokenExpiryTime = new Date(Number(userClaims.exp) * 1000);

    return tokenExpiryTime < new Date();
}