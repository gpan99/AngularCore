import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
//Grab everything with import 'rxjs/Rx';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/map'; 
import 'rxjs/add/operator/catch';
import { BaseService } from '../../shared/base.service';
import { Ingredient } from '../../shared/Ingredient.model'
@Injectable()
export class IngredientService extends BaseService {
     constructor(private http: HttpClient) {
        super();
    }
    getIngredients(): Observable<Ingredient[]> {
        return this.http.get<Ingredient[]>(`${this.apiUrl}/ingredients`);
    }
    getIngredient(id: string) : Observable<Ingredient> {
        return this.http.get<Ingredient>(`${this.apiUrl}/ingredients` + '/' + id); 
        // .map((res: Response) => {
        //          let data = res.json();
        //     })                 
        // }
    }
    updateIngredient(ingredient : Ingredient): Observable<any> {
        return this.http.put(`${this.apiUrl}/ingredients` + '/' + ingredient.ingredientId, ingredient) 
                   .map((res: Response) => {
                       const data = res.json();
                   })                 
                }
    deleteIngredient(id : string): Observable<any> {
         return this.http.delete(`${this.apiUrl}/Ingredients` + '/' + id) 
                    .map((res: Response) => {
                                   const data = res.json();
                        })                 
                    }
        
}
