import {accessTokenCookieName} from "../common/cookiesNames.ts";
import Cookies from "js-cookie";

export const logout = () => {
    Cookies.remove(accessTokenCookieName);
}