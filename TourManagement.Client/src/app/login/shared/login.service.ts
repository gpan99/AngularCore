import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/catch';
import { BaseService } from '../../shared/base.service';
import {Login} from './login.model'

@Injectable()
export class LoginService extends BaseService {
    //If you're on Angular 4.3 or higher you can use HttpClientModule. See data.service.ts.httpclient  
    constructor(private http: HttpClient) {
        super();
    }

    private token: string = "";
    private tokenExpiration: Date;

   
    public get loginRequired(): boolean {
        return this.token.length == 0 || this.tokenExpiration > new Date();
    }

    public login(creds) {
        console.log("login"+ creds.login);
        // return this.http.post("/account/createtoken", creds)
        //     .map(response => {
        //         // let tokenInfo = response.json();
        //         // this.token = tokenInfo.token;
        //         // this.tokenExpiration = tokenInfo.expiration;
        //         return true;
        //     });

    }
}
