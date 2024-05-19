import {isAccessTokenExpired} from "../functions/accessTokenManager.ts";
import {makeAutoObservable} from "mobx";

export class UserStore{
    isAuthorized: boolean = !isAccessTokenExpired();

    constructor() {
        makeAutoObservable(this)
    }
}