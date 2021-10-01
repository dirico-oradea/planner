// global service
import { observable, action, makeObservable } from 'mobx';
import { ILoginDto, IRegisterDto, User } from "../models/User";


export class Service {
    public currentUser: User | null = null;

    public setCurrentUser(currentUser: User): void {
        this.currentUser = currentUser;
    }

    public async login(data: ILoginDto): Promise<void> {
        // get token and set token into local storage
        // exchange profile data
    }

    public async register(data: IRegisterDto): Promise<void> {

    }

    public async exchangeTokenToUser(token: string): Promise<User> {
        throw new Error('no Implemented');
    }

    // programatic redirect
    public redirect(url: string): void {};

    constructor() {
        makeObservable(this, {
            currentUser: observable,
            setCurrentUser: action.bound
        });
    }
}