import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/catch';
// import { BaseService } from '../../shared/base.service';
// import {User} from './user.model'
// @Injectable()
// export class UserService extends BaseService {
//     //If you're on Angular 4.3 or higher you can use HttpClientModule. See data.service.ts.httpclient  
//     constructor(private http: HttpClient) {
//         super();
//     }
//     getUsers(): Observable<User[]> {
//         return this.http.get<User[]>(`${this.apiUrl}/users`);
//     }
//     getSearchUsers(search: string): Observable<User[]> {
//         return this.http.get<User[]>(`${this.apiUrl}/users?searchQuery=`+ search);
//     }
//   }   