import { Component, OnInit } from '@angular/core';
import { Ingredient } from '../../shared/Ingredient.model'

@Component({
  selector: 'app-ingredient-edit',
  templateUrl: './ingredient-edit.component.html',
  styleUrls: ['./ingredient-edit.component.css']
})
export class IngredientEditComponent implements OnInit {
   private ingredients: Ingredient[] = [];
  
   constructor() { }

   ngOnInit() {
   }
  // getIngredients() {
  //   this.dataService.getingredients()
  //       .subscribe((response: ingredient[]) => {
  //         this.ingredients = this.ingredients = response;
         
  //       },
  //       (err: any) => console.log(err),
  //       () => console.log('getingredients() retrieved ingredients'));
  // }
  // updateIngredient(ingredient : Ingredient)
  // {
  //   this.dataService.updateingredient(ingredient)
  //    .subscribe((response: any) => {

  //    },
  //    (err: any) => console.log(err),
  //    () => console.log('update ingredient'));
  // }
  // deleteIngredient(id : string)
  // {
  //   this.dataService.deleteIngredient(id)
  //   .subscribe((response: any) => {
  //   },
  //   (err: any) => console.log(err),
  //   () => console.log('delete ingredient'));
  // }
  // getIngredient(id : string)
  // {
  //   this.dataService.getIngredient(id)
  //   .subscribe((response: Ingredient) => {
  //   },
  //   (err: any) => console.log(err),
  //   () => console.log('get ingredient'));
  // }
}
