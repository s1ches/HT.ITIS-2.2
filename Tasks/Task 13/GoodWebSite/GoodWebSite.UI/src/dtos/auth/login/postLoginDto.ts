export class PostLoginDto{
    public userName:string;
    public password:string;
    public isPersistent:boolean;

    static create(userName:string,password:string,isPersistent:boolean){
        let result = new PostLoginDto();

        result.userName = userName;
        result.password = password;
        result.isPersistent = isPersistent;

        return result;
    }

    public constructor() {
        this.userName = "";
        this.password = "";
        this.isPersistent = false;
    }
}