import { Routes, RouterModule } from '@angular/router';

import { AboutComponent } from './about'; 
import { UsersComponent} from './users';
import { LoginComponent } from "./login/Login.component";
import { IngredientComponent} from './ingredient';
import { IngredientAddComponent } from './ingredient/ingredient-add/ingredient-add.component';
import { IngredientEditComponent } from './ingredient/ingredient-edit/ingredient-edit.component';

import { CustomersComponent} from './customers';
import { CustomerEditComponent } from './customers/customer-edit.component';
import { ManagerComponent} from './managers';
import { ManagerUpdateComponent} from './managers/manager-update/manager-update.component';
import { ManagerAddComponent} from './managers/manager-add/manager-add.component';
import { ManagerDetailComponent} from './managers/manager-detail/manager-detail.component';
import { AppComponent } from './app.component';
import { ToursComponent, TourDetailComponent, TourUpdateComponent, TourAddComponent } from './tours';

import { NgModule } from '@angular/core';
import { ShowAddComponent } from './tours/shows/index';

const routes: Routes = [
    // redirect root to the dasbhoard route
    { path: '', redirectTo: 'tours', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'users', component: UsersComponent },
    { path: 'ingredient', component: IngredientComponent },
    { path: 'ingredient-add', component: IngredientAddComponent },
    { path: 'ingredient-edit/:id', component: IngredientEditComponent},  
    { path: 'customers', component: CustomersComponent },
    { path: 'customer-edit/:id', component: CustomerEditComponent},  
    { path: 'managers', component: ManagerComponent },
    { path: 'manager-update/:managerId', component: ManagerUpdateComponent },
    { path: 'manager-add', component: ManagerAddComponent },
    { path: 'manager-detail/:managerId', component: ManagerDetailComponent },  
    { path: 'tours', component: ToursComponent },
    { path: 'about', component: AboutComponent },
    { path: 'tours/:tourId', component: TourDetailComponent },
    { path: 'tour-update/:tourId', component: TourUpdateComponent },  
    { path: 'tour-add', component: TourAddComponent },  
    { path: 'tours/:tourId/show-add', component: ShowAddComponent }
  //  { path: '**', redirectTo: 'tours' },
];

// define a module
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})

export class AppRoutingModule { }
