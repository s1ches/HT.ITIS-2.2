export class PostRegisterDto{
    public userName:string;
    public password:string;

    static create(userName:string,password:string){
        let result = new PostRegisterDto();

        result.userName = userName;
        result.password = password;

        return result;
    }

    public constructor() {
        this.userName = "";
        this.password = "";
    }
}