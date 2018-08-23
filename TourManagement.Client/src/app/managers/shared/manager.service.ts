import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/catch';
import { BaseService } from '../../shared/base.service';
import {Manager} from '../../shared/manager.model'
@Injectable()
export class ManagerService extends BaseService {
    //If you're on Angular 4.3 or higher you can use HttpClientModule. See data.service.ts.httpclient  
    constructor(private http: HttpClient) {
        super();
    }
    getManagers(): Observable<Manager[]> {
        return this.http.get<Manager[]>(`${this.apiUrl}/managers`);
    }
    getManager(id: string) : Observable<Manager> {
        return this.http.get<Manager>(`${this.apiUrl}/managers` + '/' + id); 
        // .map((res: Response) => {
        //          let data = res.json();
        //     })                 
        // }
    }
    updateManager(manager : Manager): Observable<any> {
        return this.http.put(`${this.apiUrl}/managers` + '/' + manager.managerId, manager) 
                   .map((res: Response) => {
                       const data = res.json();
                   })                 
                }
    deleteManager(id : string): Observable<any> {
         return this.http.delete(`${this.apiUrl}/managers` + '/' + id) 
                    .map((res: Response) => {
                                   const data = res.json();
                        })                 
                    }
            

                  
  

    //Not used but could be called to pass "options" (3rd parameter) to 
    //appropriate POST/PUT/DELETE calls made with http
   
    // private handleError(error: any) {
    //     console.error('server error:', error); 
    //     if (error instanceof Response) {
    //       let errMessage = '';
    //       try {
    //         errMessage = error.json().error;
    //       } catch(err) {
    //         errMessage = error.statusText;
    //       }
    //       return Observable.throw(errMessage);
    //       // Use the following instead if using lite-server
    //       //return Observable.throw(err.text() || 'backend server error');
    //     }
    //     return Observable.throw(error || 'ASP.NET Core server error');
    // }

}
