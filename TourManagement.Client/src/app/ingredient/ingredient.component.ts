import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Ingredient } from "../shared/ingredient.model";
import {IngredientService} from "./shared/ingredient.service"

@Component({
  selector: 'app-ingredient',
  templateUrl: './ingredient.component.html',
  styleUrls: ['./ingredient.component.css']
})

export class IngredientComponent implements OnInit {
  private ingredients: Ingredient[] = [];
  constructor(private dataService: IngredientService) { }
  
  ngOnInit() {
    this.getIngredients();
  }
  getIngredients() {
    this.dataService.getIngredients()
        .subscribe((response: Ingredient[]) => {
          this.ingredients = this.ingredients = response;
         
        },
        (err: any) => console.log(err),
        () => console.log('getIngredients() retrieved Ingredients'));
  }
  updateIngredient(manager : Ingredient)
  {
    this.dataService.updateIngredient(manager)
     .subscribe((response: any) => {

     },
     (err: any) => console.log(err),
     () => console.log('update manager'));
  }
  deleteIngredient(id : string)
  {
    this.dataService.deleteIngredient(id)
    .subscribe((response: any) => {
    },
    (err: any) => console.log(err),
    () => console.log('delete manager'));
  }
  getIngredient(id : string)
  {
    this.dataService.getIngredient(id)
    .subscribe((response: Ingredient) => {
    },
    (err: any) => console.log(err),
    () => console.log('get manager'));
  }
}
